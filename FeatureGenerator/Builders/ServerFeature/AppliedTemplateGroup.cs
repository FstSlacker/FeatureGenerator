using Antlr4.StringTemplate;
using System.Collections.Generic;
using System.IO;

namespace FeatureGenerator.Builders
{
    internal class AppliedTemplateGroup
    {
        class AppliedTemplate
        {
            public string path;
            public Template template;
        }

        List<AppliedTemplate> templates = new List<AppliedTemplate>();

        readonly string _saveFolder;

        public AppliedTemplateGroup(string saveFolder)
        {
            _saveFolder = saveFolder;
        }

        public void Add(string path, Template template)
        {
            templates.Add(new AppliedTemplate { path = path, template = template });
        }

        public void Save(string path)
        {
            foreach (var t in templates)
            {
                string fullPath = $"{path}\\{_saveFolder}\\{t.path}";

                FileInfo fileInfo = new FileInfo(fullPath);
                
                Directory.CreateDirectory(fileInfo.DirectoryName);
                File.WriteAllText(fullPath, t.template.Render());
            }
        }
    }
}
