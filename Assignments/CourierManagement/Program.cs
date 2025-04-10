using System.ComponentModel.DataAnnotations;
using CourierDBConnectivity.dao;
using CourierDBConnectivity.Models;
namespace CourierDBConnectivity;
internal class Program
{
    static void Main(string[] args)
    {
        UserInterface ui = new UserInterface();
        ui.Menu();
        //CourierServiceDb serviceDb = new CourierServiceDb();
        //try
        //{
        //    List<Courier> courierList = serviceDb.GetCouriers();
        //    Display(courierList);
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //}
    }
    //static void Display(List<Courier> courierList)
    //{
    //    foreach (Courier courier in courierList)
    //    {
    //        Console.WriteLine(courier);
    //    }
    //}
}