using Finance.Helper;
using Finance.Models;

namespace Finance
{
    class Program
    {
        static void Main(string[] args)
        {
            var expenseManager = new ExpenseManager();
            var incomeManager = new IncomeManager();
            var menuManager = new MenuManager(incomeManager, expenseManager);
            menuManager.DisplayMenu();
        }
    }

}