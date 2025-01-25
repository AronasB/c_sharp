using System;

namespace U6Leidiniai
{
    /// <summary>
    /// Leidinių duomenų klasė
    /// </summary>
    internal class Leidiniai
    {
        private string pavad,
                       bankas,
                       saskaita;
        private double kaina,
                       procentai,
                       uzdirbo;
        private int leidiniuSk;
        /// <summary>
        /// Konstruktorius be parametrų su duotom reikšmėm
        /// </summary>
        public Leidiniai()
        {
            pavad = string.Empty;
            kaina = 0;
            bankas = string.Empty;
            saskaita = string.Empty;
            procentai = 0;
            leidiniuSk = 0;
            uzdirbo = 0;
        }
        /// <summary>
        /// Deda duomenys į klasę
        /// </summary>
        /// <param name="pavad">Leidinio pavadinimas</param>
        /// <param name="kaina">Leidinio kaina</param>
        /// <param name="bankas">Banko pavadinimas</param>
        /// <param name="saskaita">Sąskaitos numeris</param>
        /// <param name="procentai">
        /// Procentai, atiduodami prenumeratos rinkėjui
        /// </param>
        public void Deti(string pavad, double kaina, string bankas,
                         string saskaita, double procentai)
        {
            this.pavad = pavad;
            this.kaina = kaina;
            this.bankas = bankas;
            this.saskaita = saskaita;
            this.procentai = procentai;
        }
        /// <summary>
        /// Deda leidinių skaičių į klasę
        /// </summary>
        /// <param name="leidiniuSk">Leidinių skaičius</param>
        public void Deti(int leidiniuSk)
        {
            this.leidiniuSk = leidiniuSk;
        }
        /// <summary>
        /// Deda leidinio gautą uždarbį
        /// </summary>
        /// <param name="uzdarbis">Uždarbis</param>
        public void Deti(double uzdarbis)
        {
            this.uzdirbo = uzdarbis;
        }
        /// <summary>
        /// Apskaičiuoja kiek uždirbo pinigų
        /// </summary>
        /// <returns>Uždarbis</returns>
        public double UzdirboPinigu()
        {
            return kaina * leidiniuSk * procentai / 100;
        }
        /// <summary>
        /// Grąžina pavadinimą
        /// </summary>
        /// <returns>pavadinimas</returns>
        public string ImtiPavad() { return pavad; }
        /// <summary>
        /// Grąžina kaina
        /// </summary>
        /// <returns>kaina</returns>
        public double ImtiKaina() { return kaina; }
        /// <summary>
        /// Grąžina banko pavadinimą
        /// </summary>
        /// <returns>banko pavadinimas</returns>
        public string ImtiBankas() { return bankas; }
        /// <summary>
        /// Grąžina sąskaitos numerį
        /// </summary>
        /// <returns>sąskaitos numeris</returns>
        public string ImtiSaskaita() { return saskaita; }
        /// <summary>
        /// Grąžina procentus
        /// </summary>
        /// <returns>procentai</returns>
        public double ImtiProcentai() { return procentai; }
        /// <summary>
        /// Grąžina leidinių skaičių
        /// </summary>
        /// <returns>leidinių skaičius</returns>
        public int ImtiLeidiniuSk() { return leidiniuSk; }
        /// <summary>
        /// Grąžina uždarbį
        /// </summary>
        /// <returns>uždarbis</returns>
        public double ImtiUzdarbis() { return uzdirbo; }
        /// <summary>
        /// Tikrina ar ta pati informacija
        /// </summary>
        /// <param name="obj">objektas</param>
        /// <returns>true or false</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        /// <summary>
        /// grąžina hashcode
        /// </summary>
        /// <returns>hashcode</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>
        /// Grąžina eilute su visais klasės duomenimis
        /// </summary>
        /// <returns>string eilutė</returns>
        public override string ToString()
        {
            string eilute = string.Format("|{0,-18}|{1,6}|{2,-12}|{3,-14}"
                                          + "|{4,6}|{5,8}|{6,8:f}|",
                                          pavad, kaina, bankas, saskaita,
                                          procentai, leidiniuSk, uzdirbo);
            return eilute;
        }
        /// <summary>
        /// Lygina leidinių skaičių
        /// </summary>
        /// <param name="Leidinys1">Objekto duomenų rinkinys</param>
        /// <param name="blogiausiaiSk">Blogiausiai sekančio leidinių skaičius
        /// </param>
        /// <returns>true or false</returns>
        public static bool operator >(Leidiniai Leidinys1, int blogiausiaiSk)
        {
            return Leidinys1.leidiniuSk > blogiausiaiSk;
        }
        /// <summary>
        /// Lygina leidinių skaičių
        /// </summary>
        /// <param name="Leidinys1">Objekto duomenų rinkinys</param>
        /// <param name="blogiausiaiSk">Blogiausiai sekančio leidinių skaičius
        /// </param>
        /// <returns>true or false</returns>
        public static bool operator <(Leidiniai Leidinys1, int blogiausiaiSk)
        {
            return Leidinys1.leidiniuSk < blogiausiaiSk;
        }
        /// <summary>
        /// Lygina uždarbio sumą
        /// </summary>
        /// <param name="Leidinys1">Objekto duomenų rinkinys</param>
        /// <param name="daugiausiaiSk">Daugiausiai uždirbančio leidinių suma
        /// </param>
        /// <returns>true or false</returns>
        public static bool operator >(Leidiniai Leidinys1, double daugiausiaiSk)
        {
            return Leidinys1.uzdirbo > daugiausiaiSk;
        }
        /// <summary>
        /// Lygina uždarbio sumą
        /// </summary>
        /// <param name="Leidinys1">Objekto duomenų rinkinys</param>
        /// <param name="daugiausiaiSk">Daugiausiai uždirbančio leidinių suma
        /// </param>
        /// <returns>true or false</returns>
        public static bool operator <(Leidiniai Leidinys1, double daugiausiaiSk)
        {
            return Leidinys1.uzdirbo < daugiausiaiSk;
        }
        /// <summary>
        /// Lygina leidinių skaičių
        /// </summary>
        /// <param name="Leidinys1">Objekto duomenų rinkinys</param>
        /// <param name="blogiausiaiSk">Blogiausiai sekančio leidinių skaičius
        /// </param>
        /// <returns>true or false</returns>
        public static bool operator ==(Leidiniai Leidinys1, int blogiausiaiSk)
        {
            return Leidinys1.leidiniuSk == blogiausiaiSk;
        }
        /// <summary>
        /// Lygina leidinių skaičių
        /// </summary>
        /// <param name="Leidinys1">Objekto duomenų rinkinys</param>
        /// <param name="blogiausiaiSk">Blogiausiai sekančio leidinių skaičius
        /// </param>
        /// <returns>true or false</returns>
        public static bool operator !=(Leidiniai Leidinys1, int blogiausiaiSk)
        {
            return Leidinys1.leidiniuSk != blogiausiaiSk;
        }
        /// <summary>
        /// Lygina bankų pavadinimus
        /// </summary>
        /// <param name="Leidinys1">Objekto duomenų rinkinys</param>
        /// <param name="bankuPav">Banko pavadinimas</param>
        /// <returns>true or false</returns>
        public static bool operator ==(Leidiniai Leidinys1, string bankuPav)
        {
            return string.Compare(Leidinys1.bankas, bankuPav) == 0;
        }
        /// <summary>
        /// Lygina bankų pavadinimus
        /// </summary>
        /// <param name="Leidinys1">Objekto duomenų rinkinys</param>
        /// <param name="bankuPav">Banko pavadinimas</param>
        /// <returns>true or false</returns>
        public static bool operator !=(Leidiniai Leidinys1, string bankuPav)
        {
            return string.Compare(Leidinys1.bankas, bankuPav) != 0;
        }
        /// <summary>
        /// Lygina uždarbio sumą
        /// </summary>
        /// <param name="Leidinys1">Objekto duomenų rinkinys</param>
        /// <param name="daugiausiaiSk">Daugiausiai uždirbančio leidinių suma
        /// </param>
        /// <returns>true or false</returns>
        public static bool operator ==(Leidiniai Leidinys1, double daugiausiaiSk)
        {
            return Math.Abs(Leidinys1.uzdirbo - daugiausiaiSk) < 0.001;
        }
        /// <summary>
        /// Lygina uždarbio sumą
        /// </summary>
        /// <param name="Leidinys1">Objekto duomenų rinkinys</param>
        /// <param name="daugiausiaiSk">Daugiausiai uždirbančio leidinių suma
        /// </param>
        /// <returns>true or false</returns>
        public static bool operator !=(Leidiniai Leidinys1, double daugiausiaiSk)
        {
            return Math.Abs(Leidinys1.uzdirbo - daugiausiaiSk) > 0.001;
        }
        /// <summary>
        /// Tikrina ar duomenys yra tinkami
        /// </summary>
        /// <returns>true or false</returns>
        public bool Tinkami()
        {
            if (kaina > 0 && procentai > 0)
                return true;
            else
                return false;
        }
    }
}
