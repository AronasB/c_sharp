using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD_22
{
    public class Path
    {
        private string startName, endName;
        private int length;
        public Path() 
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

    }
}