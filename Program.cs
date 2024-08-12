using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SiraKutucukUygulamasi
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            KullaniciGiris form2 = new KullaniciGiris();
            Application.Run(form2);
        }
    }
}
