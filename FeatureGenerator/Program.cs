using System;
using FeatureGenerator.Builders;
using FeatureGenerator.Builders.ServerFeature;

namespace FeatureGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input server features path:");
            string serverFeaturesPath = Console.ReadLine();
            Console.WriteLine("Input client features path:");
            string clientFeaturesPath = Console.ReadLine();
            Console.WriteLine("Input protocol features path:");
            string protocolFeaturesPath = Console.ReadLine();
            Console.WriteLine("Input config features path:");
            string configFeaturesPath = Console.ReadLine();

            Console.WriteLine("Input feature name:");
            string featureName = Console.ReadLine();

            Console.WriteLine("Input feature actions names count:");

            int count = Convert.ToInt32(Console.ReadLine());

            string[] actions = new string[count];

            for (int i = 0; i < count; i++)
            {
                string actionName = Console.ReadLine();

                actions[i] = actionName;
            }

            DirectoryBuilder db = new DirectoryBuilder(featureName, actions);

            AppliedTemplateGroup sg = db.Build("Templates\\Server");
            AppliedTemplateGroup cg = db.Build("Templates\\Client");
            AppliedTemplateGroup pg = db.Build("Templates\\Protocol");
            AppliedTemplateGroup cfg = db.Build("Templates\\Config");

            sg.Save(serverFeaturesPath);
            cg.Save(clientFeaturesPath);
            pg.Save(protocolFeaturesPath);
            cfg.Save(configFeaturesPath);
        }
    }
}
