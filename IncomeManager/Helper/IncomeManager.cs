using Finance.Models;

namespace Finance.Helper
{
    public class IncomeManager
    {
        private readonly IncomeStorage _storage;
        private readonly List<Income> _incomes;

        public IncomeManager(IncomeStorage storage)
        {
            _storage = storage;
            _incomes = _storage.LoadIncome();
        }

        public string AddIncome(Income income)
        {
            income.Id = _incomes.Count + 1;
            _incomes.Add(income);
            _storage.SaveIncome(_incomes);
            return "Income added successfully.";
        }

        public string UpdateIncome(int id, decimal newAmount, string newDescription)
        {
            var income = _incomes.FirstOrDefault(i => i.Id == id);
            if (income == null) return "Income not found.";

            income.Amount = newAmount;
            income.Description = newDescription;
            _storage.SaveIncome(_incomes);
            return "Income updated successfully.";
        }

        public string DeleteIncome(int id)
        {
            var income = _incomes.FirstOrDefault(i => i.Id == id);
            if (income == null) return "Income not found.";

            _incomes.Remove(income);
            _storage.SaveIncome(_incomes);
            return "Income deleted successfully.";
        }

        public List<Income> GetAllIncomes()
        {
            return _incomes;
        }
    }
}
