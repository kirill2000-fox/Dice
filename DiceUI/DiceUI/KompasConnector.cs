using System;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;


namespace DiceUI
{
    public class KompasConnector
    {
        private DiceBuilder _diceBuilder;

        private KompasObject OpenKompas3D()
        {
            KompasObject _kompasObject = null;
            try
            {
                _kompasObject.Visible = true;
                _kompasObject.ActivateControllerAPI();
            }
            catch
            {
                Type typeKompas = Type.GetTypeFromProgID("KOMPAS.Application.5");
                _kompasObject = (KompasObject) Activator.CreateInstance(typeKompas);
                _kompasObject.Visible = true;
                _kompasObject.ActivateControllerAPI();
            }

            return _kompasObject;
        }
        public KompasConnector(Parameters parameters)
        {
            InitializeDice(parameters);
        }
        private void InitializeDice(Parameters parameters)
        {
            _diceBuilder = new DiceBuilder(parameters, OpenKompas3D());
        }
    }
}
