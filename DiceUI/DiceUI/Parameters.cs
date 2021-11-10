using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceUI
{
    /// <summary>
    /// Перечисление с названием параметров модели
    /// </summary>

    

    public enum NameParameters
    {
        /// <summary>
        /// Высота кости
        /// </summary>
        DiceHeight,

        /// <summary>
        /// Ширина кости
        /// </summary>
        DiceWidth,

        /// <summary>
        /// Толщина кости
        /// </summary>
        DiceThickness,

        /// <summary>
        /// Диаметр выемки
        /// </summary>
        DredgingDiametr,

        /// <summary>
        /// Ширина каемки
        /// </summary>
        EdgeWidth,

    }
    public class Parameters
    {
        /// <summary>
        /// Поле хранит текущее значение параметра
        /// </summary>
        private double _value;

        /// <summary>
        /// Поле хранит название параметра
        /// </summary>
        private string _name;

        /// <summary>
        /// Устанавливает и возвращает минимальное значение параметра
        /// </summary>
        public double MinValue { get; set; }

        /// <summary>
        /// Устанавливает и возвращает максимальное значение параметра
        /// </summary>
        public double MaxValue { get; set; }
    }
}
