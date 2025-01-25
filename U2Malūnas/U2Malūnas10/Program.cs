using System;
using System.Text;

namespace Malūnas10
{
    /// <summary>
    /// Klasė grūdų duomenims aprašyti
    /// </summary>
    class Grūdai
    {
        private string rūšis;
        private int rupumas;
        private double nuostoliai;
        private int tankis;
        /// <summary>
        /// Konstruktorius su parametrais
        /// </summary>
        /// <param name="rūšis"></param>
        /// <param name="rupumas"></param>
        /// <param name="nuostoliai"></param>
        /// <param name="tankis"></param>
        public Grūdai(string rūšis, int rupumas, double nuostoliai, int tankis)
        {
            this.rūšis = rūšis;
            this.rupumas = rupumas;
            this.nuostoliai = nuostoliai;
            this.tankis = tankis;
        }
        /// <summary>
        /// Grąžina grūdų rūšį
        /// </summary>
        /// <returns>Rūšį</returns>
        public string ImtiRūšį() { return rūšis; }
        /// <summary>
        /// Grąžina grūdų rupumą
        /// </summary>
        /// <returns>Rupumą</returns>
        public int ImtiRupumas() { return rupumas; }
        /// <summary>
        /// Grąžina grūdų malimo nuostolius procentais
        /// </summary>
        /// <returns>Nuostolius</returns>
        public double ImtiNuostoliai() { return nuostoliai; }
        /// <summary>
        /// Grąžina grūdų tankį kg/m^3
        /// </summary>
        /// <returns>Tankį</returns>
        public int ImtiTankis() { return tankis; }
    }
    /// <summary>
    /// Klasė malūno duomenims aprašyti
    /// </summary>
    class Malūnas
    {
        private string pavadinimas;
        private double miltųKiekis1,
                       miltųKiekis2,
                       miltųKiekis3,
                       talpyklostūris;
        /// <summary>
        /// Konstruktorius su parametrais
        /// </summary>
        /// <param name="pavadinimas"></param>
        /// <param name="miltųKiekis1">Malūne skirtas miltų kiekis tonomis
        /// saugoti per mėnesį 1 grūdų rūšiai</param>
        /// <param name="miltųKiekis2">Malūne skirtas miltų kiekis tonomis
        /// saugoti per mėnesį 2 grūdų rūšiai</param>
        /// <param name="miltųKiekis3">Malūne skirtas miltų kiekis tonomis
        /// saugoti per mėnesį 3 grūdų rūšiai</param>
        /// <param name="talpyklostūris">Malūne bendras miltų saugyklos tūris
        /// litrais</param>
        public Malūnas(string pavadinimas, double miltųKiekis1,
                       double miltųKiekis2
                     , double miltųKiekis3, double talpyklostūris)
        {
            this.pavadinimas = pavadinimas;
            this.miltųKiekis1 = miltųKiekis1;
            this.miltųKiekis2 = miltųKiekis2;
            this.miltųKiekis3 = miltųKiekis3;
            this.talpyklostūris = talpyklostūris;
        }
        /// <summary>
        /// Grąžina malūno pavadinimą
        /// </summary>
        /// <returns>Malūno pavadinimas</returns>
        public string ImtiPavadinimą() { return pavadinimas; }
        /// <summary>
        /// Grąžina kiekį tonomis kiek reikia saugoti miltų per mėnesį
        /// </summary>
        /// <returns>1 rūšies reikalinga miltų kiekį</returns>
        public double ImtimiltųKiekį1() { return miltųKiekis1; }
        /// <summary>
        /// Grąžina kiekį tonomis kiek reikia saugoti miltų per mėnesį
        /// </summary>
        /// <returns>2 rūšies reikalinga miltų kiekį</returns>
        public double ImtimiltųKiekį2() { return miltųKiekis2; }
        /// <summary>
        /// Grąžina kiekį tonomis kiek reikia saugoti miltų per mėnesį
        /// </summary>
        /// <returns>3 rūšies reikalinga miltų kiekį</returns>
        public double ImtimiltųKiekį3() { return miltųKiekis3; }
        /// <summary>
        /// Grąžina malūno talpyklos tūrį litrais
        /// </summary>
        /// <returns>Talpyklos tūris</returns>
        public double ImtiTalpyklosTūrį() { return talpyklostūris; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Grūdai grūdai1,
                   grūdai2,
                   grūdai3;
            Malūnas malūnas;
            //
            Console.OutputEncoding = Encoding.UTF8;
            // Įvedami duomenys į klases
            grūdai1 = Skaitymas(1);
            grūdai2 = Skaitymas(2);
            grūdai3 = Skaitymas(3);
            malūnas = Skaitymas1(grūdai1, grūdai2, grūdai3);
            //
            Console.Clear();
            //grūdai1 = new Grūdai("Kviečiai", 1000, 20.1, 150);
            //grūdai2 = new Grūdai("Javai", 900, 15, 100);
            //grūdai3 = new Grūdai("Grikiai", 1000, 20.12, 156);
            //malūnas = new Malūnas("Perkūnas", 2.1, 1.8, 2, 55000);
            Skaičiavimai(grūdai1, grūdai2, grūdai3, malūnas);
        }
        /// <summary>
        /// Grąžina duomenis iš įvestų į consolę duomenų reikalingus grūdų klasei
        /// </summary>
        /// <param name="i">Kelintos rūšies grūdai</param>
        /// <returns>Grūdų duomenis</returns>
        static Grūdai Skaitymas(int i)
        {
            string rūšis;
            int rupumas;
            double nuostoliai;
            int tankis;
            Console.WriteLine("Įveskite {0} grūdų rūšį: ", i);
            rūšis = Console.ReadLine();
            Console.WriteLine("Įveskite {0} grūdų rupumą (kiek sėlenų liko): ",
                              i);
            rupumas = int.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite {0} grūdų malimo nuostolį (procentais): ",
                              i);
            nuostoliai = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite {0} grūdų tankį (kg/m^3): ", i);
            tankis = int.Parse(Console.ReadLine());
            return new Grūdai(rūšis, rupumas, nuostoliai, tankis);
        }
        /// <summary>
        /// Grąžina duomenis iš įvestų į consolę duomenų reikalingus malūno klasei
        /// </summary>
        /// <param name="grūdai1">1 rūšies grūdų duomenų rinkinys</param>
        /// <param name="grūdai2">2 rūšies grūdų duomenų rinkinys</param>
        /// <param name="grūdai3">3 rūšies grūdų duomenų rinkinys</param>
        /// <returns>Malūno duomenis</returns>
        static Malūnas Skaitymas1(Grūdai grūdai1, Grūdai grūdai2, Grūdai grūdai3)
        {
            string pavadinimas;
            double miltųKiekis1,
                   miltųKiekis2,
                   miltųKiekis3,
                   talpyklostūris;
            Console.WriteLine("Įveskite malūno pavadinimą: ");
            pavadinimas = Console.ReadLine();
            Console.WriteLine("Įveskite kiek per mėnesį tonų reikalinga gauti " +
                              "miltų kiekį iš rūšies {0}", grūdai1.ImtiRūšį());
            miltųKiekis1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite kiek per mėnesį tonų reikalinga gauti" +
                              " miltų kiekį iš rūšies {0}", grūdai2.ImtiRūšį());
            miltųKiekis2 = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite kiek per mėnesį tonų reikalinga gauti" +
                              " miltų kiekį iš rūšies {0}", grūdai3.ImtiRūšį());
            miltųKiekis3 = double.Parse(Console.ReadLine());
            Console.WriteLine("Įveskite talpykos tūrį (litrais):");
            talpyklostūris = double.Parse(Console.ReadLine());
            return new Malūnas(pavadinimas, miltųKiekis1, miltųKiekis2, 
                                miltųKiekis3, talpyklostūris);
        }
        /// <summary>
        /// Atlieka skaičiavimus jeigu duomenys yra įvesti teisingi
        /// </summary>
        /// <param name="grūdai1">1 rūšies grūdų duomenų rinkinys</param>
        /// <param name="grūdai2">2 rūšies grūdų duomenų rinkinys</param>
        /// <param name="grūdai3">3 rūšies grūdų duomenų rinkinys</param>
        /// <param name="malūnas">Malūno duomenų rinkinys</param>
        static void Skaičiavimai(Grūdai grūdai1, Grūdai grūdai2, Grūdai grūdai3,
                                 Malūnas malūnas)
        {
            string rupiausi,
                   mažNuostoliai;
            double reikiaGrūdų1,
                   reikiaGrūdų2,
                   reikiaGrūdų3,
                   talpykla;
            bool telpa;
            if (!(Tikrinimas1(grūdai1) && Tikrinimas1(grūdai2) && 
                  Tikrinimas1(grūdai3) && Tikrinimas2(malūnas)))
            {
                Console.WriteLine("Įvesti neteisingi duomenys");
            }
            else
            {
                // Skaičiavimai
                rupiausi = Rupiausi(grūdai1, grūdai2, grūdai3);
                mažNuostoliai = MažiausiNuostoliai(grūdai1, grūdai2, grūdai3);
                reikiaGrūdų1 = KiekReikiaGrūdų(grūdai1.ImtiNuostoliai(),
                                               malūnas.ImtimiltųKiekį1());
                reikiaGrūdų2 = KiekReikiaGrūdų(grūdai2.ImtiNuostoliai(), 
                                               malūnas.ImtimiltųKiekį2());
                reikiaGrūdų3 = KiekReikiaGrūdų(grūdai3.ImtiNuostoliai(),
                                               malūnas.ImtimiltųKiekį3());
                talpykla = KiekReikiaVisoTalpos(reikiaGrūdų1, reikiaGrūdų2,
                                                reikiaGrūdų3, grūdai1, grūdai2,
                                                grūdai3);
                telpa = ArTelpa(malūnas, talpykla);
                // Spausdinami gauti duomenys į consolę
                Spausdinti1(grūdai1, grūdai2, grūdai3);
                Spausdinti2(malūnas);
                Spausdinti3(rupiausi, mažNuostoliai, reikiaGrūdų1,
                            reikiaGrūdų2, reikiaGrūdų3, grūdai1, grūdai2,
                            grūdai3, telpa);
            }
        }
        /// <summary>
        /// Tikrina ar įvesti grūdų rinkinio duomenys yra tinkami
        /// </summary>
        /// <param name="grūdai">Tam tikros rūšies grūdų duomenų rinkinys</param>
        /// <returns>True or false</returns>
        static bool Tikrinimas1(Grūdai grūdai)
        {
            if (grūdai.ImtiRupumas() > 0 && grūdai.ImtiNuostoliai() > 0
                && grūdai.ImtiTankis() > 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Tikrina ar įvesti malūno rinkinio duomenys yra tinkami
        /// </summary>
        /// <param name="malūnas">Malūno duomenų rinkinys</param>
        /// <returns>True or false</returns>
        static bool Tikrinimas2(Malūnas malūnas)
        {
            if (malūnas.ImtimiltųKiekį1() >= 0 && malūnas.ImtimiltųKiekį2() >= 0
                && malūnas.ImtimiltųKiekį3() >= 0
                && malūnas.ImtiTalpyklosTūrį() >= 0)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Randa, kuri rūšis rupiausia
        /// </summary>
        /// <param name="grūdai1">1 rūšies grūdų duomenų rinkinys</param>
        /// <param name="grūdai2">2 rūšies grūdų duomenų rinkinys</param>
        /// <param name="grūdai3">3 rūšies grūdų duomenų rinkinys</param>
        /// <returns>Rupiausia grūdų rūšį</returns>
        static string Rupiausi(Grūdai grūdai1, Grūdai grūdai2, Grūdai grūdai3)
        {
            string rupiausi = grūdai1.ImtiRūšį();
            int rupumas = grūdai1.ImtiRupumas();
            if (grūdai1.ImtiRupumas() == grūdai2.ImtiRupumas() &&
                grūdai2.ImtiRupumas() == grūdai3.ImtiRupumas())
                return grūdai1.ImtiRūšį() + ", " + grūdai2.ImtiRūšį() + ", "
                       + grūdai3.ImtiRūšį();
            if (rupumas < grūdai2.ImtiRupumas())
            {
                rupiausi = grūdai2.ImtiRūšį();
                rupumas = grūdai2.ImtiRupumas();
            }
            if (rupumas < grūdai3.ImtiRupumas())
            {
                rupiausi = grūdai3.ImtiRūšį();
                rupumas = grūdai3.ImtiRupumas();
            }
            if (rupumas == grūdai1.ImtiRupumas() &&
                grūdai1.ImtiRupumas() == grūdai2.ImtiRupumas())
                return grūdai1.ImtiRūšį() + ", " + grūdai2.ImtiRūšį();
            if (rupumas == grūdai1.ImtiRupumas() &&
                grūdai1.ImtiRupumas() == grūdai3.ImtiRupumas())
                return grūdai1.ImtiRūšį() + ", " + grūdai3.ImtiRūšį();
            if (rupumas == grūdai2.ImtiRupumas() &&
                grūdai2.ImtiRupumas() == grūdai3.ImtiRupumas())
                return grūdai2.ImtiRūšį() + ", " + grūdai3.ImtiRūšį();
            return rupiausi;
        }
        /// <summary>
        /// Randa rūšį, kuri malimo metu patiria mažiausiai nuostolių
        /// </summary>
        /// <param name="grūdai1">1 rūšies grūdų duomenų rinkinys</param>
        /// <param name="grūdai2">2 rūšies grūdų duomenų rinkinys</param>
        /// <param name="grūdai3">3 rūšies grūdų duomenų rinkinys</param>
        /// <returns>Mažiausiai malimo nuostolių patiriančia rūšį</returns>
        static string MažiausiNuostoliai(Grūdai grūdai1, Grūdai grūdai2,
                                         Grūdai grūdai3)
        {
            string mažNuostoliai = grūdai1.ImtiRūšį();
            double nuostoliai = grūdai1.ImtiNuostoliai();
            if (Math.Abs(grūdai1.ImtiNuostoliai() - grūdai2.ImtiNuostoliai())
                < 0.001
                && Math.Abs(grūdai2.ImtiNuostoliai() - grūdai3.ImtiNuostoliai())
                < 0.001)
                return grūdai1.ImtiRūšį() + ", " + grūdai2.ImtiRūšį() + ", "
                       + grūdai3.ImtiRūšį();
            if (nuostoliai > grūdai2.ImtiNuostoliai())
            {
                mažNuostoliai = grūdai2.ImtiRūšį();
                nuostoliai = grūdai2.ImtiNuostoliai();
            }
            if (nuostoliai > grūdai3.ImtiNuostoliai())
            {
                mažNuostoliai = grūdai3.ImtiRūšį();
                nuostoliai = grūdai3.ImtiNuostoliai();
            }
            if (Math.Abs(nuostoliai - grūdai1.ImtiNuostoliai()) < 0.001 &&
                Math.Abs(grūdai1.ImtiNuostoliai() - grūdai2.ImtiNuostoliai())
                < 0.001)
                return grūdai1.ImtiRūšį() + ", " + grūdai2.ImtiRūšį();
            if (Math.Abs(nuostoliai - grūdai1.ImtiNuostoliai()) < 0.001 &&
                Math.Abs(grūdai1.ImtiNuostoliai() - grūdai3.ImtiNuostoliai())
                < 0.001)
                return grūdai1.ImtiRūšį() + ", " + grūdai3.ImtiRūšį();
            if (Math.Abs(nuostoliai - grūdai2.ImtiNuostoliai()) < 0.001 &&
                Math.Abs(grūdai2.ImtiNuostoliai() - grūdai3.ImtiNuostoliai())
                < 0.001)
                return grūdai2.ImtiRūšį() + ", " + grūdai3.ImtiRūšį();
            return mažNuostoliai;
        }
        /// <summary>
        /// Grąžiną, kiek reikia tonomis grūdų prieš malimą, norint gauti
        /// reikalingą kiekį per mėnesį saugoti tos rūšies grūdų
        /// </summary>
        /// <param name="nuostoliai">Tam tikros rūšies grūdų patiriamas malimo
        /// metu nuostolis</param>
        /// <param name="miltųKiekis">Kiek reikia tonų per mėnesį tam tikros
        /// rūšies grūdų saugoti malūne</param>
        /// <returns>Kiek reikia grūdų sumalti tam tikrą paskirtą kiekį tonomis
        /// per mėnesį</returns>
        static double KiekReikiaGrūdų(double nuostoliai, double miltųKiekis)
        {
            return miltųKiekis * 100 / (100 - nuostoliai);
        }
        /// <summary>
        /// Grąžina atsakymą ar tilps visi miltai malūno talpykloje jei
        /// saugosime visus rūšies sumaltus miltus
        /// </summary>
        /// <param name="malūnas">Malūno duomenų rinkinys</param>
        /// <param name="talpykla">Kiek išviso talpos reikėtų saugojant visus
        /// grūdus talpykloje</param>
        /// <returns>True or false</returns>
        static bool ArTelpa(Malūnas malūnas, double talpykla)
        {
            if (talpykla > malūnas.ImtiTalpyklosTūrį() / 1000)
                return false;
            else
                return true;
        }
        /// <summary>
        /// Kiek išviso talpos reikėtų saugojant visus grūdus talpykloje
        /// </summary>
        /// <param name="reikiaGrūdų1">Sumaltų 1 rūšies grūdų masė</param>
        /// <param name="reikiaGrūdų2">Sumaltų 2 rūšies grūdų masė</param>
        /// <param name="reikiaGrūdų3">Sumaltų 3 rūšies grūdų masė</param>
        /// <param name="grūdai1">1 rūšies grūdų duomenų rinkinys</param>
        /// <param name="grūdai2">2 rūšies grūdų duomenų rinkinys</param>
        /// <param name="grūdai3">3 rūšies grūdų duomenų rinkinys</param>
        /// <returns>Visų sumaltų per mėnesį grūdų tūrį</returns>
        static double KiekReikiaVisoTalpos(double reikiaGrūdų1,
                                           double reikiaGrūdų2,
                                           double reikiaGrūdų3,
                                           Grūdai grūdai1,
                                           Grūdai grūdai2,
                                           Grūdai grūdai3)
        {
            double talpykla;
            talpykla = KiekReikiaGrūduiTalpos(reikiaGrūdų1,grūdai1.ImtiTankis());
            talpykla += KiekReikiaGrūduiTalpos(reikiaGrūdų2,grūdai2.ImtiTankis());
            talpykla += KiekReikiaGrūduiTalpos(reikiaGrūdų3,grūdai3.ImtiTankis());
            return talpykla;
        }
        /// <summary>
        /// Apskaičiuoja kiem tam tikors rūšies grūdų pareikalautų per mėnesį
        /// vietos
        /// </summary>
        /// <param name="reikiaGrūdų">Sumaltų grūdų masė</param>
        /// <param name="tankis">Sumaltų grūdų tankis</param>
        /// <returns>Tam tikros rūšies sumaltų grūdų tūrį</returns>
        static double KiekReikiaGrūduiTalpos(double reikiaGrūdų, double tankis)
        {
            return reikiaGrūdų * 1000 / tankis;
        }
        /// <summary>
        /// Spausdina konsolėje įvestus duomenis
        /// </summary>
        /// <param name="grūdai1">1 rūšies grūdų duomenų rinkinys</param>
        /// <param name="grūdai2">2 rūšies grūdų duomenų rinkinys</param>
        /// <param name="grūdai3">3 rūšies grūdų duomenų rinkinys</param>
        static void Spausdinti1(Grūdai grūdai1, Grūdai grūdai2, Grūdai grūdai3)
        {
            const string CViršus = "Grūdų rūšis | Grūdų rupumas | Grūdų malimo" +
                                   " nuostolis | Grūdų tankis";
            const string CLinija = "-------------------------------------------" +
                                   "------------------------";
            Console.WriteLine(CLinija);
            Console.WriteLine(CViršus);
            Console.WriteLine(CLinija);
            Console.WriteLine(String.Format("{0,-11} | {1,13} | {2,22} | {3,11}",
                              grūdai1.ImtiRūšį(), grūdai1.ImtiRupumas(),
                              grūdai1.ImtiNuostoliai(), grūdai1.ImtiTankis()));
            Console.WriteLine(CLinija);
            Console.WriteLine(String.Format("{0,-11} | {1,13} | {2,22} | {3,11}",
                              grūdai2.ImtiRūšį(), grūdai2.ImtiRupumas(),
                              grūdai2.ImtiNuostoliai(), grūdai2.ImtiTankis()));
            Console.WriteLine(CLinija);
            Console.WriteLine(String.Format("{0,-11} | {1,13} | {2,22} | {3,11}",
                              grūdai3.ImtiRūšį(), grūdai3.ImtiRupumas(),
                              grūdai3.ImtiNuostoliai(), grūdai3.ImtiTankis()));
            Console.WriteLine(CLinija);
        }
        /// <summary>
        /// Spausdina malūno duomenis
        /// </summary>
        /// <param name="malūnas">Malūno duomenų rinkinys</param>
        static void Spausdinti2(Malūnas malūnas)
        {
            const string CViršus = "                     | Kiek  reikia | Kiek"
                                 + "  reikia | Kiek  reikia  |             \n"
                                 + " Malūno  pavadinimas | per  mėnesį  | per  "
                                 + "mėnesį  | per  mėnesį   | Malūno talpa\n"
                                 + "                     | gauti miltų 1| gauti"
                                 + " miltų 2| gauti miltų 3 |               ";
            const string CLinija = "------------------------------------------"
                                 + "---------------------------------------";
            Console.WriteLine("\n" + CLinija);
            Console.WriteLine(CViršus);
            Console.WriteLine(CLinija);
            Console.WriteLine(String.Format("{0,-20} | {1,10:f} t | {2,10:f} t"
                                            + " | {3,10:f} t  | {4,10} l",
                              malūnas.ImtiPavadinimą(), malūnas.ImtimiltųKiekį1(),
                              malūnas.ImtimiltųKiekį2(),malūnas.ImtimiltųKiekį3(),
                              malūnas.ImtiTalpyklosTūrį()));
            Console.WriteLine(CLinija + "\n");
        }
        /// <summary>
        /// Spausdina konsolėje rastus ar apskaičiuotus duomenis
        /// </summary>
        /// <param name="rupiausi">rupiausiams grūdų rūšis</param>
        /// <param name="mažNuostoliai">mažiausiai malimo nuostolių patirianti
        /// rūšis</param>
        /// <param name="reikiaGrūdų1">Kiek reikia tonomis grūdų prieš malimą,
        /// norint gauti reikalingą kiekį per mėnesį 
        /// saugoti 1 rūšies grūdų</param>
        /// <param name="reikiaGrūdų2">Kiek reikia tonomis grūdų prieš malimą,
        /// norint gauti reikalingą kiekį per mėnesį 
        /// saugoti 2 rūšies grūdų</param>
        /// <param name="reikiaGrūdų3">Kiek reikia tonomis grūdų prieš malimą,
        /// norint gauti reikalingą kiekį per mėnesį 
        /// saugoti 3 rūšies grūdų</param>
        /// <param name="grūdai1">1 rūšies grūdų duomenų rinkinys</param>
        /// <param name="grūdai2">2 rūšies grūdų duomenų rinkinys</param>
        /// <param name="grūdai3">3 rūšies grūdų duomenų rinkinys</param>
        /// <param name="telpa">Atsako ar tilps į malūno saugyklą visas
        /// sreikalingas kiekis grūdų per mėnesį</param>
        static void Spausdinti3(string rupiausi, string mažNuostoliai,
                                double reikiaGrūdų1, double reikiaGrūdų2,
                                double reikiaGrūdų3, Grūdai grūdai1,
                                Grūdai grūdai2, Grūdai grūdai3, bool telpa)
        {
            Console.WriteLine("Rupiausi - {0}", rupiausi);
            Console.WriteLine("Malimo nuostoliai mažiausi - {0}", mažNuostoliai);
            Console.WriteLine("Pristatyti kiekvieną mėnesį į malūna reikės:\n{0}"
                               + " - {1:f} t, {2} - {3:f} t, {4} - {5:f} t",
                             grūdai1.ImtiRūšį(), reikiaGrūdų1, grūdai2.ImtiRūšį(),
                             reikiaGrūdų2, grūdai3.ImtiRūšį(), reikiaGrūdų3);
            Console.WriteLine("Ar malūno per mėnesį primaltas miltų kiekis telpa"
                               + " talpyklose: {0}", telpa);
        }
    }
}
