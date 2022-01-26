using System;

namespace Core
{
    /// <summary>
    /// Класс, хранящий информацию о параметре кости
    /// </summary>
    public class Parameter : ICloneable
    {

        /// <summary>
        /// Текущее значение параметра
        /// </summary>
        private double _value;

        /// <summary>
        /// Минимальное значение параметра
        /// </summary>
        public double Min { get; private set; }

        /// <summary>
        /// Максимальное значение параметра
        /// </summary>
        public double Max { get; private set; }

        /// <summary>
        /// Проверка на корректность введенных данных
        /// </summary>
        public double Value
        {
            get => _value;
            set
            {
                if (value < Min || value > Max)
                {
                    throw new ArgumentException($"Значение должно быть больше {Min} " +
                                                $"и меньше {Max}");
                }

                _value = value;
                Limits = $"Значение должно быть от {Min} мм до {Max} мм";
            }
        }

        /// <summary>
        /// Наименование параметра
        /// </summary>
        public ParametersType Name { get; private set; }

        /// <summary>
        /// Добустимые значения параметра
        /// </summary>
        public string Limits { get; private set; }

        /// <summary>
        /// Создает экземпляр класса <see cref="Parameter"/>
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="min">Минимальное значение</param>
        /// <param name="max">Максимальное значение</param>
        /// <param name="value"></param>
        public Parameter(ParametersType name, double min, double max, double value)
        {
            Name = name;
            Min = min;
            Max = max;
            Value = value;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            var parameter = obj as Parameter;

            if (parameter == null)
            {
                return false;
            }

            if (parameter.Name == Name && parameter.Min == Min && parameter.Max == Max &&
                parameter.Value == Value)
            {
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
