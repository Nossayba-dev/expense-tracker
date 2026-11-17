using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace expense_tracker.Models
{
    internal class Expense
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public DateOnly Date { get; set; }
        public String? Note {get; set;}
    }
}
