using Personal_Finance_Tracker___Luca_Eisinga.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Tracker___Luca_Eisinga.Model
{
    internal class Transaction
    {
        public Guid guid { get; }
        public DateTime date { get; }
        public decimal amount { get; }
        public string description { get; }
        public Category category { get; }
        public TransactionType transactionType { get; }



        public Transaction(DateTime date, decimal amount, string description, Category category, TransactionType transactionType)
        {
            this.guid = Guid.NewGuid();
            this.date = date;
            this.amount = amount;
            this.description = description;
            this.category = category;
            this.transactionType = transactionType;
        }
    }
}
