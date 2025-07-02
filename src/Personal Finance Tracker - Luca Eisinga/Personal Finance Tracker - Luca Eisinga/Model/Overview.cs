using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Tracker___Luca_Eisinga.Model
{
    internal class Overview
    {
        public List<Transaction> transactions { get; set; }
        public List<Category> categories { get; set; }

        public Overview()
        {
            this.transactions = new List<Transaction>();
            this.categories = new List<Category>();
        }
    }
}
