using System.Linq;
using System.Security;
using NUnit.Framework;
using NUnit.Framework.Internal;
// ReSharper disable StringIndexOfIsCultureSpecific.1

namespace DanHuntCalculatorAssignment
{
    public class MathHelperTest
    {
        //Created a unit test class to rapidly test different equations without using the UI
        //used NUnit framework since that's what I'm used to using
        public class DoMathTests
        {
            [Test]
            public void MultipliesSimpleEquation()
            {
                var result = MathHelper.DoMath("1 x 2");
                Assert.That(result, Is.EqualTo(1 * 2));
            }

            [Test]
            public void DividesSimpleEquation()
            {
                var result = MathHelper.DoMath("6 / 2");
                Assert.That(result, Is.EqualTo(6 / 2));
            }

            [Test]
            public void AddsSimpleEquation()
            {
                var result = MathHelper.DoMath("20 + 3");
                Assert.That(result, Is.EqualTo(20 + 3));
            }

            [Test]
            public void SubtractsSimpleEquation()
            {
                var result = MathHelper.DoMath("10 - 6");
                Assert.That(result, Is.EqualTo(10 - 6));
            }

            [Test]
            public void SolvesMixedEquation()
            {
                var result = MathHelper.DoMath("10 + 2 / 2 * 3");
                Assert.That(result, Is.EqualTo(10 + 2 / 2 * 3));
            }

            [Test]
            public void SolvesMixedEquationWithNegatives()
            {
                var result = MathHelper.DoMath("10 - -28 / -14 * -3");
                Assert.That(result, Is.EqualTo(10 - -28 / -14 * -3));
            }

            [Test]
            public void SolvesEquationThatStartsWithNegative()
            {
                var result = MathHelper.DoMath("-13 + 4");
                Assert.That(result, Is.EqualTo(-13 + 4));
            }
        }

        public class SolveOperatorTests
        {
            [Test]
            public void Multiplies()
            {
                var result = MathHelper.SolveOperator(1,2, "x");
                Assert.That(result, Is.EqualTo(1 * 2));
            }

            [Test]
            public void Divides()
            {
                var result = MathHelper.SolveOperator(6,2,"/");
                Assert.That(result, Is.EqualTo(6 / 2));
            }

            [Test]
            public void Adds()
            {
                var result = MathHelper.SolveOperator(20,3,"+");
                Assert.That(result, Is.EqualTo(20 + 3));
            }

            [Test]
            public void Subtracts()
            {
                var result = MathHelper.SolveOperator(10,6,"-");
                Assert.That(result, Is.EqualTo(10 - 6));
            }
        }

        public class FindNumberOfOperatorsTests
        {
            [Test]
            public void FindsZero()
            {
                var result = MathHelper.FindNumberOfOperatorsInEquation("This string doesn't have any operators");
                Assert.That(result, Is.EqualTo(0));
            }

            [Test]
            public void FindNestedOperators()
            {
                var result = MathHelper.FindNumberOfOperatorsInEquation("1 + 2 / 3 * 4 - 5");
                Assert.That(result, Is.EqualTo(4));
            }

            [Test]
            public void HandlesNegativesAtStart()
            {
                var result = MathHelper.FindNumberOfOperatorsInEquation("-13 + 4");
                Assert.That(result, Is.EqualTo(1));
            }

            [Test]
            public void HandlesNegativesInMiddle()
            {
                var result = MathHelper.FindNumberOfOperatorsInEquation("13 + -4 - -23 * -4");
                Assert.That(result, Is.EqualTo(3));
            }
        }

        public class FindHighestPriorityOperatorIndexTests
        {
            [Test]
            public void ReturnsNegative1IfNoOperator()
            {
                var result = MathHelper.FindHighestPriorityOperatorIndex("abc123 no operator here");
                Assert.That(result, Is.EqualTo(-1));
            }

