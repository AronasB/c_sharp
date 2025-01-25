using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4KopijavimoDarbai
{
    internal class Darbai
    {
        const int Cn = 100;
        private KopijavimoInfo[] Kopijavimas;
        private int kiek;
        /// <summary>
        /// Konstruktorius be paremtrų su reikšmėmis
        /// </summary>
        public Darbai() 
        {
            kiek = 0;
            Kopijavimas = new KopijavimoInfo[Cn];
        }
        /// <summary>
        /// Grąžina kiekį darbų
        /// </summary>
        /// <returns>kiekis</returns>
        public int Imti() {  return kiek; }
        /// <summary>
        /// Grąžina kopijavimo klasę
        /// </summary>
        /// <param name="i">indeksas</param>
        /// <returns>kopijavimo klasė</returns>
        public KopijavimoInfo Imti(int i) { return Kopijavimas[i]; }
        /// <summary>
        /// Papildo kopijavimo klasę naujais duomenims
        /// </summary>
        /// <param name="Kopijavimas1">Kopijavimo klasė</param>
        public void Deti(KopijavimoInfo Kopijavimas1) { Kopijavimas[kiek++] =
                                                        Kopijavimas1; }
        /// <summary>
        /// Rikiavimo algoritmas
        /// </summary>
        public void Rikiuoti()
        {
            for (int i = 0; i < kiek - 1; i++)
            {
                KopijavimoInfo Kopijavimas1 = Kopijavimas[i];
                int iLaik = i;
                for(int j = i + 1; j < kiek; j++)
                {
                    if (Kopijavimas[j] >= Kopijavimas1)
                    {
                        Kopijavimas1 = Kopijavimas[j];
                        iLaik = j;
                    }
                }
                Kopijavimas[iLaik] = Kopijavimas[i];
                Kopijavimas[i] = Kopijavimas1;
            }
        }
        /// <summary>
        /// Tikrinimas ar duomenys teisingi
        /// </summary>
        /// <returns>true or falses</returns>
        public bool Tikrinimas()
        {
            for (int i = 0; i < kiek; i++)
                if (Kopijavimas[i].Neteisingi())
                    return false;
            return true;
        }
    }
}
