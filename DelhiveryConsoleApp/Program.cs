using DelhiveryConsoleApp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delhivery.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShipmentService service = new ShipmentService();

            while (true)
            {
                Console.WriteLine("\n===== DELHIVERY CONSOLE =====");
                Console.WriteLine("1. Book Shipment");
                Console.WriteLine("2. List Shipments");
                Console.WriteLine("3. Update Shipment Status");
                Console.WriteLine("4. Cancel Shipment");
                Console.WriteLine("5. Exit");

                Console.Write("Enter Choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BookShipment(service);
                        break;

                    case "2":
                        ListShipments(service);
                        break;

                    case "3":
                        UpdateStatus(service);
                        break;

                    case "4":
                        CancelShipment(service);
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid Choice.");
                        break;
                }
            }
        }

        static void BookShipment(ShipmentService service)
        {
            Shipment shipment = new Shipment();

            Console.Write("AWB Number: ");
            shipment.AWBNumber = Console.ReadLine();

            Console.Write("Sender Name: ");
            shipment.SenderName = Console.ReadLine();

            Console.Write("Receiver Name: ");
            shipment.ReceiverName = Console.ReadLine();

            Console.Write("Origin: ");
            shipment.Origin = Console.ReadLine();

            Console.Write("Destination: ");
            shipment.Destination = Console.ReadLine();

            Console.Write("Weight (Kg): ");
            shipment.WeightKg = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nValid Status:");
            Console.WriteLine("Booked");
            Console.WriteLine("In Transit");
            Console.WriteLine("Out for Delivery");
            Console.WriteLine("Delivered");
            Console.WriteLine("RTO");

            Console.Write("Status: ");
            shipment.Status = Console.ReadLine();

            string result = service.BookShipment(shipment);

            Console.WriteLine(result);
        }

        static void ListShipments(ShipmentService service)
        {
            var shipments = service.ListShipments();

            if (shipments.Count == 0)
            {
                Console.WriteLine("No shipments found.");
                return;
            }

            foreach (Shipment s in shipments)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine($"Shipment ID : {s.ShipmentId}");
                Console.WriteLine($"AWB Number  : {s.AWBNumber}");
                Console.WriteLine($"Sender      : {s.SenderName}");
                Console.WriteLine($"Receiver    : {s.ReceiverName}");
                Console.WriteLine($"Origin      : {s.Origin}");
                Console.WriteLine($"Destination : {s.Destination}");
                Console.WriteLine($"Weight      : {s.WeightKg} Kg");
                Console.WriteLine($"Status      : {s.Status}");
                Console.WriteLine($"Booked At   : {s.BookedAt}");
            }
        }

        static void UpdateStatus(ShipmentService service)
        {
            Console.Write("Enter AWB Number: ");
            string awb = Console.ReadLine();

            Console.WriteLine("\nValid Status:");
            Console.WriteLine("Booked");
            Console.WriteLine("In Transit");
            Console.WriteLine("Out for Delivery");
            Console.WriteLine("Delivered");
            Console.WriteLine("RTO");

            Console.Write("Enter New Status: ");
            string status = Console.ReadLine();

            string result = service.UpdateStatus(awb, status);

            Console.WriteLine(result);
        }

        static void CancelShipment(ShipmentService service)
        {
            Console.Write("Enter AWB Number: ");
            string awb = Console.ReadLine();

            string result = service.CancelShipment(awb);

            Console.WriteLine(result);
        }
    }
}
