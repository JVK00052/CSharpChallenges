using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPlanChallenge
{
    public class ProgramUI
    {
        private VehicleRepository _vehicleRepo = new VehicleRepository();
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
                        SeeAllCarLists();
                        break;
                    case 2:
                        AddACar();
                        break;
                    case 3:
                        EditACar();
                        break;
                    case 4:
                        RemoveACar();
                        break;
                    case 5:
                        ShowStartMenu();
                        break;
                    case 6:
                        Console.Clear();
                        break;
                    case 7:
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
            Console.WriteLine("Press 5 to see the menu options.");
            string choiceAsString = Console.ReadLine();
            int choice = Int32.Parse(choiceAsString);
            return choice;
        }

        private void ShowStartMenu()
        {
            Console.Clear();
            Console.WriteLine("What would you like to do? \n" +
                "1.See all cars \n" +
                "2.Add a car \n" +
                "3.Edit a car \n" +
                "4.Remove a car \n" +
                "5.Show console menu \n" +
                "6.Clear console\n" +
                "7.Exit");
        }

        private void SeeAllCarLists()
        {
            Console.Clear();
            List<Vehicle> _gasCars = _vehicleRepo.GetGasVehicles();
            List<Vehicle> _hybCars = _vehicleRepo.GetHyrbidVehicles();
            List<Vehicle> _elecCars = _vehicleRepo.GetElectricVehicles();
            Console.WriteLine("Which list of cars would you  like to see? \n" +
                "1.Gas Car List \n" +
                "2.Hybrid Car List \n" +
                "3.Electric Car List \n");

            int choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    foreach (Vehicle vehicle in _gasCars)
                    {
                        Console.WriteLine("VehicleRunType \t" + "VehicleID \t" + "VehicleName \t" + "VehicleModel");
                        Console.WriteLine($"{vehicle.VehicleRunType} \t" + $"{vehicle.VehicleID} \t" + $"{vehicle.VehicleName} \t" + $"{vehicle.VehicleModel}");
                    }
                    break;
                case 2:
                    foreach (Vehicle vehicle in _hybCars)
                    {
                        Console.WriteLine("VehicleRunType \t" + "VehicleID \t" + "VehicleName \t" + "VehicleModel");
                        Console.WriteLine($"{vehicle.VehicleRunType} \t" + $"{vehicle.VehicleID} \t" + $"{vehicle.VehicleName} \t" + $"{vehicle.VehicleModel}");
                    }
                    break;
                case 3:
                    foreach (Vehicle vehicle in _elecCars)
                    {
                        Console.WriteLine("VehicleRunType \t" + "VehicleID \t" + "VehicleName \t" + "VehicleModel");
                        Console.WriteLine($"{vehicle.VehicleRunType} \t" + $"{vehicle.VehicleID} \t" + $"{vehicle.VehicleName} \t" + $"{vehicle.VehicleModel}");
                    }
                    break;
            }
        }

        private void AddACar()
        {
            Console.Clear();
            Console.WriteLine("Please follow the prompt accordingly:");
            Console.WriteLine("Which kind of car would you like to add? \n" +
                "1.Gas Car \n" +
                "2.Hybrid Car \n" +
                "3.Electric Car");
            int choice = Int32.Parse(Console.ReadLine());
            VehicleType vehicleType = VehicleType.Gas;
            switch (choice)
            {
                case 1:
                    string carOne = "Gas";
                    vehicleType = (VehicleType)Enum.Parse(typeof(VehicleType), carOne);
                    Console.WriteLine("Please enter the Vehicle ID:");
                    int vehicleID = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter the Vehicle Name:");
                    string vehicleName = Console.ReadLine();

                    Console.WriteLine("Please enter the Vehicle Model:");
                    string vehicleModel = Console.ReadLine();

                    Vehicle vehicle = new Vehicle(vehicleType, vehicleID, vehicleName, vehicleModel);
                    _vehicleRepo.AddToGasVehicles(vehicle);
                    Console.WriteLine("Car Added Successfully");
                    break;
                case 2:
                    string carTwo = "Hybrid";
                    vehicleType = (VehicleType)Enum.Parse(typeof(VehicleType), carTwo);
                    Console.WriteLine("Please enter the Vehicle ID:");
                    int vehicleIDTwo = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter the Vehicle Name:");
                    string vehicleNameTwo = Console.ReadLine();

                    Console.WriteLine("Please enter the Vehicle Model:");
                    string vehicleModelTwo = Console.ReadLine();

                    Vehicle vehicleTwo = new Vehicle(vehicleType, vehicleIDTwo, vehicleNameTwo, vehicleModelTwo);
                    _vehicleRepo.AddToHybridVehicles(vehicleTwo);
                    Console.WriteLine("Car Added Successfully");
                    break;
                case 3:
                    string carThree = "Electric";
                    vehicleType = (VehicleType)Enum.Parse(typeof(VehicleType), carThree);
                    Console.WriteLine("Please enter the Vehicle ID:");
                    int vehicleIDThree = int.Parse(Console.ReadLine());

                    Console.WriteLine("Please enter the Vehicle Name:");
                    string vehicleNameThree = Console.ReadLine();

                    Console.WriteLine("Please enter the Vehicle Model:");
                    string vehicleModelThree = Console.ReadLine();

                    Vehicle vehicleThree = new Vehicle(vehicleType, vehicleIDThree, vehicleNameThree, vehicleModelThree);
                    _vehicleRepo.AddToElectricVehicles(vehicleThree);
                    Console.WriteLine("Car Added Successfully");
                    break;
            }

        }

        private void EditACar()
        {

        }

        private void RemoveACar()
        {

        }
    }
}
