using DAL.Entities;
using DAL.Services;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserService service = new UserService();
            foreach (User u in service.Get())
            {
                Console.WriteLine($"{u.User_Id} : {u.First_Name} {u.Last_Name} - {u.Email} : {u.Password}");
            }
        }
    }
}
