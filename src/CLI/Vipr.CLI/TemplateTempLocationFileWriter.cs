﻿using System;
using System.Collections.Generic;
using System.IO;
using TemplateWriter;

namespace Vipr.CLI
{
    public class TemplateTempLocationFileWriter : ITemplateTempLocationFileWriter
    {
        private readonly ITemplateAssemblyReader _templateAssemblyReader;

        public TemplateTempLocationFileWriter(ITemplateAssemblyReader templateAssemblyReader)
        {
            _templateAssemblyReader = templateAssemblyReader;
        }

        public IList<Template> WriteUsing(Type sourceType, BuilderArguments arguments)
        {
            var writtenTemplates = new List<Template>();
            var templates = _templateAssemblyReader.Read(sourceType, arguments);

            foreach (var template in templates)
            {
                var fullpath = Path.GetTempFileName();
                using (var stream = sourceType.Assembly.GetManifestResourceStream(template.ResourceName))
                {
                    if (stream != null)
                    {
                        CopyStream(stream, fullpath);
                    }
                }
                template.Path = fullpath;
                writtenTemplates.Add(template);
            }
            return writtenTemplates;
        }

        private void CopyStream(Stream stream, string destPath)
        {
            using (var fileStream = new FileStream(destPath, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(fileStream);
            }
        }

    }
}