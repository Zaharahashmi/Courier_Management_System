using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem
{
    internal class CourierUserService : ICourierUserService
    {
        private static List<Courier> courierList = new List<Courier>();

        public string GetOrderStatus(string trackingNumber)
        {
            foreach (Courier courier in courierList)
            {
                if (courier.TrackingNumber == trackingNumber)
                {
                    return courier.Status;
                }
            }
            throw new TrackingNumberNotFoundException($"Tracking number '{trackingNumber}' not found.");
        }

        public bool CancelOrder(string trackingNumber)
        {
            foreach (Courier courier in courierList)
            {
                if (courier.TrackingNumber == trackingNumber)
                {
                    courier.Status = "Cancelled";
                    return true;
                }
            }
            throw new TrackingNumberNotFoundException($"Cannot cancel. Tracking number '{trackingNumber}' does not exist.");
        }

        public string PlaceOrder(Courier courierObj)
        {
            courierList.Add(courierObj);
            return courierObj.TrackingNumber;
        }

        public List<Courier> GetAssignedOrder(int courierStaffId)
        {
            List<Courier> assignedOrders = new List<Courier>();
            foreach (Courier courier in courierList)
            {
                if (courier.UserID == courierStaffId)
                {
                    assignedOrders.Add(courier);
                }
            }
            return assignedOrders;
        }
    }
}
