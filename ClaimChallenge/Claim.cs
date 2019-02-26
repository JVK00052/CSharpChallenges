using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimChallenge
{
    public class Claim
    {
        public Claim() { }

        public Claim(int id, string type, string desc, int amount, DateTime accidentDate, DateTime claimDate)
        {
            ClaimId = id;
            ClaimType = type;
            ClaimDescription = desc;
            ClaimAmount = amount;
            DateOfAccident = accidentDate;
            DateOfClaim = claimDate;
            IsValid = DateOfClaim - DateOfAccident < TimeSpan.FromDays(30);
        }
        public int ClaimId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimDescription { get; set; }
        public int ClaimAmount { get; set; }
        public DateTime DateOfAccident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }
    }
}
