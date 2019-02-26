using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bakery_Challenge
{
    public class Bakery_exe
    {
        private BakeryRepository _bakeryRepo = new BakeryRepository();

        public void Run()
        {
            CreateMenuList();

            StartMenu();
        }

        private void StartMenu()
        {
            ShowStartMenu();

            bool continueToRun = true;

            while (continueToRun)
            {
                int choice = GetAndParseMenuChoice();

                switch (choice)
                {
                    case 1:
                        PrintMenu();
                        break;
                    case 2:
                        AddItemToList();
                        break;
                    case 3:
                        RemoveItemFromList();
                        break;
                    case 4:
                        ShowStartMenu();
                        break;
                    case 5:
                        Console.Clear();
                        break;
                    case 6:
                        continueToRun = false;
                        break;
                    default:
                        ShowStartMenu();
                        break;
                }
            }
        }

        private void CreateMenuList()
        {
            BakeryMenu bakeryMenuOne = new BakeryMenu("Baguette", BakeType.Bread, "Joshua Tucker", 1, _bakeryRepo.CalculateCost(BakeType.Bread));
            BakeryMenu bakeryMenuTwo = new BakeryMenu("Chocolate", BakeType.Cake, "Lawrence Wagner", 1, _bakeryRepo.CalculateCost(BakeType.Cake));
            BakeryMenu bakeryMenuThree = new BakeryMenu("Croissant", BakeType.Pastry, "Tyler Shelton", 1, _bakeryRepo.CalculateCost(BakeType.Pastry));
            BakeryMenu bakeryMenuFour = new BakeryMenu("Apple", BakeType.Pies, "Alexc Mortiz", 1, _bakeryRepo.CalculateCost(BakeType.Pies));

            _bakeryRepo.AddItemToList(bakeryMenuOne);
            _bakeryRepo.AddItemToList(bakeryMenuTwo);
            _bakeryRepo.AddItemToList(bakeryMenuThree);
            _bakeryRepo.AddItemToList(bakeryMenuFour);
        }
        private void ShowStartMenu()
        {
            Console.WriteLine("What would you like to do? \n" +
               "1. Show all menu items. \n" +
               "2. Add a menu item. \n" +
               "3. Remove a menu item. \n" +
               "4. Show Console Menu \n" +
               "5. Clear Console. \n" +
               "6. Exit. \n");
        }
        private int GetAndParseMenuChoice()
        {
            Console.WriteLine("Please choose what you'd like to do from the menu. To open the Options Menu enter 4. Enter input as a number:");
            string choiceAsString = Console.ReadLine();
            int choice = Int32.Parse(choiceAsString);

            return choice;
        }
        private void PrintMenu()
        {
            var items = _bakeryRepo.GetBakeryMenus();
            foreach (BakeryMenu item in items)
            {
                Console.WriteLine(
                   "////////////////////////////////////////////////////\r\n" +
                   $"Product: {item.ProductName} \r\n" +
                   $"Type: {item.Kind} \r\n" +
                   $"Customer Name: {item.CustomerName} \r\n" +
                   $"Order Size: {item.OrderBatchSize} \r\n" +
                   $"Order Cost: {item.OrderCost} \r\n" +
                   "////////////////////////////////////////////////////");
            }
        }
        private void AddItemToList()
        {
            Console.WriteLine("Please follow the prompts to add a new menu item.");
            BakeryMenu bakeryMenu = new BakeryMenu();

            Console.WriteLine("Please enter the name.");
            bakeryMenu.ProductName = Console.ReadLine();

            Console.WriteLine("Please indicate the type.\n" +
               "1. Bread. \n" +
               "2. Cake. \n" +
               "3. Pastry. \n" +
               "4. Pies \n");
            string input = Console.ReadLine();

            int kind = ParseInput(input);

            BakeType type = BakeType.Bread;
            switch (kind)
            {
                case 1:
                    type = BakeType.Bread;
                    break;
                case 2:
                    type = BakeType.Cake;
                    break;
                case 3:
                    type = BakeType.Pastry;
                    break;
                case 4:
                    type = BakeType.Pies;
                    break;
                default:
                    Console.WriteLine("not a valid input");
                    break;
            }
            bakeryMenu.Kind = type;
            bakeryMenu.OrderCost = _bakeryRepo.CalculateCost(type);

            Console.WriteLine("Please enter the order name.");
            bakeryMenu.CustomerName = Console.ReadLine();

            Console.WriteLine("Please enter how many.");
            bakeryMenu.OrderBatchSize = Int32.Parse(Console.ReadLine());

            _bakeryRepo.AddItemToList(bakeryMenu);
            Console.WriteLine("Item was added to the menu successfully.");
        }
        private void RemoveItemFromList()
        {
            Console.WriteLine("What item would you like to remove? Please enter a meal name.");
            var ProductName = Console.ReadLine();
            var item = _bakeryRepo.FindItemFromMenu(ProductName);
            _bakeryRepo.RemoveItemFromList(item);
            Console.WriteLine("The item was removed from the menu.");
        }

        private int ParseInput(string number)
        {
            int intNumber = int.Parse(number);
            return intNumber;
        }
    }
}