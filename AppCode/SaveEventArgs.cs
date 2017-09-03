using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLec.EmailTemplateManager.AppCode
{
    public class SaveEventArgs : EventArgs
    {
        public Dictionary<string, ITLec.CRMEmailTemplateGuy.Property> AttributeCollection { get; set; }
    }
}
