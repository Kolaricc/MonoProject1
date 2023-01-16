using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class Box:IPackage
    {
        private int distance;
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Lenght { get; private set; }
        public int Distance { get { return distance; } set { distance = value; CalculateDeliveryTime(); } }
        public PostalService PostalService { get; private set; }
        public int DeliveryTime { get; set; }

        public Box(int width, int height, int lenght, int distance, PostalService postalService)
        {
            this.Width = width;
            this.Height = height;
            this.Lenght = lenght;
            this.PostalService = postalService;
            this.Distance = distance;
        }
        public Box(int width, int height, int lenght)
        {
            this.Width = width;
            this.Height = height;
            this.Lenght = lenght;
        }
        public void CalculateDeliveryTime()
        {
            DeliveryTime = PostalService.DeliveryTime(distance);
        }

        public override string ToString()
        {
            return $"width: {Width}, height: {Height}, Lenght: {Lenght}\tDelivery time: {DeliveryTime}";
        }
    }
}
