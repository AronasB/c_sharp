using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web.UI.WebControls;

namespace LD1_22
{
    public partial class WebForm : System.Web.UI.Page
    {
        const int CMax = 100;
        private int N, M;
        private string[] names;
        private string startLocation, endLocation;
        private Destination[] Destinations;
        private int leastDistance = int.MaxValue;
        protected void Page_Load(object sender, EventArgs e)
        {
            names = new string[CMax];
            Destinations = new Destination[CMax];

            ReadFile(Server.MapPath("App_Data/U3_1.txt"), out N, out M, names,
                     out startLocation, out endLocation, Destinations);

            Print(N, M, names, startLocation, endLocation, Destinations);

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string[] leastPath = new string[M];
            string filePath = Server.MapPath("App_Data/U3Rez.txt");

            Recursion(startLocation, endLocation, ref leastDistance,
                    Destinations, M, 0, new string[M], 0, ref leastPath);

            PrintResults(startLocation, endLocation, leastDistance, leastPath);

            if (File.Exists(filePath))
                File.Delete(filePath);

            SaveFile(filePath, N, M, names, startLocation, endLocation,
                     Destinations, leastDistance, leastPath);
        }
        /// <summary>
        /// Recursion to find shortest distance and shortest path destination
        /// names between given destinations
        /// </summary>
        /// <param name="stDest">Start location name</param>
        /// <param name="endDest">End location name</param>
        /// <param name="leastDistance">Shortest distance</param>
        /// <param name="Destinations">Destination class</param>
        /// <param name="M">All paths ammount</param>
        /// <param name="comLength">Multiple paths combination length</param>
        /// <param name="currentPath">Current paths</param>
        /// <param name="currentPathIndex">Ammount of paths</param>
        /// <param name="leastPath">Paths with shortest distance</param>
        static void Recursion(string stDest, string endDest, ref int leastDistance
                              , Destination[] Destinations, int M, int comLength,
                              string[] currentPath, int currentPathIndex,
                              ref string[] leastPath)
        {
            currentPath[currentPathIndex] = stDest;
            currentPathIndex++;
            
            if (stDest == endDest)
            {
                if (comLength < leastDistance)
                {
                    leastDistance = comLength;
                    
                    leastPath = new string[M];
                    
                    for (int i = 0; i < currentPathIndex; i++)
                    {
                        leastPath[i] = currentPath[i];
                    }
                }
                return;
            }
            
            for (int i = 0; i < M; i++)
            {
                if (Destinations[i].TakeStart() == stDest)
                {
                    int newLength = comLength + Destinations[i].TakeLength();
                    
                    Recursion(Destinations[i].TakeEnd(), endDest,
                              ref leastDistance, Destinations, M, newLength,
                              currentPath, currentPathIndex, ref leastPath);
                }
            }
            
            currentPathIndex--;
        }
        /// <summary>
        /// Reads from file data
        /// </summary>
        /// <param name="fileName">File path</param>
        /// <param name="N">Locations ammount</param>
        /// <param name="M">All paths ammount</param>
        /// <param name="names">Locations names</param>
        /// <param name="startLocation">Start location name</param>
        /// <param name="endLocation">End location name</param>
        /// <param name="Destinations">Destination class</param>
        static void ReadFile(string fileName, out int N, out int M,
                              string[] names, out string startLocation,
                              out string endLocation, Destination[] Destinations)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string temp;
                temp = reader.ReadLine();

                string[] parts = temp.Split(' ');
                N = int.Parse(parts[0].Trim());
                M = int.Parse(parts[1].Trim());

                for (int i = 0; i < N; i++)
                    names[i] = reader.ReadLine();

                temp = reader.ReadLine();

                temp = reader.ReadLine();
                parts = temp.Split(' ');
                startLocation = parts[0].Trim();
                endLocation = parts[1].Trim();

                temp = reader.ReadLine();

