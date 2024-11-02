using Finance.Models;

namespace Finance.Helper
{
    public class MenuBarManager
    {
        private readonly IncomeManager _incomeManager;

        public MenuBarManager(IncomeManager incomeManager)
        {
            _incomeManager = incomeManager;
        }

        public void DisplayMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nIncome Manager");
                Console.WriteLine("1. Add Income");
                Console.WriteLine("2. Update Income");
                Console.WriteLine("3. Delete Income");
                Console.WriteLine("4. Display Incomes");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    exit = HandleMenuChoice(choice);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private bool HandleMenuChoice(int choice)
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
                    Console.WriteLine("Exiting program.");
                    return true;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    return false;
            }
        }

        private void AddIncome()
        {
            var income = GetIncomeDetails();
            Console.WriteLine(_incomeManager.AddIncome(income));
        }

        private void UpdateIncome()
        {
            int id = GetIncomeId();
            var income = GetIncomeDetails();
            Console.WriteLine(_incomeManager.UpdateIncome(id, income.Amount, income.Description ?? ""));
        }

        private void DeleteIncome()
        {
            int id = GetIncomeId();
            Console.WriteLine(_incomeManager.DeleteIncome(id));
        }

        private void DisplayIncomes()
        {
            var incomes = _incomeManager.GetAllIncomes();
            foreach (var income in incomes)
            {
                Console.WriteLine($"ID: {income.Id}, Amount: {income.Amount}, Description: {income.Description}, Date: {income.Date}");
            }
            Console.ReadLine();
        }

        private static Income GetIncomeDetails()
        {
            Console.Write("Enter amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                throw new ArgumentException("Invalid amount. Please enter a positive number.");
            }

            Console.Write("Enter description: ");
            string description = Console.ReadLine() ?? "";

            return new Income
            {
                Amount = amount,
                Description = description,
                Date = DateTime.Now
            };
        }

        private static int GetIncomeId()
        {
            Console.Write("Enter income ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                throw new ArgumentException($"Invalid ID. Please enter a valid number.");
            }
            return id;
        }
    }
}
