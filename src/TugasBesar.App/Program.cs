using System;
using System.Windows.Forms;
using TugasBesar.App.Views;

namespace TugasBesar.App
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            TugasBesar.Localization.LocalizationService.SetLanguage("id");
            Application.Run(new LoginForm());
        }
    }
}