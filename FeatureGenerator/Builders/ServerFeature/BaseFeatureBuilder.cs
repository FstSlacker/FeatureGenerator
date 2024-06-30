namespace FeatureGenerator.Builders.ServerFeature
{
    internal abstract class BaseFeatureBuilder
    {
        protected readonly TemplateBuilder _templateBuilder;
        protected readonly string _featureName;

        public BaseFeatureBuilder(string featureName, string[] actions)
        {
            _featureName = featureName;
            _templateBuilder = new TemplateBuilder(featureName, actions);
        }
    }
}
