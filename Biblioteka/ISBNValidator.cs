using System;
using System.Linq;

namespace Biblioteka
{
    /// <summary>
    /// Klasa sprawdzająca poprawność ISBN.
    /// </summary>
    class ISBNValidator
    {
        /// <summary>
        /// Numer ISBN.
        /// </summary>
        public string ISBN
        {
            get
            {
                return isbn;
            }
            set
            {
                isbn = value;
                isbnType = 0;
            }
        }

        /// <summary>
        /// Typ ISBN (10 lub 13). Przed walidacją ustawiony na 0.
        /// </summary>
        public int ISBNType => isbnType;

        int isbnType = 0;
        string isbn;

        /// <summary>
        /// Konstuktor.
        /// </summary>
        public ISBNValidator()
        {
        }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="isbn">Numer ISBN.</param>
        public ISBNValidator(string isbn)
        {
            this.isbn = isbn;
        }

        /// <summary>
        /// Sprawdzenie poprawności numeru.
        /// </summary>
        /// <returns>True, gdy ISBN jest poprawny.</returns>
        public bool Validate()
        {
            isbn = NormalizeIsbn(isbn);
            bool result = false;
            if(isbn.Length == 10)
            {
                result = Check10();
                isbnType = 10;
            }
            else if(isbn.Length == 13)
            {
                result = Check13();
                isbnType = 13;
            }
            else
            {
                throw new ArgumentOutOfRangeException("ISBN");
            }
            return result;
        }

        /// <summary>
        /// Normalizacja numeru. Usuwa wszystkie białe znaki i znaczniki grup.
        /// </summary>
        /// <param name="isbn">Numer ISBN.</param>
        /// <returns>Znormalizowany ISBN.</returns>
        public static string NormalizeIsbn(string isbn)
        {
            return isbn.Replace("-", "").Replace(" ", "");
        }

        /// <summary>
        /// Sprawdzenie poprawności numeru dla ISBN10.
        /// </summary>
        /// <returns>True, gdy ISBN jest poprawny.</returns>
        private bool Check10()
        {
            if (isbn == null)
                return false;

            if (isbn.Length != 10)
                return false;

            int result;
            for (int i = 0; i < 9; i++)
                if (!int.TryParse(isbn[i].ToString(), out result))
                    return false;

            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += (i + 1) * int.Parse(isbn[i].ToString());

            int remainder = sum % 11;
            if (remainder == 10)
                return isbn[9] == 'X';
            else
                return isbn[9] == (char)('0' + remainder);
        }

        /// <summary>
        /// Sprawdzenie numeru dla ISBN13.
        /// </summary>
        /// <returns>True, gdy ISBN jest poprawny.</returns>
        private bool Check13()
        {
            if (isbn.Length != 13) return false;
            int sum = 0;
            foreach (var (index, digit) in isbn.Select((digit, index) => (index, digit)))
            {
                if (char.IsDigit(digit)) sum += (digit - '0') * (index % 2 == 0 ? 1 : 3);
                else return false;
            }
            return sum % 10 == 0;
        }
    }
}
