using System;

namespace DiceUI
{
    /// <summary>
    /// Перечисление. Хранит названия параметров модели
    /// </summary>
    public class NameParameters
    {
        /// <summary>
        /// Высота кости
        /// </summary>
        
        private double _diceHeight = double.NaN;

        /// <summary>
        /// Ширина кости
        /// </summary>
        private double _diceWidth = double.NaN;
        

        /// <summary>
        /// Толщина кости
        /// </summary>
        private double _diceThickness = double.NaN;
        

        /// <summary>
        /// Диаметр выемки
        /// </summary>
        private double _dredgingDiametr = double.NaN;
        

        /// <summary>
        /// Ширина каемки
        /// </summary>
        private double _edgeWidth = double.NaN;

        /// <summary>
        /// Возвращает или задает значение высоты кости
        /// </summary>
        public double DiceHeight
        {
            get => _diceHeight;
            set
            {
                const double minValue = 60.0;
                const double maxValue = 120.0;

                if (!Validator(value, minValue, maxValue))
                    throw new ArgumentException("incorrect value");

                _diceHeight = value;
            }
        }

        /// <summary>
        /// Возвращает или задает значение ширины кости
        /// </summary>
        public double DiceWidth
        {
            get => _diceWidth;
            set
            {
                const double minValue = 30.0;
                double maxValue = 60.0;

                if (!Validator(value, minValue, maxValue))
                    throw new ArgumentException("incorrect value");

                _diceWidth = value;
            }
        }

        /// <summary>
        /// Возвращает или задает значение толщины кости
        /// </summary>
        public double DiceThickness
        {
            get => _diceThickness;
            set
            {
                const double minValue = 10.0;
                double maxValue = 30.0;

                if (!Validator(value, minValue, maxValue))
                    throw new ArgumentException("incorrect value");

                _diceThickness = value;
            }
        }

        /// <summary>
        /// Возвращает или задает значение диаметра выемки
        /// </summary>
        public double DredgingDiametr
        {
            get => _dredgingDiametr;
            set
            {
                const double minValue = 8.0;
                double maxValue = 15.0;

                

                if (!Validator(value, minValue, maxValue))
                    throw new ArgumentException("incorrect value");

                _dredgingDiametr = value;
            }
        }

        /// <summary>
        /// Возвращает или задает значение ширины выемки
        /// </summary>
        public double EdgeWidth
        {
            get => _edgeWidth;
            set
            {
                const double minValue = 3.0;
                double maxValue = 24.0;

                if (!Validator(value, minValue, maxValue))
                    throw new ArgumentException("incorrect value");

                _edgeWidth = value;
            }
        }

        /// <summary>
        /// Проверка на соответствие интервалу
        /// </summary>
        /// <param name="value">значение параметра</param>
        /// <param name="minValue">минимальное значение</param>
        /// <param name="maxValue">максимальное значение</param>
        /// <returns>Корректность</returns>
        private bool Validator(double value, double minValue, double maxValue)
        {
            if (value < minValue)
                return false;

            if (value > maxValue)
                return false;

            return true;
        }

        public void SetValue(Parameters parameter, double value)
        {
            switch (parameter)
            {
                case Parameters.DiceHeight:
                    {
                        DiceHeight = value;
                        break;
                    }
                case Parameters.DiceWidth:
                    {
                        DiceWidth = value;
                        break;
                    }
                case Parameters.DiceThickness:
                    {
                        DiceThickness = value;
                        break;
                    }
                case Parameters.DredgingDiametr:
                    {
                        DredgingDiametr = value;
                        break;
                    }
                case Parameters.EdgeWidth:
                    {
                        EdgeWidth = value;
                        break;
                    }
                
            }
        }
    }
}
