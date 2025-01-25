namespace LD4_22
{
    public class Oven : Device
    {
        public int power { get; private set; }
        public int programs { get; private set; }
        /// <summary>
        /// Oven device constructor with parameters
        /// </summary>
        /// <param name="manufacturer">manufactor name</param>
        /// <param name="model">model name</param>
        /// <param name="energyClass">energy class</param>
        /// <param name="color">color</param>
        /// <param name="price">price</param>
        /// <param name="power">power</param>
        /// <param name="programs">available programs</param>
        public Oven(string manufacturer, string model, string energyClass,
                      string color, double price, int power, int programs) :
                      base(manufacturer, model, energyClass, color, price)
        {
            type = 'O';
            this.power = power;
            this.programs = programs;
        }
        /// <summary>
        /// Returs data to string
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return $"{manufacturer},{model},{energyClass},{color},{price}," +
                $"{power},{programs}";
        }
        /// <summary>
        /// Compares power
        /// </summary>
        /// <param name="other">other oven power</param>
        /// <returns>1 or -1</returns>
        public override int CompareTo(object other)
        {
            if (other == null) return 1;
            if (other is Oven oven1)
                if (power < oven1.power)
                    return -1;
            return 1;
        }
    }
}