using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD_22
{
    public class Destination
    {
        private string startLocation, endLocation;
        public Destination() 
        {
            startLocation = string.Empty;
            endLocation = string.Empty;
        }
        public void Place(string startLocation, string endLocation)
        {
            this.startLocation = startLocation;
            this.endLocation = endLocation;
        }
        public string Take()
        {
            return startLocation;
        }
        public string Take1()
        {
            return endLocation;
        }
    }
}