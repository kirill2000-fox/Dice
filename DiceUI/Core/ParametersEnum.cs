using System.ComponentModel;

namespace Core
{
    /// <summary>
    /// Типы параметров
    /// </summary>
    public enum ParametersEnum
    {
        [Description("Высота кости")]
        DiceHeight = 0,

        [Description("Ширина кости")]
        DiceWidth = 1,

        [Description("Толщина кости")]
        DiceThickness = 2,

        [Description("Диаметр выемки")]
        DredgingDiameter = 3,

        [Description("Ширина каемки")]
        EdgeWidth = 4
    }
}
