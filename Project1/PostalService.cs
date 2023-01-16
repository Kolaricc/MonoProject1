using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public abstract class PostalService
    {
        public int DistanceTraveledPerDay { get; private set; }

        public PostalService(int DistanceTraveledPerDay)
        {
            this.DistanceTraveledPerDay = DistanceTraveledPerDay;
        }

        public int DeliveryTime(double distance)
        {
            return (int)Math.Ceiling(distance / DistanceTraveledPerDay);
        }
        public abstract void ShipPackage();
    }
}
