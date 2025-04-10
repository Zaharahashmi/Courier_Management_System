using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem
{
    internal class CourierUserServiceImpl : ICourierUserService
    {
        protected CourierCompany companyObj = new CourierCompany();

        public string PlaceOrder(Courier courierObj)
        {
            companyObj.Couriers[companyObj.courierIndex++] = courierObj;
            return courierObj.TrackingNumber;
        }

        public string GetOrderStatus(string trackingNumber)
        {
            for (int i = 0; i < companyObj.courierIndex; i++)
            {
                if (companyObj.Couriers[i].TrackingNumber == trackingNumber)
                    return companyObj.Couriers[i].Status;
            }
            throw new TrackingNumberNotFoundException("Tracking number not found.");
        }

        public bool CancelOrder(string trackingNumber)
        {
            for (int i = 0; i < companyObj.courierIndex; i++)
            {
                if (companyObj.Couriers[i].TrackingNumber == trackingNumber)
                {
                    companyObj.Couriers[i].Status = "Cancelled";
                    return true;
                }
            }
            throw new TrackingNumberNotFoundException("Tracking number not found.");
        }

        public List<Courier> GetAssignedOrder(int courierStaffId)
        {
            List<Courier> result = new List<Courier>();
            for (int i = 0; i < companyObj.courierIndex; i++)
            {
                if (companyObj.Couriers[i].UserID == courierStaffId)
                    result.Add(companyObj.Couriers[i]);
            }
            return result;
        }
    }
}
