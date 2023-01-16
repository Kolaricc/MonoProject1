using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    interface IPackage
    {
        int Distance { get; set; }
        int DeliveryTime { get; set; }
        PostalService PostalService { get; }

        public void CalculateDeliveryTime();
    }
}
