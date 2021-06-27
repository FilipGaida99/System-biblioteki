using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    /// <summary>
    /// Klasa sprawdzająca i konwertująca id podane w stringu do long
    /// </summary>
    public static class IDConverter
    {
        /// <summary>
        /// Metoda do konwersji ID podanego w textboxie na wartośc long
        /// </summary>
        /// <param name="id"></param> string z Id jako string
        /// <returns></returns> Zwraca wartość jako long
        public static long IdToLong(string id)
        {
            foreach (char c in id)
            {
                if (c < '0' || c > '9')
                {
                    throw new ArgumentException();
                }

            }
            return Convert.ToInt64(id);
        }
    }
}
