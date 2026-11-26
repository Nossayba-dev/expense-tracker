using expense_tracker.Models;
using System.Text.Json;

namespace expense_tracker
{
    internal class Program
    {
        
        // Method to write data to a JSON file
        static async Task WriteJsonToFileAsync(string filePath, List<Expense> expenses)
        {
            string json = JsonSerializer.Serialize(expenses, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(filePath, json);
        }

        // Method to read data from a JSON file
        static async Task<List<Expense>> ReadJsonFromFileAsync(string filePath)
        {
            string json = await File.ReadAllTextAsync(filePath);
            return JsonSerializer.Deserialize<List<Expense>>(json) ?? new List<Expense>() ;
        }
        static async Task AddExpense(List<Expense> expenses, string filePath)
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
            await WriteJsonToFileAsync(filePath, expenses);
            Console.WriteLine("Expense added successfully!");
        }
        static public void ViewExpenses(List<Expense> expenses)
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
        static async Task DeleteExpense(List<Expense> expenses, string filePath)
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
                await WriteJsonToFileAsync(filePath, expenses);
                Console.WriteLine("Expense deleted successfully!");
            }
            else
            {
                Console.WriteLine("Expense not found.");
            }
        }


        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to the Expense Tracker!");
            const string filePath = "expenses.json";

            List<Expense> expenses = File.Exists(filePath)
                ? await ReadJsonFromFileAsync(filePath)
                : new List<Expense>();

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
                        await AddExpense(expenses, filePath);
                        break;
                    case "2":
                        ViewExpenses(expenses);
                        break;
                    case "3":
                        await DeleteExpense(expenses, filePath);
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    
    }
}

