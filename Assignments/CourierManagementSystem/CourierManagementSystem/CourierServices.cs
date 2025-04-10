using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem
{
    internal class CourierServices
    {
        public long ServiceID { get; set; }
        public string ServiceName { get; set; }
        public double Cost { get; set; }
        public CourierServices() { }
        public CourierServices(int serviceID, string serviceName, double cost)
        {
            ServiceID = serviceID;
            ServiceName = serviceName;
            Cost = cost;
        }
        public override string ToString() => $"ServiceID: {ServiceID}, Name: {ServiceName}, Cost: {Cost}";
    }
}
