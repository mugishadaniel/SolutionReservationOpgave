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

                }
            }

        }
    }
}
