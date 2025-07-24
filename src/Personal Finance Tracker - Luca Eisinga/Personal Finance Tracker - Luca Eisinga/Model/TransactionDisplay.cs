using Personal_Finance_Tracker___Luca_Eisinga.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Tracker___Luca_Eisinga.Model
{
    class TransactionDisplay
    {
        private readonly Transaction _transaction;
        private readonly SettingsService _settingsService;

        public TransactionDisplay(Transaction transaction, SettingsService settingsService)
        {
            _transaction = transaction;
            _settingsService = settingsService;
        }

        public string DateFormatted => _transaction.date.ToString("dd MMM");
        public string CategoryName => _transaction.category?.name ?? "";
        public string AmountFormatted => _transaction.amount.ToString("C", _settingsService.getCultureInfo());
        public string TransactionType => _transaction.transactionType.ToString();

        public Transaction Model => _transaction;
    }
}
