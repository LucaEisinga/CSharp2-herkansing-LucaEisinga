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
    internal class DataService
    {
        private const string TransactionsFile = "transactions.json";
        private const string CategoriesFile = "categories.json";

        public void SaveTransactions(List<Transaction> transactions)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(transactions, options);
            File.WriteAllText(TransactionsFile, json);
        }

        public List<Transaction> LoadTransactions()
        {
            if (!File.Exists(TransactionsFile)) return new List<Transaction>();

            string json = File.ReadAllText(TransactionsFile);
            return JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>();
        }

        public void SaveCategories(List<Category> categories)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(categories, options);
            File.WriteAllText(CategoriesFile, json);
        }

        public List<Category> LoadCategories()
        {
            if (!File.Exists(CategoriesFile)) return new List<Category>();

            string json = File.ReadAllText(CategoriesFile);
            return JsonSerializer.Deserialize<List<Category>>(json) ?? new List<Category>();
        }
    }
}
