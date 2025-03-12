using System.ComponentModel.DataAnnotations;

namespace ExpensesBackend.Models
{
    public class Entry
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool IsExpense { get; set; }
        public double Value { get; set; }
    }
}
