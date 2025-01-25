using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LD5_22
{
    public class Publication
    {
        public string code { get; private set; }
        public string name { get; private set; }
        public double price { get; private set; }
        /// <summary>
        /// constructor without parameters
        /// </summary>
        public Publication() { }
        /// <summary>
        /// constructor with given parameters
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        public Publication(string code, string name, double price)
        {
            this.code = code;
            this.name = name;
            this.price = price;
        }
        /// <summary>
        /// For output
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return $"{code,-6} {name,-22} {price,5}";
        }
    }
}