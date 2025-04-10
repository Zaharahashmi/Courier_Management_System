using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierDBConnectivity.dao
{
    internal class UserInterface
    {
        private CourierServiceDb service;

        public UserInterface()
        {
            service = new CourierServiceDb();
        }
        public void Menu()
        {
            while (true)
            {
                Console.WriteLine("\nCourier Management System");
                Console.WriteLine("--------------------------");
                Console.WriteLine("1. Insert New Courier");
                Console.WriteLine("2. Update Courier Status");
                Console.WriteLine("3. Get Courier Delivery History");
                Console.WriteLine("4. Generate Shipment Status Report");
                Console.WriteLine("5. Generate Revenue Report");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        InsertCourier();
                        break;
                    case "2":
                        UpdateCourierStatus();
                        break;
                    case "3":
                        GetCourierHistory();
                        break;
                    case "4":
                        service.ShipmentStatusReport();
                        break;
                    case "5":
                        service.GenerateRevenueReport();
                        break;
                    case "6":
                        Console.WriteLine("Exit");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        private void InsertCourier()
        {
            Console.Write("Enter Courier ID: ");
            int courierId = int.Parse(Console.ReadLine());
            Console.Write("Enter Sender Name: ");
            string senderName = Console.ReadLine();
            Console.Write("Enter Sender Address: ");
            string senderAddress = Console.ReadLine();
            Console.Write("Enter Receiver Name: ");
            string receiverName = Console.ReadLine();
            Console.Write("Enter Receiver Address: ");
            string receiverAddress = Console.ReadLine();
            Console.Write("Enter Courier Weight (kg): ");
            decimal weight = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Courier Status: ");
            string status = Console.ReadLine();
            Console.Write("Enter Tracking Number: ");
            string trackingNumber = Console.ReadLine();
            Console.Write("Enter Delivery Date: ");
            DateTime deliveryDate = DateTime.Parse(Console.ReadLine());
            service.InsertCouriers(courierId, senderName, senderAddress, receiverName, receiverAddress, weight, status, trackingNumber, deliveryDate);
        }

        private void UpdateCourierStatus()
        {
            Console.Write("Enter Tracking Number: ");
            string trackNum = Console.ReadLine();
            Console.Write("Enter New Status: ");
            string newStatus = Console.ReadLine();
            service.UpdateCourierStatus(trackNum, newStatus);
        }

        private void GetCourierHistory()
        {
            Console.Write("Enter Tracking Number: ");
            string tn = Console.ReadLine();
            service.GetCourierHistory(tn);
        }
    }

}

