using ActionEvaluatorExp.interfaces;

namespace ActionEvaluatorExp.Modules.Bank.Actions
{
    public class Transfer : IAction
    {
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Ticker { get; set; }
        public long Amount { get; set; }
        
        public IWorldState Execute(IActionContext state)
        {
            IWorldState worldState = state.PreviousState;
            BankModule module = worldState.GetModule<BankModule>();
            module = module.Transfer(Sender, Receiver, Ticker, Amount);
            return worldState.SetModule(module);
        }
    }
}