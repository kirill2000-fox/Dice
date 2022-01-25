using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Core;

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
		private static void TestKompas3D()
        {
            TestApi(new KompasConnector.KompasConnector());
        }

        private static void TestApi(KompasConnector.KompasConnector apiService)
        {
            var connector = new KompasConnector.KompasConnector();
            var parameters = new DiceParameters();
            var builder = new DiceBuilder.DiceBuilder(connector, parameters);
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var streamWriter = new StreamWriter($"log{apiService}.txt", true);
            Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();
            var count = 0;
            while (true)
            {
                builder.BuildDice();
                var computerInfo = new ComputerInfo();
                var usedMemory = (computerInfo.TotalPhysicalMemory - computerInfo.AvailablePhysicalMemory) *
                                 0.000000000931322574615478515625;
                streamWriter.WriteLine(
                    $"{++count}\t{stopWatch.Elapsed:hh\\:mm\\:ss}\t{usedMemory}");
                streamWriter.Flush();
            }

            stopWatch.Stop();
            streamWriter.Close();
            streamWriter.Dispose();
            Console.Write($"End {new ComputerInfo().TotalPhysicalMemory}");
        }
	}
}
