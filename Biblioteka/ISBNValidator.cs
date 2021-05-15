using System;
using System.Linq;

namespace Biblioteka
{
    class ISBNValidator
    {
        public string ISBN
        {
            get
            {
                return isbn;
            }
            set
            {
                isbn = value;
            }
        }

        string isbn;

        public ISBNValidator()
        {
        }

        public ISBNValidator(string isbn)
        {
            this.isbn = isbn;
        }

        public bool Validate()
        {
            var _isbn = NormalizeIsbn(isbn);
            bool result = false;
            if(_isbn.Length == 10)
            {
                result = Check10(_isbn);
            }
            else if(_isbn.Length == 13)
            {
                result = Check13(_isbn);
            }
            else
            {
                throw new ArgumentOutOfRangeException("ISBN");
            }
            return result;
        }

        public static string NormalizeIsbn(string isbn)
        {
            return isbn.Replace("-", "").Replace(" ", "");
        }

        private static bool Check10(string isbn)
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

        private static bool Check13(string isbn)
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
