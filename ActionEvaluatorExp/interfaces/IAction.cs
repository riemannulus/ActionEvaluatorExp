namespace ActionEvaluatorExp.interfaces
{
    public interface IAction
    {
        IWorldState Execute(IActionContext state);
    }
}