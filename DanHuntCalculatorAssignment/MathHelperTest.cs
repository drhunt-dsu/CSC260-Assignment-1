using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NUnit.Framework;

namespace DanHuntCalculatorAssignment
{
    public class MathHelperTest
    {
        //Created a unit test class to rapidly test different equations without using the UI
        //used NUnit framework since that's what I'm used to using
        public class BasicOperationTests
        //Just test basic operations with two operands
        {
            [Test]
            public void Multiplies()
            {
                var result = MathHelper.DoMath("1x2");
                Assert.That(result, Is.EqualTo(1 * 2));
            }

            [Test]
            public void Divides()
            {
                var result = MathHelper.DoMath("6/2");
                Assert.That(result, Is.EqualTo(6 / 2));
            }

            [Test]
            public void Adds()
            {
                var result = MathHelper.DoMath("20+3");
                Assert.That(result, Is.EqualTo(20 + 3));
            }

            [Test]
            public void Subtracts()
            {
                var result = MathHelper.DoMath("10-6");
                Assert.That(result, Is.EqualTo(10 - 6));
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
    }
}

