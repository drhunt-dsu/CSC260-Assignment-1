using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanHuntCalculatorAssignment
{
    public static class MathHelper
    //This class will control all the actual math guts of the calculator
    {
        public const string PrioritizedOperators = "()S^x*/+-";

        public static double DoMath(string equation)
        {
            //Take a string containing an equation, parse it, return the answer

            //First, check the number of operators in the string. If no operands found, we have our result

            //If no operators remain, the math is complete and we can return the value.
            if (FindNumberOfOperatorsInEquation(equation) == 0)
            {
                if (double.TryParse(equation, out var result))
                {
                    return result;
                }
            }

            throw new ArithmeticException($"Cannot parse equation {equation}" );
        }

        private static string SolveEquation(string equation)
        {
            //Recursively process equation until no operators left
            //First check if string has an operator

            //If it has no operators, consider the equation solved and return the string. This is the escape condition / base case for the recursive function
            
            //if it has at least one operator, solve the highest priority operator and recursively call this method on the remaining string


            return "placeholder Text";
        }

        private static int FindHighestPriorityOperatorIndex(string equation)
        {
            //Find highest priority operator, then return its index in the equation string

            return -1; // placeholder
        }

        private static int FindNumberOfOperatorsInEquation(string equation)
        {
            //finds total number of operators in an equation and returns it;

            return -1; //placeholder
        }


        internal static double SolveOperator(double operand1, double operand2, string symbol)
        {
            switch (symbol)
            {
                case "*":
                    return operand1 * operand2;
                case "x":
                    return operand1 * operand2;
                case "/":
                    return Divide(operand1, operand2); //special case since we need to handle divide by zero
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                default:
                    throw new ArithmeticException($"Cannot process the following equation: {operand1} {symbol} {operand2}");
            }
        }

        private static double Divide(double numerator, double denominator)
        {
            try
            {
                return numerator / denominator;
            }
            catch
            {
                throw new ArithmeticException("Cannot divide by zero!");
            }
        }

    }
}
