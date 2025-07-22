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
        public Guid guid { get; set; } = Guid.NewGuid();
        public DateTime date { get; set; }
        public decimal amount { get; set; }
        public string description { get; set; }
        public Category category { get; set; }
        public TransactionType transactionType { get; set; }



        public Transaction(DateTime date, decimal amount, string description, Category category, TransactionType transactionType)
        {
            this.date = date;
            this.amount = amount;
            this.description = description;
            this.category = category;
            this.transactionType = transactionType;
        }

        // Parameterless constructor to build transactions back up from json
        public Transaction() {}
    }
}
