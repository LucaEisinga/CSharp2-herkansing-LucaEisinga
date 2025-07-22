using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Tracker___Luca_Eisinga.Model
{
    internal class Budget
    {
        public string categoryName { get; }
        public decimal limit { get; }
        public decimal spent { get; set; }
        public decimal remaining { get { return limit - spent; } }
        public double percentage
        {
            get
            {
                if (limit == 0) return 0;
                return (double)(spent / limit) * 100;
            }
        }
        public bool isOverLimit { get { return spent > limit; } }

        public Budget(string categoryName, decimal limit, decimal spent)
        {
            this.categoryName = categoryName;
            this.limit = limit;
            this.spent = spent;
        }
    }
}
