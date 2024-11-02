using System.Text.Json;
using Finance.Models;

namespace Finance.Helper
{
    public class ExpenseStorage : Storage<Expense>
    {
        public ExpenseStorage() : base("expenseData.json") { }

        public override List<Expense> Load()
        {
            if (File.Exists(FilePath))
            {
                var jsonData = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<Expense>>(jsonData) ?? new List<Expense>();
            }
            return new List<Expense>();
        }

        public override void Save(List<Expense> expenses)
        {
            var jsonData = JsonSerializer.Serialize(expenses, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, jsonData);
        }
    }

}
