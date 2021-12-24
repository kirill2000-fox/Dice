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
        /// <param name="side">Направление</param>
        private ksEntity PressOutSketch(
            ksSketchDefinition sketchDefinition,
            double thickness, bool side)
        {
            //Создание интерфейса объекта
            var extrusionEntity = (ksEntity)_connector
                .KsPart
                .NewEntity((short)Obj3dType.o3d_bossExtrusion);
            var extrusionDefinition = (ksBossExtrusionDefinition)extrusionEntity
                .GetDefinition();

            //Установить параметры выдавливания в одном направлении
            //side - направление, true - прямое направление
            //0 выдавливание на глубину)
            //глубина выдавливания
            extrusionDefinition.SetSideParam(side, 0, thickness);

            //Изменить указатель на интерфейс эскиза элемента
            extrusionDefinition.SetSketch(sketchDefinition);

            //Создать объект в модели
            extrusionEntity.Create();

            return extrusionEntity;
        }

        /// <summary>
        /// Выдавливание по эскизу
        /// </summary>
        /// <param name="sketchDefinition">Эскиз</param>
        /// <param name="thickness">Толщина</param>
        /// <param name="side">Направление</param>
        private ksEntity PressInsideSketch(
            ksCutExtrusionDefinition sketchDefinition, double thickness, bool side)
        {
            //Создание интерфейса объекта
            var entityCutExtr = (ksEntity)_connector
                .KsPart
                .NewEntity((short)Obj3dType.o3d_bossExtrusion);
            var extrusionDefinition = (ksBossExtrusionDefinition)entityCutExtr
                .GetDefinition();
            
            if (entityCutExtr != null)
            {
                ksCutExtrusionDefinition cutExtrDef = (ksCutExtrusionDefinition)entityCutExtr.GetDefinition();
                if (cutExtrDef != null)
                {
                    cutExtrDef.cut = true;
                    cutExtrDef.directionType = (short)Direction_Type.dtReverse;

                    cutExtrDef.SetSideParam(false, (short)End_Type.etBlind, thickness);

                }
            }

            //Установить параметры выдавливания в одном направлении
            //side - направление, true - прямое направление
            //0 выдавливание на глубину)
            //глубина выдавливания
            extrusionDefinition.SetSideParam(side, 0, thickness);

            //Изменить указатель на интерфейс эскиза элемента
            extrusionDefinition.SetSketch(sketchDefinition);

            //Создать объект в модели
            entityCutExtr.Create();

            return entityCutExtr;
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
            //_diceParameters = new DiceParameters();
            rectangleParam.x = 0;
            rectangleParam.y = -_diceParameters[ParametersEnum.DiceHeight].Value * 0.05;
            rectangleParam.ang = 0;
            rectangleParam.width = _diceParameters[ParametersEnum.DiceHeight].Value;
            rectangleParam.height = _diceParameters[ParametersEnum.DiceWidth].Value;
            rectangleParam.style = 1;

            doc2D.ksRectangle(rectangleParam);

            //Выйти из режима редактирования эскиза
            sketchDefinition.EndEdit();

            //Выдавливание детали
            var dice = PressOutSketch(sketchDefinition, _diceParameters[ParametersEnum.DiceThickness].Value, true);
        }

        /// <summary>
        /// Построение каемки
        /// </summary>
        /// <param name="iPart"></param>
        private void CreateEdge()
        {
            double flaskDiameter = _diceParameters[ParametersEnum.EdgeWidth].Value;

            var sketchDef = CreateSketch(Obj3dType.o3d_planeXOZ);
            var doc2d = (ksDocument2D)sketchDef.BeginEdit();
            // Параметры дуги
            var radArc = flaskDiameter / 2;
            var arcCordСenter = new double[] { 0, 0 };
            var arcCord = new double[] { 0, flaskDiameter / 2, 0, -flaskDiameter / 2 };
            short direction = 1;
            // Построение дуги
            doc2d.ksArcByPoint(arcCordСenter[0], arcCordСenter[1], radArc, arcCord[0],
                arcCord[1], arcCord[2], arcCord[3], direction, 1);
            // Параметры вспомогательного отрезка
            var auxiliaryLineX = new double[] { 0, 0 };
            var auxiliaryLineY = new double[] { -20, 20 };
            // Построение вспомогательного отрезка
            doc2d.ksLineSeg(auxiliaryLineX[0], auxiliaryLineY[0],
                auxiliaryLineX[1], auxiliaryLineY[1], 3);
            sketchDef.EndEdit();

            CreateRotation(sketchDef);
        }

        /// <summary>
        /// Метод для создания элемента вращения
        /// </summary>
        /// <param name="sketchDef">Эскиз по которому будет построен 
        /// элемент вращения</param>
        private void CreateRotation(ksSketchDefinition sketchDef)
        {
            ksObj3dTypeEnum type = ksObj3dTypeEnum.o3d_bossRotated;
            var rotationEntity = (ksEntity)_connector.KsPart.
                NewEntity((short)type);
            var rotationDef = (ksBossRotatedDefinition)
                rotationEntity.GetDefinition();
            var angleRotation = 360;
            rotationDef.SetSideParam(true, angleRotation);
            rotationDef.SetSketch(sketchDef);

            rotationEntity.Create();

            ksEntity ksEntityBossExtrusion =
                _connector.KsPart.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition ksBossExtrusionDefinition =
                (ksCutExtrusionDefinition)ksEntityBossExtrusion.
                    GetDefinition();
            ksBossExtrusionDefinition.SetSideParam(false,
                (short)End_Type.etBlind, 10,
                2, false);
            ksBossExtrusionDefinition.SetSketch(rotationEntity);
            ksEntityBossExtrusion.name = "Вращение";
            ksEntityBossExtrusion.Create();
        }

        /// <summary>
        /// Построение выемки
        /// </summary>
        private void CreateDredging()
        {
            //Плоскость построения
            var sketchDefinition = CreateSketch(Obj3dType.o3d_planeXOZ);

            //Редактирование эскиза
            var doc2D = (ksDocument2D)sketchDefinition.BeginEdit();

            //Построение круга
            var circleParam = (ksCircleParam)_connector
                .Kompas
                .GetParamStruct((short)StructType2DEnum.ko_CircleParam);

            doc2D.ksCircle(_diceParameters[ParametersEnum.DiceHeight].Value / 2,
                -_diceParameters[ParametersEnum.DiceThickness].Value,
                _diceParameters[ParametersEnum.DredgingDiameter].Value / 2,
                1);

            //Выход из редактирования
            sketchDefinition.EndEdit();

            //Выдавливание фигуры
            CreateExtrusionOffsetCutMethod(sketchDefinition, "Выемка");
        }

        /// <summary>
        /// Выдавливание вырезанием
        /// </summary>
        /// <param name="ksEntity"></param>
        /// <param name="name">Имя</param>
        private void CreateExtrusionOffsetCutMethod
            (ksSketchDefinition ksEntity, string name)
        {
            ksEntity ksEntityBossExtrusion;
            ksEntityBossExtrusion =
                _connector.KsPart.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition ksBossExtrusionDefinition =
                (ksCutExtrusionDefinition)ksEntityBossExtrusion.
                    GetDefinition();
            ksBossExtrusionDefinition.SetSideParam(false,
                (short)End_Type.etBlind, _diceParameters[ParametersEnum.DiceWidth].Value * 0.8,
                2, false);
            ksBossExtrusionDefinition.SetSketch(ksEntity);
            ksEntityBossExtrusion.name = name;
            ksEntityBossExtrusion.Create();
        }
    }
}
