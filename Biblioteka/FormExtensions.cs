using System.Windows.Forms;

namespace Biblioteka
{
    public static class FormExtensions
    {
        public static void Return(this Form form)
        {
            form.Return(DialogResult.OK);
        }

        public static void Return(this Form form, DialogResult result)
        {
            form.DialogResult = result;
            form.Close();
        }
    }
}
