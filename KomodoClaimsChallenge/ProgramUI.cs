﻿using Komodo_Claims_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims_Console
{
    class ProgramUI
    {
        private ClaimsRepository _claimsInfo = new ClaimsRepository();

        public void Run()
        {
            MenuList();
            UserInterface();
        }

        private void UserInterface()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Make your selection:\n" +
                    "1. Enter a New Claim\n" +
                    "2. See all Claims\n" +
                    "3. Find Claim by ID\n" +
                    "4. Update a Claim\n" +
                    "5. Delete a Claim\n" +
                    "6. Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        EnterAClaim();
                        break;
                    case "2":
                        ViewAllMenuItems();
                        break;
                    case "3":
                        DisplayMealByNumber();
                        break;
                    case "4":
                        UpdateMenu();
                        break;
                    case "5":
                        DeleteAMenuItem();
                        break;
                    case "6":
                        Console.WriteLine("Have a Wonderful rest of your Day!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void EnterAClaim()
        {
            Console.Clear();
            Claims newContent = new Claims();

            Console.WriteLine("What ID number would you like to use for this claim?");
            newContent.ClaimID = Int32.Parse(Console.ReadLine());

            Console.WriteLine("What would you like to name this meal?");
            newContent.MealName = Console.ReadLine();

            Console.WriteLine("Give a brief description of this claim:");
            newContent.Description = Console.ReadLine();

            Console.WriteLine("What items are in this Meal?");
            newContent.MealItems = Console.ReadLine();

            Console.WriteLine("What is the price of this Meal?");
            newContent.Price = Double.Parse(Console.ReadLine());

            _claimsInfo.AddItemsToMenu(newContent);
        }

        private void ViewAllMenuItems()
        {
            Console.Clear();
            List<Claims> listOfItems = _claimsInfo.GetMenu();

            foreach (Claims content in listOfItems)
            {
                Console.WriteLine($"Meal Number: {content.MealNumber}\n" +
                    $"Meal Name: {content.MealName}\n" +
                    $"Description: {content.Description}\n" +
                    $"Meal Includes: {content.MealItems}\n" +
                    $"Price: {content.Price}\n");
            }
        }
        private void DisplayMealByNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter the Meal number:");
            int numberOfMeal = int.Parse(Console.ReadLine());
            Claims content = _claimsInfo.GetMealByNumber(numberOfMeal);

            if (content != null)
            {
                Console.WriteLine($"Meal Number: {content.MealNumber}\n" +
                    $"Meal Name: {content.MealName}\n" +
                    $"Description: {content.Description}\n" +
                    $"Meal Includes: {content.MealItems}\n" +
                    $"Price: {content.Price}\n");
            }
            else
            {
                Console.WriteLine("No menu item by that name.");
            }

        }
        private void UpdateMenu()
        {
            ViewAllMenuItems();
            Console.WriteLine("Enter the meal number you would like to update");
            int oldMealNumber = int.Parse(Console.ReadLine());
            Claims newContent = new Claims();
            Console.WriteLine("Re-Enter the Meal Number:");
            newContent.MealNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the new Meal Name:");
            newContent.MealName = Console.ReadLine();
            Console.WriteLine("Enter the Description:");
            newContent.Description = Console.ReadLine();
            Console.WriteLine("What items are included with this meal?");
            newContent.MealItems = Console.ReadLine();
            Console.WriteLine("What is the the price of this meal?");
            newContent.Price = Double.Parse(Console.ReadLine());

            bool wasUpdated = _claimsInfo.UpdateExistingMenu(oldMealNumber, newContent);
            if (wasUpdated)
            {
                Console.WriteLine("Menu updated successfully!");
            }
            else
            {
                Console.WriteLine("Could not update the menu.");
            }
        }
        private void DeleteAMenuItem()
        {
            ViewAllMenuItems();
            Console.WriteLine("\nEnter the Meal Number you would like to remove:");
            int input = int.Parse(Console.ReadLine());
            bool wasDeleted = _claimsInfo.RemoveItemsFromMenu(input);
            if (wasDeleted)
            {
                Console.WriteLine("The Meal Number was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The Meal Number was not deleted.");
            }
        }
        private void MenuList()
        {
            Claims one = new Claims(1, "Cheeseburger with Fries", "Cheeseburger with lettuce, tomato, onion, mayo and ketchup, served with fries", "Cheeseburger and Fries", 5.00, MenuNumber.CheeseburgerFries);
            Claims two = new Claims(2, "Hamburger with Fries", "Hamburger with lettuce, tomato, onion, mayo and ketchup, served with fries", "Hamburger and Fries", 4.50, MenuNumber.HamburgerFries);
            Claims three = new Claims(3, "Chicken with Fries", "Chicken Strips served with fries", "4 Chicken Strips and Fries", 5.50, MenuNumber.ChickenStripsFries);
            Claims four = new Claims(4, "Fish and Fries", "Fish sandwich with tartar sauce and served with fries", "Fish Sandwich and Fries", 7.00, MenuNumber.FishSandwichFries);

            _claimsInfo.AddItemsToMenu(one);
            _claimsInfo.AddItemsToMenu(two);
            _claimsInfo.AddItemsToMenu(three);
            _claimsInfo.AddItemsToMenu(four);
        }
    }
}
