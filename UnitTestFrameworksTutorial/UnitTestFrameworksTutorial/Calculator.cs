namespace xUnitTutorial
{
    class Calculator
    {
        enum CalculatorState
        {
            Cleared,
            Active
        }
        private CalculatorState _state = CalculatorState.Cleared;

        public decimal Value { get; private set; }

        public decimal Add(decimal v)
        {
            return Value += v;
        }

        public decimal Divide(decimal value)
        {
            if (value == 0 && _state == CalculatorState.Cleared)
            {
                _state = CalculatorState.Active;
                return Value = value;
            }

            if (_state == CalculatorState.Cleared)
            {
                _state = CalculatorState.Active;
                return Value = value;
            }
            
            return Value /= value;
        }

    }
}
