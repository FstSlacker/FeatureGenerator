using FeatureGenerator.Builders.ServerFeature;

namespace FeatureGenerator.Builders
{
    internal class ServerBuilder : BaseFeatureBuilder
    {
        public ServerBuilder(string featureName, string[] actions) : base(featureName, actions)
        {
        }

        static class Paths
        {
            //Abstract
            public const string IClientInitializer = "Abstract\\IClientInitializer.cs";

            //Data
            public const string DbRepository = "Implementation\\Data\\DbRepository.cs";

            //Interface
            public const string RpcHandler = "Implementation\\Interface\\RpcHandler.cs";
            public const string ClientInitializer = "Implementation\\Interface\\ClientInitializer.cs";
            public const string ServerContextFactory = "Implementation\\Interface\\ServerContextFactory.cs";
            public const string Triggers = "Implementation\\Interface\\Triggers.cs";

            //Logic
            public const string Logic = "Implementation\\Logic\\Logic.cs";

            //PlayerComponent
            public const string PlayerComponent = "PlayerComponent.cs";

            //Asmdef
            public const string Asmdef = "Asmdef.asmdef";
        }

        public AppliedTemplateGroup Build(string featurePath)
        {
            TemplateBuilder builder = new TemplateBuilder();

            builder.AddActions(_actions);
            builder.AddFeatureName(_featureName);

            AppliedTemplateGroup group = new AppliedTemplateGroup(_featureName);

            group.Add(Paths.IClientInitializer, builder.Build($"{featurePath}\\{Paths.IClientInitializer}"));

            group.Add(Paths.DbRepository, builder.Build($"{featurePath}\\{Paths.DbRepository}"));

            group.Add(Paths.RpcHandler, builder.Build($"{featurePath}\\{Paths.RpcHandler}"));
            group.Add(Paths.ClientInitializer, builder.Build($"{featurePath}\\{Paths.ClientInitializer}"));
            group.Add(Paths.ServerContextFactory, builder.Build($"{featurePath}\\{Paths.ServerContextFactory}"));
            group.Add(Paths.ServerContextFactory, builder.Build($"{featurePath}\\{Paths.ServerContextFactory}"));
            group.Add(Paths.Triggers, builder.Build($"{featurePath}\\{Paths.Triggers}"));

            group.Add(Paths.Logic, builder.Build($"{featurePath}\\{Paths.Logic}"));

            group.Add(Paths.PlayerComponent, builder.Build($"{featurePath}\\{Paths.PlayerComponent}"));

            group.Add(Paths.Asmdef, builder.Build($"{featurePath}\\{Paths.Asmdef}"));

            return group;
        }
    }
}
