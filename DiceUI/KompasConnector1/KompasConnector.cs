using System;
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
            try
            {
                var t = Type.GetTypeFromProgID("KOMPAS.Application.5");
                Kompas = (KompasObject)Activator.CreateInstance(t);
            }
            catch (Exception)
            {
                throw new ArgumentException(@"Ошибка в запуске программы");
            }

            Kompas.Visible = true;
            Kompas.ActivateControllerAPI();

            var doc3D = (ksDocument3D)Kompas.Document3D();
            doc3D.Create();
            KsPart = (ksPart)doc3D.GetPart((short)Part_Type.pTop_Part);
        }
    }
}
