using System;
using System.Runtime.InteropServices;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;


namespace DiceUI
{
    public class KompasConnector
    {
        //private DiceBuilder _diceBuilder;

        //private KompasObject OpenKompas3D()
        //{
        //    KompasObject _kompasObject = null;
        //    try
        //    {
        //        _kompasObject.Visible = true;
        //        _kompasObject.ActivateControllerAPI();
        //    }
        //    catch
        //    {
        //        Type typeKompas = Type.GetTypeFromProgID("KOMPAS.Application.5");
        //        _kompasObject = (KompasObject) Activator.CreateInstance(typeKompas);
        //        _kompasObject.Visible = true;
        //        _kompasObject.ActivateControllerAPI();
        //    }

        //    return _kompasObject;
        //}
        //public KompasConnector(Parameters parameters)
        //{
        //    InitializeDice(parameters);
        //}
        //private void InitializeDice(Parameters parameters)
        //{
        //    _diceBuilder = new DiceBuilder(parameters, OpenKompas3D());
        //}

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
