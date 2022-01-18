using System;

namespace Core
{
    public class Parameter : ICloneable
    {
        private double _value;

        public double Min { get; private set; }

        public double Max { get; private set; }

        public double Value
        {
            get => _value;
            set
            {
                if (value < Min || value > Max)
                {
                    throw new ArgumentException($"Значение должно быть больше {Min} и меньше {Max}");
                }

                _value = value;
            }
        }

        public ParametersEnum Name { get; private set; }

        public Parameter(ParametersEnum name, double min, double max, double value)
        {
            Name = name;
            Min = min;
            Max = max;
            Value = value;
        }

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

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
