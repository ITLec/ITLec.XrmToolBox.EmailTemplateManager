using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using XrmToolBox.Extensibility;

namespace ITLec.EmailTemplateManager.Forms
{
    public partial class EmailTemplateEditor : Form
    {
        private Panel infoPanel;

        private readonly Entity emailTemplate;

        private readonly IOrganizationService service;

        public EmailTemplateEditor(Entity emailTemplate, IOrganizationService service)
        {
            InitializeComponent();
            this.emailTemplate = emailTemplate;
            this.service = service;
        }

        public bool HasUpdatedContent { get; private set; }

        private void EmailTemplateEditor_Load(object sender, EventArgs e)
        {
            txtName.Text = emailTemplate.GetAttributeValue<string>("title");
            txtDescription.Text = emailTemplate.GetAttributeValue<string>("description");
            tecDataDescription.Text = emailTemplate.GetAttributeValue<string>("subjectpresentationxml");
            tecVisualizationDescription.Text = emailTemplate.GetAttributeValue<string>("presentationxml");

            tecDataDescription.Text = IndentXmlString(tecDataDescription.Text);
            tecVisualizationDescription.Text = IndentXmlString(tecVisualizationDescription.Text);

            tecDataDescription.SetHighlighting("XML");
            tecVisualizationDescription.SetHighlighting("XML");
            
            Size = new Size(Size.Width + 1, Size.Height);



            string isPersonalStr = "False";
            if (emailTemplate.Attributes.Contains("IsPersonal"))
            {
                var ispersonal = (bool)emailTemplate.Attributes["IsPersonal"];
                isPersonalStr = (ispersonal) ? "True" : "False";
            }

            txtEmailTemplateType.Text = isPersonalStr;
           /* bool isSystemEmailTemplate = true;
            if (emailTemplate.Attributes.Contains("userqueryvisualizationid"))
            {
                isSystemEmailTemplate = false;
            }

            btnUpdatePublish.Visible = isSystemEmailTemplate;
            btnUpdate.Visible = !isSystemEmailTemplate;

            txtEmailTemplateType.Text = isSystemEmailTemplate ? "System" : "User";*/
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string IndentXmlString(string xml)
        {
            MemoryStream ms = new MemoryStream();
            XmlTextWriter xtw = new XmlTextWriter(ms, Encoding.Unicode);
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.LoadXml(xml);

                xtw.Formatting = Formatting.Indented;
                doc.WriteContentTo(xtw);
                xtw.Flush();
                ms.Seek(0, SeekOrigin.Begin);
                StreamReader sr = new StreamReader(ms);
                return sr.ReadToEnd();
            }
            catch (Exception error)
            {
                MessageBox.Show(string.Format("An error occured while identing XML: {0}", error));
                return null;
            }
        }


        private void btnlVisualEditor_Click(object sender, EventArgs e)
        {
            var pos = tecVisualizationDescription.ActiveTextAreaControl.Caret.Position;

            //  tecVisualizationDescription.ActiveTextAreaControl.TextArea.ge
            //  var dd = tecVisualizationDescription.Document.GetLineNumberForOffset(rr);

            tecVisualizationDescription.ActiveTextAreaControl.SelectionManager.SetSelection(new ICSharpCode.TextEditor.TextLocation(0, pos.Line), new ICSharpCode.TextEditor.TextLocation(1000000000, pos.Line));

            var str = tecVisualizationDescription.ActiveTextAreaControl.SelectionManager.SelectedText;

            str = tecVisualizationDescription.Text;
            var frm = new EmailTemplateEditorHelper(str);
           if ( frm.ShowDialog() ==  DialogResult.OK)
            {
                string emailTemplateXML = frm.EmailTemplateXML;

                if (!string.IsNullOrEmpty(emailTemplateXML))
                {
                    emailTemplateXML = ITLec.CRMEmailTemplateGuy.AppCode.TreeNodeHelper.GetFormatedXML(emailTemplateXML);
                    tecVisualizationDescription.Text = emailTemplateXML;
                }
            }
        }

