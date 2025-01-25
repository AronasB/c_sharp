using System;

namespace LD4_22
{
    public class Fridge : Device
    {
        public int capacity { get; private set; }
        public string installType { get; private set; }
        public bool hasFreezer { get; private set; }
        public int height { get; private set; }
        public int width { get; private set; }
        public int depth { get; private set; }
        /// <summary>
        /// Fridge device constructor with parameters
        /// </summary>
        /// <param name="manufacturer">manufactor name</param>
        /// <param name="model">model name</param>
        /// <param name="energyClass">energy class</param>
        /// <param name="color">color</param>
        /// <param name="price">price</param>
        /// <param name="capacity">capacity</param>
        /// <param name="installType">installation type</param>
        /// <param name="hasFreezer">has freezer</param>
        /// <param name="height">height</param>
        /// <param name="width">width</param>
        /// <param name="depth">depth</param>
        public Fridge(string manufacturer, string model, string energyClass,
                      string color, double price,
                      int capacity, string installType, bool hasFreezer,
                      int height, int width, int depth) :
                      base(manufacturer, model, energyClass, color, price)
        {
            type = 'F';
            this.capacity = capacity;
            this.installType = installType;
            this.hasFreezer = hasFreezer;
            this.height = height;
            this.width = width;
            this.depth = depth;
        }
        /// <summary>
        /// Brings data to string
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return $"{manufacturer},{model},{energyClass},{color},{price}," +
                $"{capacity},{installType},{hasFreezer},{height},{width}," +
                $"{depth}";
        }
        /// <summary>
        /// Compares heights
        /// </summary>
        /// <param name="other">other fridge height</param>
        /// <returns>1 or -1</returns>
        public override int CompareTo(object other)
        {
            if (other == null) return 1;
            if(other is Fridge fridge1)
                if(height < fridge1.height)
                    return -1;
            return 1;  
        }
    }
}