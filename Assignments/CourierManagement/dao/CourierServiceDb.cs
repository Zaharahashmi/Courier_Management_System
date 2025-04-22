using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CourierDBConnectivity.ConnectionUtil;
using CourierDBConnectivity.Models;

namespace CourierDBConnectivity.dao
{
    internal class CourierServiceDb
    {
        public void InsertCouriers(object courierIdObj, object senderName, object senderAddress, object receiverName, object receiverAddress, object weightObj, object status, object trackingNum, object deliverdateObj)
        {
            try
            {
                if (!int.TryParse(courierIdObj.ToString(), out int courierId))
                {
                    Console.WriteLine("Error: Invalid Courier ID. It must be an integer.");
                    return;
                }
                if (!decimal.TryParse(weightObj.ToString(), out decimal weight))
                {
                    Console.WriteLine("Error: Invalid weight. It must be a decimal number.");
                    return;
                }
                if (!DateTime.TryParse(deliverdateObj.ToString(), out DateTime deliverdate))
                {
                    Console.WriteLine("Error: Invalid date. Please enter a valid date format.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(senderName?.ToString()) || string.IsNullOrWhiteSpace(senderAddress?.ToString())
                    || string.IsNullOrWhiteSpace(receiverName?.ToString()) || string.IsNullOrWhiteSpace(receiverAddress?.ToString())
                    || string.IsNullOrWhiteSpace(status?.ToString()) || string.IsNullOrWhiteSpace(trackingNum?.ToString()))
                {
                    Console.WriteLine("Error: One or more required string fields are empty or invalid.");
                    return;
                }

                string query = "INSERT INTO courier VALUES (@courierid, @senderName, @senderAddress, @receivername, @receiverAddress, @courier_weight, @courier_status, @trackingNumber, @deliverdate)";

                using (SqlConnection connection = DBConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@courierid", courierId);
                    cmd.Parameters.AddWithValue("@senderName", senderName.ToString());
                    cmd.Parameters.AddWithValue("@senderAddress", senderAddress.ToString());
                    cmd.Parameters.AddWithValue("@receivername", receiverName.ToString());
                    cmd.Parameters.AddWithValue("@receiverAddress", receiverAddress.ToString());
                    cmd.Parameters.AddWithValue("@courier_weight", weight);
                    cmd.Parameters.AddWithValue("@courier_status", status.ToString());
                    cmd.Parameters.AddWithValue("@trackingNumber", trackingNum.ToString());
                    cmd.Parameters.AddWithValue("@deliverdate", deliverdate);

                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Courier inserted successfully.");
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("PRIMARY KEY") || ex.Message.Contains("UNIQUE KEY"))
                {
                    Console.WriteLine("Error: Duplicate courier ID. This ID already exists.");
                }
                else
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
            }
        }

        public void UpdateCourierStatus(string trackingNumber, string newStatus)
        {
            if (string.IsNullOrWhiteSpace(trackingNumber) || string.IsNullOrWhiteSpace(newStatus))
            {
                Console.WriteLine("Tracking number and status cannot be empty.");
                return;
            }

            if (!trackingNumber.StartsWith("TRK", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Invalid tracking number format. It should start with 'TRK'.");
                return;
            }

            if (!CheckIfTrackingNumberExists(trackingNumber))
            {
                Console.WriteLine("No courier found with the given tracking number.");
                return;
            }

            string query = "UPDATE Courier SET Courier_Status = @Courier_status WHERE TrackingNumber = @trackingNumber";

            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Courier_status", newStatus);
                    cmd.Parameters.AddWithValue("@trackingNumber", trackingNumber);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        Console.WriteLine("No courier found with the given tracking number.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating courier status: {ex.Message}");
            }
        }

        public bool CheckIfTrackingNumberExists(string trackingNumber)
        {
            string query = "SELECT COUNT(1) FROM Courier WHERE TrackingNumber = @trackingNumber";

            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@trackingNumber", trackingNumber);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking tracking number: {ex.Message}");
                return false;
            }
        }





        public void GetCourierHistory(string trackingNumber)
        {
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

            string query = "SELECT * FROM Courier WHERE TrackingNumber = @trackingNumber";

            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@trackingNumber", trackingNumber);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        bool hasRows = false;

                        while (reader.Read())
                        {
                            hasRows = true;
                            Console.WriteLine("---------- Courier History ----------");
                            Console.WriteLine($"Tracking Number : {trackingNumber}");
                            Console.WriteLine($"Sender Name     : {reader["SenderName"]}");
                            Console.WriteLine($"Receiver Name   : {reader["ReceiverName"]}");
                            Console.WriteLine($"Courier Status  : {reader["Courier_Status"]}");
                            Console.WriteLine($"Delivery Date   : {reader["Deliverdate"]}");
                            Console.WriteLine("--------------------------------------\n");
                        }

                        if (!hasRows)
                        {
                            Console.WriteLine("No courier history found for the given tracking number.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching courier history: {ex.Message}");
            }
        }

        public void ShipmentStatusReport()
        {
            string query = "SELECT Courier_Status, COUNT(*) AS Total FROM Courier GROUP BY Courier_Status";

            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Shipment Status Report:");
                        Console.WriteLine("-----------------------");
                        Console.WriteLine("Status\t\tCount");

                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Courier_Status"],-16}{reader["Total"]}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating shipment status report: {ex.Message}");
            }
        }

        public void GenerateRevenueReport()
        {
            string query = "SELECT SUM(Amount) AS TotalRevenue FROM Payment";

            try
            {
                using (SqlConnection connection = DBConnection.GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                        Console.WriteLine($"Total Revenue Collected: ₹{result}");
                    else
                        Console.WriteLine("No payments found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating revenue report: {ex.Message}");
            }
        }
    }
}
