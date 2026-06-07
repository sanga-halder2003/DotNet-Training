using RiderSharingApp.Interfaces;
using RiderSharingApp.Models;
using RiderSharingApp.Services;

class Program
{ 
    static void Main(string[] args)
    {
        // Luxury Fare Calculation
        IFareCalculation fare = new LuxuryRideFareCalculator();
        Console.WriteLine($"Fare: {fare.CalculateFare(10)}");

        // Bike Ride

        Ride bike = new BikeRide();
        bike.RideDetails();

        // Auto Ride
        Ride autoRide = new AutoRide();
        autoRide.RideDetails();

        INotification email = new EmailNotification();
        email.Send("Your Ride has been booked");
        


    }
}

