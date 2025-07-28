using Personal_Finance_Tracker___Luca_Eisinga.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Tracker___Luca_Eisinga.Model
{
    // TransactionDisplay class to format and display transaction details
    internal class TransactionDisplay
    {
        private readonly Transaction _transaction;
        private readonly SettingsService _settingsService;

        public TransactionDisplay(Transaction transaction, SettingsService settingsService)
        {
            _transaction = transaction;
            _settingsService = settingsService;
        }

        public string dateFormatted => _transaction.date.ToString("dd MMM");
        public string categoryName => _transaction.category?.name ?? "";
        public string amountFormatted
        {
            get
            {
                var multiplier = _settingsService.getCurrencyMultiplier();
                var convertedAmount = _transaction.amount * multiplier;
                return convertedAmount.ToString("C", _settingsService.getCultureInfo());
            }
        }
        public string transactionType => _transaction.transactionType.ToString();
        public string description => _transaction.description;
        public Transaction transaction => _transaction;
    }
}
