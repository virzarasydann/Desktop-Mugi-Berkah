using System;
using System.Windows.Forms;
using TugasBesar.Views;

namespace TugasBesar
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Langsung buka LoginForm, biarkan LoginForm yang mengatur default bahasanya nanti
            Application.Run(new LoginForm());
        }
    }
}