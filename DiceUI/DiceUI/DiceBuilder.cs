using DiceUI;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
namespace DiceUI
{
    class DiceBuilder
    {
        private KompasObject _kompasObject;
        private Parameters _diceParameters;
        public DiceBuilder(Parameters parameters, KompasObject kompas)
        {
            //Получение параметров 
            _diceParameters = parameters;
            //Получение объекта KOMPAS 3D
            _kompasObject = kompas;
            //Создание объекта
            CreateModel();
        }
        /// <summary>
        /// Построение кости
        /// </summary>
        private void CreateModel()
        {
            //Получение интерфейса 3d документа
            ksDocument3D iDocument3D = (ksDocument3D)_kompasObject.Document3D();
            iDocument3D.Create(false, true);
            //Получение интерфейса детали
            ksPart iPart = (ksPart)iDocument3D.GetPart((short)Part_Type.pTop_Part);
            //Создание прямоугольника
            CreateRectangle(iPart);
            //Создание каемки
            CreateEdge(iPart);
            //Создание выемки
            CreateDredging(iPart); 

            /// <summary>
            /// Построение прямоугольника
            /// </summary>
            /// <param name="iPart"></param>
            void CreateRectangle(ksPart iPart)
            {
                if (_diceParameters.parameters(Parameters.DiceHeight).Value != 0 &&
                    _diceParameters.Parameter(Parameters.DiceWidth).Value != 0)
                {
                    //Получение глубины выдавливания
                    var height = _diceParameters.Parameter(Parameters.DiceThickness).Value;
                    //Выдавливание
                    object iSketch = null;
                    ExtrusionOperation(iPart, iSketch, height, false);

                }
            }

            /// <summary>
            /// Построение каемки
            /// </summary>
            /// <param name="iPart"></param>
            void CreateEdge(ksPart iPart)
            {
                if (_diceParameters.parameters(Parameters.DiceHeight).Value != 0 &&
                    _diceParameters.parameters(Parameters.DiceWidth).Value != 0)
                {
                    //Получение глубины выдавливания
                    var height = _diceParameters.Parameter(Parameters.DiceThickness).Value;
                    //Выдавливание
                    object iSketch = null;
                    ExtrusionOperation(iPart, iSketch, height, false);

                }
            }

            /// <summary>
            /// Построение каемки
            /// </summary>
            void CreateDredging(ksPart iPart)
            {
                if (_diceParameters.parameters(Parameters.DiceHeight).Value != 0 &&
                    _diceParameters.Parameter(Parameters.DiceWidth).Value != 0)
                {
                    //Получение глубины выдавливания
                    var height = _diceParameters.parameters(Parameters.DiceThickness).Value;
                    //Выдавливание
                    object iSketch = null;
                    ExtrusionOperation(iPart, iSketch, height, false);

                }
            }

        }

        //Выдавливание
        private void ExtrusionOperation(ksPart iPart, object iSketch, object height, bool b)
        {
            throw new System.NotImplementedException();
        }
    }
}
