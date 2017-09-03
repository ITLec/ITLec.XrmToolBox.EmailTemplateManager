using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITLec.CRMEmailTemplateGuy.AppCode;
using ITLec.EmailTemplateManager.AppCode;
using ITLec.CRMEmailTemplateGuy;
using ITLec.EmailTemplateManager.Forms;

namespace ITLec.EmailTemplateManager.Controls
{
    public partial class MainEmailTemplateSectionControl : BaseMainEmailTemplateUserControl, IEmailTemplateSavable
    {
        private readonly Dictionary<string, Property> collec;

        public MainEmailTemplateSectionControl()
        {
            InitializeComponent();
            collec = new Dictionary<string, Property>();
        }

        public MainEmailTemplateSectionControl(Dictionary<string, Property> collection)
            : this()
        {
            if (collection != null)
                collec = collection;

            FillControls();
        }

        public MainEmailTemplateSectionControl(string nodeName, Dictionary<string, Property> collec)
            : this()
        {
            this.NodeName = nodeName;
            this.collec = collec;

            FillControls();
        }

        private void FillControls()
        {

            var _emailTemplate = ITLec.CRMEmailTemplateGuy.AppCode.Common.EmailTemplateStructure;
            Section section = null;
            if (NodeName == "Series.Series.CustomProperties")
            {
                section = _emailTemplate.Sections.Where(e => e.Name == "Series.Series.CustomProperties."+EmailTemplateEditorHelper.EmailTemplateType).FirstOrDefault();
            }
            else
            {
                 section = _emailTemplate.Sections.Where(e => e.Name == NodeName).FirstOrDefault();
            }


            if (section != null && section.Properties.Count > 0)
            {
                foreach (var property in section.Properties)
                {
                    AddDictionaryKeyControl(property, collec);
                }
            }

            foreach (var item in collec)
            {
                item.Value.Type = Common.DetectEmailTemplateElementType(item.Key, item.Value.Value);
                AddDictionaryKeyControl( item.Value);
            }

            int x = 0;
            foreach (var item in DictionaryKeyControl.Values)
            {
                item.Location = new Point(0, x);
                x = x + 50;
                panelMain.Height = panelMain.Height + 50;
                item.Dock = DockStyle.Top;
                panelMain.Controls.Add(item);
            }

        }



        public bool Save()
        {

            Dictionary<string, ITLec.CRMEmailTemplateGuy.Property> collection = new Dictionary<string, ITLec.CRMEmailTemplateGuy.Property>();

            foreach (var dic in DictionaryKeyControl)
            {
                if (
                    
                  (  collec.Keys.Contains(dic.Key) ||
                    (!string.IsNullOrEmpty(dic.Value.Value) )) &&

                   ! dic.Value.IsIgnoreSave
                    )
                {
                    collection.Add(dic.Key, dic.Value.CurrentProperty);
                }
            }

            SendSaveMessage(collection);
            return true;
        }


        #region Send Events

        private void SendSaveMessage(Dictionary<string, ITLec.CRMEmailTemplateGuy.Property> collection)
        {
            SaveEventArgs sea = new SaveEventArgs { AttributeCollection = collection };
            OnSaving(this, sea);
        }

        #endregion
    }
}
