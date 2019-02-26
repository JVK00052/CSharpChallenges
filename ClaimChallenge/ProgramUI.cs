using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimChallenge
{
    public class ProgramUI
    {
        private ClaimRepository _claimRepo = new ClaimRepository();

        public void Run()
        {
            InitializeQueue();

            StartMenu();
        }

        private void StartMenu()
        {
            ShowStartMenu();

            bool running = true;

            while (running)
            {
                int choice = GetAndParseMenuChoice();

                switch (choice)
                {
                    case 1:
                        SeeAllClaims();
                        break;
                    case 2:
                        EnterAClaim();
                        break;
                    case 3:
                        NextClaim();
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
                }
            }
        }

        private int GetAndParseMenuChoice()
        {
            Console.WriteLine("Please choose what you would like to do. To open the menu please press 4.");
            string choiceAsString = Console.ReadLine();
            int choice = Int32.Parse(choiceAsString);
            return choice;
        }

        public void InitializeQueue()
        {
            Claim claimOne = new Claim(1111, "House", "House burnt down", 125000, new DateTime(2019, 01, 02), new DateTime(2019, 01, 08));
            Claim claimTwo = new Claim(2222, "Car", "Car got T-boned", 50000, new DateTime(2019, 01, 28), new DateTime(2019, 02, 08));
            _claimRepo.AddClaimToQueue(claimOne);
            _claimRepo.AddClaimToQueue(claimTwo);
        }

        private void ShowStartMenu()
        {
            Console.WriteLine("What would you like to do? \n" +
                "1.See all claims \n" +
                "2.Enter a new claim \n" +
                "3.See next claim \n" +
                "4.Show console menu \n" +
                "5.Clear console \n" +
                "6.Exit \n");
        }

        private void SeeAllClaims()
        {
            Console.WriteLine("Claim ID\t" + "Type\t" + "Description\t" +
                "Amount\t" + "DateOfAccident\t" +
                "DateOfClaim\t" + "Is Valid\t");

            var claims = _claimRepo.GetClaims();
            foreach (Claim claim in claims)
            {
                Console.WriteLine($"{claim.ClaimId}\t" + $"{claim.ClaimType}\t" + $"{claim.ClaimDescription}\t" +
                 $"{claim.ClaimAmount}\t" + $"{claim.DateOfAccident.ToShortDateString()}\t" +
                 $"{claim.DateOfClaim.ToShortDateString()}\t" + $"{claim.IsValid}\t");
            }
        }

        private void EnterAClaim()
        {
            Console.WriteLine("Please follow the the prompts to add a new claim");
            Claim claim = new Claim();

            Console.WriteLine("Please enter the claim id (this should be 4 digits long)");
            claim.ClaimId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the claim type");
            claim.ClaimType = Console.ReadLine();

            Console.WriteLine("Please enter the claim description");
            claim.ClaimDescription = Console.ReadLine();

            Console.WriteLine("Please enter the claim amount");
            claim.ClaimAmount = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the date of the accident mm/dd/yyyy");
            claim.DateOfAccident = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the date the claim was filed mm/dd/yyyy");
            claim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            claim.IsValid = claim.DateOfClaim - claim.DateOfAccident < TimeSpan.FromDays(30);

            _claimRepo.AddClaimToQueue(claim);
            Console.WriteLine("Claim successfully added");
        }
        private void NextClaim()
        {
            //Get the claims first
            Queue<Claim> claimQueue = _claimRepo.GetClaims();
            //Looks at the claim next in line but doesn't remove it from the queue -> JUST A PEEK!
            Claim displayClaim = claimQueue.Peek();
            Console.WriteLine($"{displayClaim.ClaimType}\t" + $"{displayClaim.ClaimDescription}\t" +
                 $"{displayClaim.ClaimAmount}\t" + $"{displayClaim.DateOfAccident.ToShortDateString()}\t" +
                 $"{displayClaim.DateOfClaim.ToShortDateString()}\t" + $"{displayClaim.IsValid}\t");
            //This checks to see if they want to see handle the next claim. If yes remove the first claim in the queue than cw
            Console.WriteLine("Would you like to handle this claim? y/n");
            string y = Console.ReadLine();
            if (y == "y")
            {
                claimQueue.Dequeue();
                Console.WriteLine("Claim has been handled");
            }
        }
    }
}
