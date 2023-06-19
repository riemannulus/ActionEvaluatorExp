using ActionEvaluatorExp.interfaces;
using ActionEvaluatorExp.Modules.Bank.Actions;

namespace ActionEvaluatorExp.Modules.Bank
{
    public partial class BankModule : BaseStoreModule
    {
        public BankModule(IStoreState state) 
        // FIXME: to attribute
            : base(state, "bank")
        {
        }

        public BankModule()
        // FIXME: to attribute
            : base("bank")
        {
        }

        public new IEnumerable<Type> AllowList => base.AllowList.Append(typeof(Transfer));

        public override IStoreModule Load(IStoreState state) =>
            new BankModule(state);

        public BankModule Transfer(string sender, string receiver, string tickerAddress, long amount)
        {
            var balance = GetBalance(sender, tickerAddress);
            
            if (balance < amount)
            {
                throw new System.Exception("Not enough money");
            }
            
            return 
                SetBalance(sender,  tickerAddress, balance - amount).
                SetBalance(receiver, tickerAddress, balance + amount);
        }
    }
}