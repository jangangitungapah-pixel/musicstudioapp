using Microsoft.Extensions.DependencyInjection;
using musicstudioapp.Models;
using musicstudioapp.Services;

namespace musicstudioapp.Pages;

public partial class DashboardPage : ContentPage
{
    private readonly IStudioDataService _dataService;

    public DashboardPage()
    {
        InitializeComponent();

        _dataService =
            Application.Current?.Handler?.MauiContext?.Services.GetService<IStudioDataService>()
            ?? new DummyStudioDataService();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await LoadDashboardAsync();
    }

    private async Task LoadDashboardAsync()
    {
        var bookings = await _dataService.GetBookingsAsync();
        var customers = await _dataService.GetCustomersAsync();
        var inventoryItems = await _dataService.GetInventoryItemsAsync();
        var invoices = await _dataService.GetInvoicesAsync();

        var today = DateTime.Today;

        var todayBookings = bookings
            .Where(booking => booking.StartTime.Date == today)
            .ToList();

        var todayRevenue = invoices
            .Where(invoice => invoice.CreatedAt.Date == today)
            .Sum(invoice => invoice.GrandTotal);

        var lowStockItems = inventoryItems
            .Where(item => item.IsLowStock)
            .ToList();

        var upcomingBookings = bookings
            .Where(booking => booking.StartTime >= DateTime.Now)
            .OrderBy(booking => booking.StartTime)
            .Take(5)
            .Select(booking => new DashboardBookingItem
            {
                CustomerName = booking.CustomerName,
                RoomName = booking.RoomName,
                Status = booking.Status.ToString(),
                ScheduleText = $"{booking.StartTime:dd MMM yyyy, HH:mm} - {booking.EndTime:HH:mm}"
            })
            .ToList();

        var lowStockCards = lowStockItems
            .Select(item => new DashboardInventoryItem
            {
                Name = item.Name,
                StockText = $"{item.Quantity} {item.Unit}",
                Notes = string.IsNullOrWhiteSpace(item.Notes)
                    ? $"Minimal stok: {item.MinimumStock} {item.Unit}"
                    : item.Notes
            })
            .ToList();

        TodayBookingsLabel.Text = todayBookings.Count.ToString();
        TodayRevenueLabel.Text = FormatRupiah(todayRevenue);
        TotalCustomersLabel.Text = customers.Count.ToString();
        LowStockLabel.Text = lowStockItems.Count.ToString();

        UpcomingBookingsView.ItemsSource = upcomingBookings;
        LowStockItemsView.ItemsSource = lowStockCards;
    }

    private static string FormatRupiah(decimal amount)
    {
        return $"Rp {amount:N0}".Replace(",", ".");
    }

    private class DashboardBookingItem
    {
        public string CustomerName { get; set; } = string.Empty;

        public string RoomName { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string ScheduleText { get; set; } = string.Empty;
    }

    private class DashboardInventoryItem
    {
        public string Name { get; set; } = string.Empty;

        public string StockText { get; set; } = string.Empty;

        public string Notes { get; set; } = string.Empty;
    }
}