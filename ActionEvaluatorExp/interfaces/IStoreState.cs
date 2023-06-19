namespace ActionEvaluatorExp.interfaces
{
    public interface IStoreState
    {
        public string GetState(string key);

        public IStoreState SetState(string key, string value);

        public IEnumerable<Type> AllowList { get; }

        public IStoreState SetAllowAction(Type actionType);
    }
}