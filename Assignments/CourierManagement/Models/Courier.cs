using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierDBConnectivity.Models
{
    internal class Courier
    {
        public int CourierID { get; set; }
        public string SenderName { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }
        public decimal CourierWeight { get; set; }
        public string CourierStatus { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime DeliverDate { get; set; }
        public Courier() { }
        public Courier(int courierID, string senderName, string senderAddress, string receiverName, string receiverAddress,
                       decimal courierWeight, string courierStatus, string trackingNumber, DateTime deliverDate)
        {
            CourierID = courierID;
            SenderName = senderName;
            SenderAddress = senderAddress;
            ReceiverName = receiverName;
            ReceiverAddress = receiverAddress;
            CourierWeight = courierWeight;
            CourierStatus = courierStatus;
            TrackingNumber = trackingNumber;
            DeliverDate = deliverDate;
        }
        public override string ToString()
        {
            return $"CourierID: {CourierID}, Sender: {SenderName}, Receiver: {ReceiverName}, Status: {CourierStatus}, Tracking: {TrackingNumber}, Delivery: {DeliverDate.ToShortDateString()}";
        }
    }
}
