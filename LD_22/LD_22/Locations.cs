using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD_22
{
    public class Locations
    {
        const int CMax = 51;
        private string[] Names;
        private int leastLength;
        public Locations() 
        {
            Names = new string[CMax];
            leastLength = 0;
        }
        public void Place(string Name, int i)
        {
            Names[i] = Name;
        }
        public void Place(int leastLength)
        {
            this.leastLength = leastLength;
        }
        public string Take(int i)
        {
            return Names[i];
        }
        public int TakeLeast()
        {
            return leastLength;
        }
    }
}