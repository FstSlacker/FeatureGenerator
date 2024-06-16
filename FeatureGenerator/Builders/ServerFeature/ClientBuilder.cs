using FeatureGenerator.Builders.ServerFeature;

namespace FeatureGenerator.Builders
{
    internal class ClientBuilder : BaseFeatureBuilder
    {
        public ClientBuilder(string featureName, string[] actions) : base(featureName, actions)
        {
        }

        static class Paths
        {
            //Abstract
            public const string IController = "Abstract\\IController.cs";
            public const string IModel = "Abstract\\IModel.cs";
            public const string IEvents = "Abstract\\IEvents.cs";

            //Data
            public const string Repository = "Implementation\\Data\\ServerContextRepository.cs";

            //Interface
            public const string RpcHandler = "Implementation\\Interface\\RpcHandler.cs";
            public const string Controller = "Implementation\\Interface\\Controller.cs";
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

            group.Add(Paths.IController, builder.Build($"{featurePath}\\{Paths.IController}"));
            group.Add(Paths.IModel, builder.Build($"{featurePath}\\{Paths.IModel}"));
            group.Add(Paths.IEvents, builder.Build($"{featurePath}\\{Paths.IEvents}"));

            group.Add(Paths.Repository, builder.Build($"{featurePath}\\{Paths.Repository}"));

            group.Add(Paths.RpcHandler, builder.Build($"{featurePath}\\{Paths.RpcHandler}"));
            group.Add(Paths.Controller, builder.Build($"{featurePath}\\{Paths.Controller}"));
            group.Add(Paths.Triggers, builder.Build($"{featurePath}\\{Paths.Triggers}"));

            group.Add(Paths.Logic, builder.Build($"{featurePath}\\{Paths.Logic}"));

            group.Add(Paths.PlayerComponent, builder.Build($"{featurePath}\\{Paths.PlayerComponent}"));

            group.Add(Paths.Asmdef, builder.Build($"{featurePath}\\{Paths.Asmdef}"));

            return group;
        }
    }
}
