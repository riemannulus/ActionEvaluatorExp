using ActionEvaluatorExp.interfaces;

namespace ActionEvaluatorExp
{
    public class ActionEvaluator
    {
        public IWorldState Evaluate(IAction action, IActionContext state)
        {
            IWorldState result = action.Execute(state);
            return result
                .UpdatedModules
                .Any(updatedModule => !updatedModule.AllowList.Contains(action.GetType())) 
                ? state.PreviousState 
                : result;
        }
    }
}