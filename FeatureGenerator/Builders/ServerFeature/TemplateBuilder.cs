using Antlr4.StringTemplate;
using System;
using System.Collections.Generic;
using System.IO;

namespace FeatureGenerator.Builders
{
    internal class TemplateBuilder
    {
        List<Action<Template>> templateBindings = new List<Action<Template>>();

        public Template Build(string templatePath)
        {
            string data;

            using (StreamReader sr = new StreamReader(templatePath))
            {
                data = sr.ReadToEnd();
            }

            Template template = new Template(data, '$', '$');

            foreach(Action<Template> action in templateBindings) 
            { 
                action(template); 
            }

            return template;
        }

        public TemplateBuilder AddFeatureName(string name)
        {
            templateBindings.Add((t) => t.Add("featureName", name));
            return this;
        }

        public TemplateBuilder AddActions(IEnumerable<string> actionNames)
        {
            templateBindings.Add((t) =>
            {
                foreach (string name in actionNames)
                {
                    t.AddMany("actions.{actionName}", name);
                }
            });

            return this;
        }
    }
}
