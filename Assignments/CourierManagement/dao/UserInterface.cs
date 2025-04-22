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
                Console.WriteLine("3. Courier Delivery History");
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
            string inputCourierId = Console.ReadLine();
            if (!int.TryParse(inputCourierId, out int courierId))
            {
                Console.WriteLine("Invalid Courier ID. Please enter a valid number.");
                return;
            }

            Console.Write("Enter Sender Name: ");
            string senderName = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(senderName))
            {
                Console.WriteLine("Sender name cannot be empty.");
                return;
            }

            Console.Write("Enter Sender Address: ");
            string senderAddress = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(senderAddress))
            {
                Console.WriteLine("Sender address cannot be empty.");
                return;
            }

            Console.Write("Enter Receiver Name: ");
            string receiverName = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(receiverName))
            {
                Console.WriteLine("Receiver name cannot be empty.");
                return;
            }

            Console.Write("Enter Receiver Address: ");
            string receiverAddress = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(receiverAddress))
            {
                Console.WriteLine("Receiver address cannot be empty.");
                return;
            }

            Console.Write("Enter Courier Weight (kg): ");
            string inputWeight = Console.ReadLine();
            if (!decimal.TryParse(inputWeight, out decimal weight))
            {
                Console.WriteLine("Invalid weight. Please enter a valid decimal number.");
                return;
            }

            Console.Write("Enter Courier Status: ");
            string status = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(status))
            {
                Console.WriteLine("Courier status cannot be empty.");
                return;
            }

            Console.Write("Enter Tracking Number: ");
            string trackingNumber = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(trackingNumber))
            {
                Console.WriteLine("Tracking number cannot be empty.");
                return;
            }
            if (!trackingNumber.StartsWith("TRK", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Invalid tracking number format. It should start with 'TRK'.");
                return;
            }

            Console.Write("Enter Delivery Date (e.g., 2025-04-22): ");
            string inputDate = Console.ReadLine();
            if (!DateTime.TryParse(inputDate, out DateTime deliveryDate))
            {
                Console.WriteLine("Invalid delivery date. Please use the format yyyy-MM-dd.");
                return;
            }

            try
            {
                service.InsertCouriers(courierId, senderName, senderAddress, receiverName, receiverAddress, weight, status, trackingNumber, deliveryDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inserting the courier: {ex.Message}");
            }
        }

        private void UpdateCourierStatus()
        {
            Console.Write("Enter Tracking Number: ");
            string trackNum = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(trackNum))
            {
                Console.WriteLine("Tracking number cannot be empty.");
                return;
            }

            if (!trackNum.StartsWith("TRK", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Invalid tracking number format. It should start with 'TRK'.");
                return;
            }

            Console.Write("Enter New Status: ");
            string newStatus = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(newStatus))
            {
                Console.WriteLine("Status cannot be empty.");
                return;
            }

            try
            {
                if (!service.CheckIfTrackingNumberExists(trackNum))
                {
                    Console.WriteLine("No courier found with the given tracking number.");
                    return;
                }

                service.UpdateCourierStatus(trackNum, newStatus);
                Console.WriteLine("Courier status updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating courier status: {ex.Message}");
            }
        }
        private void GetCourierHistory()
        {
            Console.Write("Enter Tracking Number: ");
            string tn = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(tn))
            {
                Console.WriteLine("Tracking number cannot be empty.");
                return;
            }

            try
            {
                service.GetCourierHistory(tn);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving courier history: {ex.Message}");
            }
        }
    }
}
