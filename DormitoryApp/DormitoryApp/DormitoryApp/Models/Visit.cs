using System;
using System.Collections.Generic;
using System.Text;

namespace DormitoryApp.Models
{
    public class Visit
    {
        public string Id { get; set; }
        public DateTime ArrivalTime { get; set; }
        public bool Visited { get; set; }
    }
}
