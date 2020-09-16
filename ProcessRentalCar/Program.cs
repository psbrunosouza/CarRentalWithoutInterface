using ProcessRentalCar.Entities;
using ProcessRentalCar.Services;
using System;
using System.Globalization;

namespace ProcessRentalCar {
    class Program {
        static void Main(string[] args) {

            Console.WriteLine("Enter with the data: ");
            Console.Write("Model: ");
            string model = Console.ReadLine();
            Console.Write("Pickup: (dd/MM/yyyy hh/mm): ");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Return: (dd/MM/yyyy hh/mm): ");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write("Enter price per hour: ");
            double pricePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter price per day: ");
            double pricePerDay = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            CarRental carRental = new CarRental(start, finish, new Vehicle(model));
            RentalService rentalService = new RentalService(pricePerHour, pricePerDay, new BrasilTaxService());
            rentalService.ProcessInvoice(carRental);

            Console.WriteLine("INVOICE: ");
            Console.WriteLine(carRental.Invoice);

        }
    }
}
