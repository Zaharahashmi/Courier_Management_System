using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierDBConnectivity.Models
{
    internal class Payment
    {
        public int PaymentID { get; set; }
        public int CourierID { get; set; }
        public int LocationID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public Payment() { }
        public Payment(int paymentID, int courierID, int locationID, decimal amount, DateTime paymentDate)
        {
            PaymentID = paymentID;
            CourierID = courierID;
            LocationID = locationID;
            Amount = amount;
            PaymentDate = paymentDate;
        }
        public override string ToString()
        {
            return $"PaymentID: {PaymentID}, CourierID: {CourierID}, LocationID: {LocationID}, Amount: {Amount:C}, PaymentDate: {PaymentDate.ToShortDateString()}";
        }
    }
}
