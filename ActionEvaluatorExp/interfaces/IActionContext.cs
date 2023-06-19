namespace ActionEvaluatorExp.interfaces
{
    public interface IActionContext
    {
        IWorldState PreviousState { get; }
        string Signer { get; }
    }
}