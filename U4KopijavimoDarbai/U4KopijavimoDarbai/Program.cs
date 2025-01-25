using System;
using System.IO;

namespace U4KopijavimoDarbai
{
    internal class Program
    {
        const string CFd = "..\\..\\Duom.txt";
        const string CFr = "..\\..\\Rez.txt";
        static void Main(string[] args)
        {
            Darbai Darbas = new Darbai();
            Darbai Darbas1 = new Darbai();

            int susegFunk,
                skylFunk,
                daugCiklu;

            string formatCiklu;

            if(File.Exists(CFr))
                File.Delete(CFr);

            Skaitymas(CFd, ref Darbas);

            Spausdinti(CFr, Darbas, "Pradiniai duomenys");

            if (Darbas.Tikrinimas() && Darbas.Imti() > 0)
            {
                susegFunk = Skaičiuoti(Darbas, "susegimas");
                skylFunk = Skaičiuoti(Darbas, "skylių išmušimas");

                daugCiklu = Daugiausiai(Darbas);

                formatCiklu = CikluFormatai(Darbas, daugCiklu);

                using (var fr = File.AppendText(CFr))
                {
                    fr.WriteLine();
                    fr.WriteLine(susegFunk + " darbų turi papildomą susegimo" +
                                " funkciją.\n");
                    fr.WriteLine(skylFunk + " darbų turi skylių išmušimo" +
                                " funkciją.\n");
                    fr.WriteLine(formatCiklu +
                                " daugiausiai kopijavimo aparato ciklų" +
                                " reikalaujantis darbas " +
                                Darbas.Imti(daugCiklu).ImtiKopijuSk());
                    fr.WriteLine();
                } 

                Formuoti(Darbas, ref Darbas1);

                Darbas1.Rikiuoti();

                Spausdinti(CFr, Darbas1, "Vienpusio kopijavimo darbai");
            }
        }
        /// <summary>
        /// Įrašo pradinius duomenis
        /// </summary>
        /// <param name="fv">Tekstinio dokumento failo vieta</param>
        /// <param name="Darbas">Konteineris</param>
        static void Skaitymas(string fv, ref Darbai Darbas)
        {
            string formatas,
                   grupavimas,
                   papildFunkcija,
                   eilute;
            int lapuSk,
                kopijuSk,
                vienDvipusis;
            using (StreamReader sr = new StreamReader(fv))
            {
                while ((eilute = sr.ReadLine()) != null)
                {
                    string[] dalys = eilute.Split(';');
                    formatas = dalys[0];
                    lapuSk = int.Parse(dalys[1]);
                    kopijuSk = int.Parse(dalys[2]);
                    vienDvipusis = int.Parse(dalys[3]);
                    grupavimas = dalys[4];
                    papildFunkcija = dalys[5].Trim();
                    KopijavimoInfo Kopijavimas1 = new KopijavimoInfo();
                    Kopijavimas1.Deti(formatas, lapuSk, kopijuSk, vienDvipusis,
                                      grupavimas, papildFunkcija);
                    Darbas.Deti(Kopijavimas1);
                }
            }
        }
        /// <summary>
        /// Grazina bruksnio ilguma
        /// </summary>
        /// <param name="simb">Simbolis</param>
        /// <param name="kiek">Kiek simboliu reikia</param>
        /// <returns>Bruksni</returns>
        static string Bruksnys(char simb, int kiek)
        {
            string eilute = "";
            for (int i = 0; i < kiek; i++)
                eilute += simb;
            return eilute;
        }
        /// <summary>
        /// Spausdina objekto rinkinio duomenis iš konteinerio
        /// </summary>
        /// <param name="fv">Tekstinio failo vieta</param>
        /// <param name="Darbas">Konteineris</param>
        /// <param name="tekstas">Norimas tekstas</param>
        static void Spausdinti(string fv, Darbai Darbas, string tekstas)
        {
            const string CTekstas = "|  Popieriaus  |   Lapų   |  Kopijų  |" +
                                    " Vienpusis   | Grupavimas | Papildoma" +
                                    " kopijos |",
                         CTekstas1 = "|   formatas   | Skaičius | Skaičius |" +
                                     " ar dvipusis |            |   apdorojimo" +
                                     " f.   |";
            using (var fr = File.AppendText(fv))
            {
                if(Darbas.Imti() > 0)
                {
                    fr.WriteLine(tekstas);
                    fr.WriteLine(Bruksnys('=', CTekstas.Length));
                    fr.WriteLine(CTekstas);
                    fr.WriteLine(CTekstas1);
                    fr.WriteLine(Bruksnys('=', CTekstas.Length));
                    for (int i = 0; i < Darbas.Imti(); i++)
                    {
                        fr.WriteLine(Darbas.Imti(i).ToString());
                        fr.WriteLine(Bruksnys('=', CTekstas.Length));
                    }
                }
                else
                    fr.Write("Nėra duomenų");
            }
        }
        /// <summary>
        /// Skaičiuoja darbų turi papildomą funkciją
        /// </summary>
        /// <param name="Darbas">Konstruktorius</param>
        /// <param name="tekstas">Papildomos funkcijos pavadinimas</param>
        /// <returns>kiekis</returns>
        static int Skaičiuoti(Darbai Darbas, string tekstas)
        {
            int kiek = 0;
            for (int i = 0; i < Darbas.Imti(); i++)
                if (Darbas.Imti(i) == tekstas)
                    kiek++;
            return kiek;
        }

        /// <summary>
        /// Randa indeksą daugiausiai kopijavimo aparato ciklų
        /// </summary>
        /// <param name="Darbas">Konstruktorius</param>
        /// <returns>indeksas</returns>
        static int Daugiausiai(Darbai Darbas)
        {
            int did = 0;
            for (int i = 1; i < Darbas.Imti(); i++)
                if (Darbas.Imti(i) > Darbas.Imti(did))
                    did = i;
            return did;
        }
        /// <summary>
        /// Suranda visas didziausius darbų ciklus
        /// </summary>
        /// <param name="Darbas">Konteineris</param>
        /// <param name="daugCiklu">Indeksas daugiausiai ciklų</param>
        /// <returns>formatas</returns>
        static string CikluFormatai(Darbai Darbas, int daugCiklu)
        {
            string formatas = string.Empty;
            for (int i = 0; i < Darbas.Imti(); i++)
                if (Darbas.Imti(i).Equals(Darbas.Imti(daugCiklu)))
                {
                    if (formatas != string.Empty)
                        formatas += ", ";
                    formatas += Darbas.Imti(i).ImtiFormatas();
                }
            return formatas;
        }
        /// <summary>
        /// Suformuoja nauja vienpusio kopijavimo darbai konteineri
        /// </summary>
        /// <param name="Darbas">Konteineris</param>
        /// <param name="Darbas1">Konteineris</param>
        static void Formuoti(Darbai Darbas, ref Darbai Darbas1)
        {
            for (int i = 0; i < Darbas.Imti(); i++)
                if (~Darbas.Imti(i))
                    Darbas1.Deti(Darbas.Imti(i));
        }
    }
}
