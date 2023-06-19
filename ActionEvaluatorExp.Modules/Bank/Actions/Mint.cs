using ActionEvaluatorExp.interfaces;

namespace ActionEvaluatorExp.Modules.Bank.Actions
{
    public class Mint : IAction
    {
        public string Address { get; set; }
        public string Ticker { get; set; }
        public long Amount { get; set; }

        public IWorldState Execute(IActionContext state)
        {
            IWorldState worldState = state.PreviousState;
            BankModule module = worldState.GetModule<BankModule>();
            if (!IsAllowed(state))
            {
                return worldState;
            }

            module = module.SetBalance(Address, Ticker, Amount);
            return worldState.SetModule(module);
        }
        
        public static bool IsAllowed(IActionContext context)
        {
            var allowList = new List<string>();
            if (allowList == null)
            {
                throw new ArgumentNullException(nameof(allowList));
            }

            return allowList.Contains(context.Signer);
        }
    }
}