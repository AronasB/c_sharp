using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD1_22
{
    public class Destination
    {
        private string startName, endName;
        private int length;
        public Destination()
        {
            startName = string.Empty;
            endName = string.Empty;
            length = 0;
        }
        public void Place(string startName, string endName, int length)
        {
            this.startName = startName;
            this.endName = endName;
            this.length = length;
        }
        public override string ToString()
        {
            string temp = string.Format("{0,-10} {1,-10} {2}", startName, endName,
                                        length);
            return temp;
        }
        public string TakeStart()
        {
            return startName;
        }
        public string TakeEnd()
        {
            return endName;
        }
        public int TakeLength()
        {
            return length;
        }
    }
}