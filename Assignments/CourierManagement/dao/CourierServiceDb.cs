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
        public void InsertCouriers(int courierId, string senderName, string senderAddress, string receiverName, string receiverAddress, decimal weight, string status, string trackingNum, DateTime deliverdate)
        {
            string query = "insert into courier values (@courierid, @senderName, @senderAddress, @receivername, @receiverAddress, @courier_weight, @courier_status, @trackingNumber, @deliverdate)";
            using (SqlConnection connection = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@courierid", courierId);
                cmd.Parameters.AddWithValue("@senderName", senderName);
                cmd.Parameters.AddWithValue("@senderAddress", senderAddress);
                cmd.Parameters.AddWithValue("@receivername", receiverName);
                cmd.Parameters.AddWithValue("@receiverAddress", receiverAddress);
                cmd.Parameters.AddWithValue("@courier_weight", weight);
                cmd.Parameters.AddWithValue("@courier_status", status);
                cmd.Parameters.AddWithValue("@trackingNumber", trackingNum);
                cmd.Parameters.AddWithValue("@deliverdate", deliverdate);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                cmd.ExecuteNonQuery();
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            Console.WriteLine("Courier inserted successfully.");
        }

        public void UpdateCourierStatus(string trackingNumber, string newStatus)
        {
            string query = "update Courier set Courier_Status = @Courier_status WHERE TrackingNumber = @trackingNumber";
            using (SqlConnection connection = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Courier_status", newStatus);
                cmd.Parameters.AddWithValue("@TrackingNumber", trackingNumber);

                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                cmd.ExecuteNonQuery();
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            Console.WriteLine("Courier updated successfully.");
        }

        public void GetCourierHistory(string trackingNumber)
        {
            string query = "select * from Courier WHERE TrackingNumber = @trackingNumber";
            using (SqlConnection connection = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@trackingNumber", trackingNumber);

                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"Sender: {reader["SenderName"]}, Receiver: {reader["ReceiverName"]}, Status: {reader["Courier_Status"]}, Delivered: {reader["Deliverdate"]}");
                    }
                }
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        public void ShipmentStatusReport()
        {
            string query = "select Courier_Status, COUNT(*) AS Total from Courier GROUP BY Courier_Status";
            using (SqlConnection connection = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("Status: Count");
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["Courier_Status"]}: {reader["Total"]}");
                    }
                }
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public void GenerateRevenueReport()
        {
            string query = "select sum(Amount) as TotalRevenue from Payment";
            using (SqlConnection connection = DBConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                object result = cmd.ExecuteScalar();
                Console.WriteLine($"Total Revenue Collected: ₹{result}");
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        //public List<Courier> GetCouriers()
        //{
        //    List<Courier> couriers = new List<Courier>();
        //    Courier courier = null;
        //    string query = "select * from courier";
        //    try
        //    {
        //        SqlCommand command = new SqlCommand(query, connection);
        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            courier = new Courier();
        //            courier.CourierID = reader.GetInt32(0);
        //            courier.SenderName = reader.GetString(1);
        //            courier.SenderAddress = reader.GetString(2);
        //            courier.ReceiverName = reader.GetString(3);
        //            courier.ReceiverAddress = reader.GetString(4);
        //            courier.CourierWeight = reader.GetDecimal(5);
        //            courier.CourierStatus = reader.GetString(6);
        //            courier.TrackingNumber = reader.GetString(7);
        //            courier.DeliverDate = reader.GetDateTime(8);
        //            couriers.Add(courier);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //    return couriers;
        //}

    }
}
