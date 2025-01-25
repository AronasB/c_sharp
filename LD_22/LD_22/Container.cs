using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD_22
{
    public class Container
    {
        const int CMax = 51;
        private Destination Destination;
        private Path[] Paths;
        private Locations Location;
        public int n { get; set; }
        public int m {  get; set; }
        public Container()
        {
            n = 0;
            m = 0;
            Destination = new Destination();
            Location = new Locations();
            Paths = new Path[CMax];
        }
        public void Place(Destination NewDestination)
        {
            Destination = NewDestination;
        }
        public void Place(Path NewPath, int i)
        {
            Paths[i] = NewPath;
        }
        public void Place(Locations NewLocation)
        {
            Location = NewLocation;
        }
        public Destination Take1()
        {
            return Destination;
        }
        public Path Take(int i)
        {
            return Paths[i];
        }
        public Locations Take()
        {
            return Location;
        }
    }
}