using System;

namespace Core
{
    public class Parameter
    {
        private double _max;

        private double _value;

        private ParametersEnum _name;

        public double Min { get; private set; }

        public double Max { get; private set; }

        public double Value
        {
            get => _value;
            set
            {
                if (value < Min || value > Max)
                {
                    throw new ArgumentException($"Value should be more then {Min} and less then {Max}");
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
    }
}
