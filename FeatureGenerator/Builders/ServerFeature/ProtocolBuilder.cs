﻿using FeatureGenerator.Builders.ServerFeature;

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
        }

        public AppliedTemplateGroup Build(string featurePath)
        {
            TemplateBuilder builder = new TemplateBuilder();

            builder.AddActions(_actions);
            builder.AddFeatureName(_featureName);

            AppliedTemplateGroup group = new AppliedTemplateGroup(_featureName);

            group.Add(Paths.Protocol, builder.Build($"{featurePath}\\{Paths.Protocol}"));

            return group;
        }
    }
}
