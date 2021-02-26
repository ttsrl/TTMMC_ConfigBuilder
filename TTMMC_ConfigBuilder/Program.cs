using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace TTMMC_ConfigBuilder
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CultureInfo ci = new CultureInfo("it-IT");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            Application.Run(new Form1());
        }
    }
}
