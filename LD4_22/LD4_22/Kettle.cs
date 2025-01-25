namespace LD4_22
{
    public class Kettle : Device
    {
        public int power { get; private set; }
        public double volume { get; private set; }
        /// <summary>
        /// Kettle device contructor with parameters
        /// </summary>
        /// <param name="manufacturer"></param>
        /// <param name="model"></param>
        /// <param name="energyClass"></param>
        /// <param name="color"></param>
        /// <param name="price"></param>
        /// <param name="power"></param>
        /// <param name="volume"></param>
        public Kettle(string manufacturer, string model, string energyClass,
                      string color, double price, int power, double volume) :
                      base(manufacturer, model, energyClass, color, price)
        {
            type = 'K';
            this.power = power;
            this.volume = volume;
        }
        /// <summary>
        /// Returns data to string
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return $"{manufacturer},{model},{energyClass},{color},{price}," +
                $"{power},{volume}";
        }
        /// <summary>
        /// Compares power
        /// </summary>
        /// <param name="other">other kettle power</param>
        /// <returns>1 or -1</returns>
        public override int CompareTo(object other)
        {
            if (other == null) return 1;
            if (other is Kettle kettle1)
                if (power < kettle1.power)
                    return -1;
            return 1;
        }
    }
}