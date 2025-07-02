using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Tracker___Luca_Eisinga.Model
{
    internal class Budget
    {
        public Category category { get; }
        public decimal limit { get; }
        public decimal spent { get; set; }
        public decimal remaining { get { return limit - spent; } }

        public Budget(Category category, decimal limit, decimal spent)
        {
            this.category = category;
            this.limit = limit;
            this.spent = spent;
        }
    }
}
