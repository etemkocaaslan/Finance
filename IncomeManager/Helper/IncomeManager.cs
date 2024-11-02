using Finance.Models;

namespace Finance.Helper
{

    public class IncomeManager : Manager<Income>
    {
        private readonly IncomeStorage _storage;

        public IncomeManager()
        {
            _storage = new IncomeStorage();
            Items = _storage.Load();
        }

        public override void Add(Income income)
        {
            income.Id = Items.Count + 1;
            Items.Add(income);
            _storage.Save(Items);
            Console.WriteLine("Income added successfully.");
        }

        public override void Update(int id, Income updatedIncome)
        {
            var income = Items.FirstOrDefault(i => i.Id == id);
            if (income != null)
            {
                income.Amount = updatedIncome.Amount;
                income.Description = updatedIncome.Description;
                _storage.Save(Items);
                Console.WriteLine("Income updated successfully.");
            }
            else
            {
                Console.WriteLine("Income not found.");
            }
        }

        public override void Delete(int id)
        {
            var income = Items.FirstOrDefault(i => i.Id == id);
            if (income != null)
            {
                Items.Remove(income);
                _storage.Save(Items);
                Console.WriteLine("Income deleted successfully.");
            }
            else
            {
                Console.WriteLine("Income not found.");
            }
        }

        public override void Display()
        {
            foreach (var income in Items)
            {
                Console.WriteLine($"ID: {income.Id}, Amount: {income.Amount}, Description: {income.Description}, Date: {income.Date}");
            }
        }
    }

}
