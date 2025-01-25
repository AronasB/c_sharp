using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U4KopijavimoDarbai
{
    internal class KopijavimoInfo
    {
        private string formatas,
                       grupavimas,
                       papildFunkcija;
        private int lapuSk,
                    kopijuSk,
                    vienDvipusis;
        /// <summary>
        /// Konstruktorius be perametrų su reikšmėmis
        /// </summary>
        public KopijavimoInfo()
        {
            formatas = string.Empty;
            lapuSk = 0;
            kopijuSk = 0;
            vienDvipusis = 0;
            grupavimas = string.Empty;
            papildFunkcija = string.Empty;
        }
        /// <summary>
        /// Duomenų įrašymas į klasę
        /// </summary>
        /// <param name="formatas1">Lapo formatas</param>
        /// <param name="lapuSk1">Lapų skaičius</param>
        /// <param name="kopijuSk1">Kopijų skaičius</param>
        /// <param name="vienDvipusis1">Vienpusis ar dvipusis kopijavimas</param>
        /// <param name="grupavimas1">Grupavimas taip ar ne</param>
        /// <param name="papildFunkcija1">Papildomos funkcijos</param>
        public void Deti(string formatas1, int lapuSk1, int kopijuSk1,
                         int vienDvipusis1, string grupavimas1,
                         string papildFunkcija1)
        {
            formatas = formatas1;
            lapuSk = lapuSk1;
            kopijuSk = kopijuSk1;
            vienDvipusis = vienDvipusis1;
            grupavimas = grupavimas1;
            papildFunkcija = papildFunkcija1;
        }
        /// <summary>
        /// Grąžina string tipu visus duomenis klasėje
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("| {0,-12} | {1,8} | {2,8} | {3,11} |" +
                                   " {4,-10} | {5,-17} |",
                                   formatas, lapuSk, kopijuSk, vienDvipusis,
                                   grupavimas, papildFunkcija);
            return eilute;
        }
        /// <summary>
        /// Tikrina ar lygus kopijavimai
        /// </summary>
        /// <param name="obj">objektas</param>
        /// <returns>true or false</returns>
        public override bool Equals(object obj)
        {
            KopijavimoInfo Kopijavimas1 = obj as KopijavimoInfo;
            return Kopijavimas1.kopijuSk == kopijuSk;
        }
        /// <summary>
        /// Grąžina hashcode
        /// </summary>
        /// <returns>hashcode</returns>
        public override int GetHashCode()
        {
            int hashCode = 1048672734;
            hashCode = hashCode * -1521134295 +
                       EqualityComparer<string>.Default.GetHashCode(formatas);
            hashCode = hashCode * -1521134295 +
                       EqualityComparer<string>.Default.GetHashCode(grupavimas);
            hashCode = hashCode * -1521134295 + 
                     EqualityComparer<string>.Default.GetHashCode(papildFunkcija);
            hashCode = hashCode * -1521134295 + lapuSk.GetHashCode();
            hashCode = hashCode * -1521134295 + kopijuSk.GetHashCode();
            hashCode = hashCode * -1521134295 + vienDvipusis.GetHashCode();
            return hashCode;
        }
        /// <summary>
        /// Tikrina ar atitinka papildomos funkcijos pavadinima
        /// </summary>
        /// <param name="Kopijavimas1">Kopijavimo klasė</param>
        /// <param name="tekstas">funkcijos pavadinimas</param>
        /// <returns>true or false</returns>
        public static bool operator ==(KopijavimoInfo Kopijavimas1, string tekstas)
        {
            int poz = string.Compare(Kopijavimas1.papildFunkcija, tekstas,
                                     StringComparison.CurrentCulture);
            return poz == 0;
        }
        /// <summary>
        /// Tikrina ar neatitinka papildomos funkcijos pavadinima
        /// </summary>
        /// <param name="Kopijavimas1">Kopijavimo klasė</param>
        /// <param name="tekstas">funkcijos pavadinimas</param>
        /// <returns>true or false</returns>
        public static bool operator !=(KopijavimoInfo Kopijavimas1,
                                       string tekstas)
        {
            int poz = string.Compare(Kopijavimas1.papildFunkcija, tekstas,
                                     StringComparison.CurrentCulture);
            return poz != 0;
        }
        /// <summary>
        /// Tikrina ar pirmo kopiju skaičius didesnis negu kito
        /// </summary>
        /// <param name="Kopijavimas1">Kopijavimo klasė</param>
        /// <param name="Kopijavimas2">Kita kopijavimo klasė</param>
        /// <returns>true or false</returns>
        public static bool operator >(KopijavimoInfo Kopijavimas1,
                                      KopijavimoInfo Kopijavimas2)
        {
            return Kopijavimas1.kopijuSk > Kopijavimas2.kopijuSk;
        }
        /// <summary>
        /// Tikrina ar pirmo kopiju skaičius mažesnis negu kito
        /// </summary>
        /// <param name="Kopijavimas1">Kopijavimo klasė</param>
        /// <param name="Kopijavimas2">Kita kopijavimo klasė</param>
        /// <returns>true or false</returns>
        public static bool operator <(KopijavimoInfo Kopijavimas1,
                                      KopijavimoInfo Kopijavimas2)
        {
            return Kopijavimas1.kopijuSk < Kopijavimas2.kopijuSk;
        }
        /// <summary>
        /// Tikrina ar vienpusis
        /// </summary>
        /// <param name="Kopijavimas1">Kopijavimo klasė</param>
        /// <returns>true or false</returns>
        public static bool operator ~(KopijavimoInfo Kopijavimas1)
        {
            if (Kopijavimas1.vienDvipusis == 1)
                return true;
            return false;
        }
        /// <summary>
        /// Tikrina pagal formata jei lygus pagal lapų skaičių
        /// </summary>
        /// <param name="Kopijavimas1">Kopijavimo klasė</param>
        /// <param name="Kopijavimas2">Kita kopijavimo klasė</param>
        /// <returns>true or false</returns>
        public static bool operator >=(KopijavimoInfo Kopijavimas1,
                                       KopijavimoInfo Kopijavimas2)
        {
            int poz = string.Compare(Kopijavimas1.formatas,
                                     Kopijavimas2.formatas);
            return (poz == -1) || (poz == 0 && Kopijavimas1.lapuSk >
                                   Kopijavimas2.lapuSk);
        }
        /// <summary>
        /// Tikrina pagal formata jei lygus pagal lapų skaičių
        /// </summary>
        /// <param name="Kopijavimas1">Kopijavimo klasė</param>
        /// <param name="Kopijavimas2">Kita kopijavimo klasė</param>
        /// <returns>true or false</returns>
        public static bool operator <=(KopijavimoInfo Kopijavimas1,
                                       KopijavimoInfo Kopijavimas2)
        {
            int poz = string.Compare(Kopijavimas1.formatas,
                                     Kopijavimas2.formatas);
            return (poz == 1) || (poz == 0 && Kopijavimas1.lapuSk <
                                  Kopijavimas2.lapuSk);
        }
        /// <summary>
        /// Tikrina ar pradiniai duomenys teisingi
        /// </summary>
        /// <returns>true or false</returns>
        public bool Neteisingi()
        {
            if (lapuSk < 1 || kopijuSk < 1 ||
                vienDvipusis < 1 || vienDvipusis > 2)
                return true;
            return false;
        }
        /// <summary>
        /// Grąžina formato pavadinimą
        /// </summary>
        /// <returns>lapo formatas</returns>
        public string ImtiFormatas() { return formatas; }
        /// <summary>
        /// Grąžina kopijų skaičių
        /// </summary>
        /// <returns>Kopijų skaičius</returns>
        public int ImtiKopijuSk() { return kopijuSk; }
    }
}
