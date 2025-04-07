using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICourierUserService userService = new CourierUserService();
            ICourierAdminService adminService = new CourierAdminService();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n====== Courier Management System ======");
                Console.WriteLine("1. Place Courier Order");
                Console.WriteLine("2. Track Courier Status");
                Console.WriteLine("3. Cancel Courier Order");
                Console.WriteLine("4. View Assigned Orders by Staff ID");
                Console.WriteLine("5. Add Courier Staff");
                Console.WriteLine("6. Get Courier Staff by ID");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an option (1-7): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Courier courier = new Courier();
                        Console.Write("Enter Sender Name: ");
                        courier.SenderName = Console.ReadLine();
                        Console.Write("Enter Sender Address: ");
                        courier.SenderAddress = Console.ReadLine();
                        Console.Write("Enter Receiver Name: ");
                        courier.ReceiverName = Console.ReadLine();
                        Console.Write("Enter Receiver Address: ");
                        courier.ReceiverAddress = Console.ReadLine();
                        Console.Write("Enter Weight (kg): ");
                        courier.Weight = double.Parse(Console.ReadLine());
                        courier.Status = "Placed";
                        courier.DeliveryDate = DateTime.Now.AddDays(3);
                        Console.Write("Enter Courier Staff ID to assign: ");
                        courier.UserID = int.Parse(Console.ReadLine());

                        string trackingNum = userService.PlaceOrder(courier);
                        Console.WriteLine($"Courier placed successfully! Tracking Number: {trackingNum}");
                        break;

                    case "2":
                        Console.Write("Enter Tracking Number: ");
                        string trackNum = Console.ReadLine();
                        try
                        {
                            string status = userService.GetOrderStatus(trackNum);
                            Console.WriteLine($"Status: {status}");
                        }
                        catch (TrackingNumberNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "3":
                        Console.Write("Enter Tracking Number to cancel: ");
                        string cancelTrack = Console.ReadLine();
                        try
                        {
                            if (userService.CancelOrder(cancelTrack))
                                Console.WriteLine("Order cancelled successfully.");
                        }
                        catch (TrackingNumberNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "4":
                        Console.Write("Enter Courier Staff ID: ");
                        long staffId = long.Parse(Console.ReadLine());
                        List<Courier> assignedOrders = userService.GetAssignedOrder(staffId);
                        if (assignedOrders.Count == 0)
                            Console.WriteLine("No orders assigned to this staff.");
                        else
                        {
                            Console.WriteLine("Assigned Orders:");
                            foreach (var c in assignedOrders)
                                Console.WriteLine(c);
                        }
                        break;

                    case "5":
                        Employee emp = new Employee();
                        Console.Write("Enter Employee Name: ");
                        emp.EmployeeName = Console.ReadLine();
                        Console.Write("Enter Email: ");
                        emp.Email = Console.ReadLine();
                        Console.Write("Enter Contact Number: ");
                        emp.ContactNumber = Console.ReadLine();
                        Console.Write("Enter Role: ");
                        emp.Role = Console.ReadLine();
                        Console.Write("Enter Salary: ");
                        emp.Salary = double.Parse(Console.ReadLine());

                        int newEmpId = adminService.AddCourierStaff(emp);
                        Console.WriteLine($"Employee added with ID: {newEmpId}");
                        break;

                    case "6":
                        Console.Write("Enter Employee ID to fetch: ");
                        long empId = long.Parse(Console.ReadLine());
                        try
                        {
                            Employee found = ((CourierAdminService)adminService).GetEmployeeById(empId);
                            Console.WriteLine(found);
                        }
                        catch (InvalidEmployeeIdException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "7":
                        exit = true;
                        Console.WriteLine("Exit");
                        break;

                    default:
                        Console.WriteLine("Invalid option!");
                        break;
                }
            }
        }
    }
}


