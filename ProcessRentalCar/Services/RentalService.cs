using ProcessRentalCar.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProcessRentalCar.Services {
    class RentalService {

        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }

        // Maneira errada de realizar, pois gera dependencia na classe.
        //private BrasilTaxService _brasilTaxService = new BrasilTaxService();

        private ITaxService _taxService;

        public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService) {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _taxService = taxService;
        }

        public void ProcessInvoice(CarRental carRental) {

            TimeSpan duration = carRental.Finish.Subtract(carRental.Start);
            double basicPayment = 0.0;

            if (duration.TotalHours <= 12) {
                basicPayment = PricePerHour * Math.Ceiling(duration.TotalHours);
            }
            else {
                basicPayment = PricePerDay * Math.Ceiling(duration.TotalHours);
            }

            double tax = _brasilTaxService.Tax(basicPayment);
            carRental.Invoice = new Invoice(basicPayment, tax);

        }
    }
}
