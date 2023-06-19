namespace ActionEvaluatorExp.interfaces
{
    public interface IWorldState
    {
        public T GetModule<T>() where T : IStoreModule;

        public IWorldState SetModule(IStoreModule module);

        public IEnumerable<IStoreModule> UpdatedModules { get; }
    }
}