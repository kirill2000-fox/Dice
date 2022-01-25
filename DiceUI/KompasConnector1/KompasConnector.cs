using System;
using System.Runtime.InteropServices;
using Kompas6API5;
using Kompas6Constants3D;

namespace KompasConnector
{
    //TODO: вынести в отдельный проект.(Исправлено)
    /// <summary>
    /// Коннектор для Компаса
    /// </summary>
    public class KompasConnector
    {
        /// <summary>
        /// Интерфейс API Компас-3D
        /// </summary>
        public KompasObject Kompas { get; set; }

        /// <summary>
        /// Интерфейс компонента Компас-3D
        /// </summary>
        public ksPart KsPart { get; set; }

        /// <summary>
        /// Конструктор класса KompasConnector
        /// </summary>
        public void OpenKompas()
        {
            var activekompas = GetActiveKompas(out var kompas);
            if (!activekompas)
            {
                try
                {
                    var t = Type.GetTypeFromProgID("KOMPAS.Application.5");
                    Kompas = (KompasObject) Activator.CreateInstance(t);
                }
                catch (Exception)
                {
                    throw new ArgumentException(@"Ошибка в запуске программы");
                }
            }

            Kompas.Visible = true;
            Kompas.ActivateControllerAPI();

            var doc3D = (ksDocument3D)Kompas.Document3D();
            doc3D.Create();
            KsPart = (ksPart)doc3D.GetPart((short)Part_Type.pTop_Part);
        }

        private bool GetActiveKompas(out KompasObject kompas)
        {
            kompas = null;
            try
            {
                kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
                return true;
            }
            catch (COMException)
            {
                return false;
            }
        }
    }
}
