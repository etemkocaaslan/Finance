using Finance.Helper;

namespace Finance
{
    class Program
    {
        static void Main()
        {
            var incomestorage = new IncomeStorage();
            var incomeManager = new IncomeManager(incomestorage);
            var menubarManager = new MenuBarManager(incomeManager);
            menubarManager.DisplayMenu();
        }
    }
}