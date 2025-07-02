using Personal_Finance_Tracker___Luca_Eisinga.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Tracker___Luca_Eisinga.Model
{
    internal class Settings
    {
        public Currency currency { get; set; }
        public Theme theme { get; set; }

        public Settings(Currency currency, Theme theme)
        {
            this.currency = currency;
            this.theme = theme;
        }
    }
}
