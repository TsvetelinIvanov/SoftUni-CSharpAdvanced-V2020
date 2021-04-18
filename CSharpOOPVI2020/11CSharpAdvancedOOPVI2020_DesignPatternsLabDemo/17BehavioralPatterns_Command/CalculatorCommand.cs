using System;

namespace _17BehavioralPatterns_Command
{
    public class CalculatorCommand : Command
    {
        private char @operator;
        private int operand;
        private Calculator calculator;

        // Constructor
        public CalculatorCommand(Calculator calculator, char @operator, int operand)
        {
            this.calculator = calculator;
            this.@operator = @operator;
            this.operand = operand;
        }

        public char Operator
        {
            set => this.@operator = value;
        }

        public int Operand
        {
            set => this.operand = value;
        }

        public override void Execute()
        {
            this.calculator.Operation(this.@operator, this.operand);
        }

        public override void UnExecute()
        {
            this.calculator.Operation(Undo(this.@operator), this.operand);
        }

        private char Undo(char @operator)
        {
            switch (@operator)
            {
                case '+':
                    return '-';
                case '-':
                    return '+';
                case '*':
                    return '/';
                case '/':
                    return '*';
                default:
                    throw new ArgumentException("@operator");
            }
        }
    }
}