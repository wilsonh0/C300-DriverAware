using System;
using System.Collections.Generic;

#nullable disable

namespace DriverAware_WebApp.Models
{
    public partial class UserLogIn
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
    }
}
