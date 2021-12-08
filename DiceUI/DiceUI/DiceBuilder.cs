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
            ksPart part = (ksPart)iDocument3D.GetPart((short)Part_Type.pTop_Part);
            //Создание прямоугольника
            CreateRectangle(part);
            //Создание каемки
            CreateEdge(part);
            //Создание выемки
            CreateDredging(part);
            //Войти в режим редактирования эскиза
           


            /// <summary>
            /// Построение прямоугольника
            /// </summary>
            /// <param name="iPart"></param>
            void CreateRectangle(ksPart iPart)
            {
                
            }

            /// <summary>
            /// Построение каемки
            /// </summary>
            /// <param name="iPart"></param>
            void CreateEdge(ksPart iPart)
            {
                
            }

            /// <summary>
            /// Построение выемки
            /// </summary>
            void CreateDredging(ksPart iPart)
            {
                
            }

        }

        //Выдавливание
        private void ExtrusionOperation(ksPart iPart, object iSketch, double height, bool b)
        {
            ksEntity extrusion = iPart.NewEntity(24);
			ksBaseExtrusionDefinition extrusionDefinition = extrusion.GetDefinition();

			extrusionDefinition.SetSideParam(true, 0, height);
			extrusionDefinition.SetSketch(iSketch);
			extrusion.Create();
        }

    }
}
