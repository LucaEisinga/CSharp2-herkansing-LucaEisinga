using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Tracker___Luca_Eisinga.Model
{
    internal class Category
    {
        public Guid guid { get; set; }
        public String name { get; set; }
        public decimal budgetLimit { get; set; }
        public bool canDelete { get; set; } 

        public Category(String name, decimal budgetLimit, bool canDelete)
        {
            this.guid = Guid.NewGuid(); // Initialize guid to a new unique identifier
            this.name = name;
            this.budgetLimit = budgetLimit;
            this.canDelete = canDelete;
        }

        // Parameterless constructor to build transactions back up from json
        public Category() { }
        
    }
}
