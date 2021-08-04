using System;
using System.Collections.Generic;

#nullable disable

namespace DriverAware_WebApp.Models
{
    public partial class Driver
    {
        public Driver()
        {
            Shifts = new HashSet<Shift>();
        }

        public int Id { get; set; }
        public string EmployeeNo { get; set; }
        public string LastName { get; set; }
        public string GivenName { get; set; }
        public string OtherNames { get; set; }
        public string Age { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; }
    }
}
