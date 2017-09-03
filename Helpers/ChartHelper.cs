using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ITLec.EmailTemplateManager.Helpers
{
    public class EmailTemplateDefinition
    {
        public Entity Entity { get; set; }
        public List<string> Errors { get; set; }
        public bool Exists { get; set; }
        public string FileName { get; set; }
        public bool IsValid { get; set; }
        public string Name { get; set; }
        public bool Overwrite { get; set; }
    }

    internal class EmailTemplateHelper
    {
        public static List<EmailTemplateDefinition> AnalyzeFiles(List<string> filenames, IOrganizationService service)
        {
            var list = new List<EmailTemplateDefinition>();

            foreach (var fileName in filenames)
            {
                var fi = new FileInfo(fileName);
                var name = fi.Name.Replace(fi.Extension, "");
                var systemEmailTemplate = !name.EndsWith("_personal");

                var doc = XDocument.Load(fileName);

                var cd = new EmailTemplateDefinition
                {
                    FileName = fileName,
                    Name = new FileInfo(fileName).Name,
                    IsValid = doc.Element("visualization") != null,
                    Errors = new List<string>()
                };

                if (!cd.IsValid)
                {
                    cd.Errors.Add("Not a emailTemplate definition");
                    list.Add(cd);
                    continue;
                }

                var emailTemplate = new Entity(systemEmailTemplate ? "savedqueryvisualization" : "userqueryvisualization");

                var idElement = doc.Descendants("visualizationid").FirstOrDefault();
                if (idElement != null)
                {
                    emailTemplate.Id = new Guid(idElement.Value);
                }

                var nameElement = doc.Descendants("name").FirstOrDefault();
                if (nameElement == null)
                {
                    cd.Errors.Add("Missing 'name' node");
                }
                else
                {
                    emailTemplate["name"] = nameElement.Value;
                }

                var descriptionElement = doc.Descendants("description").FirstOrDefault();
                if (descriptionElement == null)
                {
                    cd.Errors.Add("Missing 'description' node");
                }
                else
                {
                    emailTemplate["description"] = descriptionElement.Value;
                }

                var primaryentitytypecodeElement = doc.Descendants("primaryentitytypecode").FirstOrDefault();
                if (primaryentitytypecodeElement == null)
                {
                    cd.Errors.Add("Missing 'primaryentitytypecode' node");
                }
                else
                {
                    emailTemplate["primaryentitytypecode"] = primaryentitytypecodeElement.Value;
                }

                var datadescriptionElement = doc.Descendants("datadescription").FirstOrDefault();
                if (datadescriptionElement == null)
                {
                    cd.Errors.Add("Missing 'datadescription' node");
                }
                else
                {
                    emailTemplate["datadescription"] = datadescriptionElement.FirstNode.ToString();
                }

                var presentationdescriptionElement = doc.Descendants("presentationdescription").FirstOrDefault();
                if (presentationdescriptionElement == null)
                {
                    cd.Errors.Add("Missing 'presentationdescription' node");
                }
                else
                {
                    emailTemplate["presentationdescription"] = presentationdescriptionElement.FirstNode.ToString();
                }

                var isdefaultElement = doc.Descendants("isdefault").FirstOrDefault();
                if (isdefaultElement == null)
                {
                    cd.Errors.Add("Missing 'isdefault' node");
                }
                else
                {
                    emailTemplate["isdefault"] = isdefaultElement.Value.ToLower() == "true";
                }

                cd.Entity = emailTemplate;

                if (emailTemplate.Id != Guid.Empty)
                {
                    cd.Exists = service.RetrieveMultiple(new QueryExpression("savedqueryvisualization")
                    {
                        Criteria = new FilterExpression
                        {
                            Conditions =
                            {
                                new ConditionExpression("savedqueryvisualizationid", ConditionOperator.Equal, emailTemplate.Id)
                            }
                        }
                    }).Entities.Count > 0;
                }

                list.Add(cd);
            }

            return list;
        }

        public static EntityCollection GetTemplatessByEntity(string entityLogicalName, IOrganizationService service)
        {
            var templates = service.RetrieveMultiple(new QueryExpression("template")
            {
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("templatetypecode", ConditionOperator.Equal, entityLogicalName)
                    }
                }
            });

          /*  var userqueries = service.RetrieveMultiple(new QueryExpression("userqueryvisualization")
            {
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression
                {
                    Conditions =
                    {
                        new ConditionExpression("primaryentitytypecode", ConditionOperator.Equal, entityLogicalName)
                    }
                }
            });

            savedqueries.Entities.AddRange(userqueries.Entities.ToArray());*/
            return templates;
        }

        public static void ImportFiles(List<EmailTemplateDefinition> emailTemplates, IOrganizationService service)
        {
            foreach (var emailTemplate in emailTemplates)
            {
                if (emailTemplate.Exists)
                {
                    if (!emailTemplate.Overwrite)
                    {
                        emailTemplate.Entity["name"] = string.Format("{0}_{1}", emailTemplate.Entity.GetAttributeValue<string>("name"), DateTime.Now.ToShortTimeString());
                        emailTemplate.Entity.Attributes.Remove("savedqueryvisualizationid");
                        emailTemplate.Entity.Attributes.Remove("userqueryvisualizationid");
                        emailTemplate.Entity.Id = Guid.Empty;

                        service.Create(emailTemplate.Entity);
                    }
                    else
                    {
                        service.Update(emailTemplate.Entity);
                    }
                }
                else
                {
                    service.Create(emailTemplate.Entity);
                }
            }
        }
    }
}