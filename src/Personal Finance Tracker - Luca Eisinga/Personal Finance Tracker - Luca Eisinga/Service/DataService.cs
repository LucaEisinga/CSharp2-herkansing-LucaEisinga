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
        // File paths for transactions and categories
        private const string transactionsFile = "transactions.json";
        private const string categoriesFile = "categories.json";

        // Transaction and category save and loading methods
        public void saveTransactions(List<Transaction> transactions)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(transactions, options);
            File.WriteAllText(transactionsFile, json);
        }

        public List<Transaction> loadTransactions()
        {
            if (!File.Exists(transactionsFile)) return new List<Transaction>();

            string json = File.ReadAllText(transactionsFile);
            return JsonSerializer.Deserialize<List<Transaction>>(json) ?? new List<Transaction>();
        }

        public void saveCategories(List<Category> categories)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(categories, options);
            File.WriteAllText(categoriesFile, json);
        }

        public List<Category> loadCategories()
        {
            if (!File.Exists(categoriesFile)) return new List<Category>();

            string json = File.ReadAllText(categoriesFile);
            return JsonSerializer.Deserialize<List<Category>>(json) ?? new List<Category>();
        }

        // Transaction and category management methods
        public void addTransaction(Transaction transaction)
        {
            var transactions = loadTransactions();

            // Check for duplicates by GUID
            transactions = transactions.Where(t => t.guid != transaction.guid).ToList();

            transactions.Add(transaction);
            saveTransactions(transactions);
        }

        public void deleteTransaction(Transaction transaction)
        {
            var transactions = loadTransactions();

            var updated = transactions
                .Where(t => t.guid != transaction.guid)
                .ToList();

            saveTransactions(updated);
        }

        public void updateTransaction(Transaction updatedTransaction)
        {
            var transactions = loadTransactions();

            // Replace matching transaction
            var updatedList = transactions
                .Select(t => t.guid == updatedTransaction.guid ? updatedTransaction : t)
                .ToList();

            saveTransactions(updatedList);
        }

        public void addCategory(Category category)
        {
            var categories = loadCategories();

            // Prevent duplicates by GUID
            if (!categories.Any(c => c.guid == category.guid))
            {
                categories.Add(category);
                saveCategories(categories);
            }
        }

        public void updateCategory(Category updatedCategory)
        {
            var categories = loadCategories();

            var updatedList = categories
                .Select(c => c.guid == updatedCategory.guid ? updatedCategory : c)
                .ToList();

            saveCategories(updatedList);
        }

        public void deleteCategory(Category category)
        {
            var categories = loadCategories();
            var updated = categories.Where(c => c.guid != category.guid).ToList();
            saveCategories(updated);
        }
    }
}
