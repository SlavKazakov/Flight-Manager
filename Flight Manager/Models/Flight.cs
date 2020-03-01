using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Models
{
    public class Flight
    {
        public int ID { get; set; }
        public string LocationFrom {get;set;}
        public string LocationTo { get; set; }
        public DateTime DateOfTakeOf { get; set; }
        public DateTime DateOfLanding { get; set; }
        public int UniqueNumber { get; set; }
        public string PilotName { get; set; }
        public int Capacity { get; set; }
        public int CapacityBusinessClass { get; set; }
    }
}
