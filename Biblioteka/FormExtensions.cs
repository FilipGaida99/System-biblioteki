using System.Windows.Forms;

namespace Biblioteka
{
    public static class FormExtensions
    {
        public static void Return(this Form form)
        {
            form.DialogResult = DialogResult.OK;
            form.Close();
        }
    }
}
