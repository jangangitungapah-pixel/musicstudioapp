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
'

















@

Write-CodeFile "Services/IStudioDataService.cs" @'
using musicstudioapp.Models;

namespace musicstudioapp.Services;

public interface IStudioDataService
{
    Task<List<StudioRoom>> GetStudioRoomsAsync();

    Task<List<Customer>> GetCustomersAsync();

    Task<List<Booking>> GetBookingsAsync();

    Task<List<InventoryItem>> GetInventoryItemsAsync();

    Task<List<Invoice>> GetInvoicesAsync();

    Task<List<Expense>> GetExpensesAsync();
}
