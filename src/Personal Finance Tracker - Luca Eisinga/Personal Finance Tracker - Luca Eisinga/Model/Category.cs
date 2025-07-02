using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Tracker___Luca_Eisinga.Model
{
    internal class Category
    {
        public Guid guid { get; }
        public String name { get; }
        public decimal budgetLimit { get; }

        public Category(String name, decimal budgetLimit)
        {
            this.guid = Guid.NewGuid();
            this.name = name;
            this.budgetLimit = budgetLimit;
        }
        
    }
}
