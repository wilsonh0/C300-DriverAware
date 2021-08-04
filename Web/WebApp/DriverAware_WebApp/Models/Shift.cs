using System;
using System.Collections.Generic;

#nullable disable

namespace DriverAware_WebApp.Models
{
    public partial class Shift
    {
        public int Id { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int VehicleId { get; set; }
        public int DriverId { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
