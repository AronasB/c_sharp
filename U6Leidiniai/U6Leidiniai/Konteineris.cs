using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U6Leidiniai
{
    internal class Konteineris
    {
        const int CnMax = 1000;
        const int CmMax = 30;
        private Leidiniai[] Leidinys;
        /// <summary>
        /// Leidinių kiekis
        /// </summary>
        public int n { get; set; }
        /// <summary>
        /// Mėnesio dienos
        /// </summary>
        public int m { get; set; }
        private int[,] UzsLeidiniai;
        /// <summary>
        /// Konstruktorius be paremtrų su reikšmėmis
        /// </summary>
        public Konteineris()
        {
            n = 0;
            m = 0;
            Leidinys = new Leidiniai[CnMax];
            UzsLeidiniai = new int[CnMax, CmMax];
        }
        /// <summary>
        /// Grąžina leidinio klasę
        /// </summary>
        /// <param name="nr">leidinio vieta klasėje</param>
        /// <returns>leidinio klasę</returns>
        public Leidiniai Imti(int nr) { return Leidinys[nr]; }
        /// <summary>
        /// Matrica, kiek nupirkta
        /// </summary>
        /// <param name="nNr">leidinių kiekis</param>
        /// <param name="mNr">mėnesio dienos</param>
        /// <returns>kiek nupirkta</returns>
        public int Imti(int nNr, int mNr) { return UzsLeidiniai[nNr, mNr]; }
        /// <summary>
        /// Papildo kopijavimo klasę naujais duomenims
        /// </summary>
        /// <param name="Leidinys1">leidinių klasė</param>
        public void Deti(Leidiniai Leidinys1) { Leidinys[n++] = Leidinys1; }
        /// <summary>
        /// Pakeičia kopijavimo klasę naujais duomenims
        /// </summary>
        /// <param name="nr">vieta</param>
        /// <param name="Leidinys1">leidinių klasė</param>
        public void Deti(int nr, Leidiniai Leidinys1) { Leidinys[nr] = Leidinys1;}
        /// <summary>
        /// Pakeičia matricą naujais duomenims
        /// </summary>
        /// <param name="nNr">vieta leidinio</param>
        /// <param name="mNr">vieta mėnesio dienos</param>
        /// <param name="sk">nupirktų leidinių kiekis</param>
        public void Deti(int nNr, int mNr, int sk) { UzsLeidiniai[nNr, mNr] = sk;}
        /// <summary>
        /// Suskaičiuoja kiek leidinių nupirko iš viso
        /// </summary>
        public void UzsakytaLeidiniu()
        {
            for (int j = 0; j < n; j++)
            {
                int leidiniuSk = 0;
                for (int i = 0; i < m; i++)
                    leidiniuSk += UzsLeidiniai[j, i];
                Leidinys[j].Deti(leidiniuSk);
            }
        }
        /// <summary>
        /// Suskaičiuoja kiek uždirbo leidinys
        /// </summary>
        public void UzdirboLeidiniu()
        {
            double uzdirbo;

            for (int i = 0; i < n; i++)
            {
                uzdirbo = Leidinys[i].UzdirboPinigu();
                Leidinys[i].Deti(uzdirbo);
            }
        }
        /// <summary>
        /// Randa blogiausia pasisekusi kiekį nupirktų leidinių
        /// </summary>
        /// <returns>blogiausia pasisekusis kiekis</returns>
        public int BlogiausiaiSk()
        {
            int blogiausiaiSk = 0;

            for (int i = 0; i < n; i++)
            {
                if (Leidinys[i] < blogiausiaiSk || blogiausiaiSk == 0)
                {
                    blogiausiaiSk = Leidinys[i].ImtiLeidiniuSk();
                }
            }
            return blogiausiaiSk;
        }
        /// <summary>
        /// Suranda visus leidinius, kuriems blogiausia sekėsi parduoti leidinius
        /// </summary>
        /// <param name="blogiausiaiSekas">blogiausia pasisekę leidiniai</param>
        public void BlogiausiaiSekasi(string[] blogiausiaiSekas)
        {
            int blogiausiaiSk,
                kiek = 0;

            blogiausiaiSk = BlogiausiaiSk();

            for (int i = 0; i < n; i++)
            {
                if (Leidinys[i] == blogiausiaiSk)
                {
                    blogiausiaiSekas[kiek++] = Leidinys[i].ImtiPavad();
                }
            }
        }
        /// <summary>
        /// Suranda visų bankų pavadinimus
        /// </summary>
        /// <param name="bankuPav">bankų pavadinimai</param>
        public void Bankai(string[] bankuPav)
        {
            int k = 0;
            bool unikalus;
            for (int i = 0; i < n; i++)
            {
                unikalus = true;
                for (int j = 0; j < bankuPav.Length; j++)
                    if (Leidinys[i] == bankuPav[j])
                    {
                        unikalus = false;
                        break;
                    }
                if (unikalus)
                    bankuPav[k++] = Leidinys[i].ImtiBankas();
            }
        }
        /// <summary>
        /// Daugiausiai uždirbta suma
        /// </summary>
        /// <returns>Uždirbta suma</returns>
        public double DaugiausiaiSk()
        {
            double daugiausiaiSk = 0;

            for (int i = 0; i < n; i++)
            {
                if (Leidinys[i] > daugiausiaiSk || daugiausiaiSk == 0)
                {
                    daugiausiaiSk = Leidinys[i].ImtiUzdarbis();
                }
            }
            return daugiausiaiSk;
        }
        /// <summary>
        /// Daugiausiai uždirbtos sumos leidiniai
        /// </summary>
        /// <param name="daugiausiaiUzdirbs">leidinių pavadinimai</param>
        public void DaugiausiaiUzdirbs(string[] daugiausiaiUzdirbs)
        {
            int kiek = 0;
            double daugiausiaiSk = 0;

            daugiausiaiSk = DaugiausiaiSk();

            for (int i = 0; i < n; i++)
            {
                if (Leidinys[i] == daugiausiaiSk)
                {
                    daugiausiaiUzdirbs[kiek++] = Leidinys[i].ImtiPavad();
                }
            }
        }
        /// <summary>
        /// Tikrina ar klasės duomenys tinkami
        /// </summary>
        /// <returns>true or false</returns>
        public bool Tikrinimas1()
        {
            for (int i = 0; i < n; i++)
                if (!Leidinys[i].Tinkami())
                    return false;

            return true;
        }
        /// <summary>
        /// Tikrina ar matricos duomenys tinkami
        /// </summary>
        /// <returns>true or false</returns>
        public bool Tikrinimas2()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    if (!(UzsLeidiniai[i, j] > 0))
                        return false;

            return true;
        }
    }
}
