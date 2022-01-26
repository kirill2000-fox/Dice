using System.Collections.Generic;
using System.Linq;

namespace Core
{
    /// <summary>
    /// Класс, хранящий параметры кости
    /// </summary>
    public class DiceParameters
    {
        /// <summary>
        /// Поле определяющее будет ли вырез кубическим
        /// </summary>
	    private bool _cubeDredging;

        /// <summary>
        /// Поле определяющее будет ли каёмка кубической
        /// </summary>
        private bool _cubeEdge;

	    /// <summary>
        /// Устанавливает форму вырезов
        /// </summary>
        public bool CubeDredging
        {
	        set => _cubeDredging = value;
	        get => _cubeDredging;
        }

        /// <summary>
        /// Устанавливает форму каемки
        /// </summary>
	    public bool CubeEdge
	    {
		    set => _cubeEdge = value;
		    get => _cubeEdge;
	    }
        /// <summary>
        /// Список параметров
        /// </summary>
        public List<Parameter> ParametersList { get; } = new List<Parameter>();

        /// <summary>
        /// Словарь ошибок параметров
        /// </summary>
        public Dictionary<ParametersType, string> Errors =
            new Dictionary<ParametersType, string>();

        /// <summary>
        /// Флаг существования ошибки
        /// </summary>
        public bool HasError => Errors.Any();

        /// <summary>
        /// Создает экземпляр класса <see cref="DiceParameters"/>
        /// Список параметров со значениями по умолчанию
        /// </summary>
        public DiceParameters()
        {
            SetDefaultValues();
        }

        /// <summary>
        /// Метод для установки дефолтных данных
        /// </summary>
        public void SetDefaultValues()
        {
            ParametersList.Clear();
            ParametersList.Add(new Parameter(ParametersType.DiceWidth,
                30, 60, 30));
            ParametersList.Add(new Parameter(ParametersType.DiceHeight,
                60, 120, 60));
            ParametersList.Add(new Parameter(ParametersType.DiceThickness,
                10, 30, 10));
            ParametersList.Add(new Parameter(ParametersType.DredgingDiameter,
                8, 15, 8));
            ParametersList.Add(new Parameter(ParametersType.EdgeWidth, 3,
                24, 3));
            CubeDredging = false;
        }

        /// <summary>
        /// Проверка зависимых параметров
        /// </summary>
        /// <param name="nameParameters"></param>
        /// <param name="value"></param>
        public void CheckDependentParameters(ParametersType nameParameters, double value)
        {
            if (nameParameters == ParametersType.DiceHeight)
            {
                var width = this[ParametersType.DiceWidth];
                this[ParametersType.DiceWidth] = new Parameter
                    (width.Name, width.Min, value / 2.0, width.Value);

                var edge = this[ParametersType.EdgeWidth];
                this[ParametersType.EdgeWidth] = new Parameter
                    (edge.Name, edge.Min, value / 5.0, edge.Value);
            }
        }

        /// <summary>
        /// Индексатор, который позволяет получать элементы списка по значению
        /// <see cref="ParametersType"/>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Parameter this[ParametersType index]
        {
            get
            {
                return ParametersList.FirstOrDefault(param => param.Name == index);
            }
            set
            {
                var oldParameter = ParametersList.First(parameter => parameter.Name == index);
                var newIndex = ParametersList.IndexOf(oldParameter);
                ParametersList[newIndex] = value;
            }
        }
    }
}
