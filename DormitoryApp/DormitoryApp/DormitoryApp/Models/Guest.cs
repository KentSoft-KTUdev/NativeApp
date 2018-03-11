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

        public string ArrivalTimeString
        {
            get { return ArrivalTimeString; }
            set
            {
                ArrivalTimeString = value;
                try
                {
                    ArrivalTime = DateTime.ParseExact(value, "yyyy-MM-dd HH:mm:ss",
                                           System.Globalization.CultureInfo.InvariantCulture);
                }
                catch
                {
                    Debug.WriteLine("DateTime input error");
                }
            }
        }
    }
}
