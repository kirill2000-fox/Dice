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
        /// Список параметров
        /// </summary>
        public List<Parameter> ParametersList { get; set; } = new List<Parameter>();

        /// <summary>
        /// Словарь ошибок параметров
        /// </summary>
        public Dictionary<ParametersEnum, string> Errors = new Dictionary<ParametersEnum, string>();

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
            ParametersList.Add(new Parameter(ParametersEnum.DiceWidth, 30, 60, 30));
            ParametersList.Add(new Parameter(ParametersEnum.DiceHeight, 60, 120, 60));
            ParametersList.Add(new Parameter(ParametersEnum.DiceThickness, 10, 30, 10));
            ParametersList.Add(new Parameter(ParametersEnum.DredgingDiameter, 8, 15, 8));
            ParametersList.Add(new Parameter(ParametersEnum.EdgeWidth, 3, 24, 3));
        }

        /// <summary>
        /// Индексатор, который позволяет получать элементы списка по значению
        /// <see cref="ParametersEnum"/>
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Parameter this[ParametersEnum index]
        {
            get
            {
                return ParametersList.FirstOrDefault(param => param.Name == index);
            }
            set
            {
                var oldParameter = ParametersList.First(parameter => parameter.Name == index);
                var i = ParametersList.IndexOf(oldParameter);
                ParametersList[i] = value;
            }
        }
    }
}
