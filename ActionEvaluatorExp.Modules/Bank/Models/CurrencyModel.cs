using ActionEvaluatorExp.interfaces;

namespace ActionEvaluatorExp.Modules.Bank.Models
{
    public class CurrencyModel : IStateModel
    {
        public long TotalSupply { get; set; }
        public IDictionary<string, long> Balances { get; set; }
        public string Ticker { get; set; }
        
        public CurrencyModel(string address, string plainValue)
        {
            Address = address;
        }

        public string Address { get; }
    }
}