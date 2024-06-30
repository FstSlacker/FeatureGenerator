using Antlr4.StringTemplate;
using System;
using System.Collections.Generic;
using System.IO;

namespace FeatureGenerator.Builders
{
    internal class TemplateBuilder
    {
        List<Action<Template>> _templateBindings;

        public TemplateBuilder(string featureName, string[] actionNames)
        {
            _templateBindings = new List<Action<Template>>
            {
                (t) => t.Add("featureName", featureName),
                (t) =>
                {
                    foreach (string name in actionNames)
                    {
                        t.AddMany("actions.{actionName}", name);
                    }
                }
            };
        }

        public Template Build(string templatePath)
        {
            string data;

            using (StreamReader sr = new StreamReader(templatePath))
            {
                data = sr.ReadToEnd();
            }

            return BuildFromText(data);
        }

        public Template BuildFromText(string text)
        {
            Template template = new Template(text, '$', '$');

            foreach (Action<Template> action in _templateBindings)
            {
                action(template);
            }

            return template;
        }
    }
}
