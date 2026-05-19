namespace musicstudioapp.Models;

public class InvoiceItem
{
    public string Name { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal DiscountAmount { get; set; }













    public decimal LineTotal => Math.Max(0, Quantity * UnitPrice - DiscountAmount);
}
