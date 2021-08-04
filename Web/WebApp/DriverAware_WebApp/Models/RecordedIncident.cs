using System;
using System.Collections.Generic;

#nullable disable

namespace DriverAware_WebApp.Models
{
    public partial class RecordedIncident
    {
        public RecordedIncident()
        {
            InverseShift = new HashSet<RecordedIncident>();
        }

        public int Id { get; set; }
        public DateTime? IncidentTime { get; set; }
        public string IncidentType { get; set; }
        public double? Gpslat { get; set; }
        public double? Gpslong { get; set; }
        public int ShiftId { get; set; }

        public virtual RecordedIncident Shift { get; set; }
        public virtual ICollection<RecordedIncident> InverseShift { get; set; }

    }
}
