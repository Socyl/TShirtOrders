using System;
using System.Collections.Generic;
//Byron Corbitt
//bcorbitt@cnm.edu
//Program.cs
//quiz 2 debugging exercise


//Program.cs
//Programmer: Rob Garner (rgarner7@cnm.edu)
//Date: 10 Mar 2020
//Purpose: Process a series of tshirt orders. 
namespace TShirtOrders
{
    class Program
    {
        private const string CompanyName = "Super Shirt Ordermatic 3000";
        private const string CompanySlogan = "The best shirt ordering system in the multiverse!";

        static void Main(string[] args)
        {
            Header();
            char option;
            List<TShirtOrder> orders = new List<TShirtOrder>();
            do
            {
                DisplayShirtOrders(orders);
                string userInput = GetStringFromUser("(A)dd shirt (R)emove shirt (T)otal (E)xit: ");
                option = userInput.Trim().ToUpper()[0];
                switch (option)
                {
                    case 'A':
                        AddShirtOrder(orders);
                        break;
                    case 'R':
                        RemoveShirtOrder(orders);
                        break;
                    case 'T':
                        DisplayTotal(orders);
                        break;
                }
            } while (option != 'E');
            Console.WriteLine("Thank you for using " + CompanyName);
        }

        private static void DisplayTotal(List<TShirtOrder> orders)
        {
            decimal total = 0;
            //BC orders contains TShirtOrder objects, not strings
            foreach (TShirtOrder order in orders)
            {
                total += order.Price;
            }
            Console.WriteLine("Total price of order is: " + total);
        }

        private static void RemoveShirtOrder(List<TShirtOrder> orders)
        {
            int index = GetIntFromUser("Enter index of shirt order to remove: ");
            if (GetBoolFromUser("Are you sure you want to delete this order"))
            {
                //BC index is an int.  Proper method for removing an item from a list by index is RemoveAt(int)
                //BC also, orders is a zero indexed list, whereas our list of printed orders starts with 1.
                //BC so changed index to index-1
                orders.RemoveAt(index-1);
            }
        }

        private static void AddShirtOrder(List<TShirtOrder> orders)
        {
            TShirtOrder order = new TShirtOrder();
            order.FirstName = GetStringFromUser("Please enter your first name: ");
            order.LastName = GetStringFromUser("Please enter your last name: ");
            order.IsLocalPickup = GetBoolFromUser("Local pickup");
            if (!order.IsLocalPickup)
            {
                order.Address = GetStringFromUser("Address: ");
            }
            //BC GetDoubleFromUser returns a double, order.PrintAreaInSqIn is a decimal...conversion required.  Added Convert. Fixed spelling error (are to area)
            //BC Alternatively, I could have changed the function GetDoubleFromUser to return a decimal, but would then also probably need to rename the function
            //BC to GetDecimalFromUser.  This method is less intrusive, and doesnt change the underlying code of the app.
            order.PrintAreaInSqIn = Convert.ToDecimal(GetDoubleFromUser("Please enter area of your design in square inches: "));
            order.NumColors = GetIntFromUser("Please enter number of colors: ");
            order.NumShirts = GetIntFromUser("Please enter the number of shirts: ");
            Console.WriteLine(order.ToString());
            orders.Add(order);
        }

        private static void DisplayShirtOrders(List<TShirtOrder> orders)
        {
            Console.WriteLine();
            Console.WriteLine("Current shirts orders:");
            //BC Count is property not method.   removed ()
            if (orders.Count > 0)
            {
                //BC Count is property not method.  removed ()
                for (int i = 0; i < orders.Count; ++i)
                {
                    Console.WriteLine((i + 1) + ": " + orders[i]);
                }
            }
            else
            {
                Console.WriteLine("No shirts in order.");
            }
            Console.WriteLine();
        }

        private static void Header()
        {
            Console.WriteLine("Welcome to " + CompanyName + "!");
            Console.WriteLine(CompanySlogan);
            Console.WriteLine();
        }

        private static bool GetBoolFromUser(string prompt)
        {
            Console.Write(prompt + " (y/n)? ");
            return Console.ReadLine().ToLower()[0] == 'y';
        }

        private static int GetIntFromUser(string prompt)
        {
            Console.Write(prompt);
            return int.Parse(Console.ReadLine());
        }

        private static double GetDoubleFromUser(string prompt)
        {
            Console.Write(prompt);
            //BC nitpicky, but this return should parse to a double to return a double vs parsing to an int
            //program seemed to automagically convert it, as I had earlier issue in troubleshooting where this function WAS returning
            //a double.  Logic still stands, 
            //if returning a double, parse it as a double and dont count on the program getting it right.
            return double.Parse(Console.ReadLine());
        }

        private static string GetStringFromUser(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
