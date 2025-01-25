using System;

namespace LD4_22
{
    public abstract class Device: IComparable<double>, IEquatable<char>,
                                  IEquatable<string>, IComparable<object>
    {
        public char type { get; set; }
        public string manufacturer { get; private set; }
        public string model { get; private set; }
        public string energyClass { get; private set; }
        public string color { get; private set; }
        public double price { get; private set; }
        /// <summary>
        /// Device contructor with parameters
        /// </summary>
        /// <param name="manufacturer">manufactor name</param>
        /// <param name="model">model name</param>
        /// <param name="energyClass">energy class</param>
        /// <param name="color">color</param>
        /// <param name="price">price</param>
        public Device(string manufacturer, string model, string energyClass,
                      string color, double price)
        {
            this.manufacturer = manufacturer;
            this.model = model;
            this.energyClass = energyClass;
            this.color = color;
            this.price = price;
        }
        /// <summary>
        /// Compares devices prices
        /// </summary>
        /// <param name="other">other price</param>
        /// <returns>1 or -1</returns>
        public int CompareTo(double other)
        {
            if (price < other) return 1;
            return -1;
        }
        /// <summary>
        /// Checks if device is the same with another
        /// </summary>
        /// <param name="other">other device</param>
        /// <returns>true or false</returns>
        public bool Equals(char other)
        {
            if(type == other) return true;
            else return false;
        }
        /// <summary>
        /// Checks if colors are the same 
        /// </summary>
        /// <param name="other">other color</param>
        /// <returns>true or false</returns>
        public bool Equals(string other)
        {
            if(other == string.Empty) return false;
            if(other == color) return true;
            else return false;
        }
        /// <summary>
        /// virtual compare with two devices
        /// </summary>
        /// <param name="other">other device</param>
        /// <returns>1 or 0</returns>
        public virtual int CompareTo(object other)
        {
            if (other == null) return 1;
            return 0;
        }
    }
}