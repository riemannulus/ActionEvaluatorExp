namespace ActionEvaluatorExp.interfaces
{
    public interface IStoreModule
    {
        public string Name { get; }

        public IEnumerable<Type> AllowList { get; }

        public IStoreModule Load(IStoreState state);
    }
}