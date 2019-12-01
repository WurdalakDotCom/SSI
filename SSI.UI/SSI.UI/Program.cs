using System;
using System.Windows.Forms;
using DevExpress.UserSkins;
using SSI.UI.Core;

namespace SSI.UI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BonusSkins.Register();

            var authorization = new Authorization();
            while (!authorization.UserAuthorizationForm());


            Application.Run(new MainForm());
        }
    }
}
