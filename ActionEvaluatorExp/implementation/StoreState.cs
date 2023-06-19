using System.Collections.Immutable;
using ActionEvaluatorExp.interfaces;

namespace ActionEvaluatorExp.implementation
{
    public class StoreState : IStoreState
    {
        private readonly IImmutableDictionary<string, string> _state;
        
        private const string AllowListAddress = "0x00";

        public StoreState()
        {
            _state = new Dictionary<string, string>().ToImmutableDictionary();
        }
        
        public StoreState(IImmutableDictionary<string, string> state)
        {
            _state = state;
        }

        public string GetState(string key) =>
            _state[key];

        public IStoreState SetState(string key, string value) =>
            new StoreState(_state.SetItem(key, value));

        public IEnumerable<Type> AllowList =>
            _state[AllowListAddress].Split(',').Select(Type.GetType);

        public IStoreState SetAllowAction(Type actionType) =>
            new StoreState(_state.SetItem(AllowListAddress, string.Join(',', AllowList.Append(actionType))));
    }
}