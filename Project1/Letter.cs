using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Letter : IPackage
    {
        private int distance;
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Distance { get { return distance; } set { distance = value; CalculateDeliveryTime(); } }
        public PostalService PostalService { get; private set; }
        public int DeliveryTime { get; set; }

        public Letter(int width, int height, int distance,PostalService postalService)
        {
            this.Width = width;
            this.Height = height;
            this.PostalService = postalService;
            this.Distance = distance;
        }
        public void CalculateDeliveryTime()
        {
            DeliveryTime = PostalService.DeliveryTime(Distance);
        }

        public override string ToString()
        {
            return $"width: {Width}, height: {Height}\t\t        Delivery time: {DeliveryTime}";
        }
    }
}
