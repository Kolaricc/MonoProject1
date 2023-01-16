using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class PaidPostalService : PostalService
    {
        public double PricePerUnit { get; private set; }
        public PaidPostalService(double pricePerUnit, int distanceTraveledPerDay) : base(distanceTraveledPerDay)
        {
            this.PricePerUnit = Math.Round(PricePerUnit, 2);
        }
        public void ChangePrice(double PricePerUnit)
        {
            this.PricePerUnit = Math.Round(PricePerUnit, 2);
        }

        public double CalculatePrice(Box box)
        {
            double price = PricePerUnit * box.Height * box.Lenght * box.Width;
            return Math.Round(price,2);
        }
        public double CalculatePrice(Letter letter)
        {
            double price = PricePerUnit * letter.Height * letter.Width;
            return Math.Round(price, 2);
        }

        public override void ShipPackage()
        {
            Console.WriteLine($"Package has been delivered.");
        }
    }
}
