
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
﻿
namespace ConsoleApp3
{
    internal class Menu
    {
        public static string welcome = "Welcome to Arriba Eats!";
        public static string mainPrompt = "Please make a choice from the menu below:" +
            "\n1: Login as a registered user" +
            "\n2: Register as a new user" +
            "\n3: Exit" +
            "\nPlease enter a choice between 1 and 3:" +
            "\nThank you for using Arriba Eats!";
        public static string userPrompt = "Which type of user would you like to register as?" +
                "\n1: Customer\n2: Deliverer" +
                "\n3: Client" +
                "\n4: Return to the previous menu";
        public static string namePrompt = "Please enter your name:";
        public static string agePrompt = "Please enter your age (18-100):";
        public static string emailPrompt = "Please enter your email address:";
        public static string mobileNumberPrompt = "Please enter your mobile phone number:";
        public static string passwordPrompt = "Your password must:" +
               "\n- be at least 8 characters long" +
               "\n- contain a number" +
               "\n- contain a lowercase letter" +
               "\n- contain an uppercase letter" +
               "\nPlease enter a password:";
        public static string passwordConfirmationPrompt = "Please confirm your password:";
        public static string locationPrompt = "Please enter your location (in the form of X,Y):";
        public static string successfulRegistration = "You have been successfully registered as a {0}, {1}!";
        public static string licencePrompt = "Please enter your licence plate:";
        public static string restaurantNamePrompt = "Please enter your restaurant's name:";
        public static string restaurantStylePrompt = "Please select your restaurant's style:" +
            "\n1: Italian" +
            "\n2: French" +
            "\n3: Chinese" +
            "\n4: Japanese" +
            "\n5: American" +
            "\n6: Australian" +
            "\nPlease enter a choice between 1 and 6:";
        public static string promptAfterLogin = "Please make a choice from the menu below:" +
            "\n1: Display your user information" +
            "\n2: Select a list of restaurants to order from" +
            "\n3: See the status of your orders" +
            "\n4: Rate a restaurant you've ordered from" +
            "\n5: Log out";
        public static string restaurantOrderPrompt = "How would you like the list of restaurants ordered?" +
            "\n1: Sorted alphabetically by name" +
            "\n2: Sorted by distance" +
            "\n3: Sorted by style" +
            "\n4: Sorted by average rating" +
            "\n5: Return to the previous menu" +
            "\nPlease enter a choice between 1 and 5:";

        public static string Display(string prompt)
        {
            Console.WriteLine(prompt);
            string response = Console.ReadLine();
            return response.Trim();
        }
    }
}