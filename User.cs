using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp3;


namespace ConsoleApp3
{
    internal class Deliverer:User
    {
        public string? licencePlate;
        public Deliverer() { }
        
        public override void RegisterAsUser()
        {
            base.RegisterAsUser();
            licencePlate = GetLicencePlate();
            
        }
        /// <summary>
        /// Prompts deliverers to enter in licence plate and checks if it is valid
        /// </summary>
        /// <returns>returns valid licence plate</returns>
        public string GetLicencePlate()
        {
            bool keepGoing = true;
            do
            {
                Console.WriteLine(Menu.licencePrompt);
                response = Console.ReadLine();
                if (response.Length > 0 && response.Length <= 8)
                {
                    keepGoing = false;
                    if (response.Any(char.IsLower))
                    {
                        Console.WriteLine("Invalid licence plate.");
                        keepGoing = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid licence plate.");
                    keepGoing = true;
                }
            } while (keepGoing);
            return response;
        }
    }
    internal class Client : User
    {
        public string? restaurantName;
        public string? restaurantStyle;
      
        public Client()
        {
        }
        /// <summary>
        /// Prompts client to enter restaurant name and checks if it is valid
        /// </summary>
        /// <returns>returns valid restaurant name</returns>
        public string GetRestaurantName()
        {
            bool keepGoing = true;
            do
            {
                response = Menu.Display(Menu.restaurantNamePrompt);
                if (response.Length == 0)
                {
                    Console.WriteLine("Invalid restaurant name.");
                    keepGoing = true;
                }
                else
                {
                    keepGoing = false;
                    Restaurant.restaurantNames.Add(response);
                }
            } while (keepGoing);
            return response;
        }
        /// <summary>
        /// Prompts client to enter restaurant style 
        /// </summary>
        /// <returns>returns restaurant style: string</returns>
        public string GetRestaurantStyle()
        {
            response = Menu.Display(Menu.restaurantStylePrompt);
            switch (response)
            {
                case "1":
                    response = "Italian";
                    break;
                case "2":
                    response = "French";
                    break;
                case "3":
                    response = "Chinese";
                    break;
                case "4":
                    response = "Japanese";
                    break;
                case "5":
                    response = "American";
                    break;
                case "6":
                    response = "Australian";
                    break;
            }
            return response;
        }
        public override void RegisterAsUser()
        {
            name = GetName();
            //age = GetAge();
            //email = GetEmail();
            //mobileNumber = GetMobileNumber();
            password = GetPassword();
            restaurantName = GetRestaurantName();
            //restaurantStyle = GetRestaurantStyle();
            //location = GetLocation();
        }

    }
    internal class User // Customer
    {
        public static List<User> users = new List<User>();
        public string name;
        public int age;
        public string email;
        public string mobileNumber;
        public string password;
        public string response;
        int[] location;

        // Variables used only in this context
        static string userInfo;
        

