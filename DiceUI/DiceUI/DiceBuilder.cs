using Core;
using DiceUI;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;

namespace DiceUI
{
    public class DiceBuilder
    {
        private KompasConnector _connector;
        private DiceParameters _diceParameters;

        public DiceBuilder(KompasConnector connector, DiceParameters parameters)
        {
            _connector = connector;
            _diceParameters = parameters;
        }

        //public void BuildEngineValve()
        //{
        //    BuildRect();
        //    BuildEdge();
        //    BuildDredging();
        //}
        //private void BuildPlate()
        //{
        //    ksEntity planeXOY = _part.GetDefaultEntity(1);
        //    var length = _parameters.ThicknessPlate + _parameters.LengthChamfer;
        //    CreateCylinder(planeXOY, _parameters.DiameterPlate, length);
        //}
        //Выдавливание
        private void ExtrusionOperation(ksPart iPart, object iSketch, double height, bool b)
        {
            ksEntity extrusion = iPart.NewEntity(24);
            ksBaseExtrusionDefinition extrusionDefinition = extrusion.GetDefinition();

            extrusionDefinition.SetSideParam(true, 0, height);
            extrusionDefinition.SetSketch(iSketch);
            extrusion.Create();
        }

        /// <summary>
        /// Построение кости
        /// </summary>
        public void BuildDice()
        {
            //Создание прямоугольника
            CreateRectangle();
            //Создание каемки
            CreateEdge();
            //Создание выемки
            CreateDredging();
            //Войти в режим редактирования эскиза
        }

        /// <summary>
        /// Построение прямоугольника
        /// </summary>
        void CreateRectangle()
        {
            //Выбор плоскости для построения
            var sketchDefinition = CreateSketch(Obj3dType.o3d_planeXOY);

            //Войти в режим редактирования эскиза
            var doc2D = (ksDocument2D)sketchDefinition.BeginEdit();

            //Построение прямоугольника
            var rectangleParam = (ksRectangleParam)_connector
                .Kompas
                .GetParamStruct((short)StructType2DEnum.ko_RectangleParam);

            rectangleParam.x = 0;
            rectangleParam.y = 0;
            rectangleParam.ang = 0;
            rectangleParam.width = 60;
            rectangleParam.height = 30;
            rectangleParam.style = 1;

            doc2D.ksRectangle(rectangleParam);

            //Выйти из режима редактирования эскиза
            sketchDefinition.EndEdit();

            //Выдавливание детали
            //PressOutSketch(sketchDefinition, ((Parameter)_diceParameters[ParametersEnum.DiceHeight]).Value);
            PressOutSketch(sketchDefinition, 20);

        }

        /// <summary>
        /// Создание эскиза
        /// </summary>
        /// <param name="planeType">Выбор плоскости</param>
        /// <returns>ksSketchDefinition</returns>
        public ksSketchDefinition CreateSketch(Obj3dType planeType)
        {
            //Элемент модели по умолчанию
            var plane = (ksEntity)_connector
                .KsPart
                .GetDefaultEntity((short)planeType);

            //Создать новый интерфейс объекта и получить указатель на него
            var sketch = (ksEntity)_connector
                .KsPart
                .NewEntity((short)Obj3dType.o3d_sketch);

            //Получить указатель на интерфейс параметров объектов или элементов
            var sketchDefinition = (ksSketchDefinition)sketch.GetDefinition();

            //Изменить базовую плоскость эскиза
            sketchDefinition.SetPlane(plane);

            //Создать объект в модели
            sketch.Create();
            return sketchDefinition;
        }

        /// <summary>
        /// Выдавливание по эскизу
        /// </summary>
        /// <param name="sketchDefinition">Эскиз</param>
        /// <param name="thickness">Толщина</param>
        private void PressOutSketch(
            ksSketchDefinition sketchDefinition,
            double thickness)
        {
            //Создать новый интерфейс объекта и получить указатель на него
            var extrusionEntity = (ksEntity)_connector
                .KsPart
                .NewEntity((short)Obj3dType.o3d_bossExtrusion);

            //Интерфейс приклеенного элемента выдавливания
            var extrusionDefinition = (ksBossExtrusionDefinition)extrusionEntity
                .GetDefinition();

            //Установить параметры выдавливания в одном направлении
            //side - направление (true - прямое направление)
            //тип выдавливания (0 - строго на глубину)
            //глубина выдавливания
            extrusionDefinition.SetSideParam(true, 0, thickness);

            //Изменить указатель на интерфейс эскиза элемента
            extrusionDefinition.SetSketch(sketchDefinition);

            //Создать объект в модели
            extrusionEntity.Create();
        }

        /// <summary>
        /// Построение каемки
        /// </summary>
        /// <param name="iPart"></param>
        void CreateEdge()
        {

        }

        /// <summary>
        /// Построение выемки
        /// </summary>
        void CreateDredging()
        {

        }
    }
}
