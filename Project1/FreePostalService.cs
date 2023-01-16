using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class FreePostalService:PostalService
    {

        public FreePostalService(int distanceTraveledPerDay):base(distanceTraveledPerDay)
        {
        }
        public override void ShipPackage()
        {
            Console.WriteLine("Package has been shipped.");
        }
    }
}
