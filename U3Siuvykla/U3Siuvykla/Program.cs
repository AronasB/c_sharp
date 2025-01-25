using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net;

namespace U3Siuvykla
{
    /// <summary>
    /// Klasė Kostiumų duomenims saugoti
    /// </summary>
    class Kostiumas
    {
        private string pavadinimas,
                       medžiagosPav;
        private double ilgis,
                       plotis,
                       atraižos;
        /// <summary>
        /// Konstruktorius be parametrų
        /// </summary>
        public Kostiumas()
        {

        }
        /// <summary>
        /// Konstruktorius su parametrais
        /// </summary>
        /// <param name="pavadinimas">Kostiumų modelio pavadinimas</param>
        /// <param name="medžiagosPav">Medžiagos iš kurios gaminama
        /// pavadinimas</param>
        /// <param name="ilgis">Pasiuvimui reikalingas medžiagos ilgis</param>
        /// <param name="plotis">Pasiuvimui reikalingas medžiagos plotis</param>
        /// <param name="atraižos">Atraižų kiekis</param>
        public Kostiumas(string pavadinimas, string medžiagosPav, double ilgis,
                         double plotis, double atraižos)
        {
            this.pavadinimas = pavadinimas;
            this.medžiagosPav = medžiagosPav;
            this.ilgis = ilgis;
            this.plotis = plotis;
            this.atraižos = atraižos;
        }
        /// <summary>
        /// Grąžina kostiumo modelio pavadinimą
        /// </summary>
        /// <returns>Modelio pavadinimas</returns>
        public string ImtiPavadinimą() { return pavadinimas; }
        /// <summary>
        /// Grąžina medžiagos iš kurios gaminama pavadinimą
        /// </summary>
        /// <returns>Medžiagos pavadinimas</returns>
        public string ImtiMedžiagosPav() { return medžiagosPav; }
        /// <summary>
        /// Grąžina pasiuvimui reikalingą medžiagos ilgį
        /// </summary>
        /// <returns>Medžiagos ilgis</returns>
        public double ImtiIlgį() { return ilgis; }
        /// <summary>
        /// Grąžina pvsiuvimui reikalingą medžiagos plotį
        /// </summary>
        /// <returns>Medžiagos plotis</returns>
        public double ImtiPlotį() { return plotis; }
        /// <summary>
        /// Grąžina atraižų kiekį
        /// </summary>
        /// <returns>Atraižų kiekis</returns>
        public double ImtiAtraižas() { return atraižos; }

    }
    internal class Program
    {
        const int Cn = 100;
        const string CFd1 = "..\\..\\Duom1a.txt";
        const string CFd2 = "..\\..\\Duom2a.txt";
        const string CFr = "..\\..\\Rez.txt";
        static void Main(string[] args)
        {
            int kiek1, kiek2, kiek = 0,
                kiekDaug1,
                kiekMaž1,
                daugMedž1, daugMedž2,
                mažAtraižų1;
            string siuvykla1, siuvykla2,
                   daugMedžSiuvykla;
            double vidurkis,
                   procentai,
                   riba1,
                   riba2;
            bool tinka1, tinka2;
            Kostiumas[] Kostiumai1 = new Kostiumas[Cn];
            Kostiumas[] Kostiumai2 = new Kostiumas[Cn];
            Kostiumas[] KostiumaiDaug1 = new Kostiumas[Cn];
            Kostiumas[] KostiumaiMaž1 = new Kostiumas[Cn];
            Kostiumas[] Kostiumai = new Kostiumas[Cn];
            
            if (File.Exists(CFr))
                File.Delete(CFr);
            
            Skaitymas(CFd1, Kostiumai1, out kiek1, out siuvykla1);
            Skaitymas(CFd2, Kostiumai2, out kiek2, out siuvykla2);
            
            Spausdinti(CFr, Kostiumai1, kiek1, siuvykla1);
            Spausdinti(CFr, Kostiumai2, kiek2, siuvykla2);
            
            tinka1 = TikrinimasSkaičiu(CFr, kiek1, Kostiumai1);
            tinka2 = TikrinimasSkaičiu(CFr, kiek2, Kostiumai2);
            
            if (tinka1 && tinka2 && kiek1 != 0 && kiek2 != 0)
            {
                daugMedž1 = DaugMedž(Kostiumai1, kiek1);
                daugMedž2 = DaugMedž(Kostiumai2, kiek2);
                
                Formatuoti1(Kostiumai1, kiek1, daugMedž1, KostiumaiDaug1,
                            out kiekDaug1);
                
                Spausdinti(CFr, KostiumaiDaug1, kiekDaug1, siuvykla1 + " daugiau"+
                           "siai medžiagos");

                mažAtraižų1 = MažAtraižų(Kostiumai1, kiek1);
                
                Formatuoti2(Kostiumai1, kiek1, mažAtraižų1, KostiumaiMaž1,
                            out kiekMaž1);
                
                Spausdinti(CFr, KostiumaiMaž1, kiekMaž1, siuvykla1 + " mažiausia"+
                           "i atraižų");

                daugMedžSiuvykla = DaugMedžSąrašo(Kostiumai1, daugMedž1,
                                                  Kostiumai2, daugMedž2
                                                  ,siuvykla1, siuvykla2);

                SpausdintiRez1(CFr, daugMedžSiuvykla);

                procentai = Procentai();

                vidurkis = Suma(Kostiumai1, kiek1);
                vidurkis += Suma(Kostiumai2, kiek2);
                vidurkis /= (kiek1 + kiek2);
                
                riba1 = Riba(vidurkis, 100 - procentai);
                riba2 = Riba(vidurkis, 100 + procentai);
                
                Formuoti(Kostiumai1, kiek1, Kostiumai, ref kiek, riba1, riba2);
                Formuoti(Kostiumai2, kiek2, Kostiumai, ref kiek, riba1, riba2);

                Spausdinti(CFr, Kostiumai, kiek, "Atitinkantys vidutinio modelio"+
                                                 " kriterijus");
            }
        }
        /// <summary>
        /// Įrašo pradinius duomenis
        /// </summary>
        /// <param name="fv">Tekstinio dokumento failo vieta</param>
        /// <param name="Kostiumai1">Kostiumų duomenų rinkinys</param>
        /// <param name="kiek1">Kostiumų kiekis</param>
        /// <param name="siuvykla1">Siuvyklos pavadinimas</param>
        static void Skaitymas(string fv, Kostiumas[] Kostiumai1, out int kiek1,
                              out string siuvykla1)
        {
            using (StreamReader srautas = new StreamReader(fv))
            {
                string eilute,
                       pavadinimas,
                       medžPav;
                double ilgis,
                       plotis,
                       atraižos;
                kiek1 = 0;
                siuvykla1 = srautas.ReadLine();
                while ((eilute = srautas.ReadLine()) != null && (kiek1 < Cn))
                {
                    string[] eilDalis = eilute.Split("; ".ToCharArray(),
                                           StringSplitOptions.RemoveEmptyEntries);
                    pavadinimas = eilDalis[0];
                    medžPav = eilDalis[1];
                    ilgis = double.Parse(eilDalis[2]);
                    plotis = double.Parse(eilDalis[3]);
                    atraižos = double.Parse(eilDalis[4]);
                    Kostiumai1[kiek1++] = new Kostiumas(pavadinimas, medžPav,
                                                        ilgis, plotis, atraižos);
                }
            }
        }
        /// <summary>
        /// Tikrina ar skaičiai tenkina sąlyga 
        /// </summary>
        /// <param name="fv">Tekstinio failo vieta</param>
        /// <param name="kiek1">Kostiumų kiekis</param>
        /// <param name="Kostiumai1">Kostiumų duomenų rinkinys</param>
        /// <returns></returns>
        static bool TikrinimasSkaičiu(string fv, int kiek1,
                                      Kostiumas[] Kostiumai1)
        {
            for (int i = 0; i < kiek1; i++)
                if (Kostiumai1[i].ImtiIlgį() < 0 || Kostiumai1[i].ImtiPlotį() < 0
                    || Kostiumai1[i].ImtiAtraižas() < 0)
                {
                    using (var fr = File.AppendText(fv))
                        fr.WriteLine("Įvesti neteisingi duomenys!");
                    return false;
                }
            return true;
        }
        /// <summary>
        /// Grąžina medžiagos plotį, kiek reikės medžiagos
        /// </summary>
        /// <param name="Kostiumas1">Kostiumų duomenų rinkinys</param>
        /// <param name="kuris">Skaičiuojomo kostiumo vieta duomenų rinkinyje
        /// </param>
        /// <returns>Medžiagos plotį</returns>
        static double ReikMedž(Kostiumas[] Kostiumas1, int kuris)
        {
            return Kostiumas1[kuris].ImtiPlotį() * Kostiumas1[kuris].ImtiIlgį();
        }
        /// <summary>
        /// Grąžina daugiaisiai medžiagos reikalaujantį kostiumo vietą rinkinyje
        /// </summary>
        /// <param name="Kostiumai1">Kostiumų duomenų rinkinys</param>
        /// <param name="kiek1">Kostiumų kiekis</param>
        /// <returns>Kostiumo duomenų rinkinio vietą</returns>
        static int DaugMedž(Kostiumas[] Kostiumai1, int kiek1)
        {
            int did = 0;
            double daugReikMedž,
                   daugReikMedž1;
            daugReikMedž = ReikMedž(Kostiumai1, did);
            for (int i = 1; i < kiek1; i++)
            {
                daugReikMedž1 = ReikMedž(Kostiumai1, i);
                if (daugReikMedž < daugReikMedž1)
                {
                    did = i;
                    daugReikMedž = ReikMedž(Kostiumai1, did);

                }
            }
            return did;
        }
        /// <summary>
        /// Grąžina mažiausiai atraižų kiekį kostiumo vietą rinkinyje
        /// </summary>
        /// <param name="Kostiumai1">Kostiumų duomenų rinkinys</param>
        /// <param name="kiek1">Kostiumų kiekis</param>
        /// <returns>Kostiumo duomenų rinkinio vietą</returns>
        static int MažAtraižų(Kostiumas[] Kostiumai1, int kiek1)
        {
            int maž = 0;
            for (int i = 1; i < kiek1; i++)
                if (Kostiumai1[maž].ImtiAtraižas() > Kostiumai1[i].ImtiAtraižas())
                    maž = i;
            return maž;
        }
        /// <summary>
        /// Suformuoja Daugiausiai medžiagos pareikalaujanti modelius
        /// </summary>
        /// <param name="Kostiumai1">Kostiumų duomenų rinkinys</param>
        /// <param name="kiek1">Kostiumų skaičius</param>
        /// <param name="daugMedž1">Daugiausiai medžiagos reikalaujantčio
        /// objekto rinkinyje vieta</param>
        /// <param name="KostiumaiDaug1">Daugiausiai medžiagos reikalaujančio
        /// kostiumų duomenų rinkinys</param>
        /// <param name="kiekDaug1">Daugiausiai medžiagos reikalaujančio
        /// kostiumų kiekis</param>
        static void Formatuoti1(Kostiumas[] Kostiumai1, int kiek1, int daugMedž1,
                                Kostiumas[] KostiumaiDaug1, out int kiekDaug1)
        {
            double reikMedž = ReikMedž(Kostiumai1, daugMedž1),
                   reikMedž1;
            kiekDaug1 = 0;
            for (int i = daugMedž1; i < kiek1; i++)
            {
                reikMedž1 = ReikMedž(Kostiumai1, daugMedž1);
                if (Math.Abs(reikMedž - reikMedž1) < 0.001)
                {
                    KostiumaiDaug1[kiekDaug1++] = Kostiumai1[i];
                }
            }
        }
        /// <summary>
        /// Formuoja mažiausiai atraižų reikalaujančių modelius
        /// </summary>
        /// <param name="Kostiumai1">Kostiumų duomenų rinkinys</param>
        /// <param name="kiek1">Kostiumų kiekis</param>
        /// <param name="mažAtraižų1">Mažiausiai atraižų objekto rinkinyje
        /// vieta</param>
        /// <param name="KostiumaiMaž1">Mažiausiai atraižų reikalaujančio
        /// kostiumų duomenų rinkinys</param>
        /// <param name="kiekMaž1">Mažiausiai atraižų reikalaujančio
        /// kostiumų kiekis</param>
        static void Formatuoti2(Kostiumas[] Kostiumai1, int kiek1, int mažAtraižų1
                                , Kostiumas[] KostiumaiMaž1, out int kiekMaž1)
        {
            kiekMaž1 = 0;
            for (int i = mažAtraižų1; i < kiek1; i++)
                if (Math.Abs(Kostiumai1[mažAtraižų1].ImtiAtraižas() - 
                    Kostiumai1[i].ImtiAtraižas()) < 0.001)
                    KostiumaiMaž1[kiekMaž1++] = Kostiumai1[i];
        }
        /// <summary>
        /// Grąžina siuvykla(os) pavadinimą, kurioje daugiausiai reikalauja
        /// kostiumas medžiagos
        /// </summary>
        /// <param name="Kostiumai1">Kostiumų duomenų rinkinys</param>
        /// <param name="daugMedž1">Kostiumų rinkinyje
        /// daugiausiai reikalaujančio medžiagos vietą</param>
        /// <param name="Kostiumai2">Kostiumų duomenų rinkinys</param>
        /// <param name="daugMedž2">Kostiumų rinkinyje
        /// daugiausiai reikalaujančio medžiagos vietą</param>
        /// <param name="siuvykla1">Siuvyklos pavadinimas</param>
        /// <param name="siuvykla2">Siuvyklos pavadinimas</param>
        /// <returns>Siuvyklos pavadinimą(us)</returns>
        static string DaugMedžSąrašo(Kostiumas[] Kostiumai1, int daugMedž1,
                                     Kostiumas[] Kostiumai2, int daugMedž2,
                                     string siuvykla1, string siuvykla2)
        {
            string siuvykla = siuvykla1;
            double daugReikMedž1 = ReikMedž(Kostiumai1, daugMedž1),
                   daugReikMedž2 = ReikMedž(Kostiumai2, daugMedž2);
            if (Math.Abs(daugReikMedž1 - daugReikMedž2) < 0.001)
                siuvykla += " ir " + siuvykla2;
            else if (daugReikMedž1 < daugReikMedž2)
                siuvykla = siuvykla2;
            return siuvykla;
        }
        /// <summary>
        /// Vartotojo prašo įvesti procentus
        /// </summary>
        /// <returns>Procentai</returns>
        static double Procentai()
        {
            double procentai = -1;
            while (procentai < 0)
            {
                Console.WriteLine("Įveskite kiek maksimaliai procentų gali skir" +
                                  "tis kostiumas nuo visų modelių reikalingos m" +
                                  "edžiagos vidurkio:");
                procentai = double.Parse(Console.ReadLine());
            }
            return procentai;
        }
        /// <summary>
        /// Suskaičiuoja bendrą kiekį kiek reikės medžiagos tam tikram sąraše
        /// </summary>
        /// <param name="Kostiumas1">Kostiumo duomenų rinkinys</param>
        /// <param name="kiek1">Kostiumų kiekis</param>
        /// <returns>Tam tikro sąrašo bendrą kiekį medžiagos ploto</returns>
        static double Suma(Kostiumas[] Kostiumas1, int kiek1)
        {
            double suma = 0;
            for (int i = 0; i < kiek1; i++)
                suma += ReikMedž(Kostiumas1, i);
            return suma;
        }
        /// <summary>
        /// Apskaičiuoja tenkinama ribą, kurią galima skaityti prie vidutinių
        /// kostiumų
        /// </summary>
        /// <param name="vidurkis">Bendras kostiumų aritmetinis vidurkis</param>
        /// <param name="procentai">Vartotojo įvesta riba procentais</param>
        /// <returns>Didžiausia arba mažiausia galima riba ploto</returns>
        static double Riba(double vidurkis, double procentai)
        {
            return vidurkis * procentai / 100;
        }
        /// <summary>
        /// Suformuoja naują objekto rinkinį iš kitų objektų pagal tenkinamą
        /// sąlygą
        /// </summary>
        /// <param name="Kostiumai1">Kostiumo duomenų rinkinys</param>
        /// <param name="kiek1">Kostiumų kiekis</param>
        /// <param name="Kostiumai">Kostiumo duomenų rinkinys</param>
        /// <param name="kiek">Kostiumų kiekis</param>
        /// <param name="riba1">Mažiausia galimą ribą ploto</param>
        /// <param name="riba2">Didžiausi galima riba ploto</param>
        static void Formuoti(Kostiumas[] Kostiumai1, int kiek1,
                             Kostiumas[] Kostiumai, ref int kiek, double riba1,
                             double riba2)
        {
            double reikMedž;
            for (int i = 0; i < kiek1; i++)
            {
                reikMedž = ReikMedž(Kostiumai1, i);
                if (reikMedž >= riba1 && reikMedž <= riba2)
                {
                    Kostiumai[kiek] = Kostiumai1[i];
                    kiek++;
                }
            }
        }
        /// <summary>
        /// Spausdina objekto rinkinio duomenis
        /// </summary>
        /// <param name="fv">Tekstinio failo vieta</param>
        /// <param name="Kostiumai1">Kostiumo duomenų rinkinys</param>
        /// <param name="kiek">Kostiumų kiekis</param>
        /// <param name="siuvykla1">Siuvyklos pavadinimas</param>
        static void Spausdinti(string fv, Kostiumas[] Kostiumai1, int kiek,
                           string siuvykla1)
        {
            const string CVirsus = "=------------------------------------------" +
                                   "-----------------= \r\n"+
                                   "| Nr. | Pavadinimas | Medžiagos | Ilgis | P" +
                                   "lotis | Atraižos | \r\n" +
                                   "|     |             |    pav.   |       |  " +
                                   "      |          | \r\n"+
                                   "=------------------------------------------" +
                                   "-----------------=";
            const string CLentele ="| {0,3} | {1,-11} | {2,-9} | {3,5} | {4,6} " +
                                   "| {5,8} | \r\n" +
                                   "=------------------------------------------" +
                                   "-----------------=";
            using (var fr = File.AppendText(fv))
            {
                if (kiek > 0)
                {
                    fr.WriteLine("Siuvyklos pavadinimas: {0}", siuvykla1);
                    fr.WriteLine(CVirsus);
                    for (int i = 0; i < kiek; i++)
                    {
                        fr.WriteLine(CLentele, i + 1,
                                     Kostiumai1[i].ImtiPavadinimą(),
                                     Kostiumai1[i].ImtiMedžiagosPav(),
                                     Kostiumai1[i].ImtiIlgį(),
                                     Kostiumai1[i].ImtiPlotį(),
                                     Kostiumai1[i].ImtiAtraižas());
                    }
                }
                else
                    fr.WriteLine("Duomenų nėra");
                fr.WriteLine();
            }
        }
        /// <summary>
        /// Spausdina, siuvykla(os) pavadinimą, kurioje daugiausiai reikalauja
        /// kostiumas medžiagos
        /// </summary>
        /// <param name="fv">Tekstinio failo vieta</param>
        /// <param name="daugMedžSiuvykla">siuvykla(os) pavadinimą, kurioje
        /// daugiausiai reikalauja kostiumas medžiagos</param>
        static void SpausdintiRez1(string fv, string daugMedžSiuvykla)
        {
            using (var fr = File.AppendText(fv))
                fr.WriteLine("Kostiumas, kuriam reikia daugiausia medžiagos yra" +
                    " {0}\n", daugMedžSiuvykla);
        }
    }
}


