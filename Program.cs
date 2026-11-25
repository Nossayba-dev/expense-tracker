using expense_tracker.Models;

namespace expense_tracker
{
    internal class Program
    {
        static List<Expense> expenses = new();
        static public void AddExpense()
        {
            Console.WriteLine("Enter the amount:");
            decimal amount;
            while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <=0)
            {
                Console.WriteLine("Not a valid number, try again:");
            }

            Console.WriteLine("Enter the category:");
            string category = Console.ReadLine()!;
            while (string.IsNullOrWhiteSpace(category))
            {
                Console.WriteLine("Category can't be empty, try again:");
                category = Console.ReadLine()!;
            }

            Console.WriteLine("Enter the date (yyyy-MM-dd):");
            DateOnly date;
            while (!DateOnly.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Not a valid date, try again:");
            }

            Console.WriteLine("Enter a note (optional):");
            string? note = Console.ReadLine();
            int id = (expenses.Count == 0 ? 1 : expenses.Max(e => e.Id) + 1);
            Expense newExpense = new Expense(id, amount, category, date, note);
            expenses.Add(newExpense);
            Console.WriteLine("Expense added successfully!");
        }
        static public void ViewExpenses()
        {
            if (expenses.Count == 0)
            {
                Console.WriteLine("No expenses recorded.");
                return;
            }
            Console.WriteLine("All Expenses:");
            foreach (var expense in expenses)
            {
                Console.WriteLine(expense);
            }
        }
        static public void DeleteExpense()
        {
            Console.WriteLine("Enter the Id of the expense to delete:");
            int id ;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Not a valid number, try again:");
            }
            var expenseToRemove = expenses.FirstOrDefault(e => e.Id == id);
            if (expenseToRemove != null)
            {
                expenses.Remove(expenseToRemove);
                Console.WriteLine("Expense deleted successfully!");
            }
            else
            {
                Console.WriteLine("Expense not found.");
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Expense Tracker!");
            while (true)
            {
                Console.WriteLine("1. Add an expense");
                Console.WriteLine("2. View all expenses");
                Console.WriteLine("3. Delete an expense");
                Console.WriteLine("4. Exit");


                Console.WriteLine("Please select an option (1-4):");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddExpense();
                        break;
                    case "2":
                        ViewExpenses();
                        break;
                    case "3":
                        DeleteExpense();
                        break;
                    case "4":
                        Console.WriteLine("Exiting the application. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                
              
            }
        }
    }
}

