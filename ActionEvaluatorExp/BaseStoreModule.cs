using ActionEvaluatorExp.implementation;
using ActionEvaluatorExp.interfaces;

namespace ActionEvaluatorExp
{
    public abstract class BaseStoreModule : IStoreModule
    {
        protected readonly IStoreState State;

        public string Name { get; }

        public IEnumerable<Type> AllowList => State.AllowList;

        public abstract IStoreModule Load(IStoreState state);

        protected BaseStoreModule(IStoreState state, string name)
        {
            State = state;
            Name = name;
        }

        protected BaseStoreModule(string name)
        {
            State = new StoreState();
            Name = name;
        }
    }
}