                for (int i = 0; i < M; i++)
                {
                    temp = reader.ReadLine();
                    parts = temp.Split(' ');
                    Destinations[i] = new Destination();
                    Destinations[i].Place(parts[0], parts[1],
                                          int.Parse(parts[2]));
                }
            }
        }
        /// <summary>
        /// Inserts data into a website table
        /// </summary>
        /// <param name="N">Locations ammount</param>
        /// <param name="M">All paths ammount</param>
        /// <param name="names">Locations names</param>
        /// <param name="startLocation">Start location name</param>
        /// <param name="endLocation">End location name</param>
        /// <param name="Destinations">Destination class</param>
        private void Print(int N, int M, string[] names, string startLocation,
                           string endLocation, Destination[] Destinations)
        {
            Table1.Rows.Add(CreateRow(string.Format("{0,5} {1,5}", N, M)));

            for(int i = 0; i < N;i++)
            {
                Table1.Rows.Add(CreateRow(names[i]));
            }

            Table1.Rows.Add(CreateRow(""));

            Table1.Rows.Add(CreateRow(string.Format("{0,-10} {1}", startLocation,
                            endLocation)));

            Table1.Rows.Add(CreateRow(""));

            for (int i = 0;i < M; i++)
            {
                Table1.Rows.Add(CreateRow(Destinations[i].ToString()));
            }
        }
        /// <summary>
        /// Inserts calculated results into a website table
        /// </summary>
        /// <param name="stDest">Start location name</param>
        /// <param name="endDest">End location name</param>
        /// <param name="leastDistance">Shortest distance</param>
        /// <param name="leastPath">Paths with shortest distance</param>
        private void PrintResults(string stDest, string endDest, int leastDistance
                                 ,string[] leastPath)
        {
            Table2.Rows.Add(CreateRow("Minimalus atstumas tarp vietovių"));

            Table2.Rows.Add(CreateRow(string.Format("{0,-10} ir {1,-10} {2,5} km",
                                      stDest, endDest, leastDistance)));

            Table2.Rows.Add(CreateRow("Trasa eina per vietoves:"));

            for(int i = 0; i < leastPath.Length; i++) 
            {
                if (leastPath[i] != null)
                    Table2.Rows.Add(CreateRow(leastPath[i]));
            }
        }
        /// <summary>
        /// Creates a row
        /// </summary>
        /// <param name="name">given string</param>
        /// <returns>row</returns>
        static TableRow CreateRow(string name)
        {
            TableRow row = new TableRow();
            TableCell cell = new TableCell();
            
            cell.Text = name;
            
            row.Cells.Add(cell);
            
            return row;
        }
        /// <summary>
        /// Saves data into file
        /// </summary>
        /// <param name="filename">file path</param>
        /// <param name="N">Locations ammount</param>
        /// <param name="M">All paths ammount</param>
        /// <param name="names">Locations names</param>
        /// <param name="startLocation">Start location name</param>
        /// <param name="endLocation">End location name</param>
        /// <param name="Destinations">Destination class</param>
        /// <param name="leastDistance">Shortest distance</param>
        /// <param name="leastPath">Paths with shortest distance</param>
        static void SaveFile(string filename, int N, int M,
                             string[] names, string startLocation,
                             string endLocation, Destination[] Destinations,
                             int leastDistance, string[] leastPath)
        {
            using (var fr = File.AppendText(filename))
            {
                fr.WriteLine("Pradiniai duomenys:");

                fr.Write(N);
                fr.Write(" ");
                fr.Write(M);
                fr.Write("\n");

                for(int i = 0; i < N; i++)
                {
                    fr.WriteLine(names[i]);
                }

                fr.WriteLine();
                fr.WriteLine(string.Format("{0,-10} {1}", startLocation,
                             endLocation));
                fr.WriteLine();

                for(int i = 0; i < M; i++)
                {
                    fr.WriteLine(Destinations[i].ToString());
                }

                fr.WriteLine();
                
                fr.WriteLine("Rezultatai:");

                fr.WriteLine("Minimalus atstumas tarp vietovių");

                fr.WriteLine(string.Format("{0,-10} ir {1,-10} {2} km",
                             startLocation, endLocation, leastDistance));

                fr.WriteLine("Trasa eina per vietoves:");

                for (int i = 0; i < leastPath.Length; i++)
                    if (leastPath[i] != null)
                        fr.WriteLine(leastPath[i]);
            }
        }
    }
}