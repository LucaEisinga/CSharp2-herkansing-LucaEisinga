using Personal_Finance_Tracker___Luca_Eisinga.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

namespace Personal_Finance_Tracker___Luca_Eisinga.Service
{
    internal class SettingsService
    {
        private const string FilePath = "settings.json";

        public void SaveSettings(Settings settings)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(settings, options);
            File.WriteAllText(FilePath, json);
        }

        public Settings LoadSettings()
        {
            if (!File.Exists(FilePath))
            {
                return new Settings(Enums.Currency.EURO, Enums.Theme.DARK); 
            }

            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<Settings>(json) ?? new Settings(Enums.Currency.EURO, Enums.Theme.DARK);
        }
    }
}
