using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeChallenge
{
    public class ProgramUI
    {
        private BadgeRepository _badgeRepo = new BadgeRepository();
        public void Run()
        {
            StartMenu();
        }

        public void StartMenu()
        {
            ShowStartMenu();

            bool running = true;

            while (running)
            {
                int choice = GetAndParseMenuChoice();

                switch (choice)
                {
                    case 1:
                        SeeAllBadges();
                        break;
                    case 2:
                        AddABadge();
                        break;
                    case 3:
                        EditABadge();
                        break;
                    case 4:
                        ShowStartMenu();
                        break;
                    case 5:
                        Console.Clear();
                        break;
                    case 6:
                        running = false;
                        break;
                    default:
                        ShowStartMenu();
                        break;
                }
            }
        }

        private int GetAndParseMenuChoice()
        {
            Console.WriteLine("Press 4 to see the menu options.");
            string choiceAsString = Console.ReadLine();
            int choice = Int32.Parse(choiceAsString);
            return choice;
        }

        private void ShowStartMenu()
        {
            Console.Clear();
            Console.WriteLine("What would you like to do? \n" +
                "1.See all badges \n" +
                "2.Add a badge \n" +
                "3.Edit a badge \n" +
                "4.Show console menu \n" +
                "5.Clear console \n" +
                "6.Exit");
        }

        private void SeeAllBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> dictionary = _badgeRepo.ReturnDictionary();
            Console.WriteLine("Badge Number \t Door Access");
            foreach (KeyValuePair<int, List<string>> badges in dictionary)
            {
                Console.WriteLine($"{badges.Key}");
                foreach (string door in badges.Value)
                {
                    Console.WriteLine($"\t\t\t{door}");
                }
            }
        }

        private void AddABadge()
        {
            Console.Clear();

            Badge _badge = new Badge();

            List<string> doorList = new List<string>();

            _badge.Doors = doorList;
            Console.WriteLine("Enter the Badge ID");
            _badge.BadgeID = int.Parse(Console.ReadLine());
        LoopForDoors:
            Console.WriteLine("Select access to doors");
            Console.WriteLine("What is the name of the door?");
            string doorName = Console.ReadLine();
            Badge addingToBadge = _badgeRepo.AddToListOfDoors(_badge, doorName);
            _badge = addingToBadge;
            Console.WriteLine("Does this badge have access to more doors? y/n");
            string answer = Console.ReadLine();

            if (answer == "y")
            {
                goto LoopForDoors;
            }
            _badgeRepo.AddToDictionary(_badge);
        }
        private void EditABadge()
        {
            Console.Clear();
            Dictionary<int, List<string>> dictionary = _badgeRepo.ReturnDictionary();
            Console.WriteLine("What is the badge number to be updated?");
            int badgeID = int.Parse(Console.ReadLine());
            Console.Clear();
            foreach (KeyValuePair<int, List<string>> badge in dictionary)
            {
                if (badge.Key == badgeID)
                {
                    Console.WriteLine($"Badge {badge.Key} has access to the following doors:");
                    foreach (string door in badge.Value)
                    {
                        Console.WriteLine($"{door}");
                    }
                }
            }
            Console.WriteLine("How would you like to update your badge? \n" +
                "1. Add access to a door \n" +
                "2. Remove access to a door \n");
            int choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    goto AddADoor;
                case 2:
                    goto RemoveADoor;
                default:
                    goto UpdatedDoor;

            }
        AddADoor:
            Console.Clear();
            Console.WriteLine("Please state the name of the door that will be added:");
            string doorName = Console.ReadLine();
            foreach (KeyValuePair<int, List<string>> badge in dictionary)
            {
                if (badge.Key == badgeID)
                {
                    badge.Value.Add(doorName);
                }
            }
            goto UpdatedDoor;

        RemoveADoor:
            Console.Clear();
            Console.WriteLine("Please state the name of the door that will be removed:");
            string doorNameRemoved = Console.ReadLine();
            foreach (KeyValuePair<int, List<string>> badge in dictionary)
            {
                if (badge.Key == badgeID)
                {
                    badge.Value.Remove(doorNameRemoved);
                }
            }
            goto UpdatedDoor;

        UpdatedDoor:
            foreach (KeyValuePair<int, List<string>> badge in dictionary)
            {
                if (badge.Key == badgeID)
                {
                    Console.Clear();
                    Console.WriteLine($"Badge {badge.Key} has been updated and now has access to the following doors:");
                    foreach (string door in badge.Value)
                    {
                        Console.WriteLine($"{door}");
                    }
                }
                Console.WriteLine("Would you like to do anything else? y/n");
                string answer = Console.ReadLine();

                if (answer == "y")
                {
                    Console.WriteLine("How would you like to update your badge? \n" +
                "1. Add access to a door \n" +
                "2. Remove access to a door \n");
                    int choiceRepeat = GetAndParseMenuChoice();
                    switch (choiceRepeat)
                    {
                        case 1:
                            goto AddADoor;
                        case 2:
                            goto RemoveADoor;
                        default:
                            goto UpdatedDoor;

                    }
                }
                else
                {
                    ShowStartMenu();
                }
            }
        }
    }
}
