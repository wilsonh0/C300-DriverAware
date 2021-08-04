using System;
using System.Collections.Generic;

#nullable disable

namespace DriverAwareAPI.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Shifts = new HashSet<Shift>();
        }

        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string RegistrationNo { get; set; }
        public string SwVersion { get; set; }
        public string UnitNo { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; }
    }
}
