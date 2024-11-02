using System.Text.Json;
using Finance.Models;

namespace Finance.Helper
{
    public class IncomeStorage
    {
        private const string FilePath = "incomeData.json";
        private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

        public List<Income> LoadIncome()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    var jsonData = File.ReadAllText(FilePath);
                    return JsonSerializer.Deserialize<List<Income>>(jsonData) ?? new List<Income>();
                }
                return new List<Income>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading income data: {ex.Message}");
                return [];
            }
        }

        public void SaveIncome(List<Income> incomes)
        {
            try
            {
                var jsonData = JsonSerializer.Serialize(incomes, _options);
                File.WriteAllText(FilePath, jsonData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving income data: {ex.Message}");
            }
        }
    }
}
