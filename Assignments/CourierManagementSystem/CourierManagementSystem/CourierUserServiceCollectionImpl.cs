using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem
{
    internal class CourierUserServiceCollectionImpl : ICourierUserService
    {
        protected CourierCompanyCollection companyObj;
        public CourierUserServiceCollectionImpl(CourierCompanyCollection companyObj)
        {
            this.companyObj = companyObj;
        }

        public string PlaceOrder(Courier courierObj)
        {
            companyObj.Couriers.Add(courierObj);
            return courierObj.TrackingNumber;
        }

        public string GetOrderStatus(string trackingNumber)
        {
            foreach (var courier in companyObj.Couriers)
            {
                if (courier.TrackingNumber == trackingNumber)
                    return courier.Status;
            }
            throw new TrackingNumberNotFoundException("Tracking number not found.");
        }

        public bool CancelOrder(string trackingNumber)
        {
            foreach (var courier in companyObj.Couriers)
            {
                if (courier.TrackingNumber == trackingNumber)
                {
                    courier.Status = "Cancelled";
                    return true;
                }
            }
            throw new TrackingNumberNotFoundException("Tracking number not found.");
        }

        public List<Courier> GetAssignedOrder(int courierStaffId)
        {
            return companyObj.Couriers.FindAll(c => c.UserID == courierStaffId);
        }
    }
}
