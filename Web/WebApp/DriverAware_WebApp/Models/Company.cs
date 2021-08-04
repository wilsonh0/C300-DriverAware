using System;
using System.Collections.Generic;

#nullable disable

namespace DriverAware_WebApp.Models
{
    public partial class Company
    {
        public Company()
        {
            Drivers = new HashSet<Driver>();
            Vehicles = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string TradingAs { get; set; }
        public string Eun { get; set; }
        public DateTime IncorporationDate { get; set; }
        public string RegisteredOffice { get; set; }

        public virtual ICollection<Driver> Drivers { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
