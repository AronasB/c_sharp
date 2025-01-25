using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace LD5_22
{
    public class Subscriber
    {
        public string dateInserted {  get; private set; }
        public string surname { get; private set; }
        public string adress { get; private set; }
        public int dateStart { get; private set; }
        public int dateLength { get; private set; }
        public string code { get; private set; }
        public int amount { get; private set; }
        /// <summary>
        /// constructor without parameters
        /// </summary>
        public Subscriber() { }
        public Subscriber(string dateInserted, string surname, string adress,
            int dateStart, int dateLength, string code, int amount)
        {
            this.dateInserted = dateInserted;
            this.surname = surname;
            this.adress = adress;
            this.dateStart = dateStart;
            this.dateLength = dateLength;
            this.code = code;
            this.amount = amount;
        }
        /// <summary>
        /// constructor with parameters
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{surname,-16} {adress,-20} {dateStart,2} {dateLength,2}" +
                   $" {code,-6} {amount,5}";
        }
    }
}