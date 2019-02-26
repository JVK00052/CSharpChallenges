using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutingChallenge
{
    public enum OutingType : int
    { Golf = 1, Bowling = 2, AmusementPark = 3, Concert =4}
    public class Outing
    {
        public Outing() { }

        public Outing(OutingType outing, DateTime eventDate, decimal admissionPrice, int totalPeople)
        {
            Event = outing;
            EventDate = eventDate;
            AdmissionPrice = admissionPrice;
            TotalPeople = totalPeople;
            TotalEventCost = admissionPrice * totalPeople;
        }
        public OutingType Event { get; set; }
        public DateTime EventDate { get; set; }
        public decimal AdmissionPrice { get; set; }
        public int TotalPeople { get; set; }
        public decimal TotalEventCost { get; set; }
    }
}
