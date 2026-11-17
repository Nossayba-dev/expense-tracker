using expense_tracker.Models;

namespace expense_tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Expense expense = new Expense();
            expense.Id = 1;
            expense.Amount = 100.50m;
            expense.Category = "Food";
            expense.Date = DateOnly.FromDateTime(DateTime.Now);
            expense.Note = "Lunch at a restaurant";

            Console.WriteLine("expense: " + expense.Id.ToString()
                            + ", Amount: " + expense.Amount.ToString()
                            + ", Category: " + expense.Category
                            + ", Date: " + expense.Date.ToString()
                            + ", Note: " + expense.Note);

        }
    }
}
