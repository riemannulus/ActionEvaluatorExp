using ActionEvaluatorExp.interfaces;

namespace ActionEvaluatorExp.Modules.Bank.Models
{
    public class BankAccount : IStateModel
    {
        public IEnumerable<string> OwnedCurrency { get; set; }
        
        public BankAccount(string address, string plainValue)
        {
            Address = address;
        }

        public string Address { get; }
    }
}