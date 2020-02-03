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

        private float? _memVal;
        private const string InitialValue = "0";

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
        private void btnNumberKeys_Click(object sender, EventArgs e)
        {
            //Append each button's text into the calculator
            AppendToInputOutputBox(((ButtonBase) sender).Text);
        }

        private void btnOperator_click(object sender, EventArgs e)
        {
            //Surround operators with space for easy reading
            var stringToAppend = $" {((ButtonBase) sender).Text} ";
            AppendToInputOutputBox(stringToAppend);
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            //Check to see if we can actually add a zero before adding it. 
            if (!tbxInputOutput.Text.EndsWith(" ") || tbxInputOutput.Text != "0")
            {
                AppendToInputOutputBox(((ButtonBase)sender).Text);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //Remove the latest character in the textbox, only if there are characters in the textbox 
            if (tbxInputOutput.Text.Length > 0)
            {
                //If we are deleting the last character, swap it with a zero 
                if (tbxInputOutput.Text == string.Empty || tbxInputOutput.Text.Length == 1)
                {
                    tbxInputOutput.Text = InitialValue;
                }
                //Otherwise just delete the rightmost character
                else
                {
                    tbxInputOutput.Text = tbxInputOutput.Text.Remove(tbxInputOutput.Text.Length - 1);
                }
            }
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

        private void btnEquals_Click(object sender, EventArgs e)
        {
            //try to get the answer but catch errors in case user is dividing by zero or something
            double result = 0;
            try
            {
                result = MathHelper.DoMath(tbxInputOutput.Text);
            }
            catch (ArithmeticException exception)
            {
                MessageBox.Show(exception.Message, "Uh oh");
            }

            tbxHistory.Text += $"{tbxInputOutput.Text} = {result}{Environment.NewLine}";
            ResetInputOutputTbx(); //Clear the input from the box
            tbxInputOutput.Text = result.ToString(CultureInfo.InvariantCulture);
        }

        #endregion
        #region Keypress Handlers

        private void CalculatorKeyPress(object sender, KeyPressEventArgs e)
        {
            var operatorChars = MathHelper.PrioritizedOperators.ToCharArray();  //Get an array of operators so we can quickly make keypresses.

            if (e.KeyChar >= 48 && e.KeyChar <= 57 || operatorChars.Contains(e.KeyChar)) //Only allow an explicit list of keys. Operators & Numbers.
            {
                AppendToInputOutputBox(e.KeyChar.ToString());
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
        private void AppendToInputOutputBox(string val)
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

        private void ResetInputOutputTbx()
        {
            tbxInputOutput.Text = InitialValue;
        }

        private void AddDecimalToCurrentNumber()
        {
            //We only want to append a decimal if the LAST number in the box does not already have one.
            //For this we will quickly split the equation with regex and check the last number in the list.

            var currentString = tbxInputOutput.Text;
            //Stackoverflow to the rescue with this regex idea
            //https://stackoverflow.com/questions/13525024/how-to-split-a-mathematical-expression-on-operators-as-delimiters-while-keeping
            string[] numbers = Regex.Split(currentString, MathHelper.OperatorRegex);
            if (!numbers.Last().Contains("."))
            {
                AppendToInputOutputBox(".");
            }
        }
        #endregion
        #region Utility Functions
        private void ResetCalculator()
        {
            ResetInputOutputTbx();
            ClearValueInMemory();
        }

        #endregion
    }
}
