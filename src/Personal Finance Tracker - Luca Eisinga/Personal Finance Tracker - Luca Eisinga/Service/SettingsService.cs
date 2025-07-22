using Personal_Finance_Tracker___Luca_Eisinga.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace Personal_Finance_Tracker___Luca_Eisinga.Service
{
    internal class SettingsService
    {
        private const string FilePath = "settings.json";
        public Settings settings { get; set; }

        public SettingsService()
        {
            settings = loadSettings();
        }

        public void saveSettings()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(this.settings, options);
            File.WriteAllText(FilePath, json);
        }

        public Settings loadSettings()
        {
            if (!File.Exists(FilePath))
            {
                return new Settings(Enums.Currency.EURO, Enums.Theme.DARK); 
            }

            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<Settings>(json) ?? new Settings(Enums.Currency.EURO, Enums.Theme.DARK);
        }

        public CultureInfo getCultureInfo()
        {
            return settings.currency switch
            {
                Enums.Currency.EURO => new CultureInfo("nl-NL"),
                Enums.Currency.DOLLAR => new CultureInfo("en-US"),
                Enums.Currency.BRITISH_POUND => new CultureInfo("en-GB"),
                _ => new CultureInfo("nl-NL"), // Default to Euro if currency is unknown
            };
        }

        public void applyTheme()
        {
            string themePath = settings.theme switch
            {
                Enums.Theme.DARK => "Themes/DarkTheme.xaml",
                Enums.Theme.LIGHT => "Themes/LightTheme.xaml",
                _ => "Themes/LightTheme.xaml"
            };

            var dict = new ResourceDictionary { Source = new Uri(themePath, UriKind.Relative) };

            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }
    }
}
