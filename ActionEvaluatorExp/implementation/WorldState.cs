using ActionEvaluatorExp.interfaces;

namespace ActionEvaluatorExp.implementation
{
    public class WorldState : IWorldState
    {
        private readonly IDictionary<string, Type> _types;

        public T GetModule<T>() where T : IStoreModule
        {
            var type = _types[typeof(T).Name];
            T? instance = (T?)Activator.CreateInstance(type, this);
            if (instance != null)
            {
                return (T)instance.Load(StoreStateGetter(instance.Name));
            }

            throw new Exception($"Failed to create instance of {typeof(T).Name}");
        }
        
        private WorldState(IDictionary<string, Type> types, IEnumerable<IStoreModule> updatedModules)
        {
            _types = types;
            UpdatedModules = updatedModules;
        }

        public IWorldState SetModule(IStoreModule module) =>
            new WorldState(_types, UpdatedModules.Append(module));

        public IEnumerable<IStoreModule> UpdatedModules { get; }

        private IStoreState StoreStateGetter(string name) => new StoreState();
    }
}