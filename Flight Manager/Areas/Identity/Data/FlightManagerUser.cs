using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FlightManager.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the FlightManagerUser class
    public class FlightManagerUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }

        [PersonalData]
        public string Surname { get; set; }

        [PersonalData]
        public string EGN { get; set; }

        [PersonalData]
        public string Adress { get; set; }
    }
}
