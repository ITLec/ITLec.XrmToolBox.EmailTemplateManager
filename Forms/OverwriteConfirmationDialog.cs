using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITLec.EmailTemplateManager.Helpers;

namespace ITLec.EmailTemplateManager.Forms
{
    public partial class OverwriteConfirmationDialog : Form
    {
        private readonly List<EmailTemplateDefinition> emailTemplates;

        public OverwriteConfirmationDialog(List<EmailTemplateDefinition> emailTemplates)
        {
            InitializeComponent();

            this.emailTemplates = emailTemplates;
        }

        private void ErrorsListForm_Load(object sender, EventArgs e)
        {
            foreach (var emailTemplate in emailTemplates.Where(c => c.Exists))
            {
                var item = new ListViewItem(emailTemplate.Name) {Tag = emailTemplate};
                item.Checked = true;

                lvEmailTemplates.Items.Add(item);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvEmailTemplates.Items)
            {
                ((EmailTemplateDefinition) item.Tag).Overwrite = item.Checked;
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
