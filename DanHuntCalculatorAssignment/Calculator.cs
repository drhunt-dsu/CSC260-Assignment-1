//Dan Hunt
//Daniel.Hunt@trojans.dsu.edu
//CSC260 Assignment 1: Calculator

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DanHuntCalculatorAssignment
{
    public partial class Calculator : Form
    {

        private float _memVal;
        private const string InitialValue = "0";

        public Calculator()
        {
            InitializeComponent();
            ResetCalculator(); //Set Calculator to initial value so we don't have an empty string
        }

        #region ButtonHandlers
        private void btnNumberKeys_Click(object sender, EventArgs e)
        {
            AppendToInputOutputBox(((ButtonBase) sender).Text);
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

        private void btnMemRestore_Click(object sender, EventArgs e)
        {
            RestoreValueFromMemory();
        }

        private void btnMemClear_Click(object sender, EventArgs e)
        {
            ClearValueInMemory();
        }

        private void btnMemStore_Click(object sender, EventArgs e)
        {
            UpdateMemoryValueAndLabel();
        }
        #endregion
        #region Stored memory value functions
        private void UpdateMemoryValueAndLabel()
        {
            _memVal = float.Parse(tbxInputOutput.Text);
            lblMemVal.Text = _memVal.ToString(CultureInfo.InvariantCulture);
        }

        private void RestoreValueFromMemory()
        {
            tbxInputOutput.Text = _memVal.ToString(CultureInfo.InvariantCulture);
        }

        private void ClearValueInMemory()
        {
            _memVal = 0;
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
