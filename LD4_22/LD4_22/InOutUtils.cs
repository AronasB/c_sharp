using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace LD4_22
{
    public static class InOutUtils
    {
        /// <summary>
        /// Takes from folder all txt files
        /// </summary>
        /// <param name="file">folder path</param>
        /// <param name="stores">store class</param>
        public static void ReadData(string file, List<Store> stores)
        {
            string[] filePaths = Directory.GetFiles(file, "*.txt");
            foreach (string filePath in filePaths)
            {
                Store store = ReadDeviceData(filePath);
                stores.Add(store);
            }
        }
        /// <summary>
        /// Reads data from certain file
        /// </summary>
        /// <param name="file">file path</param>
        /// <returns>store class</returns>
        private static Store ReadDeviceData(string file)
        {
            Store store;
            using(StreamReader sr = new StreamReader(@file, Encoding.UTF8))
            {
                string name = sr.ReadLine();
                string adress = sr.ReadLine();
                string phone = sr.ReadLine();
                
                store = new Store(name, adress, phone);
                
                string line;
                string manufacturer, model, energyClass, color; 
                double price;
                
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    manufacturer = parts[0].Trim();
                    model = parts[1].Trim();
                    energyClass = parts[2].Trim();
                    color = parts[3].Trim();
                    price = Convert.ToDouble(parts[4]);
                    try
                    {
                        int capacity;
                        string installType;
                        bool hasFreezer;
                        int height, width, depth;

                        capacity = Convert.ToInt32(parts[5]);
                        installType = parts[6].Trim();
                        hasFreezer = Convert.ToBoolean(parts[7]);
                        height = Convert.ToInt32(parts[8]);
                        width = Convert.ToInt32(parts[9]);
                        depth = Convert.ToInt32(parts[10]);
                        
                        Fridge fridge = new Fridge(manufacturer,
                            model, energyClass, color, price, capacity,
                            installType, hasFreezer, height, width, depth);
                        
                        store.AddDevices(fridge);
                    }
                    catch (FormatException)
                    {
                        int power = Convert.ToInt32(parts[5]);
                        try
                        {
                            int programs = Convert.ToInt32(parts[6]);

                            Oven oven = new Oven(manufacturer,
                            model, energyClass, color, price, power, programs);

                            store.AddDevices(oven);

                        }
                        catch
                        {

                            double volume = Convert.ToDouble(parts[6]);

                            Kettle kettle = new Kettle(manufacturer,
                            model, energyClass, color, price, power, volume);

                            store.AddDevices(kettle);
                        }
                    }
                }
            }
            return store;
        }
        /// <summary>
        /// Prints data to csv file
        /// </summary>
        /// <typeparam name="Type">class type</typeparam>
        /// <param name="file">file path</param>
        /// <param name="obj">class data</param>
        /// <param name="header">header</param>
        public static void PrintData<Type>(string file, List<Type> obj,
                                           string header)
        {
            using(var fr = new StreamWriter(file, true, 
                  Encoding.UTF8))
            {
                fr.WriteLine(header);
                foreach(var type in obj)
                {
                    fr.WriteLine(type.ToString());
                }
                fr.WriteLine();
            }
        }
    }
}