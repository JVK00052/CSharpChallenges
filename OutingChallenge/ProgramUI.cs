using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutingChallenge
{
    public class ProgramUI
    {
        private OutingRepository _outingRepo = new OutingRepository();
        public void Run()
        {
            IntializeList();

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
                        SeeAllEvents();
                        break;
                    case 2:
                        AddAnEvent();
                        break;
                    case 3:
                        SeeCostOfEvents();
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
            Console.WriteLine("Please choose what you would like to do. To open the menu press 4.");
            string choiceAsString = Console.ReadLine();
            int choice = Int32.Parse(choiceAsString);
            return choice;
        }

        private void IntializeList()
        {
            Outing outingOne = new Outing(OutingType.Bowling, new DateTime(2019, 01, 01), 20.00m, 25);
            Outing outingTwo = new Outing(OutingType.Golf, new DateTime(2019, 01, 05), 50.00m, 15);
            Outing outingThree = new Outing(OutingType.AmusementPark, new DateTime(2019, 1, 10), 100.00m, 40);
            Outing outingFour = new Outing(OutingType.Concert, new DateTime(2019, 01, 15), 150.00m, 30);

            _outingRepo.AddEventToList(outingOne);
            _outingRepo.AddEventToList(outingTwo);
            _outingRepo.AddEventToList(outingThree);
            _outingRepo.AddEventToList(outingFour);
        }
        private void ShowStartMenu()
        {
            Console.WriteLine("What would you like to do? \n" +
                "1.See all events \n" +
                "2.Add a new event \n" +
                "3.See cost of each event \n" +
                "4.Show console menu \n" +
                "5.Clear console \n" +
                "6.Exit \n");
        }
        private void SeeAllEvents()
        {
            Console.WriteLine("Event \t" + "Event Date \t" + "Admission Price \t" + "Total People \t" + "Event Total");

            var events = _outingRepo.GetEvents();
            foreach (Outing outing in events)
            {
                Console.WriteLine($"{outing.Event}\t" + $"{outing.EventDate.ToShortDateString()}\t\t" +
                    $"${outing.AdmissionPrice}\t\t" + $"{outing.TotalPeople}\t\t" + $"${outing.TotalEventCost}");
            }
        }
        private void AddAnEvent()
        {
            Console.WriteLine("Please follow the prompts to add a new claim to the list. \n" +
                        "1.Bowling \n" +
                        "2.Golfing \n" +
                        "3.Amusement Park \n" +
                        "4.Concert");
            Console.WriteLine("Please enter the type of event (Options 1-4)");
            int newEventType = Int32.Parse(Console.ReadLine());
            OutingType outingEnum = OutingType.Bowling;
            switch (newEventType)
            {
                case 1:
                    string outingOne = "Bowling";
                    outingEnum = (OutingType)Enum.Parse(typeof(OutingType), outingOne);
                    break;
                case 2:
                    string outingTwo = "Golfing";
                    outingEnum = (OutingType)Enum.Parse(typeof(OutingType), outingTwo);
                    break;
                case 3:
                    string outingThree = "Amusement Park";
                    outingEnum = (OutingType)Enum.Parse(typeof(OutingType), outingThree);
                    break;
                case 4:
                    string outingFour = "Concert";
                    outingEnum = (OutingType)Enum.Parse(typeof(OutingType), outingFour);
                    break;
            }
            Console.WriteLine("Please enter date of event. Please enter MM/DD/YYYY");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please enter admission or ticket price.");
            decimal admission = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Please enter total people in attendance of event.");
            int people = Int32.Parse(Console.ReadLine());

            Outing outing = new Outing(outingEnum, date, admission, people);
            _outingRepo.AddEventToList(outing);
            Console.WriteLine("Event was recorded successfully.");

        }
        private void SeeCostOfEvents()
        {
            var outings = _outingRepo.GetEvents();
            List<Outing> outingsEvents = new List<Outing>();
            Console.WriteLine("Please select event you would like to see. \n" +
                       "1.Bowling \n" +
                       "2.Golfing \n" +
                       "3.Amusement Park \n" +
                       "4.Concert");
            Console.WriteLine("Please select the event via options 1-4.");
            int newOutingType = Int32.Parse(Console.ReadLine());
            decimal bowling = 0;
            decimal golfing = 0;
            decimal amusementpark = 0;
            decimal concert = 0;

            switch (newOutingType)
            {
                case 1:
                    foreach (var outing in outings)
                    {
                        if (outing.Event == OutingType.Bowling)
                            bowling += outing.TotalEventCost;
                    }
                    Console.WriteLine($"Bowling: {bowling}");
                    break;
                case 2:
                    foreach (var outing in outings)
                    {
                        if (outing.Event == OutingType.Golf)
                            golfing += outing.TotalEventCost;
                    }
                    Console.WriteLine($"Golfing: {golfing}");
                    break;
                case 3:
                    foreach (var outing in outings)
                    {
                        if (outing.Event == OutingType.AmusementPark)
                            amusementpark += outing.TotalEventCost;
                    }
                    Console.WriteLine($"Amusement Park: {amusementpark}");
                    break;
                case 4:
                    foreach (var outing in outings)
                    {
                        if (outing.Event == OutingType.Concert)
                            concert += outing.TotalEventCost;
                    }
                    Console.WriteLine($"Concert: {concert}");
                    break;
            }
        }
    }
}
