using expense_tracker.Models;

namespace expense_tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Expense expense = new Expense(1, 100.50m, "Food", DateOnly.FromDateTime(DateTime.Now), "Lunch at a restaurant");

            Console.WriteLine(expense.ToString());

        }
    }
}
