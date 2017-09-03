﻿using System;
using System.ComponentModel.Composition;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace ITLec.EmailTemplateManager
{
    [Export(typeof (IXrmToolBoxPlugin)),
     ExportMetadata("Name", "Email Template Manager"),
     //, and customize all its attributes.
     ExportMetadata("Description", "Here you can edit the emailTemplate"),
     ExportMetadata("SmallImageBase64", "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"),
     ExportMetadata("BigImageBase64", "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"),
     ExportMetadata("BackgroundColor", "Lavender"),
     ExportMetadata("PrimaryFontColor", "Black"),
     ExportMetadata("SecondaryFontColor", "Gray")]
    public class Plugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new MainControl();
        }
    }
}
