using SolutionReservation.API.DTO.Input;

namespace SolutionReservation.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world!");
            ReservationServiceClient client = new ReservationServiceClient();


            while (true)
            {
                Console.WriteLine("1. Get a user");
                Console.WriteLine("2. Add a user");

                int choise = int.Parse(Console.ReadLine());

                if (choise == 1)
                {
                    Console.WriteLine("Enter the client number of the user you want to get");
                    int clientNumber = int.Parse(Console.ReadLine());
                    var user = client.GetUserAsync(clientNumber.ToString()).Result;
                    Console.WriteLine(user.ToString());
                }
                else if (choise == 2)
                {
                    UserInputDTO user = new UserInputDTO(); 
                    Console.WriteLine("Enter the name of the user");
                    user.Name = Console.ReadLine();
                    Console.WriteLine("Enter the email of the user");
                    user.Email = Console.ReadLine();
                    Console.WriteLine("Enter the phone number of the user");
                    user.Phone = Console.ReadLine();
                    Console.WriteLine("Enter the postal code of the user");
                    user.PostalCode = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the municipality of the user");
                    user.Municipality = Console.ReadLine();
                    Console.WriteLine("Enter the street of the user");
                    user.Street = Console.ReadLine();
                    Console.WriteLine("Enter the house number of the user");
                    user.HouseNumber = Console.ReadLine();
                    var result = client.AddUserAsync(user).Result;
                    Console.WriteLine(result.ToString());
                }
            }

        }
    }
}
