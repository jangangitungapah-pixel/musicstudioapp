using musicstudioapp.Models;

namespace musicstudioapp.Services;

public class DummyStudioDataService : IStudioDataService
{
    public Task<List<StudioRoom>> GetStudioRoomsAsync()
    {
        var rooms = new List<StudioRoom>
        {
            new()
            {
                Id = 1,
                Name = "Studio A",
                Description = "Ruangan utama untuk full band rehearsal.",
                HourlyRate = 75000,
                Capacity = 8,
                ColorHex = "#38BDF8"
 



















           },
            new()
            {
                Id = 2,
                Name = "Studio B",
                Description = "Ruangan kecil untuk vocal, gitar, dan latihan ringan.",
                HourlyRate = 50000,
                Capacity = 4,
                ColorHex = "#A78BFA"
            },
            new()
            {
                Id = 3,
                Name = "Recording Room",
                Description = "Ruangan recording vocal, podcast, dan take instrument.",
                HourlyRate = 125000,
                Capacity = 5,
 
















               ColorHex = "#F97316"
            }
        };

        return Task.FromResult(rooms);
    }

    public Task<List<Customer>> GetCustomersAsync()
    {
        var customers = new List<Customer>
        {
            new()
            {
                Id = 1,
                FullName = "Andi Pratama",
                BandName = "Noise Weekend",
                Phone = "081234567890",
                Ema
















il = "andi@example.com",
                Notes = "Sering booking malam minggu."
            },
            new()
            {
                Id = 2,
                FullName = "Raka Firmansyah",
                BandName = "Sunset Riot",
                Phone = "082112223333",
                Email = "raka@example.com",
                Notes = "Butuh extra mic setiap latihan."
            },
            new()
            {
                Id = 3,
 














               FullName = "Maya Lestari",
                BandName = "Solo Vocal",
                Phone = "085677788899",
                Email = "maya@example.com",
                Notes = "Customer recording vocal."
            }
        };

        return Task.FromResult(customers);
    }

    public Task<List<Booking>> GetBookingsAsync()
    {
        var today = DateTime.Today;

        var bookings = new List<Booking>
        {
            new()

















            {
                Id = 1,
                StudioRoomId = 1,
                RoomName = "Studio A",
                CustomerId = 1,
                CustomerName = "Andi Pratama",
                StartTime = today.AddHours(13),
                EndTime = today.AddHours(15),
                HourlyRate = 75000,
                DownPayment = 50000,
                Status = BookingStatus.Confirmed,
                PaymentStatus = PaymentStatus.Partial,
                Notes = "Full band rehearsal."
            },
            new()
 















           {
                Id = 2,
                StudioRoomId = 2,
                RoomName = "Studio B",
                CustomerId = 2,
                CustomerName = "Raka Firmansyah",
                StartTime = today.AddHours(16),
                EndTime = today.AddHours(18),
                HourlyRate = 50000,
                DownPayment = 100000,
                Status = BookingStatus.Completed,
                PaymentStatus = PaymentStatus.Paid,
                Notes = "Latihan acoustic set."
            },
            new()
            {
                Id = 3,
                StudioRoomId = 3,
 

















               RoomName = "Recording Room",
                CustomerId = 3,
                CustomerName = "Maya Lestari",
                StartTime = today.AddDays(1).AddHours(10),
                EndTime = today.AddDays(1).AddHours(13),
                HourlyRate = 125000,
                DownPayment = 100000,
                Status = BookingStatus.PendingDp,
                PaymentStatus = PaymentStatus.Partial,
         








       Notes = "Recording vocal single."
            }
        };

        return Task.FromResult(bookings);
    }

    public Task<List<InventoryItem>> GetInventoryItemsAsync()
    {
        var items = new List<InventoryItem>
        {
            new()
            {
                Id = 1,
                Name = "Senar Gitar Elektrik",
                Category = InventoryCategory.Consumable,
                Quantity = 4,
                MinimumStock = 5,

















                Unit = "set",
                UnitCost = 45000,
                SellingPrice = 65000,
                Notes = "Low stock, perlu restock."
            },
            new()
            {
                Id = 2,
                Name = "Stick Drum",
                Category = InventoryCategory.Accessory,
                Quantity = 12,
                MinimumStock = 4,
                Unit = "pair",
                UnitCost = 35000,
                SellingPrice = 50000
            },
            new()
            {
 


















               Id = 3,
                Name = "Mic Dynamic",
                Category = InventoryCategory.AudioEquipment,
                Quantity = 6,
                MinimumStock = 2,
                Unit = "pcs",
                UnitCost = 350000,
                SellingPrice = 0,
                Notes = "Aset studio."
            }
        };

        return Task.FromResult(items);
    }

    public Task<List<Invoice>> GetInvoicesAsync()
    {
        var invoices = new List<Invoice>
        {
 


















           new()
            {
                Id = 1,
                InvoiceNumber = "INV-2026-0001",
                CustomerId = 1,
                CustomerName = "Andi Pratama",
                CreatedAt = DateTime.Today.AddHours(15),
                PaymentStatus = PaymentStatus.Paid,
                PaidAmount = 150000,
                Items = new List<InvoiceItem>
                {
                    new()
                    {
                        Name = "Sewa Studio A - 2 Jam",
                        Quantity = 2,
                        UnitPrice = 75000
                    }

















                }
            },
            new()
            {
                Id = 2,
                InvoiceNumber = "INV-2026-0002",
                CustomerId = 2,
                CustomerName = "Raka Firmansyah",
                CreatedAt = DateTime.Today.AddHours(18),
                PaymentStatus = PaymentStatus.Paid,
                PaidAmount = 150000,
                Items = new List<InvoiceItem>
                {
                    new()
                    {
                        Name = "Sewa Studio B - 2 Jam",
                        Quantity = 2,
                        UnitPrice = 50000
 

















                   },
                    new()
                    {
                        Name = "Stick Drum",
                        Quantity = 1,
                        UnitPrice = 50000
                    }
                }
            }
        };

        return Task.FromResult(invoices);
    }

    public Task<List<Expense>> GetExpensesAsync()
    {
        var expenses = new List<Expense>
        {
            new()
            {
                Id = 1,
  




















              Date = DateTime.Today,
                Title = "Beli Senar Gitar",
                Category = "Inventory",
                Amount = 180000,
                Notes = "Restock senar gitar elektrik."
            },
            new()
            {
                Id = 2,
                Date = DateTime.Today,
                Title = "Listrik Studio",
                Category = "Operasional",
                Amount = 250000,
                Notes = "Token listrik studio."
            }
        };

 
















       return Task.FromResult(expenses);
    }
}
