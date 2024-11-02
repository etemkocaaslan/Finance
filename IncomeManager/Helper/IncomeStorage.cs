using System.Text.Json;
using Finance.Models;

namespace Finance.Helper
{
    public class IncomeStorage : Storage<Income>
    {
        public IncomeStorage() : base("incomeData.json") { }

        public override List<Income> Load() => (File.Exists(FilePath)) ? JsonSerializer.Deserialize<List<Income>>(File.ReadAllText(FilePath)) ?? [] : [];

        public override void Save(List<Income> incomes)
        {
            var jsonData = JsonSerializer.Serialize(incomes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, jsonData);
        }
    }

}
