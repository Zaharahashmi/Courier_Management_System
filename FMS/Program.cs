using FinanaceManagementSystem.main;
namespace FinanaceManagementSystem;
internal class Program
{
    static void Main(string[] args)
    {
        FinanceApp app = new FinanceApp();
        app.Menu();
    }
}