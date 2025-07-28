using Personal_Finance_Tracker___Luca_Eisinga.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Tracker___Luca_Eisinga.Model
{
    internal class Budget
    {
        private readonly SettingsService _settingsService;

        public Category category { get; }
        public string limit { get; }
        public string spent { get; set; }
        public decimal percentage { get; }
        public bool isOverLimit { get; }

        public Budget(Category category, decimal limit, decimal spent, SettingsService settingsService)
        {
            _settingsService = settingsService;

            this.category = category;
            this.limit = limit.ToString("C", _settingsService.getCultureInfo());
            this.spent = spent.ToString("C", _settingsService.getCultureInfo());
            this.percentage = limit == 0 ? 0 : (spent / limit) * 100;
            this.isOverLimit = spent > limit;
        }
    }
}