        public User()
        {
            RegisterAsUser();
            users.Add(this);
        }
        /// <summary>
        /// Prompts user to enter his/her name and checks if it is valid
        /// </summary>
        /// <returns> string name</returns>
        public string GetName()
        {
            bool keepGoing = false;
            do
            {
                response = Menu.Display(Menu.namePrompt);
                if (response.Length == 0 || response.Contains("0") || response.Contains("1") || response.Contains("2") || response.Contains("3") ||
                    response.Contains("4") || response.Contains("5") || response.Contains("6") || response.Contains("7") || response.Contains("8") ||
                    response.Contains("9"))
                {
                    keepGoing = true;
                    Console.WriteLine("Invalid name.");
                }
                else
                {
                    keepGoing = false;
                }
            } while (keepGoing);
            return response;
        }
        /// <summary>
        /// Prompts user to enter his/her age and checks if it is valid
        /// </summary>
        /// <returns>integer value: age</returns>
        public int GetAge()
        {
            int number = 0;
            bool keepGoing = false;
            do
            {
                response = Menu.Display(Menu.agePrompt);
                number = int.Parse(response);
                if (number < 18 || number > 100)
                {
                    Console.WriteLine("Invalid age.");
                    keepGoing = true;
                }
                else
                {
                    keepGoing = false;
                }
            } while (keepGoing);
            return number;
        }
        /// <summary>
        /// Prompts user to enter email address and checks if it is valid
        /// </summary>
        /// <returns>string: email address</returns>
        public string GetEmail()
        {
            bool keepGoing = true;
            do
            {
                response = Menu.Display(Menu.emailPrompt);
                if (response.Length >= 3 && response.Contains("@") && response.IndexOf("@") != 0 && response.IndexOf("@") != (response.Length - 1))
                {
                    keepGoing = false;
                    foreach (User user in users)
                    {
                        if (user.email == response)
                        {
                            Console.WriteLine("This email address is already in use.");
                            keepGoing = true;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid email address.");
                    keepGoing = true;
                }
            } while (keepGoing);
            return response;
        }
        /// <summary>
        /// Prompts user to enter in a mobile number and checks if it is valid
        /// </summary>
        /// <returns>string: mobile number</returns>


        public string GetMobileNumber()
        {
            bool keepGoing = true;
            do
            {
                response = Menu.Display(Menu.mobileNumberPrompt);
                if (response.Length != 10 || response[0] != '0')
                {
                    keepGoing = true;
                    foreach (char c in response)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            if (c == char.Parse($"{i}"))
                            {
                                keepGoing = true;
                            }
                        }
                    }
                    Console.WriteLine("Invalid phone number.");
                }
                else
                {
                    keepGoing = false;
                }




            } while (keepGoing);
            return response;
        }
        /// <summary>
        /// Prompts user to create a new password and confirm. it checks if password is valid
        /// </summary>
        /// <returns></returns>
        public string GetPassword()
        {
            string response2;
            bool keepGoing = true;
            do
            {
                response = Menu.Display(Menu.passwordPrompt);
                if (response.Length >= 8 && response.Any(char.IsUpper) && response.Any(char.IsLower) && response.Any(char.IsDigit))
                {
                    keepGoing = false;
                    response2 = Menu.Display(Menu.passwordConfirmationPrompt);
                    if (response2 != response)
                    {
                        Console.WriteLine("Passwords do not match.");
                        keepGoing = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid password.");
                    keepGoing = true;
                }




            } while (keepGoing);
            return response;
        }
        /// <summary>
        /// Prompts user to enter location
        /// </summary>
        /// <returns>returns an array of integers</returns>
        public int[] GetLocation()
        {
            bool keepGoing = true;
            int[] intCoord = new int[2];
            do
            {
                response = Menu.Display(Menu.locationPrompt);
                if (response.Length != 3 || response[1] != ',')
                {
                    Console.WriteLine("Invalid location.");
                    keepGoing = true;
                }
                else
                {
                    string[] stringCoord = response.Split(',');
                    intCoord = [int.Parse(stringCoord[0]), int.Parse(stringCoord[1])];
                    keepGoing = false;
                }
            } while (keepGoing);
            return intCoord;
        }
        /// <summary>
        /// Register a new user
        /// </summary>
        public virtual void RegisterAsUser()
        {
            name = GetName();
            age = GetAge();
            email = GetEmail();
            mobileNumber = GetMobileNumber();
            password = GetPassword();
            location = GetLocation();
        }

        /// <summary>
        /// Authentication of the user
        /// </summary>
        public static bool AuthenticateUser()
        {
            bool validUser = false;
            Console.WriteLine("Email:");
            string email = Console.ReadLine();

            Console.WriteLine("Password:");
            string password = Console.ReadLine();


            foreach (User user in users)
            {
                if (user.email == email && user.password == password)
                {
                    //thisname = user.name;
                    //currentUser.age = user.age;
                    //currentUser.email = user.email;
                    //currentUser.mobileNumber = user.mobileNumber;
                    //currentUser.password = user.password;
                    string name = user.name;
                    Console.WriteLine("Welcome back, {0}!", name);
                    validUser = true;
                    userInfo = $"Name: {user.name}\nAge: {user.age}\nEmail: {user.email}\nMobile: {user.mobileNumber}\n" +
                        $"Location: {user.location[0]},{user.location[1]}\n"
                        + "You've made 0 order(s) and spent a total of $0.00 here.";



                }
                else
                {
                    Console.WriteLine("Invalid email or password.");
                }
            }
            return validUser;
        }
        public static void Login()
        {
            string response;
            do
            {
                response = Menu.Display(Menu.promptAfterLogin);
                switch (response)
                {
                    case "1":// user info
                        DisplayUserInfo();
                        break;
                    case "2":// restaurants
                        Console.WriteLine();
                        break;
                    case "3":// Orders
                        Console.WriteLine();
                        break;
                    case "4":// Rating the restaurants
                        Console.WriteLine();
                        break;
                }
            } while (response != "5");
            Console.WriteLine("You are now logged out.");
        }
        public static void DisplayUserInfo()
        {
            Console.WriteLine(userInfo);

        }
    }
}


