//Dan Hunt
//Daniel.Hunt@trojans.dsu.edu
//CSC260 Assignment 1: Calculator
using System;
using System.Windows.Forms;
using Moq;
using NUnit.Framework;


namespace DanHuntCalculatorAssignment
{
    public class CalculatorTest
    {
        //Created a unit test class to rapidly test different equations without using the UI
        //used NUnit & Moq framework since that's what I'm used to using
        //Incorporated Moq library to help ease setup

        public class BasicClickTests
        {
            private ButtonBase sender;
            private EventArgs args;
            private Calculator sut;
            private string buttonString;

            [SetUp]
            protected void SetUp()
            {
                sut = new Calculator();
                args = new EventArgs();
                var MockSender = new Mock<ButtonBase>();
                MockSender.Setup(x => x.Text).Returns(() => buttonString);
                sender = MockSender.Object;
            }

            #region Number and Operator Tests
            [Test]
            public void NumberButtonDoesNotAppendSpaces()
            {
                sut.AppendToInputOutputBox("1");
                buttonString = "2";
                sut.btnNumberKeys_Click(sender, args);

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo("12"));
            }

            [Test]
            public void OperatorButtonAppendsSpaces()
            {
                sut.AppendToInputOutputBox("1");
                buttonString = "*";
                sut.btnOperator_click(sender, args);
                sut.AppendToInputOutputBox("2");

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo("1 * 2"));
            }

