namespace musicstudioapp.Models;

public class Invoice
{
    public int Id { get; set; }

    public string InvoiceNumber { get; set; } = string.Empty;

    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
















    public List<InvoiceItem> Items { get; set; } = new();

    public decimal DiscountAmount { get; set; }

    public decimal TaxAmount { get; set; }

    public decimal PaidAmount { get; set; }

    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Unpaid;

    public decimal Subtotal => Items.Sum(item => item.LineTotal);

    public decimal GrandTotal => Math.Max(0, Subtotal - DiscountAmount + TaxAmount);

    public decimal ChangeAmount => Math.Max(0, PaidAmount - GrandTotal);
}
