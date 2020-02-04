//Dan Hunt
//Daniel.Hunt@trojans.dsu.edu
//CSC260 Assignment 1: Calculator

using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DanHuntCalculatorAssignment
{
    public partial class Calculator : Form
    {

        private float? _memVal; //Tracks user stored memory value. Nullable in case no memory stored.
        private const string InitialValue = "0"; //Initial value for calculator so we don't have an empty string

        public Calculator()
        {
            InitializeComponent();
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            ResetCalculator(); //Set Calculator to initial value so we don't have an empty string
            KeyPress += CalculatorKeyPress;
        }

        #region ButtonHandlers
        protected internal void btnNumberKeys_Click(object sender, EventArgs e)
        {
            //Append each button's text into the calculator
            AppendToInputOutputBox(((ButtonBase) sender).Text);
        }

        protected internal void btnOperator_click(object sender, EventArgs e)
        {
            //Surround operators with space for easy reading
            AppendOperatorToInputOutputBox(((ButtonBase)sender).Text);
        }

        protected internal void btnZero_Click(object sender, EventArgs e)
        {
            AppendZeroToInputOuputBox();
        }

        private void btnPower_Click(object sender, EventArgs e)
        {
            AppendOperatorToInputOutputBox("^");
        }

        protected internal void btnSquare_Click(object sender, EventArgs e)
        {
            AppendOperatorToInputOutputBox("^");
            AppendToInputOutputBox("2");
        }

        protected internal void btnPosNeg_Click(object sender, EventArgs e)
        {
            MakeNegative();
        }

        protected internal void MakeNegative()
        {
            //Dynamically sets last (or only) nonzero number in textbox to negative
            if (tbxInputOutput.Text != InitialValue && GetLastNumberAsStringFromTextbox() != "0")
            {
                var newLastNumber = (double.Parse(GetLastNumberAsStringFromTextbox()) * -1).ToString();
                var trimmedText = tbxInputOutput.Text.Remove(
                    tbxInputOutput.Text.Length - GetLastNumberAsStringFromTextbox().Length,
                    GetLastNumberAsStringFromTextbox().Length); //Trim out the number we just made negative
                tbxInputOutput.Text =  trimmedText + newLastNumber; //combine the new number with the original string and put it in the box
            }
        }

        protected internal void btnBack_Click(object sender, EventArgs e)
        {
            DeleteLastCharacter();
        }

        private void btnClearBox_Click(object sender, EventArgs e)
        {
            //Just clear the textbox, nothing else
            ResetInputOutputTbx();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            //Clear textbox and memory
            ResetCalculator();
        }

        private void btnMemRestore_Click(object sender, EventArgs e)
        {
            RecallValueFromMemory();
        }

        private void btnMemClear_Click(object sender, EventArgs e)
        {
            ClearValueInMemory();
        }

        private void btnMemStore_Click(object sender, EventArgs e)
        {
            StoreValueInMemory();
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            AddDecimalToCurrentNumber();
        }

        protected internal void btnEquals_Click(object sender, EventArgs e)
        {
            //try to get the answer but catch errors in case user is dividing by zero or something
            double result = 0;
            try
            {
                result = MathHelper.DoMath(tbxInputOutput.Text);
            }
            catch (ArithmeticException exception)
            {
                ShowErrorMessage(exception.Message, "Uh Oh");
            }

            tbxHistory.Text += $"{tbxInputOutput.Text} = {result}{Environment.NewLine}";
            ResetInputOutputTbx(); //Clear the input from the box
            tbxInputOutput.Text = result.ToString(CultureInfo.InvariantCulture);
        }

        protected internal void btnSquareRoot_Click(object sender, EventArgs e)
        {
            //SquareRoot button will only work with one operand and NO operators in the box.
            //This is due to time constraints preventing me from implementing parentheses 
            
            //First check the number of operators & operands to see if we can do a square root 
            if (GetAllNumbersFromTextbox().Length == 1 &&
                MathHelper.FindNumberOfOperatorsInEquation(tbxInputOutput.Text) == 0)
            {
                //If we can do a squareroot, simply squareroot whatever value is in the box and add the equation to the history
                var root = Math.Sqrt(double.Parse(tbxInputOutput.Text));
                tbxHistory.Text += $"√({tbxInputOutput.Text}) = {root.ToString()} {Environment.NewLine}"; 
                tbxInputOutput.Text = root.ToString();
            }
            else
            {
                //If conditions are not correct for using the squareroot button, throw an error to let the user know.
                ShowErrorMessage("Can only use sqrt button on one number because I never implemented parentheses. Sorry.", "Dev was lazy");
            }
        }

        #endregion
        #region Keypress Handlers

        protected internal void CalculatorKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '1' && e.KeyChar <= '9') //Check if it's a non-zero number
            {
                AppendToInputOutputBox(e.KeyChar.ToString());
            }

            else if (MathHelper.IsAnOperator(e.KeyChar)) //Check if it's a mathematical operator
            {
                AppendOperatorToInputOutputBox(e.KeyChar.ToString());
            }

            else if (e.KeyChar == '0') //If it's zero, handle with special logic
            {
                AppendZeroToInputOuputBox();
            }

            else if (e.KeyChar == (char) Keys.Back)
            {
                DeleteLastCharacter();
            }

            else if (e.KeyChar == '.') //Handle Decimals with special logic
            {
                AddDecimalToCurrentNumber();
            }

        }
        #endregion
        #region Stored memory value functions
        private void StoreValueInMemory()
        {
            _memVal = float.Parse(tbxInputOutput.Text);
            lblMemVal.Text = _memVal.ToString();
        }

        private void RecallValueFromMemory()
        {
            if (_memVal != null)
            {
                tbxInputOutput.Text = _memVal.ToString();
            }
            
        }

        private void ClearValueInMemory()
        {
            _memVal = null;
            lblMemVal.Text = string.Empty;
        }
        #endregion
        #region TbxInput/Output textbox manip

        protected internal void AppendToInputOutputBox(string val)
        {
            if (tbxInputOutput.Text == InitialValue)
            {
                //If textbox is at initial state (e.g. 0), replace instead of append
                tbxInputOutput.Text = val;
            }
            else
            {
                tbxInputOutput.Text += val;
            }
        }

        private void AppendZeroToInputOuputBox()
        {
            //Check to see if we can actually add a zero before adding it. 
            if (!tbxInputOutput.Text.EndsWith(" ") || tbxInputOutput.Text != "0")
            {
                AppendToInputOutputBox("0");
            }
        }

        private void AppendOperatorToInputOutputBox(string text)
        {
            var stringToAppend = $" {text} "; //Add spaces around operators to make them easier to read & parse
            if (tbxInputOutput.Text != InitialValue)
            {
                //If we are not in initial state just add the operator as normal.
                AppendToInputOutputBox(stringToAppend);
            }
            else
            {
                //If textbox is in initial state we need to preserve the 0 when adding the operator.
                AppendToInputOutputBox(tbxInputOutput.Text + stringToAppend);
            }
        }


        private void ResetInputOutputTbx()
        {
            tbxInputOutput.Text = InitialValue;
        }

        private void AddDecimalToCurrentNumber()
        {
            //We only want to append a decimal if the LAST number in the box does not already have one.
            //For this we will quickly split the equation with regex and check the last number in the list.
            if (!GetLastNumberAsStringFromTextbox().Contains("."))
            {
                AppendToInputOutputBox(".");
            }
        }

        private string GetLastNumberAsStringFromTextbox()
        {
            //Return last number in current textbox
            return GetAllNumbersFromTextbox().Last(); 
        }

        private string[] GetAllNumbersFromTextbox()
        {
            //Stackoverflow to the rescue with this regex idea
            //https://stackoverflow.com/questions/13525024/how-to-split-a-mathematical-expression-on-operators-as-delimiters-while-keeping
            return Regex.Split(tbxInputOutput.Text, MathHelper.OperatorRegex);

        }

        private void DeleteLastCharacter()
        {
            //Remove the latest character in the textbox, only if there are characters in the textbox 
            if (tbxInputOutput.Text.Length > 0)
            {
                //If we are deleting the last character, swap it with a zero 
                if (tbxInputOutput.Text == string.Empty || tbxInputOutput.Text.Length == 1)
                {
                    tbxInputOutput.Text = InitialValue;
                }
                //Otherwise just delete the rightmost non space character
                //Spaces must be preserved for parsing. 
                else
                {
                    var charToDelete = tbxInputOutput.Text.Last();
                    //If last character is a space, assume we have an operator and delete 3 characters
                    if (charToDelete == ' ')
                    {
                        tbxInputOutput.Text = tbxInputOutput.Text.Remove(tbxInputOutput.Text.Length - 3);
                    }

                    //If it's a number just delete it
                    if (charToDelete >= '0' && charToDelete <= '9' || charToDelete == '.')
                    {
                        tbxInputOutput.Text = tbxInputOutput.Text.Remove(tbxInputOutput.Text.Length - 1);
                    }

                    //Finally if we just deleted a negative number we must delete the negative sign as well
                    if (GetLastNumberAsStringFromTextbox() == "-")
                    {
                        tbxInputOutput.Text = tbxInputOutput.Text.Remove(tbxInputOutput.Text.Length - 1);
                    }
                }
            }
        }
        #endregion
        #region Utility Functions

        internal void ResetCalculator()
        {
            ResetInputOutputTbx();
            ClearValueInMemory();
        }

        protected internal virtual void ShowErrorMessage(string message, string title)
        {
            //This method simply throws a messagebox with a message & title. 
            //I made it its own method so it can be overridden in tests.
            MessageBox.Show(message, title);
        }
        #endregion
    }
}
