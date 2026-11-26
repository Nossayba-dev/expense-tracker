namespace expense_tracker.Models
{
    internal class Expense
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public DateOnly Date { get; set; }
        public string? Note {get; set;}

        public Expense(int id, decimal amount, string category, DateOnly date, string? note)
        {
            Id = id;
            Amount = amount;
            Category = category;
            Date = date;
            Note = note;
        }
        public override string ToString()
        {
            return $"Expense Id: {Id}, Amount: {Amount} MAD, Category: {Category}, Date: {Date.ToShortDateString()}, Note: {Note}";
        }
    }
}
