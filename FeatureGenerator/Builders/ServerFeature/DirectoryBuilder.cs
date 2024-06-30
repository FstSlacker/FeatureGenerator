using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FeatureGenerator.Builders.ServerFeature
{
    internal class DirectoryBuilder : BaseFeatureBuilder
    {
        public DirectoryBuilder(string featureName, string[] actions) 
            : base(featureName, actions)
        {
        }

        public AppliedTemplateGroup Build(string featurePath)
        {
            AppliedTemplateGroup group = new AppliedTemplateGroup(_featureName);
            Stack<string> foldersHierarchy = new Stack<string>();

            Traverse(featurePath, foldersHierarchy, group);

            return group;
        }

        void Traverse(string pathToTemplateFolder, Stack<string> foldersHierarchy, AppliedTemplateGroup group)
        {
            string relativePath = Path.Combine(foldersHierarchy.Reverse().ToArray());
            string fullPathToCurrentFolder = Path.Combine(pathToTemplateFolder, relativePath);

            var dirInfo = new DirectoryInfo(fullPathToCurrentFolder);

            foreach (var item in dirInfo.GetDirectories())
            {
                foldersHierarchy.Push(item.Name);
                Traverse(pathToTemplateFolder, foldersHierarchy, group);
                foldersHierarchy.Pop();
            }

            foreach (var item in dirInfo.GetFiles())
            {
                string outputName = _templateBuilder.BuildFromText(item.Name).Render();

                string pathToTemplateFile = Path.Combine(fullPathToCurrentFolder, item.Name);
                string relativePathToFile = Path.Combine(relativePath, outputName);

                group.Add(relativePathToFile, _templateBuilder.Build(pathToTemplateFile));
            }
        }
    }
}
