using System;
using System.IO;
using Antlr4.StringTemplate;
using FeatureGenerator.Builders;

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

            ServerBuilder sb = new ServerBuilder(featureName, actions);
            ClientBuilder cb = new ClientBuilder(featureName, actions);
            ProtocolBuilder pb = new ProtocolBuilder(featureName, actions);

            AppliedTemplateGroup sg = sb.Build("Templates\\Server");
            AppliedTemplateGroup cg = cb.Build("Templates\\Client");
            AppliedTemplateGroup pg = pb.Build("Templates\\Protocol");

            sg.Save(serverFeaturesPath);
            cg.Save(clientFeaturesPath);
            pg.Save(protocolFeaturesPath);
        }
    }
}
