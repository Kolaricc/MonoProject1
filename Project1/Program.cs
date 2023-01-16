using System;
using System.Collections.Generic;
using System.Linq;

namespace Project1
{
    class Program
    {
        public static Box AddBox(FreePostalService freePostalService, PaidPostalService paidPostalService)
        {
            int width, height, lenght, postalService, distance;
            Console.WriteLine($"\nEnter specifications of box package(W x H x L): ");
            width = Convert.ToInt32(Console.ReadLine());
            height = Convert.ToInt32(Console.ReadLine());
            lenght = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter distance to the location: ");
            distance = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter desired type of Postal service (1 for free, 2 for paid): ");
            postalService = Convert.ToInt32(Console.ReadLine());
            if (postalService == 1)
            {
                return new Box(width, height, lenght, distance, freePostalService);
            }
            else if (postalService == 2)
            {
                return new Box(width, height, lenght, distance, paidPostalService);
            }
            else
            {
                Console.WriteLine("Invalid postal service!");
                return AddBox(freePostalService, paidPostalService);
            }
        }

        public static Letter AddLetter(FreePostalService freePostalService, PaidPostalService paidPostalService)
        {
            int width, height, postalService, distance;
            Console.WriteLine($"\nEnter specifications of a letter(W x H): ");
            width = Convert.ToInt32(Console.ReadLine());
            height = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter distance to the location: ");
            distance = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter desired type of Postal service (1 for free, 2 for paid): ");
            postalService = Convert.ToInt32(Console.ReadLine());
            if (postalService == 1)
            {
                return new Letter(width, height, distance, freePostalService);
            }
            else if (postalService == 2)
            {
                return new Letter(width, height, distance, paidPostalService);
            }
            else
            {
                Console.WriteLine("Invalid postal service!");
                return AddLetter(freePostalService, paidPostalService);
            }
        }

        public static void SendPackage(List<IPackage> packages)
        {
            int index;
            Console.WriteLine("\nChoose the index of a package you wish to send(enter -1 to go back): ");
            index = Convert.ToInt32(Console.ReadLine());
            if(index != -1)
            {
                packages.ElementAt(index-1).PostalService.ShipPackage();
                Console.WriteLine("Expected delivery time is:" + packages.ElementAt(index-1).DeliveryTime + " days");
                packages.RemoveAt(index-1);
            }
        }

        public static void ViewAllPackages(List<IPackage> packages)
        {
            int index = 0;
            Console.WriteLine();
            foreach(IPackage package in packages)
            {
                index++;
                Console.WriteLine(index+"\t"+package.ToString());
            }
        }

        public static void DeliveryThisWeek(List<IPackage> packages)
        {
            var thisWeekDelivery = from package in packages
                                   where package.DeliveryTime <= 7
                                   select package;
            foreach(var package in thisWeekDelivery)
            {
                Console.WriteLine(package.ToString());
            }
        }

        public static void AddPackage(List<IPackage> packages,FreePostalService freePostalService, PaidPostalService paidPostalService)
        {
            int choice;
            Console.Write("\nTo add a letter enter 1, to add a box package enter 2, to go back enter any other key: ");
            choice=Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    packages.Add(AddBox(freePostalService, paidPostalService));
                    break;
                case 2:
                    packages.Add(AddLetter(freePostalService, paidPostalService));
                    break;
                default:
                    break;
            }
        }

        static void Main(string[] args)
        {
            int numberOfLetters;
            int numberOfBoxPackages;
            List<IPackage> packages = new List<IPackage>();
            FreePostalService freePostalService = new FreePostalService(10);
            PaidPostalService paidPostalService = new PaidPostalService(1, 100);
            int menuChoice = 1;

            Console.Write("Enter number of box packages: ");
            numberOfBoxPackages = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter number of letters: ");
            numberOfLetters=Convert.ToInt32(Console.ReadLine());

            for (int index = 0; index < numberOfBoxPackages; index++)
            {
                packages.Add(AddBox(freePostalService, paidPostalService));
            }
            for (int index = 0; index < numberOfLetters; index++)
            {
                packages.Add(AddLetter(freePostalService, paidPostalService));
            }
            while (menuChoice != 0)
            {
                Console.WriteLine("\nTo send a package enter 1 \nTo view all packages enter 2 \nTo find packages that will be delivered this week enter 3\nTo add a package enter 4\nTo end program enter 0");
                menuChoice = Convert.ToInt32(Console.ReadLine());
                switch(menuChoice)
                {
                    case 0:
                        break;
                    case 1:
                        SendPackage(packages);
                        break;
                    case 2:
                        ViewAllPackages(packages);
                        break;
                    case 3:
                        DeliveryThisWeek(packages);
                        break;
                    case 4:
                        AddPackage(packages, freePostalService, paidPostalService);
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
}
