﻿using System.Linq;
using Core;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;

namespace DiceBuilder
{
    //TODO: вынести в отдельный проект.
    //TODO: XML(ИСПРАВЛЕНО)
    /// <summary>
    /// Класс построения кости
    /// </summary>
    public class DiceBuilder
    {
        //TODO: XML
        private KompasConnector.KompasConnector _connector;
        private DiceParameters _diceParameters;

        /// <summary>
        /// Конструктор класса DiceBuilder
        /// </summary>
        /// //TODO: XML
        public DiceBuilder(KompasConnector.KompasConnector connector, DiceParameters parameters)
        {
            _connector = connector;
            _diceParameters = parameters;
        }

        /// <summary>
        /// Построение кости
        /// </summary>
        public void BuildDice()
        {
            //Создание прямоугольника
            CreateRectangle();

            //Создание выемки
            CreateDredging();

            //Создание каемки
            CreateEdge();
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
            rectangleParam.y = -_diceParameters[ParametersEnum.DiceHeight].Value * 0.05;
            rectangleParam.ang = 0;
            rectangleParam.width = _diceParameters[ParametersEnum.DiceHeight].Value;
            rectangleParam.height = _diceParameters[ParametersEnum.DiceWidth].Value;
            rectangleParam.style = 1;

            doc2D.ksRectangle(rectangleParam);

            //Выйти из режима редактирования эскиза
            sketchDefinition.EndEdit();

            //Выдавливание детали
            PressOutSketch(sketchDefinition, _diceParameters[ParametersEnum.DiceThickness].Value, true);
        }

        /// <summary>
        /// Построение выемки
        /// </summary>
        private void CreateDredging()
        {
            double flaskDiameter = _diceParameters.ParametersList
                .First(parameter => parameter.Name == ParametersEnum.DredgingDiameter).Value;
            // Параметры дуги
            var radArc = flaskDiameter / 2;
            var width = _diceParameters.ParametersList
                .First(parameter =>
                    parameter.Name == ParametersEnum.DiceWidth).Value;
            var height = _diceParameters.ParametersList
                .First(parameter =>
                    parameter.Name == ParametersEnum.DiceHeight).Value;
            var x1 = height * 0.25;
            var y1 = width * 0.5 - _diceParameters[ParametersEnum.DiceHeight].Value * 0.05;
            var x2 = height * 0.75;
            var y2 = width * 0.5 - _diceParameters[ParametersEnum.DiceHeight].Value * 0.05;

            CreateArc(x1, y1, radArc);
            CreateArc(x2, y2, radArc);
        }

        /// <summary>
        /// Построение однной выемки
        /// </summary>
        /// <param name="x"> координаты центра дуги</param>
        /// <param name="y">координаты центра дуги</param>
        /// <param name="radArc">радиус дуги</param>
        private void CreateArc(double x, double y, double radArc)
        {
            ksEntity planeXoy = _connector.KsPart.GetDefaultEntity((int)Obj3dType.o3d_planeXOY);
            ksEntity plane = _connector.KsPart.NewEntity((int)Obj3dType.o3d_planeOffset);
            ksPlaneOffsetDefinition planeOffsetDefinition = plane.GetDefinition();
            planeOffsetDefinition.direction = true;
            planeOffsetDefinition.offset = _diceParameters.ParametersList
                .First(parameter => parameter.Name == ParametersEnum.DiceThickness).Value;
            planeOffsetDefinition.SetPlane(planeXoy);
            plane.Create();
            ksEntity sketch = _connector.KsPart.NewEntity((int)Obj3dType.o3d_sketch);
            ksSketchDefinition sketchDef = sketch.GetDefinition();
            sketchDef.SetPlane(plane);
            sketch.Create();
            var doc2d = (ksDocument2D)sketchDef.BeginEdit();
            var arcCordСenter = new double[] { x, y };
            var arcCord = new double[] { x, arcCordСenter[1] + radArc, x, arcCordСenter[1] - radArc };
            short direction = 1;

            //Построение дуги
            doc2d.ksArcByPoint(arcCordСenter[0], arcCordСenter[1], radArc, arcCord[0],
                arcCord[1], arcCord[2], arcCord[3], direction, 1);

            //Параметры вспомогательного отрезка
            var auxiliaryLineX = new double[] { arcCord[0], arcCord[2] };
            var auxiliaryLineY = new double[] { arcCord[1], arcCord[3] };

            //Построение вспомогательного отрезка
            doc2d.ksLineSeg(auxiliaryLineX[0], auxiliaryLineY[0],
                auxiliaryLineX[1], auxiliaryLineY[1], 3);
            sketchDef.EndEdit();

            CreateRotation(sketchDef);
            //Выход из редактирования
            sketchDef.EndEdit();

            //Выдавливание фигуры
            CreateCutRotation(sketchDef, "Выемка");
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
                (short)End_Type.etBlind, 30,
                2, false);
            ksBossExtrusionDefinition.SetSketch(rotationEntity);
            ksEntityBossExtrusion.name = "Вращение";
            ksEntityBossExtrusion.Create();
        }

        /// <summary>
        /// Вырезание вращением
        /// </summary>
        /// <param name="sketchDefinition">Эскиз по которому будет построен 
        /// элемент вращения</param>
        /// <param name="name">Имя</param>
        private void CreateCutRotation(ksSketchDefinition sketchDefinition, string name)
        {
            ksEntity cutRotated = _connector.KsPart.NewEntity(29);
            ksCutRotatedDefinition cutRotatedDefinition =
                cutRotated.GetDefinition();
            cutRotatedDefinition.SetSideParam(false, 360D);
            cutRotatedDefinition.SetSketch(sketchDefinition);
            cutRotated.Create();
        }

        /// <summary>
        /// Построение каемки
        /// </summary>
        private void CreateEdge()
        {
            //Плоскость построения
            var sketchDefinition = CreateSketch(Obj3dType.o3d_planeXOZ);

            //Редактирование эскиза
            var doc2D = (ksDocument2D)sketchDefinition.BeginEdit();

            //Построение круга
            var circleParam = (ksCircleParam)_connector
                .Kompas
                .GetParamStruct((short)StructType2DEnum.ko_CircleParam);

            //Построение окружности
            doc2D.ksCircle(_diceParameters[ParametersEnum.DiceHeight].Value / 2,
                -_diceParameters[ParametersEnum.DiceThickness].Value,
                _diceParameters[ParametersEnum.EdgeWidth].Value / 2,
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
            ksEntity ksEntityBossExtrusion = _connector.KsPart.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition ksBossExtrusionDefinition =
                (ksCutExtrusionDefinition)ksEntityBossExtrusion.
                    GetDefinition();
            ksBossExtrusionDefinition.SetSideParam(false,
                (short)End_Type.etBlind, _diceParameters[ParametersEnum.DiceWidth].Value * 0.8,
                0.1, false);
            ksBossExtrusionDefinition.SetSketch(ksEntity);
            ksEntityBossExtrusion.name = name;
            ksEntityBossExtrusion.Create();
        }
    }
}