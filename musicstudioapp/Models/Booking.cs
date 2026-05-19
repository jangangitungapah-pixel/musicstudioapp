namespace musicstudioapp.Models;

public class Booking
{
    public int Id { get; set; }

    public int StudioRoomId { get; set; }

    public string RoomName { get; set; } = string.Empty;

    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public decimal HourlyRate { get; set; }

    public decimal DiscountAmount { get; set; }

    public decimal DownPayment { get; set; }


























    public BookingStatus Status { get; set; } = BookingStatus.Draft;

    public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Unpaid;

    public string Notes { get; set; } = string.Empty;

    public decimal DurationHours => (decimal)Math.Max(0, (EndTime - StartTime).TotalHours);

    public decimal Subtotal => DurationHours * HourlyRate;

    public decimal Total => Math.Max(0, Subtotal - DiscountAmount);

    public decimal RemainingPayment => Math.Max(0, Total - DownPayment);
}
