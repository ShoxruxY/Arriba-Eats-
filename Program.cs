using ConsoleApp3;


namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Welcome 
            string selection;
            bool validUser;
            Console.WriteLine(Menu.welcome);
            // App 
            do
            {
                selection = Menu.Display(Menu.mainPrompt);
                // Login
                if (selection == "1") // Login
                {
                    validUser = User.AuthenticateUser();
                    if (validUser)
                    {
                        User.Login();
                    }
                } // Registration
                else if (selection == "2") // Register as a new user
                {
                    selection = Menu.Display(Menu.userPrompt);// user type
                    if (selection == "1")// Customer;
                    {
                        User user = new User();
                        Console.WriteLine(Menu.successfulRegistration, "customer", user.name);
                    }
                    else if (selection == "2") // Deliverer
                    {
                        Deliverer deliverer = new Deliverer();
                        Console.WriteLine(Menu.successfulRegistration, "deliverer", deliverer.name);
                    }
                    else if (selection == "3")// Client
                    {
                        Client client = new Client();
                        Console.WriteLine(Menu.successfulRegistration, "client", client.name);
                        selection = "1";
                    }
                }
            } while (selection != "3");
        }
    }
}

