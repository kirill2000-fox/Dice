using System;
using System.Runtime.InteropServices;
using Kompas6API5;
using Kompas6Constants3D;

namespace KompasConnector
{
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
            Kompas = GetActiveKompas();
            if (Kompas == null)
            {
                try
                {
                    var type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                    Kompas = (KompasObject)Activator.CreateInstance(type);
                }
                catch (COMException)
                {
                    Kompas = null;
                }
            }
            Kompas.Visible = true;
            Kompas.ActivateControllerAPI();

            var doc3D = (ksDocument3D)Kompas.Document3D();
            doc3D.Create();
            KsPart = (ksPart)doc3D.GetPart((short)Part_Type.pTop_Part);
        }

        private KompasObject GetActiveKompas()
        {
            try
            {
                var kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
                return kompas;
            }
            catch (COMException)
            {
                return null;
            }
        }
    }
}