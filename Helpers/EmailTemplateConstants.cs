using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITLec.EmailTemplateManager.Helpers
{
  public   class EmailTemplateConstants
    {
        public static Dictionary<string,string> TemplateTypeCodes()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();



            dic.Add("Account", "1");
            dic.Add("Contact", "2");
            dic.Add("Opportunity", "3");
            dic.Add("Lead", "4");



            dic.Add("Incident", "112");

            dic.Add("Quote", "1084");

            dic.Add("Contract", "1010");

            dic.Add("Invoice", "1090");

            dic.Add("User", "8");
            return dic;
        }
    }
}
