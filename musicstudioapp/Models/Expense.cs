namespace musicstudioapp.Models;

public class Expense
{
    public int Id { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    public string Title { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public string Notes { get; set; } = string.Empty;
}