            [Test]
            public void OperatorCanBePlacedAfterInitialZero()
            {
                sut.ResetCalculator();
                buttonString = "+";
                sut.btnOperator_click(sender, args);

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo("0 + "));
            }

            [Test]
            public void ZeroButtonWillNotAddAnotherZeroInInitialState()
            {
                sut.ResetCalculator(); //Sets Textbox text to "0"
                sut.btnZero_Click(sender, args);

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo("0"));
            }

            [Test]
            public void ZeroButtonWillAddAZeroIfInNonInitialState()
            {
                sut.ResetCalculator(); //Sets Textbox text to "0"
                sut.AppendToInputOutputBox("1");
                sut.btnZero_Click(sender, args);

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo("10"));
            }

            [Test]
            public void SquareButtonAppendsOperatorAndNumber2()
            {
                sut.AppendToInputOutputBox("1");
                sut.btnSquare_Click(sender, args);

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo("1 ^ 2"));
            }

            #endregion
            #region MakeNegativeTests

            [Test]
            public void MakesSingleItemNegative()
            {
                sut.AppendToInputOutputBox("10");
                sut.btnPosNeg_Click(sender, args);

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo("-10"));
            }

            [Test]
            public void MakesLastItemInStringNegative()
            {
                sut.AppendToInputOutputBox("10 + 2 - 3");
                sut.btnPosNeg_Click(sender, args);

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo("10 + 2 - -3"));
            }

            [Test]
            public void DoesNotMakeZeroNegative()
            {
                sut.AppendToInputOutputBox("10 + 2 - 0");
                sut.btnPosNeg_Click(sender, args);

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo("10 + 2 - 0"));
            }

            [Test]
            public void DoesNotMakeInitialValueNegative()
            {
                sut.ResetCalculator(); //Sets Textbox text to "0"
                sut.btnPosNeg_Click(sender, args);

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo("0"));
            }

            #endregion
            #region BackButtonTests
            [Test]
            public void BackButtonReplacesLastValueWithZero()
            {
                sut.ResetCalculator();
                sut.AppendToInputOutputBox("1");
                sut.btnBack_Click(sender, args);

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo("0"));
            }

            [Test]
            public void BackButtonDeletesOnlyLastValueIfSeveralArePresent()
            {
                sut.ResetCalculator();
                sut.AppendToInputOutputBox("123456");
                sut.btnBack_Click(sender, args);

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo("12345"));
            }

            [Test]
            public void HandlesDecimals()
            {
                sut.ResetCalculator();
                sut.AppendToInputOutputBox("123.");
                sut.btnBack_Click(sender, args);

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo("123"));
            }

            [Test]
            public void DoesNotDeleteSpaceAroundOperatorWhenDeletingNumber()
            {
                sut.ResetCalculator();
                sut.AppendToInputOutputBox("1 + 2");
                sut.btnBack_Click(sender, args);

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo("1 + "));
            }

            [Test]
            public void DeletesSpacesAlongWithOperator()
            {
                sut.ResetCalculator();
                sut.AppendToInputOutputBox("1 + ");
                sut.btnBack_Click(sender, args);

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo("1"));
            }

            [Test]
            public void DeletesNegativeSign()
            {
                sut.ResetCalculator();
                sut.AppendToInputOutputBox("1 - -2");
                sut.btnBack_Click(sender, args);

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo("1 - "));
            }

            #endregion
        }
        
        public class EqualButtonTests
        {
            //The meat of the math tests will be covered in MathHelperTest.cs
            private ButtonBase sender;
            private EventArgs args;
            private Mock<Calculator> mockSut;

            [SetUp]

            public void SetUp()
            {
                mockSut = new Mock<Calculator>() {CallBase = true};
                args = new EventArgs();
                sender = new Button() {Text = "="};
            }
           
            [Test]
            public void DivideByZeroTest()
            {
                mockSut.Object.AppendToInputOutputBox("10 / 0");
                mockSut.Setup(x => x.ShowErrorMessage(It.IsAny<string>(), It.IsAny<string>())); //We don't actually want to show the error so mock it
                mockSut.Object.btnEquals_Click(sender, args);

                mockSut.Verify(x => x.ShowErrorMessage(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            }

            [Test]
            public void ShowsAnswerInTextbox()
            {
                mockSut.Object.AppendToInputOutputBox("1 + 2 * 3");
                mockSut.Object.btnEquals_Click(sender, args);

                var result = mockSut.Object.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo((1 + 2 * 3).ToString()));
            }

            [Test]
            public void AddsAnswerToHistory()
            {
                mockSut.Object.AppendToInputOutputBox("1 + 2 * 3");
                mockSut.Object.btnEquals_Click(sender, args);

                var result = mockSut.Object.Controls.Find("tbxHistory", false)[0].Text;

                Assert.That(result, Is.EqualTo("1 + 2 * 3 = 7" + Environment.NewLine));
            }
        }

        public class SquareRootButtonTests
        {
            private object sender;
            private EventArgs args;
            private Mock<Calculator> mockSut;

            [SetUp]
            public void SetUp()
            {
                sender = new object();
                args = new EventArgs();
                mockSut = new Mock<Calculator>() {CallBase = true};
                mockSut.Setup(x => x.ShowErrorMessage(It.IsAny<string>(), It.IsAny<string>()));
            }

            [Test]
            public void DoesNothingIfMoreThanOneNumberPresent()
            {
                mockSut.Object.AppendToInputOutputBox("1 + 2");
                mockSut.Object.btnSquareRoot_Click(sender, args);

                var result = mockSut.Object.Controls.Find("tbxInputOutput", false)[0].Text;

                //Make sure the output doesn't change & and error is thrown
                Assert.That(result, Is.EqualTo("1 + 2"));
                mockSut.Verify(x => x.ShowErrorMessage(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            }

            [Test]
            public void PerformsOperationIfOnlyOneValuePresent()
            {
                mockSut.Object.AppendToInputOutputBox("9");
                mockSut.Object.btnSquareRoot_Click(sender, args);

                var resultInputOutput = mockSut.Object.Controls.Find("tbxInputOutput", false)[0].Text;
                var resultHistory = mockSut.Object.Controls.Find("tbxHistory", false)[0].Text;

                //Make sure the output shows correct value & and error is not thrown
                Assert.That(resultInputOutput, Is.EqualTo("3"));
                Assert.That(resultHistory, Is.EqualTo($"√(9) = 3 {Environment.NewLine}"));
                mockSut.Verify(x => x.ShowErrorMessage(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            }


        }

        public class KeyPressTests
        {
            private object sender;
            private KeyPressEventArgs args;
            private Calculator sut;

            [SetUp]
            protected void SetUp()
            {
                sut = new Calculator();
                args = new KeyPressEventArgs('\0'); //placeholder key
                sender = new object();
            }

            [Test]
            public void NumberKeyAddsNumber()
            {
                args.KeyChar = '1';
                sut.CalculatorKeyPress(sender, args);
                args.KeyChar = '2';
                sut.CalculatorKeyPress(sender, args);
                args.KeyChar = '3';
                sut.CalculatorKeyPress(sender, args);

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo("123"));
            }

            [Test]
            public void OperatorKeyAddsOperatorWithSpaces()
            {
                sut.AppendToInputOutputBox("1");
                args.KeyChar = '+';
                sut.CalculatorKeyPress(sender, args);
                sut.AppendToInputOutputBox("2");

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo("1 + 2"));
            }

            [Test]
            public void AddsZeroIfApplicable()
            {
                sut.AppendToInputOutputBox("1");
                args.KeyChar = '0';
                sut.CalculatorKeyPress(sender, args);

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo("10"));
            }

            [Test]
            public void DoesNotAddZeroIfNotApplicable()
            {
                sut.ResetCalculator();
                args.KeyChar = '0';
                sut.CalculatorKeyPress(sender, args);

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                //One zero is expected, two is not 
                Assert.That(result, Is.Not.EqualTo("00")); 
                Assert.That(result, Is.EqualTo("0")); 
            }

            [Test]
            public void BackSpaceDeletes()
            {
                sut.AppendToInputOutputBox("123");
                args.KeyChar = (char)Keys.Back;
                sut.CalculatorKeyPress(sender, args);

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo("12"));
            }

            [Test]
            public void DecimalAddsDecimal()
            {
                sut.AppendToInputOutputBox("123");
                args.KeyChar = '.';
                sut.CalculatorKeyPress(sender, args);

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo("123."));
            }

            [Test]
            public void DecimalDoesNotAddSecondDecimal()
            {
                sut.AppendToInputOutputBox("123.");
                args.KeyChar = '.';
                sut.CalculatorKeyPress(sender, args);

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo("123."));
            }

            [Test]
            public void DecimalAddsZeroWhenNecessary()
            {
                sut.AppendToInputOutputBox("12 + ");
                args.KeyChar = '.';
                sut.CalculatorKeyPress(sender, args);

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo("12 + 0."));
            }

            [Test]
            public void EnterKeySolvesEquation()
            {
                sut.AppendToInputOutputBox("1 + 2 * 3");
                args.KeyChar = (char) Keys.Enter;
                sut.CalculatorKeyPress(sender, args);

                var result = sut.Controls.Find("tbxInputOutput", false)[0].Text;

                Assert.That(result, Is.EqualTo("7"));
            }
        }
    }
}

