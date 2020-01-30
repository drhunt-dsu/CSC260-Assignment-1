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

        private float memVal;

        public Calculator()
        {
            InitializeComponent();
        }

        #region ButtonHandlers

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void btnMemRestore_Click(object sender, EventArgs e)
        {

        }

        private void btnMemClear_Click(object sender, EventArgs e)
        {
            ClearValueInMemory();
        }

        private void btnMemStore_Click(object sender, EventArgs e)
        {
            UpdateMemoryValueAndLabel();
            RestoreValueFromMemory();
        }

        #endregion
        #region MemoryManip

        private void UpdateMemoryValueAndLabel()
        {
            memVal = float.Parse(tbxInputOutput.Text);
            lblMemVal.Text = memVal.ToString(CultureInfo.InvariantCulture);
        }

        private void RestoreValueFromMemory()
        {
            tbxInputOutput.Text = memVal.ToString(CultureInfo.InvariantCulture);
        }

        private void ClearValueInMemory()
        {
            memVal = 0;
            lblMemVal.Text = string.Empty;
        }

        #endregion

    }
}
