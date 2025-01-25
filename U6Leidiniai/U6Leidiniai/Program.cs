using System;
using System.IO;

namespace U6Leidiniai
{
    internal class Program
    {
        const string CFd = "..\\..\\Duom.txt";
        const string CFr = "..\\..\\Rez.txt";
        static void Main(string[] args)
        {
            Konteineris konteineris = new Konteineris();

            Skaityti(CFd, ref konteineris);

            if (File.Exists(CFr))
                File.Delete(CFr);

            if (konteineris.n != 0)
            {
                Spausdinti(konteineris, "Pradiniai duomenys", CFr);

                if (konteineris.Tikrinimas1() && konteineris.Tikrinimas2())
                {
                    konteineris.UzsakytaLeidiniu();

                    Spausdinti(konteineris, "Rezultatai", CFr);

                    konteineris.UzdirboLeidiniu();

                    Spausdinti(konteineris, "Rezultatai", CFr);

                    string[] blogiausiaiSekas = new string[konteineris.n];

                    konteineris.BlogiausiaiSekasi(blogiausiaiSekas);

                    using (var fr = File.AppendText(CFr))
                    {
                        fr.Write("Blogiausiai sekas ");

                        for (int i = 0; i < blogiausiaiSekas.Length &&
                             blogiausiaiSekas[i] != null; i++)
                            fr.Write(blogiausiaiSekas[i] + " ");

                        fr.WriteLine("\n");
                    }

                    string[] bankuPav = new string[konteineris.n];

                    konteineris.Bankai(bankuPav);

                    BankoSarasas(konteineris, bankuPav, CFr);

                    string[] daugiausiaiUzdirbs = new string[konteineris.n];

                    konteineris.DaugiausiaiUzdirbs(daugiausiaiUzdirbs);

                    using (var fr = File.AppendText(CFr))
                    {
                        fr.Write("Daugiausiai uždirbs ");

                        for (int i = 0; i < daugiausiaiUzdirbs.Length &&
                             daugiausiaiUzdirbs[i] != null; i++)
                            fr.Write(daugiausiaiUzdirbs[i] + " ");
                    }
                }
                else
                {
                    using (var fr = File.AppendText(CFr))
                    {
                        fr.WriteLine("Neteisingi duomenys");
                    }
                }
            }
            else
            {
                using (var fr = File.AppendText(CFr))
                {
                    fr.WriteLine("Nėra duomenų");
                }
            }
        }
        /// <summary>
        /// Skaito duomenus
        /// </summary>
        /// <param name="fd">duomenų failas</param>
        /// <param name="konteineris">konteineris</param>
        static void Skaityti(string fd, ref Konteineris konteineris)
        {
            string pavad, bankas, saskaita, eilute;
            double kaina, procentai;
            int leidiniuSk;

            using (StreamReader reader = new StreamReader(fd))
            {
                eilute = reader.ReadLine();
                string[] dalys;
                
                if (eilute != null)
                {
                    dalys = eilute.Split("; ".ToCharArray(),
                                     StringSplitOptions.RemoveEmptyEntries);
                    
                    konteineris.n = int.Parse(dalys[0]);
                    konteineris.m = int.Parse(dalys[1]);
                    
                    for (int i = 0; i < konteineris.n; i++)
                    {
                        eilute = reader.ReadLine();
                        dalys = eilute.Split(';');
                        pavad = dalys[0].Trim();
                        kaina = double.Parse(dalys[1]);
                        bankas = dalys[2].Trim();
                        saskaita = dalys[3].Trim();
                        procentai = double.Parse(dalys[4]);
                        
                        Leidiniai Leidinys1;
                        
                        Leidinys1 = new Leidiniai();
                        
                        Leidinys1.Deti(pavad, kaina, bankas, saskaita, procentai);
                        konteineris.Deti(i, Leidinys1);
                    }
                    for (int i = 0; i < konteineris.n; i++)
                    {
                        eilute = reader.ReadLine();
                        dalys = eilute.Split(';');
                        
                        for (int j = 0; j < konteineris.m; j++)
                        {
                            leidiniuSk = int.Parse(dalys[j]);
                            konteineris.Deti(i, j, leidiniuSk);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Spausdina duomenis
        /// </summary>
        /// <param name="konteineris">konteineris</param>
        /// <param name="antraste">antraštė</param>
        /// <param name="fv">Rezultatų failas</param>
        static void Spausdinti(Konteineris konteineris, string antraste,
                               string fv)
        {
            using (var fr = File.AppendText(fv))
            {
                string lentele = new string('=', 80);
                
                fr.WriteLine(antraste + "\n");
                
                fr.WriteLine("Leidinių skaičius {0}, mėnesio dienų skaičius {1}",
                                  konteineris.n, konteineris.m);
                
                fr.WriteLine(lentele);
                
                fr.WriteLine("|{0,-18}|{1,-6}|{2,-12}|{3,-14}" +
                             "|{4,-6}|{5,-8}|{6,-8}|",
                             "Leidinys", "Kaina", "Bankas", "Saskaita",
                             "Proc", "Leid sk", "Uzdarbis");
                
                fr.WriteLine(lentele);
                
                for (int i = 0; i < konteineris.n; i++)
                    fr.WriteLine(konteineris.Imti(i).ToString());
                
                fr.WriteLine(lentele + "\n");
                
                fr.WriteLine("Leidiniu užsakymai:");
                
                for (int i = 0; i < konteineris.n; i++)
                {
                    for (int j = 0; j < konteineris.m; j++)
                        fr.Write("{0,5} ", konteineris.Imti(i, j));
                    fr.Write("\n");
                }
                
                fr.WriteLine();
            }
        }
        /// <summary>
        /// Spausdina kiekvieno banko sąrašą
        /// </summary>
        /// <param name="konteineris">konteineris</param>
        /// <param name="bankuPav">bankų pavadinimai</param>
        /// <param name="fv">rezultatų failas</param>
        static void BankoSarasas(Konteineris konteineris, string[] bankuPav,
                                 string fv)
        {
            for (int i = 0; i < bankuPav.Length && bankuPav[i] != null; i++)
            {
                Konteineris konteinerisLaikinas = new Konteineris();

                konteinerisLaikinas.m = konteineris.m;

                for (int j = 0; j < konteineris.n; j++)
                {
                    if (konteineris.Imti(j) == bankuPav[i])
                    {
                        konteinerisLaikinas.Deti(konteineris.Imti(j));

                        for (int z = 0; z < konteineris.m; z++)
                        {
                            konteinerisLaikinas.Deti(konteinerisLaikinas.n - 1, z,
                                                     konteineris.Imti(j, z));
                        }
                    }
                }
                Spausdinti(konteinerisLaikinas, bankuPav[i], fv);
            }
        }
    }
}
