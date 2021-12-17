using System.ComponentModel;

namespace Core
{
    /// <summary>
    /// Типы параметров
    /// </summary>
    public enum ParametersEnum
    {
        [Description("Высота кости")]
        DiceHeight,
        [Description("Ширина кости")]
        DiceWidth,

        /// <summary>
        /// Толщина кости
        /// </summary>
        DiceThickness,

        /// <summary>
        /// Диаметр выемки
        /// </summary>
        DredgingDiameter,

        /// <summary>
        /// Ширина каемки
        /// </summary>
        EdgeWidth,
    }
}
