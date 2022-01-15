using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    /// <summary>
    /// Параметры
    /// </summary>
    public class DiceParameters
    {
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
        /// </summary>
        public DiceParameters()
        {
            
            ParametersList.Add(new Parameter(ParametersEnum.DiceWidth, 30, 60, 30));
            ParametersList.Add(new Parameter(ParametersEnum.DiceHeight, 60, 120, 60));
            ParametersList.Add(new Parameter(ParametersEnum.DiceThickness, 10, 30, 10));
            ParametersList.Add(new Parameter(ParametersEnum.DredgingDiameter, 8, 15, 8));
            ParametersList.Add(new Parameter(ParametersEnum.EdgeWidth, 3, 24, 3));
        }

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
