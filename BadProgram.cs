namespace TechnicalAssesmentBackendDeveloper;

public class Booking
{
    // Fields with consistent naming
    private string _guestName;
    private string _roomNumber;
    private DateTime _checkInDate;
    private DateTime _checkOutDate;
    private int _totalDays;
    private double _ratePerDay;
    private double _discount;
    private double _totalAmount;

    public async Task BookRoom(string name, string room, DateTime checkIn, DateTime checkOut, double rate, double discountRate)
    {
        InitializeBookingDetails(name, room, checkIn, checkOut, rate, discountRate);
        CalculateBookingCost();
        
        await LogBookingDetailsAsync();
        DisplayBookingConfirmation();
    }

    private void InitializeBookingDetails(string name, string room, DateTime checkIn, DateTime checkOut, double rate, double discountRate)
    {
        _guestName = name;
        _roomNumber = room;
        _checkInDate = checkIn;
        _checkOutDate = checkOut;
        _ratePerDay = rate;
        _discount = discountRate;
    }

    private void CalculateBookingCost()
    {
        _totalDays = (_checkOutDate - _checkInDate).Days;
        _totalAmount = _totalDays * _ratePerDay;
        _totalAmount -= _totalAmount * _discount / 100;
    }

    private void DisplayBookingConfirmation()
    {
        Console.WriteLine($"Room Booked for {_guestName}");
        Console.WriteLine($"Room No: {_roomNumber}");
        Console.WriteLine($"Check-In: {_checkInDate}");
        Console.WriteLine($"Check-Out: {_checkOutDate}");
        Console.WriteLine($"Total Days: {_totalDays}");
        Console.WriteLine($"Amount: {_totalAmount}");
    }

    public async Task LogBookingDetailsAsync()
    {
        await Task.Delay(1000);
        Console.WriteLine("Booking log saved.");
    }

    public void Cancel()
    {
        ResetBookingProperties();
        Console.WriteLine("Booking cancelled");
    }

    private void ResetBookingProperties()
    {
        _guestName = null;
        _roomNumber = null;
        _checkInDate = DateTime.MinValue;
        _checkOutDate = DateTime.MinValue;
        _ratePerDay = 0;
        _discount = 0;
        _totalAmount = 0;
    }
}

public interface IItemManager<T>
{
    void AddItem(T item);
    void RemoveItem(T item);
    void PrintAllItems();
}

public static class AppHost
{
    public static async Task Run(string[] args)
    {
        Booking booking = new Booking();
        
        await booking.BookRoom(
            "Alice", 
            "101", 
            DateTime.Now, 
            DateTime.Now.AddDays(3), 
            150.5, 
            10
        );
        
        booking.Cancel();
    }
}

// Entry point class
public class Program
{
    public static async Task Main(string[] args)
    {
        await AppHost.Run(args);
    }
}
