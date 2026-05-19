namespace musicstudioapp.Models;

public class InventoryItem
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public InventoryCategory Category { get; set; } = InventoryCategory.Other;

    public int Quantity { get; set; }

    public int MinimumStock { get; set; }

    public string Unit { get; set; } = "pcs";

    public decimal UnitCost { get; set; }

    public decimal SellingPrice { get; se



















t; }

    public DateTime LastUpdatedAt { get; set; } = DateTime.Now;

    public string Notes { get; set; } = string.Empty;

    public bool IsLowStock => Quantity <= MinimumStock;
}
