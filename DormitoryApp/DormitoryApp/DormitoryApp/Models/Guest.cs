using System;
using System.Collections.Generic;
using System.Text;

using System.Diagnostics;

namespace DormitoryApp.Models
{
    public class Guest 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
