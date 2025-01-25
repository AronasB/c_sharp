using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LD5_22
{
    public static class InOutUtils
    {
        /// <summary>
        /// Reads subscriber data
        /// </summary>
        /// <param name="file">folder path</param>
        /// <returns>subscriber list</returns>
        public static List<Subscriber> ReadData(string file)
        {
            List<Subscriber> data = new List<Subscriber>();
            string[] filePaths = Directory.GetFiles(file, "*.txt");

            foreach (string path in filePaths)
            {
                using (StreamReader sr = new StreamReader(@path, Encoding.UTF8))
                {
                    string line;
                    string dateInserted = sr.ReadLine();
                    string surname, adress;
                    int dateStart, dateLength;
                    string code;
                    int amount;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        surname = parts[0].Trim();
                        adress = parts[1].Trim();
                        dateStart = int.Parse(parts[2]);
                        dateLength = int.Parse(parts[3]);
                        code = parts[4].Trim();
                        amount = int.Parse(parts[5]);
                        data.Add(new Subscriber(dateInserted, surname,
                            adress, dateStart, dateLength, code, amount));
                    }
                }
            }

            return data;
        }
        /// <summary>
        /// Reads publication data
        /// </summary>
        /// <param name="file">file path</param>
        /// <returns>publication list</returns>
        public static List<Publication> ReadPublication(string file)
        {
            List<Publication> data = new List<Publication>();
            try
            {
                using (StreamReader sr = new StreamReader(file, Encoding.UTF8))
                {
                    string line;
                    string code, name;
                    double price;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        code = parts[0].Trim();
                        name = parts[1].Trim();
                        price = double.Parse(parts[2]);
                        data.Add(new Publication(code, name, price));
                    }
                }
                return data;
            }
            catch { return null; }
        }
        /// <summary>
        /// Prints certain data to txt file
        /// </summary>
        /// <typeparam name="T">type of list</typeparam>
        /// <param name="file">file path</param>
        /// <param name="list">list data</param>
        /// <param name="header">given text</param>
        public static void PrintData<T>(string file, IEnumerable<T> list,
                                        string header)
        {
            using(var fr = new StreamWriter(file, true, Encoding.UTF8))
            {
                fr.WriteLine(header);
                foreach(var type in list)
                {
                    fr.WriteLine(type.ToString());
                }
                fr.WriteLine();
            }
        }
    }
}