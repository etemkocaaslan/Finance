using System.Text.Json;
using Finance.Models;

namespace Finance.Helper
{
    public class IncomeStorage : Storage<Income>
    {
        public IncomeStorage() : base("incomeData.json") { }

        public override List<Income> Load()
        {
            if (File.Exists(FilePath))
            {
                var jsonData = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<Income>>(jsonData) ?? new List<Income>();
            }
            return new List<Income>();
        }

        public override void Save(List<Income> incomes)
        {
            var jsonData = JsonSerializer.Serialize(incomes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, jsonData);
        }
    }

}
