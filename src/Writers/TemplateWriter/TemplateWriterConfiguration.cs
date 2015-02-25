﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateWriter
{
    public class TemplateWriterConfiguration
    {
        public static TemplateWriterConfiguration Default = new TemplateWriterConfiguration() {
            AvailableLanguages = new HashSet<string> { "java", "objectivec" },
            PrimaryNamespaceName = "com",
            NamespacePrefix = "MS"
        };

        /// <summary>
        /// Target languages provided via templates.
        /// </summary>
        public HashSet<string> AvailableLanguages { get; set; }

        public string PrimaryNamespaceName { get; set; }

        public string NamespacePrefix { get; set; }
        
        public IReadOnlyDictionary<string, string> Parameters { get; set; }

        /// <summary>
        /// The code language to be targeted by this template writer instance.
        /// </summary>
        public string TargetLanguage { get; set; }

        public string InputFile { get; set; }

        /// <summary>
        /// Where to write output source code files.
        /// </summary>
        public string OutputDirectory { get; set; }

        public string[] Plugins { get; set; }
        
        public bool ShowHelp { get; set; }
    }
}
