using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ProcessRentalCar.Entities {
    class Invoice {

        public double BasicPayment { get; set; }
        public double Tax { get; set; }

        public Invoice(double basicPayment, double tax) {
            BasicPayment = basicPayment;
            Tax = tax;
        }

        public double TotalPayment => BasicPayment + Tax;

        public override string ToString() {
            return "BasicPayment: "
                + BasicPayment.ToString("F2", CultureInfo.InvariantCulture)
                + "\n tax: "
                + Tax.ToString("F2", CultureInfo.InvariantCulture)
                + "\n TotalPayment: "
                + TotalPayment.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
