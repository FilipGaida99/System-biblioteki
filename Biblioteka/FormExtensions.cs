using System.Windows.Forms;

namespace Biblioteka
{
    /// <summary>
    /// Klasa rozszerzeń klasy Form.
    /// </summary>
    public static class FormExtensions
    {

        /// <summary>
        /// Funkcja zamykająca formularz uruchomiony jako okno dialogowe.
        /// </summary>
        /// <param name="form">Formularz wywołujący.</param>
        public static void Return(this Form form, DialogResult result = DialogResult.OK)
        {
            form.DialogResult = result;
            form.Close();
        }
    }
}
