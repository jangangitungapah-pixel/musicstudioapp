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