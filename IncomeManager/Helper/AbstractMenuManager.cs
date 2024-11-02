namespace Finance.Helper
{
    public abstract class AbstractMenuManager
    {
        private protected static bool exit = false;
        protected abstract void DisplayMenu();
        protected static void DisplayMenuOptions() => Console.WriteLine(
              "|| Finance Manager ||"
            + "\n1. Manage Income"
            + "\n2. Manage Expenses"
            + "\n3. Exit"
            + "\nSelect an option: ");
        protected abstract bool HandleMenuChoice(int choice);

        protected static int GetId(string itemType)
        {
            Console.Write($"Enter {itemType} ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                throw new ArgumentException($"Invalid ID. Please enter a valid number.");
            }
            return id;
        }


        protected static decimal GetAmount()
        {
            Console.Write("Enter amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                throw new ArgumentException("Invalid amount. Please enter a positive number.");
            }
            return amount;
        }

        protected static string GetDescription()
        {
            Console.Write("Enter description: ");
            return Console.ReadLine() ?? "";
        }
    }
}
