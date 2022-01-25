using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Core;
using Microsoft.VisualBasic.Devices;

namespace DiceUI
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
