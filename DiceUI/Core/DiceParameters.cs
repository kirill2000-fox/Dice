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
        /// Создает экземпляр класса <see cref="DiceParameters"/>
        /// </summary>
        public DiceParameters()
        {
            // TODO: Min Max Value
            ParametersList.Add(new Parameter(ParametersEnum.DiceHeight, 60, 120, 60));
            ParametersList.Add(new Parameter(ParametersEnum.DiceWidth, 60, 120, 60));
            ParametersList.Add(new Parameter(ParametersEnum.DiceThickness, 60, 120, 60));
            ParametersList.Add(new Parameter(ParametersEnum.DredgingDiameter, 60, 120, 60));
            ParametersList.Add(new Parameter(ParametersEnum.EdgeWidth, 60, 120, 60));
        }

        public object this[ParametersEnum index]
        {
            get
            {
                return ParametersList.FirstOrDefault(param => param.Name == index);
            }
            set
            {
                // TODO
                //ParametersList.FirstOrDefault(param => param.Name == index) = (Parameter)value;

                //first = new Parameter(first.Name, first.Min, first.Max, first.Value);
            }
        }
    }
}
