﻿using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace DanHuntCalculatorAssignment
{
    public static class MathHelper
    //This class will control all the actual math guts of the calculator
    {
        internal const string PrioritizedOperators = "^x*/+-"; //List of mathematical operators in PEMDAS order
        internal const string OperatorRegex = @"[-+*x\/%\^]"; //Regex to find operators 

        public static double DoMath(string equation)
        {
            //Take a string containing an equation, parse it, return the answer
            //First, attempt to solve the equation
            var solvedEquation = SolveEquation(equation);
            //If no operators remain, the math is complete and we can return the value.
            if (FindNumberOfOperatorsInEquation(solvedEquation) == 0)
            {
                if (double.TryParse(solvedEquation, out var result))
                {
                    return result;
                }
            }

            //If we still have an operand, or if we cannot parse the number, we have encountered an error.
            throw new ArithmeticException($"Cannot parse equation {equation}" );
        }

        private static string SolveEquation(string equation)
        {
            //Recursively process equation until no operators left
            //First check if string has an operator
            if (FindNumberOfOperatorsInEquation(equation) == 0)
            {
                //If it has no operators, consider the equation solved and return the string. This is the escape condition / base case for the recursive function
                return equation;
            }
            //if it has at least one operator, solve the highest priority operator and recursively call this method on the remaining string
            var operatorIndex = FindHighestPriorityOperatorIndex(equation); //Find highest priority operator
            var operands = GetOperands(equation, operatorIndex);
            var operatorSymbol = equation[operatorIndex].ToString(); //Get operator itself

            var partialSolve = SolveOperator(operands[0], operands[1], operatorSymbol); //Solve this portion onf the equation

            var remainingEquation = equation.Remove(0, operatorIndex + 2); //Hold the remaining equation

            return SolveEquation(partialSolve+remainingEquation); //Combine the result & remaining equation, continue solving it.
        }

        private static double[] GetOperands(string equation, int index)
        {
            //Get two arrays of numbers, one before and one after the operand. These will still be strings for now. 
            var beforeOperand = Regex.Split(equation.Substring(0, index),OperatorRegex); //Get everything before the operator
            var afterOperand = Regex.Split(equation.Substring(index+1), OperatorRegex); //Get everything after the operator

            //Now return last of the "before operator" and first of the "after operator" string arrays.
            //Convert to doubles when doing so
            return new [] {double.Parse(beforeOperand.Last()), double.Parse(afterOperand.First())};
        }

        internal static int FindHighestPriorityOperatorIndex(string equation)
        {
            //Find highest priority operator, then return its index in the equation string
            var indexOfHighestPriorityOperator = -1;
            char highestPriorityOperator = '\0'; //Tracks highest priority operator, initialized as lowest possible priority operator

            for (var i = 0; i < equation.Length; i++)
            {
                if (IsAnOperator(equation[i]))
                {
                    if(indexOfHighestPriorityOperator == -1)
                    {
                        //First check if no operator has been found yet. If so, assign it immediately. 
                        indexOfHighestPriorityOperator = i;
                        highestPriorityOperator = equation[i];
                    }
                    else if (PrioritizedOperators.IndexOf(equation[i]) < PrioritizedOperators.IndexOf(highestPriorityOperator))
                    {
                        //Next, check if current operator is higher priority than the index we are saving. If so, update our return value.
                        indexOfHighestPriorityOperator = i;
                        highestPriorityOperator = equation[i];
                    }
                }
            }

            return indexOfHighestPriorityOperator;
        }

        internal static int FindNumberOfOperatorsInEquation(string equation)
        {
            var totalOperators = 0; //keep track of operators in equation

            foreach (var character in equation)
            //iterate through equation and check each character to see if it is an operator
            {
                if (IsAnOperator(character))
                {
                    totalOperators++;
                }
            }

            return totalOperators; //placeholder
        }

        private static bool IsAnOperator(char character)
        {
            return PrioritizedOperators.Contains(character);
        }


        internal static double SolveOperator(double operand1, double operand2, string symbol)
        {
            //Performs mathematical operation depending on the operator and returns the result. 
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
            //Attempts to divide two numbers, throws an exception if dividing by zero
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
