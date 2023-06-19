using ActionEvaluatorExp.interfaces;
using ActionEvaluatorExp.Modules.Bank.Models;

namespace ActionEvaluatorExp.Modules.Bank
{
    public partial class BankModule
    {
        public BankAccount GetBankAccount(string address)
        {
            return new BankAccount(address, State.GetState(address));
        }
        
        public bool HasCurrency(string address, string currencyAddress)
        {
            var bankAccount = GetBankAccount(address);
            return bankAccount.OwnedCurrency.Contains(currencyAddress);
        }
        
        public long GetBalance(string address, string currencyAddress)
        {
            var currencyModel = new CurrencyModel(currencyAddress, State.GetState(currencyAddress));
            return currencyModel.Balances.Keys.Contains(address) ? currencyModel.Balances[address] : 0;
        }
        
        public BankModule SetBalance(string address, string currencyAddress, long value)
        {
            var currencyModel = new CurrencyModel(currencyAddress, State.GetState(currencyAddress));
            currencyModel.Balances[address] = value;

            var bankAccount = GetBankAccount(address);
            if (!bankAccount.OwnedCurrency.Contains(currencyAddress))
            {
                bankAccount.OwnedCurrency.Append(currencyAddress);
            }

            var nextState = State
                .SetState(currencyAddress, currencyModel.ToString())
                .SetState(address, bankAccount.ToString());

            return new BankModule(nextState);
        }
    }
}