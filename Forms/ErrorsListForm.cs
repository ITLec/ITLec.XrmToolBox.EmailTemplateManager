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
    public partial class ErrorsListForm : Form
    {
        private readonly List<EmailTemplateDefinition> emailTemplates;

        public ErrorsListForm(List<EmailTemplateDefinition> emailTemplates)
        {
            InitializeComponent();

            this.emailTemplates = emailTemplates;
        }

        private void ErrorsListForm_Load(object sender, EventArgs e)
        {
            foreach (var emailTemplate in emailTemplates)
            {
                foreach (var error in emailTemplate.Errors)
                {
                    var item = new ListViewItem(emailTemplate.Name);
                    item.SubItems.Add(error);

                    listView1.Items.Add(item);
                }
            }
        }
    }
}
