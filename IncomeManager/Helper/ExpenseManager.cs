using Finance.Models;

namespace Finance.Helper
{

    public class ExpenseManager : Manager<Expense>
    {
        private readonly ExpenseStorage _storage;

        public ExpenseManager()
        {
            _storage = new ExpenseStorage();
            Items = _storage.Load();
        }

        public override void Add(Expense expense)
        {
            expense.Id = Items.Count + 1;
            Items.Add(expense);
            _storage.Save(Items);
            Console.WriteLine("Expense added successfully.");
        }

        public override void Update(int id, Expense updatedExpense)
        {
            var expense = Items.FirstOrDefault(e => e.Id == id);
            if (expense != null)
            {
                expense.Amount = updatedExpense.Amount;
                expense.Description = updatedExpense.Description;
                _storage.Save(Items);
                Console.WriteLine("Expense updated successfully.");
            }
            else
            {
                Console.WriteLine("Expense not found.");
            }
        }

        public override void Delete(int id)
        {
            var expense = Items.FirstOrDefault(e => e.Id == id);
            if (expense != null)
            {
                Items.Remove(expense);
                _storage.Save(Items);
                Console.WriteLine("Expense deleted successfully.");
            }
            else
            {
                Console.WriteLine("Expense not found.");
            }
        }

        public override void Display()
        {
            foreach (var expense in Items)
            {
                Console.WriteLine($"ID: {expense.Id}, Amount: {expense.Amount}, Description: {expense.Description}, Date: {expense.Date}");
            }
        }
    }

}