            [Test]
            public void FindsLowestPriorityOperatorIfItsTheOnlyOneInTheString()
            {
                var lowestPriorityOperator = MathHelper.PrioritizedOperators.Last();
                var searchString = $"This string has only one operator and it is {lowestPriorityOperator}";

                var result = MathHelper.FindHighestPriorityOperatorIndex(searchString);

                Assert.That(result, Is.EqualTo(searchString.IndexOf(lowestPriorityOperator)));
            }

            [Test]
            public void FindsLeftMostHighPriorityOperatorWhenSeveralAreTied()
            {
                var equation = "12-44+32/3*96";
                var result = MathHelper.FindHighestPriorityOperatorIndex(equation);

                Assert.That(result, Is.EqualTo(equation.IndexOf("/")));
            }

            [Test]
            public void FindsOnyFirstInstanceOfHighestPriorityOperator()
            {
                var equation = "12*44*32*3*96";

                var result = MathHelper.FindHighestPriorityOperatorIndex(equation);

                Assert.That(result, Is.EqualTo(equation.IndexOf("*")));
                //This next test duplicates the above assert but leaving it to be clear what I'm explicitly testing
                Assert.That(result, Is.EqualTo(2)); 
            }

            [Test]
            public void HandlesNegativeNumberBeforeAddition()
            {
                var equation = "-13 + 4";

                var result = MathHelper.FindHighestPriorityOperatorIndex(equation);

                Assert.That(result, Is.EqualTo(equation.IndexOf("+")));
            }
        }

        public class GetRemainingEquationTests
        {
            [Test]
            public void HandlesSpacesInMiddle()
            {
                var equation = "1 + 6 / 2 * 4";
                var index = MathHelper.FindHighestPriorityOperatorIndex(equation);
                var operands = MathHelper.GetOperands(equation, index);
                var operatorSymbol = equation[index].ToString();
                var partialSolve = MathHelper.SolveOperator(operands[0], operands[1], operatorSymbol);

                var result = MathHelper.GetRemainingEquation(equation, index, operands, partialSolve);

                Assert.That(result, Is.EqualTo("1 + 3 * 4"));
            }

            [Test]
            public void HandlesSpaceHighPriorityStart()
            {
                var equation = "6 / 2 * 4 + 2 - 4";
                var index = MathHelper.FindHighestPriorityOperatorIndex(equation);
                var operands = MathHelper.GetOperands(equation, index);
                var operatorSymbol = equation[index].ToString();
                var partialSolve = MathHelper.SolveOperator(operands[0], operands[1], operatorSymbol);

                var result = MathHelper.GetRemainingEquation(equation, index, operands, partialSolve);

                Assert.That(result, Is.EqualTo("3 * 4 + 2 - 4"));
            }

            [Test]
            public void HandlesSpaceHighPriorityEnd()
            {
                var equation = "10 + 2 - 3 * 6";
                var index = MathHelper.FindHighestPriorityOperatorIndex(equation);
                var operands = MathHelper.GetOperands(equation, index);
                var operatorSymbol = equation[index].ToString();
                var partialSolve = MathHelper.SolveOperator(operands[0], operands[1], operatorSymbol);

                var result = MathHelper.GetRemainingEquation(equation, index, operands, partialSolve);

                Assert.That(result, Is.EqualTo("10 + 2 - 18"));
            }

            [Test]
            public void HandlesNegatives()
            {
                var equation = "10 + 2 - -3 * -6";
                var index = MathHelper.FindHighestPriorityOperatorIndex(equation);
                var operands = MathHelper.GetOperands(equation, index);
                var operatorSymbol = equation[index].ToString();
                var partialSolve = MathHelper.SolveOperator(operands[0], operands[1], operatorSymbol);

                var result = MathHelper.GetRemainingEquation(equation, index, operands, partialSolve);

                Assert.That(result, Is.EqualTo("10 + 2 - 18"));
            }
        }
    }
}

