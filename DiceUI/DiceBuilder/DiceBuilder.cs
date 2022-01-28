using System.Linq;
using Core;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;

namespace DiceBuilder
{
    /// <summary>
    /// Класс построения кости
    /// </summary>
    public class DiceBuilder
    {
        /// <summary>
        /// Соединение с КОМПАС-3D
        /// </summary>
        private readonly KompasConnector.KompasConnector _connector;

        /// <summary>
        /// Экземпляр класса параметров
        /// </summary>
        private readonly DiceParameters _diceParameters;

        /// <summary>
        /// Конструктор класса DiceBuilder
        /// </summary>
        /// <param name="connector">Коннектор для компаса</param>
        /// <param name="parameters">Параметры для компаса</param>
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
            CreateRectangle(0,
                -_diceParameters[ParametersType.DiceHeight].Value * 0.05,
                _diceParameters[ParametersType.DiceHeight].Value,
                _diceParameters[ParametersType.DiceWidth].Value);

            //Создание выемки
            CreateDredging();

            //Создание каемки
            CreateEdge();
        }

        /// <summary>
        /// Создание кубической выемки
        /// </summary>
        private void CreateDredging()
        {
            if (_diceParameters.CubeDredging)
            {
                CreateCubeDredging();
            }
            else
            {
                СreateSphereDredging();
            }
        }

        /// <summary>
        /// Создание кубической каемки
        /// </summary>
        private void CreateEdge()
        {
            if (_diceParameters.CubeEdge)
            {
                CreateCubeEdge();
            }
            else
            {
                CreateCylinderEdge();
            }
        }

        /// <summary>
        /// Создание эскиза
        /// </summary>
        /// <param name="planeType">Выбор плоскости</param>
        /// <returns>ksSketchDefinition</returns>
        private ksSketchDefinition CreateSketch(Obj3dType planeType)
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
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        void CreateRectangle(double x, double y, double width, double height)
        {
            //Выбор плоскости для построения
            var sketchDefinition = CreateSketch(Obj3dType.o3d_planeXOY);

            //Войти в режим редактирования эскиза
            var doc2D = (ksDocument2D)sketchDefinition.BeginEdit();

            //Построение прямоугольника
            var rectangleParam = (ksRectangleParam)_connector
                .Kompas
                .GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            rectangleParam.x = x;
            rectangleParam.y = y;
            rectangleParam.ang = 0;
            rectangleParam.width = width;
            rectangleParam.height = height;
            rectangleParam.style = 1;

            doc2D.ksRectangle(rectangleParam);

            //Выйти из режима редактирования эскиза
            sketchDefinition.EndEdit();

            //Выдавливание детали
            PressOutSketch(sketchDefinition, _diceParameters[ParametersType.DiceThickness].Value, true);
        }


        /// <summary>
        /// Построение cферической выемки
        /// </summary>
        private void СreateSphereDredging()
        {
            double flaskDiameter = _diceParameters.ParametersList
                .First(parameter => parameter.Name == ParametersType.DredgingDiameter).Value;
            // Параметры дуги
            var radArc = flaskDiameter / 2;
            var width = _diceParameters.ParametersList
                .First(parameter =>
                    parameter.Name == ParametersType.DiceWidth).Value;
            var height = _diceParameters.ParametersList
                .First(parameter =>
                    parameter.Name == ParametersType.DiceHeight).Value;
            var x1 = height * 0.25;
            var y1 = width * 0.5 - _diceParameters[ParametersType.DiceHeight].Value * 0.05;
            var x2 = height * 0.75;
            var y2 = width * 0.5 - _diceParameters[ParametersType.DiceHeight].Value * 0.05;

            CreateArc(x1, y1, radArc);
            CreateArc(x2, y2, radArc);
        }

