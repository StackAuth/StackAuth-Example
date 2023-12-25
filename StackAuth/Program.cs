using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StackAuth
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            OnProgramStart.Initialize("StackWorkShop", "1", "MybgKgVLGA", "1.0.0.1", "Stack-kxBC3aBdP0", "9qaALU9wAbIg9GmHpXcVKCi7ibckgQRmMA79XazJDm3PtqWhCB==", false, false);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
