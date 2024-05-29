namespace FeatureGenerator.Builders.ServerFeature
{
    internal abstract class BaseFeatureBuilder
    {
        protected readonly string _featureName;
        protected readonly string[] _actions;

        public BaseFeatureBuilder(string featureName, string[] actions)
        {
            _featureName = featureName;
            _actions = actions;
        }
    }
}