        /// <summary>
        /// Построение одной выемки
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
                .First(parameter => parameter.Name == ParametersType.DiceThickness).Value;
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
        /// Построение КВАДРАТНОЙ выемки
        /// </summary>
        private void CreateCubeDredging()
        {
	        double flaskDiameter = _diceParameters.ParametersList
		        .First(parameter => parameter.Name == ParametersType.DredgingDiameter).Value;
	        var width = _diceParameters.ParametersList
		        .First(parameter =>
			        parameter.Name == ParametersType.DiceWidth).Value;
	        var height = _diceParameters.ParametersList
		        .First(parameter =>
			        parameter.Name == ParametersType.DiceHeight).Value;
	        var thickness = _diceParameters.ParametersList
		        .First(parameter => parameter.Name == ParametersType.DiceThickness).Value;


            var offsetPosition = thickness - flaskDiameter;

            ksEntity planeXoy = _connector.KsPart.GetDefaultEntity((int)Obj3dType.o3d_planeXOY);
            ksEntity plane = _connector.KsPart.NewEntity((int)Obj3dType.o3d_planeOffset);
            ksPlaneOffsetDefinition planeOffsetDefinition = plane.GetDefinition();
            planeOffsetDefinition.direction = true;
            planeOffsetDefinition.offset = offsetPosition;
            planeOffsetDefinition.SetPlane(planeXoy);
            plane.Create();
            ksEntity sketch = _connector.KsPart.NewEntity((int)Obj3dType.o3d_sketch);
            ksSketchDefinition sketchDefinition = sketch.GetDefinition();
            sketchDefinition.SetPlane(plane);
            sketch.Create();
            var doc2d = (ksDocument2D)sketchDefinition.BeginEdit();


            var x1 = height * 0.25;
            var y1 = width * 0.5 - _diceParameters[ParametersType.DiceHeight].Value * 0.05;
            var x2 = height * 0.75;
            var y2 = width * 0.5 - _diceParameters[ParametersType.DiceHeight].Value * 0.05;

            //Построение многоугольника
            CreatePolygon(x1, y1, flaskDiameter / 2, doc2d);
            CreatePolygon(x2, y2, flaskDiameter / 2, doc2d);
            
            //Выход из редактирования
            sketchDefinition.EndEdit();
            //Выдавливание фигуры
            CreateExtrusionOffsetCutMethod(sketchDefinition, "Квадратная Выемка", flaskDiameter);

        }

        /// <summary>
        /// Построение многоугольника
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="radius"></param>
        /// <param name="doc2d"></param>
        private void CreatePolygon(double x, double y, double radius, ksDocument2D doc2d)
        {
            var rectangleParam = (ksRegularPolygonParam)_connector
                .Kompas
                .GetParamStruct((short)StructType2DEnum.ko_RegularPolygonParam);
            rectangleParam.count = 4;
            rectangleParam.xc = x;
            rectangleParam.yc = y;
            rectangleParam.ang = 0;
            rectangleParam.radius = radius;
            rectangleParam.describe = true;
            rectangleParam.style = 1;

            doc2d.ksRegularPolygon(rectangleParam);
        }

        /// <summary>
        /// Построение каемки
        /// </summary>
        private void CreateCylinderEdge()
        {
            //Плоскость построения
            var sketchDefinition = CreateSketch(Obj3dType.o3d_planeXOZ);

            //Редактирование эскиза
            var doc2D = (ksDocument2D)sketchDefinition.BeginEdit();

            //Построение окружности
            doc2D.ksCircle(_diceParameters[ParametersType.DiceHeight].Value / 2,
                -_diceParameters[ParametersType.DiceThickness].Value,
                _diceParameters[ParametersType.EdgeWidth].Value / 2,
                1);

            //Выход из редактирования
            sketchDefinition.EndEdit();

            //Выдавливание фигуры
            CreateExtrusionOffsetCutMethod(sketchDefinition, "Каемка",
	            _diceParameters[ParametersType.DiceWidth].Value * 0.8);
        }

        /// <summary>
        /// Построение кубической каемки
        /// </summary>
        private void CreateCubeEdge()
        {
	        //Плоскость построения
	        var sketchDefinition = CreateSketch(Obj3dType.o3d_planeXOZ);

	        //Редактирование эскиза
	        var doc2d = (ksDocument2D)sketchDefinition.BeginEdit();

	        var x = _diceParameters[ParametersType.DiceHeight].Value / 2;
	        var y = -_diceParameters[ParametersType.DiceThickness].Value;
	        var radius = _diceParameters[ParametersType.EdgeWidth].Value / 2;
            
            CreatePolygon(x, y, radius, doc2d);
            

            //Выход из редактирования
	        sketchDefinition.EndEdit();

	        //Выдавливание фигуры
	        CreateExtrusionOffsetCutMethod(sketchDefinition, "Каемка",
		        _diceParameters[ParametersType.DiceWidth].Value * 0.8);
        }

        /// <summary>
        /// Выдавливание вырезанием
        /// </summary>
        /// <param name="sketchDefinition"></param>
        /// <param name="name">Имя</param>
        private void CreateExtrusionOffsetCutMethod
            (ksSketchDefinition sketchDefinition, string name, double depth)
        {
            ksEntity ksEntityBossExtrusion = 
                _connector.KsPart.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            ksCutExtrusionDefinition ksBossExtrusionDefinition =
                (ksCutExtrusionDefinition)ksEntityBossExtrusion.
                    GetDefinition();
            ksBossExtrusionDefinition.SetSideParam(false,
                (short)End_Type.etBlind, depth);
            ksBossExtrusionDefinition.SetSketch(sketchDefinition);
            ksEntityBossExtrusion.name = name;
            ksEntityBossExtrusion.Create();
        }
    }
}
