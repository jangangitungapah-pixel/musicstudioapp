namespace musicstudioapp.Models;

public enum BookingStatus
{
    Draft,
    PendingDp,
    Confirmed,
    CheckedIn,
    Completed,
    Cancelled
}

public enum PaymentStatus
{
    Unpaid,
    Partial,
    Paid,
    Refunded
}

public enum InventoryCategory
{
    Instrument,
    AudioEquipment,
    Accessory,
    Consumable,
    Furniture,
    Other
}

public enum TransactionType
{
    Income,
    Expense
}
