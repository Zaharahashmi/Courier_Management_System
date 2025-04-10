using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CourierDBConnectivity.ConnectionUtil
{
    internal class DBConnection
    {
        static readonly string connectionString = @"Server = DESKTOP-DOOT0V1\SQLEXPRESS ; Database = Courier_Management_System ; Integrated Security =True ; MultipleActiveResultSets=true;";
        public static SqlConnection GetConnection()
        {
            SqlConnection connectionObject = new SqlConnection(connectionString);
            try
            {
                connectionObject.Open();
                return connectionObject;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error opening the Connection:{e.Message}");
                return null;
            }

        }
        public static void CloseDbConnection(SqlConnection connectionObject)
        {
            if (connectionObject != null)
            {
                try
                {
                    if (connectionObject.State != ConnectionState.Open)
                    {
                        connectionObject.Close();
                        connectionObject.Dispose();
                        Console.WriteLine("Connection Closed");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Connection is already null");
                }
            }
        }
    }
}
