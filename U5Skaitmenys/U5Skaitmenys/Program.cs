using System;
using System.IO;
using System.Text;

namespace U5Skaitmenys
{
    internal class Program
    {
        const string CFd = "..\\..\\Duom.txt";
        const string CFr = "..\\..\\Rez.txt";
        const string CFa = "..\\..\\Analize.txt";
        static void Main(string[] args)
        {
            char[] skyrikliai = { ' ', '.', ',', '!', '?', ':', ';', '(', ')',
                                  '\t' };

            Apdoroti(CFd, CFr, CFa, skyrikliai);
        }
        /// <summary>
        /// Skaito failą, analizuoja eilutes, kuria rezultatų failą
        /// </summary>
        /// <param name="fv">Duomenų failas</param>
        /// <param name="fr">Rezultatų failas</param>
        /// <param name="skyrikliai">Žodžių skyrikliai</param>
        static void Apdoroti(string fv, string fr, string fa, char[] skyrikliai)
        {
            string[] eilutės = File.ReadAllLines(fv);

            using (var far = File.CreateText(fr))
            {
                using (var faar = File.CreateText(fa))
                {
                    if (eilutės.Length > 0)
                        foreach (string eilutė in eilutės)
                        {

                            if (eilutė.Length > 0)
                            {
                                string rastiSk;

                                rastiSk = Žodžiai(eilutė, skyrikliai);

                                if (rastiSk.Length > 0)
                                {
                                    int skVieta;

                                    StringBuilder tekstas = new StringBuilder();

                                    skVieta = eilutė.IndexOf(rastiSk);

                                    tekstas.Append(eilutė.Remove(skVieta));

                                    skVieta += rastiSk.Length;

                                    rastiSk += Skyrikliai(eilutė.Substring(skVieta));

                                    skVieta = eilutė.IndexOf(rastiSk);

                                    skVieta += rastiSk.Length;

                                    tekstas.Append(eilutė.Substring(skVieta));

                                    tekstas.Insert(0, rastiSk);

                                    faar.WriteLine(rastiSk);

                                    far.WriteLine(tekstas);
                                }
                                else
                                    far.WriteLine(eilutė);
                            }
                            else
                                far.WriteLine();
                        }
                    else
                        far.WriteLine("Nėra įvesti duomenys faile!");
                }
            }
        }
        /// <summary>
        /// Išskirsto eilute į žodžius ir grąžina tinkamą žodį
        /// </summary>
        /// <param name="line">Eilutė</param>
        /// <param name="skyrikliai">Skyrikliai</param>
        /// <returns>Žodis sudarytas vien iš skaičių</returns>
        static string Žodžiai(string line, char[] skyrikliai)
        {
            string[] žodžiai = line.Split(skyrikliai,
                                          StringSplitOptions.RemoveEmptyEntries);

            foreach (string žodis in žodžiai)
                if (Skaičiai(žodis))
                    return žodis;

            return string.Empty;
        }
        /// <summary>
        /// Grąžina ar žodis yra skaičius
        /// </summary>
        /// <param name="žodis">Žodis</param>
        /// <returns>true or false</returns>
        static bool Skaičiai(string žodis)
        {
            if (žodis.Length > 0 && Char.IsDigit(žodis[0]))
            {
                int j = 1;

                while (j < žodis.Length)
                {
                    if (!(Char.IsDigit(žodis[j])))
                        return false;
                    j++;
                }
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Grąžina visus skyriklius po skaičiaus
        /// </summary>
        /// <param name="žodis">Žodis</param>
        /// <returns>Skyrikliai po skaičiaus</returns>
        static string Skyrikliai(string žodis)
        {
            if (žodis.Length > 0 && (Char.IsPunctuation(žodis[0]) ||
                                     Char.IsWhiteSpace(žodis[0])))
            {
                int j = 1;

                string skyriklis = string.Empty + žodis[0];

                while (j < žodis.Length)
                {
                    if (!(Char.IsPunctuation(žodis[j]) ||
                          Char.IsWhiteSpace(žodis[j])))
                        return skyriklis;

                    skyriklis += žodis[j];

                    j++;
                }
                return skyriklis;
            }
            else
                return string.Empty;
        }
    }
}
