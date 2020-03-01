using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Models
{
    public class Passengers
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public int EGN { get; set; }
        public int PhoneNumber { get; set; }
        public string Nationality { get; set; }
        public string TicketType { get; set; }
    }
}