        private void btnUpdatePublish_Click(object sender, EventArgs e)
        {

            emailTemplate["title"] = txtName.Text;
            emailTemplate["description"] = txtDescription.Text;
            emailTemplate["subjectpresentationxml"] = tecDataDescription.Text;
            emailTemplate["presentationxml"] = tecVisualizationDescription.Text;


            infoPanel = InformationPanel.GetInformationPanel(this, "Updating emailTemplate...", 350, 150);

            var worker = new BackgroundWorker { WorkerReportsProgress = true };
            worker.DoWork += (w, evt) =>
            {
                service.Update((Entity)evt.Argument);

                ((BackgroundWorker)w).ReportProgress(0, "Publishing entity...");

                service.Execute(new PublishXmlRequest
                {
                    ParameterXml = string.Format("<importexportxml><entities><entity>{0}</entity></entities><nodes/><securityroles/><settings/><workflows/></importexportxml>", emailTemplate.GetAttributeValue<string>("primaryentitytypecode"))
                });
            };
            worker.ProgressChanged += (w, evt) =>
            {
                InformationPanel.ChangeInformationPanelMessage(infoPanel, evt.UserState.ToString());
            };
            worker.RunWorkerCompleted += (w, evt) =>
            {
                if (evt.Error != null)
                {
                    MessageBox.Show(this, evt.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    HasUpdatedContent = true;
                }

                Controls.Remove(infoPanel);
                infoPanel.Dispose();
            };
            worker.RunWorkerAsync(emailTemplate);
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {

            emailTemplate["title"] = txtName.Text;
            emailTemplate["description"] = txtDescription.Text;
            emailTemplate["subjectpresentationxml"] = tecDataDescription.Text;
            emailTemplate["presentationxml"] = tecVisualizationDescription.Text;


            infoPanel = InformationPanel.GetInformationPanel(this, "Updating emailTemplate...", 350, 150);

            var worker = new BackgroundWorker { WorkerReportsProgress = true };
            worker.DoWork += (w, evt) =>
            {
                service.Update((Entity)evt.Argument);
            };
            worker.ProgressChanged += (w, evt) =>
            {
                InformationPanel.ChangeInformationPanelMessage(infoPanel, evt.UserState.ToString());
            };
            worker.RunWorkerCompleted += (w, evt) =>
            {
                if (evt.Error != null)
                {
                    MessageBox.Show(this, evt.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    HasUpdatedContent = true;
                }

                Controls.Remove(infoPanel);
                infoPanel.Dispose();
            };
            worker.RunWorkerAsync(emailTemplate);
        }

        private void buttonSaveAs_Click(object sender, EventArgs e)
        {




            Entity newemailTemplate = emailTemplate;
            string newEmailTemplateName = ITLec.CRMEmailTemplateGuy.AppCode.Common.ShowDialog("New EmailTemplate Name:", "EmailTemplate Name", txtName.Text+" - COPY");

            if (!string.IsNullOrEmpty(newEmailTemplateName))
            {
                newemailTemplate["name"] = newEmailTemplateName;
                newemailTemplate["description"] = txtDescription.Text;
                newemailTemplate["datadescription"] = tecDataDescription.Text;
                newemailTemplate["presentationdescription"] = tecVisualizationDescription.Text;

                newemailTemplate.Id = Guid.NewGuid();

                if (newemailTemplate.Attributes.Contains("savedqueryvisualizationid"))
                {
                    newemailTemplate["savedqueryvisualizationid"] = newemailTemplate.Id;
                }
                else
                {
                    newemailTemplate["userqueryvisualizationid"] = newemailTemplate.Id;
                }

                infoPanel = InformationPanel.GetInformationPanel(this, "Save As emailTemplate...", 350, 150);

                var worker = new BackgroundWorker { WorkerReportsProgress = true };
                worker.DoWork += (w, evt) =>
                {
                    service.Create((Entity)evt.Argument);
                };
                worker.ProgressChanged += (w, evt) =>
                {
                    InformationPanel.ChangeInformationPanelMessage(infoPanel, evt.UserState.ToString());
                };
                worker.RunWorkerCompleted += (w, evt) =>
                {
                    if (evt.Error != null)
                    {
                        MessageBox.Show(this, evt.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        HasUpdatedContent = true;
                    }

                    Controls.Remove(infoPanel);
                    infoPanel.Dispose();
                    this.Close();
                };
                worker.RunWorkerAsync(newemailTemplate);
            }
        }

        private void buttonDeleteEmailTemplate_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("Are you sure to delete this emailTemplate ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {

                infoPanel = InformationPanel.GetInformationPanel(this, "Deleting emailTemplate...", 350, 150);

                var worker = new BackgroundWorker { WorkerReportsProgress = true };
                worker.DoWork += (w, evt) =>
                {
                    service.Delete(((Entity)evt.Argument).LogicalName, ((Entity)evt.Argument).Id);
                };
                worker.ProgressChanged += (w, evt) =>
                {
                    InformationPanel.ChangeInformationPanelMessage(infoPanel, evt.UserState.ToString());
                };
                worker.RunWorkerCompleted += (w, evt) =>
                {
                    if (evt.Error != null)
                    {
                        MessageBox.Show(this, evt.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        HasUpdatedContent = true;
                    }

                    Controls.Remove(infoPanel);
                    infoPanel.Dispose();

                    this.Close();
                };
                worker.RunWorkerAsync(emailTemplate);
            }
        }

        private void tecVisualizationDescription_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
