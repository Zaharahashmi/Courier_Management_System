﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierManagementSystem
{
    internal class Courier
    {
        private static int trackingSeed = 1000;
        public int CourierID { get; set; }
        public string SenderName { get; set; }
        public string SenderAddress { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress { get; set; }
        public double Weight { get; set; }
        public string Status { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int UserID { get; set; }

        public Courier()
        {
            TrackingNumber = GenerateTrackingNumber();
        }
        public Courier(int courierID, string senderName, string senderAddress, string receiverName, string receiverAddress, double weight, string status, string trackingNumber, DateTime deliveryDate, int userId)
        {
            CourierID = courierID;
            SenderName = senderName;
            SenderAddress = senderAddress;
            ReceiverName = receiverName;
            ReceiverAddress = receiverAddress;
            Weight = weight;
            Status = status;
            TrackingNumber = trackingNumber;
            DeliveryDate = deliveryDate;
            UserID = userId;
        }
        private string GenerateTrackingNumber()
        {
            return $"TRK{trackingSeed++}";
        }
        public override string ToString() => $"CourierID: {CourierID}, Sender: {SenderName}, Receiver: {ReceiverName}, Status: {Status}, Tracking: {TrackingNumber}";
    }
}
