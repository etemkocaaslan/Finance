using Finance.Models;

namespace Finance.Helper
{
    public class MenuManager(IncomeManager incomeManager, ExpenseManager expenseManager) : AbstractMenuManager
    {
        public void DisplayMenu()
        {
            while (!exit)
            {
                DisplayMenuOptions();

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.Clear();
                    exit = HandleMenuChoice(choice);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        protected override bool HandleMenuChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    DisplayIncomeMenu();
                    return false;
                case 2:
                    DisplayExpenseMenu();
                    return false;
                case 3:
                    Console.WriteLine("Exiting program.");
                    return true;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    return false;
            }
        }

        private void DisplayIncomeMenu()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\nIncome Manager");
                Console.WriteLine("1. Add Income");
                Console.WriteLine("2. Update Income");
                Console.WriteLine("3. Delete Income");
                Console.WriteLine("4. Display Incomes");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Select an option: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    back = HandleIncomeChoice(choice);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private void DisplayExpenseMenu()
        {
            bool back = false;
            while (!back)
            {
                Console.WriteLine("\nExpense Manager");
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. Update Expense");
                Console.WriteLine("3. Delete Expense");
                Console.WriteLine("4. Display Expenses");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Select an option: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    back = HandleExpenseChoice(choice);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private bool HandleIncomeChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddIncome();
                    return false;
                case 2:
                    UpdateIncome();
                    return false;
                case 3:
                    DeleteIncome();
                    return false;
                case 4:
                    DisplayIncomes();
                    return false;
                case 5:
                    return true;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    return false;
            }
        }

        private bool HandleExpenseChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddExpense();
                    return false;
                case 2:
                    UpdateExpense();
                    return false;
                case 3:
                    DeleteExpense();
                    return false;
                case 4:
                    DisplayExpenses();
                    return false;
                case 5:
                    return true;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    return false;
            }
        }

        private void AddIncome()
        {
            var income = new Income
            {
                Amount = GetAmount(),
                Description = GetDescription(),
                Date = DateTime.Now
            };
            incomeManager.Add(income);
        }

        private void UpdateIncome()
        {
            int id = GetId("income");
            var income = new Income
            {
                Amount = GetAmount(),
                Description = GetDescription(),
                Date = DateTime.Now
            };
            incomeManager.Update(id, income);
        }

        private void DeleteIncome()
        {
            int id = GetId("income");
            incomeManager.Delete(id);
        }

        private void DisplayIncomes()
        {
            incomeManager.Display();
        }

        private void AddExpense()
        {
            var expense = new Expense
            {
                Amount = GetAmount(),
                Description = GetDescription(),
                Date = DateTime.Now
            };
            expenseManager.Add(expense);
        }

        private void UpdateExpense()
        {
            int id = GetId("expense");
            var expense = new Expense
            {
                Amount = GetAmount(),
                Description = GetDescription(),
                Date = DateTime.Now
            };
            expenseManager.Update(id, expense);
        }

        private void DeleteExpense()
        {
            int id = GetId("expense");
            expenseManager.Delete(id);
        }

        private void DisplayExpenses()
        {
            expenseManager.Display();
        }
    }
}
