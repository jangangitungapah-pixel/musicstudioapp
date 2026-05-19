using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using Microsoft.Extensions.DependencyInjection;
using musicstudioapp.Models;
using musicstudioapp.Services;

namespace musicstudioapp.Pages;

public partial class DashboardPage : ContentPage
{
    private readonly IStudioDataService _dataService;
    private bool _hasAnimated;

    public ISeries[] RevenueSeries { get; set; } = Array.Empty<ISeries>();

    public Axis[] RevenueXAxes { get; set; } = Array.Empty<Axis>();

    public Axis[] RevenueYAxes { get; set; } = Array.Empty<Axis>();

    public DashboardPage()
    {
        InitializeComponent();

        BindingContext = this;

        _dataService =
            Application.Current?.Handler?.MauiContext?.Services.GetService<IStudioDataService>()
            ?? new DummyStudioDataService();

        SetupChart();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await LoadDashboardAsync();

        if (!_hasAnimated)
        {
            _hasAnimated = true;
            await RunIntroAnimationAsync();
        }
    }

    private void SetupChart()
    {
        RevenueSeries =
        [
            new LineSeries<double>
            {
                Name = "Revenue",
                Values = [320000, 450000, 380000, 760000, 640000, 980000, 1250000],
                GeometrySize = 10,
                LineSmoothness = 0.75,
                Fill = null
            }
        ];

        RevenueXAxes =
        [
            new Axis
            {
                Labels = ["Sen", "Sel", "Rab", "Kam", "Jum", "Sab", "Min"],
                TextSize = 12,
                SeparatorsPaint = null
            }
        ];

        RevenueYAxes =
        [
            new Axis
            {
                Labeler = value => FormatRupiahShort((decimal)value),
                TextSize = 12
            }
        ];
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
                ScheduleText = $"{booking.RoomName} • {booking.StartTime:dd MMM yyyy, HH:mm} - {booking.EndTime:HH:mm}"
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
        TodayBookingSubtitleLabel.Text = todayBookings.Count == 1 ? "jadwal aktif" : "jadwal aktif";
        TodayRevenueLabel.Text = FormatRupiah(todayRevenue);
        HeroRevenueLabel.Text = FormatRupiahShort(todayRevenue);
        TotalCustomersLabel.Text = customers.Count.ToString();
        LowStockLabel.Text = lowStockItems.Count.ToString();
        RevenueGrowthLabel.Text = "+24%";

        UpcomingBookingsView.ItemsSource = upcomingBookings;
        LowStockItemsView.ItemsSource = lowStockCards;
    }

    private async Task RunIntroAnimationAsync()
    {
        RootContent.Opacity = 0;
        RootContent.TranslationY = 18;

        await Task.WhenAll(
            RootContent.FadeToAsync(1, 420, Easing.CubicOut),
            RootContent.TranslateToAsync(0, 0, 420, Easing.CubicOut)
        );

        await AnimateCardAsync(HeroCard, 0);
        await AnimateCardAsync(MetricsGrid, 40);
        await AnimateCardAsync(RevenueCard, 60);

        await Task.WhenAll(
            AnimateCardAsync(BookingCard, 80),
            AnimateCardAsync(InventoryCard, 100)
        );
    }

    private static async Task AnimateCardAsync(VisualElement element, uint delay)
    {
        await Task.Delay((int)delay);

        element.Opacity = 0;
        element.Scale = 0.97;
        element.TranslationY = 14;

        await Task.WhenAll(
            element.FadeToAsync(1, 260, Easing.CubicOut),
            element.ScaleToAsync(1, 260, Easing.CubicOut),
            element.TranslateToAsync(0, 0, 260, Easing.CubicOut)
        );
    }

    private static string FormatRupiah(decimal amount)
    {
        return $"Rp {amount:N0}".Replace(",", ".");
    }

    private static string FormatRupiahShort(decimal amount)
    {
        if (amount >= 1_000_000)
        {
            return $"Rp {amount / 1_000_000:N1}jt".Replace(",", ".");
        }

        if (amount >= 1_000)
        {
            return $"Rp {amount / 1_000:N0}rb".Replace(",", ".");
        }

        return FormatRupiah(amount);
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