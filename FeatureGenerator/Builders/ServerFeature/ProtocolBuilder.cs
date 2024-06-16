using FeatureGenerator.Builders.ServerFeature;

namespace FeatureGenerator.Builders
{
    internal class ProtocolBuilder : BaseFeatureBuilder
    {
        public ProtocolBuilder(string featureName, string[] actions) : base(featureName, actions)
        {
        }

        static class Paths
        {
            public const string Protocol = "Protocol.cs";
            //Asmdef
            public const string Asmdef = "Asmdef.asmdef";
        }

        public AppliedTemplateGroup Build(string featurePath)
        {
            TemplateBuilder builder = new TemplateBuilder();

            builder.AddActions(_actions);
            builder.AddFeatureName(_featureName);

            AppliedTemplateGroup group = new AppliedTemplateGroup(_featureName);

            group.Add(Paths.Protocol, builder.Build($"{featurePath}\\{Paths.Protocol}"));
            group.Add(Paths.Asmdef, builder.Build($"{featurePath}\\{Paths.Asmdef}"));

            return group;
        }
    }
}
