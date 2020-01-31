//Dan Hunt
//Daniel.Hunt@trojans.dsu.edu
//CSC260 Assignment 1: Calculator

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanHuntCalculatorAssignment
{
    public partial class Calculator : Form
    {

        private float? _memVal;
        private const string InitialValue = "0";
        private const string StockOperands = @"^-+*x/%";
        private const string OperandRegex = @"[-+*x\/%\^]"; //Hopefully matches all math operands
        private Stack<float> numberStack; //Stores numbers to be math'd upon
        private Stack<string> operandStack; //Stores math to math upon the numbers
        private Stack<string> mathHistory; //Stores historical list of math

        public Calculator()
        {
            InitializeComponent();
            mathHistory = new Stack<string>();
            ResetCalculator(); //Set Calculator to initial value so we don't have an empty string
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            //I don't remember what I clicked on to create this method but at this point I'm too afraid to delete it
        }

        #region ButtonHandlers
        private void btnNumberKeys_Click(object sender, EventArgs e)
        {
            AppendToInputOutputBox(((ButtonBase) sender).Text);
        }

        private void btnOperand_click(object sender, EventArgs e)
        {
            //Keeping sparate from number key method in case I want to do something different
            var stringToAppend = $" {((ButtonBase) sender).Text} ";
            AppendToInputOutputBox(stringToAppend);
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
            PopulateStacks(); //Populate number and operand stacks for mathy math

            //Kind of placeholder stuff to check if history is working. Not sure if I will ever need this mathHistory stack 
            //mathHistory stack feeling useless, might delete later
            mathHistory.Push(tbxInputOutput.Text);
            tbxHistory.Text += tbxInputOutput.Text + Environment.NewLine; //Eventually need to replace this with whole math equation
            ResetInputOutputTbx(); //Clear the input from the box

            //Add something here to do math
            //Add something here to populate the box with the most recent answer
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

        private void ReadTexbox()
        {
            string mathString = tbxInputOutput.Text;
            List<float> numbersToPush = new List<float>();
            List<string> operandsToPush = new List<string>();

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
            //Stackoverflow to the rescue with this regex
            //https://stackoverflow.com/questions/13525024/how-to-split-a-mathematical-expression-on-operators-as-delimiters-while-keeping
            string[] numbers = Regex.Split(currentString, @"[-+*x/%]");
            if (!numbers.Last().Contains("."))
            {
                AppendToInputOutputBox(".");
            }
        }
        #endregion
        #region Utility Functions
        private void ResetCalculator()
        {
            ClearNumberAndOperandStacks();
            ResetInputOutputTbx();
            ClearValueInMemory();
        }

        private void PopulateStacks()
        {
            ClearNumberAndOperandStacks(); //Clear existing data in stacks
            var currentString = tbxInputOutput.Text; //capture the textbox data in a string that we can manipulate
            currentString = currentString.Replace(" ", string.Empty); //remove all whitespace since we don't care about it for math

            //Get all the numbers in left to right oder and push onto number stack
            var numbers = Regex.Split(currentString, OperandRegex);
            numbers.ToList().ForEach(number => numberStack.Push(float.Parse(number)));
            //Get all the operands in left to right order and push onto stack
            foreach (var character in currentString)
            {
                if (StockOperands.Contains(character))
                {
                    operandStack.Push(character.ToString());
                }
            }
        }

        private void ClearNumberAndOperandStacks()
        {
            numberStack = new Stack<float>();
            operandStack = new Stack<string>();
        }
        #endregion

        
    }
}
