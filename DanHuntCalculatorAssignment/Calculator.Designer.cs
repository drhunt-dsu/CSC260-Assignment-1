namespace DanHuntCalculatorAssignment
{
    partial class Calculator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbxInputOutput = new System.Windows.Forms.TextBox();
            this.lblInputOutput = new System.Windows.Forms.Label();
            this.btnMemStore = new System.Windows.Forms.Button();
            this.btnMemRestore = new System.Windows.Forms.Button();
            this.btnMemClear = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnClearBox = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnPower = new System.Windows.Forms.Button();
            this.btnSquare = new System.Windows.Forms.Button();
            this.btnSquareRoot = new System.Windows.Forms.Button();
            this.btnDivide = new System.Windows.Forms.Button();
            this.btnSeven = new System.Windows.Forms.Button();
            this.btnEight = new System.Windows.Forms.Button();
            this.btnNine = new System.Windows.Forms.Button();
            this.btnMultiply = new System.Windows.Forms.Button();
            this.btnFour = new System.Windows.Forms.Button();
            this.btnFive = new System.Windows.Forms.Button();
            this.btnSix = new System.Windows.Forms.Button();
            this.btnSubtract = new System.Windows.Forms.Button();
            this.btnOne = new System.Windows.Forms.Button();
            this.btnTwo = new System.Windows.Forms.Button();
            this.btnThree = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnPosNeg = new System.Windows.Forms.Button();
            this.btnZero = new System.Windows.Forms.Button();
            this.btnDecimal = new System.Windows.Forms.Button();
            this.btnEquals = new System.Windows.Forms.Button();
            this.lblMemory = new System.Windows.Forms.Label();
            this.lblMemVal = new System.Windows.Forms.Label();
            this.lblHistory = new System.Windows.Forms.Label();
            this.tbxHistory = new System.Windows.Forms.TextBox();
            this.btnModulus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxInputOutput
            // 
            this.tbxInputOutput.Location = new System.Drawing.Point(97, 37);
            this.tbxInputOutput.Name = "tbxInputOutput";
            this.tbxInputOutput.ReadOnly = true;
            this.tbxInputOutput.Size = new System.Drawing.Size(171, 20);
            this.tbxInputOutput.TabIndex = 1;
            this.tbxInputOutput.TabStop = false;
            this.tbxInputOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblInputOutput
            // 
            this.lblInputOutput.AutoSize = true;
            this.lblInputOutput.Location = new System.Drawing.Point(23, 40);
            this.lblInputOutput.Name = "lblInputOutput";
            this.lblInputOutput.Size = new System.Drawing.Size(71, 13);
            this.lblInputOutput.TabIndex = 0;
            this.lblInputOutput.Text = "Input/Output:";
            // 
            // btnMemStore
            // 
            this.btnMemStore.Location = new System.Drawing.Point(150, 95);
            this.btnMemStore.Name = "btnMemStore";
            this.btnMemStore.Size = new System.Drawing.Size(56, 28);
            this.btnMemStore.TabIndex = 9;
            this.btnMemStore.Text = "MS";
            this.btnMemStore.UseVisualStyleBackColor = true;
            this.btnMemStore.Click += new System.EventHandler(this.btnMemStore_Click);
            // 
            // btnMemRestore
            // 
            this.btnMemRestore.Location = new System.Drawing.Point(88, 95);
            this.btnMemRestore.Name = "btnMemRestore";
            this.btnMemRestore.Size = new System.Drawing.Size(56, 28);
            this.btnMemRestore.TabIndex = 8;
            this.btnMemRestore.Text = "MR";
            this.btnMemRestore.UseVisualStyleBackColor = true;
            this.btnMemRestore.Click += new System.EventHandler(this.btnMemRestore_Click);
            // 
            // btnMemClear
            // 
            this.btnMemClear.Location = new System.Drawing.Point(26, 95);
            this.btnMemClear.Name = "btnMemClear";
            this.btnMemClear.Size = new System.Drawing.Size(56, 28);
            this.btnMemClear.TabIndex = 7;
            this.btnMemClear.Text = "MC";
            this.btnMemClear.UseVisualStyleBackColor = true;
            this.btnMemClear.Click += new System.EventHandler(this.btnMemClear_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClearAll.Location = new System.Drawing.Point(88, 143);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(56, 33);
            this.btnClearAll.TabIndex = 11;
            this.btnClearAll.Text = "CE";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnClearBox
            // 
            this.btnClearBox.Location = new System.Drawing.Point(150, 143);
            this.btnClearBox.Name = "btnClearBox";
            this.btnClearBox.Size = new System.Drawing.Size(56, 33);
            this.btnClearBox.TabIndex = 12;
            this.btnClearBox.Text = "C";
            this.btnClearBox.UseVisualStyleBackColor = true;
            this.btnClearBox.Click += new System.EventHandler(this.btnClearBox_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(212, 143);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(56, 33);
            this.btnBack.TabIndex = 13;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnPower
            // 
            this.btnPower.Location = new System.Drawing.Point(26, 189);
            this.btnPower.Name = "btnPower";
            this.btnPower.Size = new System.Drawing.Size(56, 33);
            this.btnPower.TabIndex = 14;
            this.btnPower.Text = "x^y";
            this.btnPower.UseVisualStyleBackColor = true;
            this.btnPower.Click += new System.EventHandler(this.btnPower_Click);
            // 
            // btnSquare
            // 
            this.btnSquare.Location = new System.Drawing.Point(88, 189);
            this.btnSquare.Name = "btnSquare";
            this.btnSquare.Size = new System.Drawing.Size(56, 33);
            this.btnSquare.TabIndex = 15;
            this.btnSquare.Text = "x^2";
            this.btnSquare.UseVisualStyleBackColor = true;
            this.btnSquare.Click += new System.EventHandler(this.btnSquare_Click);
            // 
            // btnSquareRoot
            // 
            this.btnSquareRoot.Location = new System.Drawing.Point(150, 189);
            this.btnSquareRoot.Name = "btnSquareRoot";
            this.btnSquareRoot.Size = new System.Drawing.Size(56, 33);
            this.btnSquareRoot.TabIndex = 16;
            this.btnSquareRoot.Text = "sqrt";
            this.btnSquareRoot.UseVisualStyleBackColor = true;
            this.btnSquareRoot.Click += new System.EventHandler(this.btnSquareRoot_Click);
            // 
            // btnDivide
            // 
            this.btnDivide.Location = new System.Drawing.Point(212, 189);
            this.btnDivide.Name = "btnDivide";
            this.btnDivide.Size = new System.Drawing.Size(56, 33);
            this.btnDivide.TabIndex = 17;
            this.btnDivide.Text = "/";
            this.btnDivide.UseVisualStyleBackColor = true;
            this.btnDivide.Click += new System.EventHandler(this.btnOperator_click);
            // 
            // btnSeven
            // 
            this.btnSeven.Location = new System.Drawing.Point(26, 228);
            this.btnSeven.Name = "btnSeven";
            this.btnSeven.Size = new System.Drawing.Size(56, 33);
            this.btnSeven.TabIndex = 18;
            this.btnSeven.Text = "7";
            this.btnSeven.UseVisualStyleBackColor = true;
            this.btnSeven.Click += new System.EventHandler(this.btnNumberKeys_Click);
            // 
            // btnEight
            // 
            this.btnEight.Location = new System.Drawing.Point(88, 228);
            this.btnEight.Name = "btnEight";
            this.btnEight.Size = new System.Drawing.Size(56, 33);
            this.btnEight.TabIndex = 19;
            this.btnEight.Text = "8";
            this.btnEight.UseVisualStyleBackColor = true;
            this.btnEight.Click += new System.EventHandler(this.btnNumberKeys_Click);
            // 
            // btnNine
            // 
            this.btnNine.Location = new System.Drawing.Point(150, 228);
            this.btnNine.Name = "btnNine";
            this.btnNine.Size = new System.Drawing.Size(56, 33);
            this.btnNine.TabIndex = 20;
            this.btnNine.Text = "9";
            this.btnNine.UseVisualStyleBackColor = true;
            this.btnNine.Click += new System.EventHandler(this.btnNumberKeys_Click);
            // 
            // btnMultiply
            // 
            this.btnMultiply.Location = new System.Drawing.Point(212, 228);
            this.btnMultiply.Name = "btnMultiply";
            this.btnMultiply.Size = new System.Drawing.Size(56, 33);
            this.btnMultiply.TabIndex = 21;
            this.btnMultiply.Text = "x";
            this.btnMultiply.UseVisualStyleBackColor = true;
            this.btnMultiply.Click += new System.EventHandler(this.btnOperator_click);
            // 
            // btnFour
            // 
            this.btnFour.Location = new System.Drawing.Point(26, 267);
            this.btnFour.Name = "btnFour";
            this.btnFour.Size = new System.Drawing.Size(56, 33);
            this.btnFour.TabIndex = 22;
            this.btnFour.Text = "4";
            this.btnFour.UseVisualStyleBackColor = true;
            this.btnFour.Click += new System.EventHandler(this.btnNumberKeys_Click);
            // 
            // btnFive
            // 
            this.btnFive.Location = new System.Drawing.Point(88, 267);
            this.btnFive.Name = "btnFive";
            this.btnFive.Size = new System.Drawing.Size(56, 33);
            this.btnFive.TabIndex = 23;
            this.btnFive.Text = "5";
            this.btnFive.UseVisualStyleBackColor = true;
            this.btnFive.Click += new System.EventHandler(this.btnNumberKeys_Click);
            // 
            // btnSix
            // 
            this.btnSix.Location = new System.Drawing.Point(150, 267);
            this.btnSix.Name = "btnSix";
            this.btnSix.Size = new System.Drawing.Size(56, 33);
            this.btnSix.TabIndex = 24;
            this.btnSix.Text = "6";
            this.btnSix.UseVisualStyleBackColor = true;
            this.btnSix.Click += new System.EventHandler(this.btnNumberKeys_Click);
            // 
            // btnSubtract
            // 
            this.btnSubtract.Location = new System.Drawing.Point(212, 267);
            this.btnSubtract.Name = "btnSubtract";
            this.btnSubtract.Size = new System.Drawing.Size(56, 33);
            this.btnSubtract.TabIndex = 25;
            this.btnSubtract.Text = "-";
            this.btnSubtract.UseVisualStyleBackColor = true;
            this.btnSubtract.Click += new System.EventHandler(this.btnOperator_click);
            // 
            // btnOne
            // 
            this.btnOne.Location = new System.Drawing.Point(26, 306);
            this.btnOne.Name = "btnOne";
            this.btnOne.Size = new System.Drawing.Size(56, 33);
            this.btnOne.TabIndex = 26;
            this.btnOne.Text = "1";
            this.btnOne.UseVisualStyleBackColor = true;
            this.btnOne.Click += new System.EventHandler(this.btnNumberKeys_Click);
            // 
            // btnTwo
            // 
            this.btnTwo.Location = new System.Drawing.Point(88, 306);
            this.btnTwo.Name = "btnTwo";
            this.btnTwo.Size = new System.Drawing.Size(56, 33);
            this.btnTwo.TabIndex = 27;
            this.btnTwo.Text = "2";
            this.btnTwo.UseVisualStyleBackColor = true;
            this.btnTwo.Click += new System.EventHandler(this.btnNumberKeys_Click);
            // 
            // btnThree
            // 
            this.btnThree.Location = new System.Drawing.Point(150, 306);
            this.btnThree.Name = "btnThree";
            this.btnThree.Size = new System.Drawing.Size(56, 33);
            this.btnThree.TabIndex = 28;
            this.btnThree.Text = "3";
            this.btnThree.UseVisualStyleBackColor = true;
            this.btnThree.Click += new System.EventHandler(this.btnNumberKeys_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Location = new System.Drawing.Point(212, 306);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(56, 33);
            this.btnPlus.TabIndex = 29;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnOperator_click);
            // 
            // btnPosNeg
            // 
            this.btnPosNeg.Location = new System.Drawing.Point(26, 345);
            this.btnPosNeg.Name = "btnPosNeg";
            this.btnPosNeg.Size = new System.Drawing.Size(56, 33);
            this.btnPosNeg.TabIndex = 30;
            this.btnPosNeg.Text = "+/-";
            this.btnPosNeg.UseVisualStyleBackColor = true;
            this.btnPosNeg.Click += new System.EventHandler(this.btnPosNeg_Click);
            // 
            // btnZero
            // 
            this.btnZero.Location = new System.Drawing.Point(88, 345);
            this.btnZero.Name = "btnZero";
            this.btnZero.Size = new System.Drawing.Size(56, 33);
            this.btnZero.TabIndex = 31;
            this.btnZero.Text = "0";
            this.btnZero.UseVisualStyleBackColor = true;
            this.btnZero.Click += new System.EventHandler(this.btnZero_Click);
            // 
            // btnDecimal
            // 
            this.btnDecimal.Location = new System.Drawing.Point(150, 345);
            this.btnDecimal.Name = "btnDecimal";
            this.btnDecimal.Size = new System.Drawing.Size(56, 33);
            this.btnDecimal.TabIndex = 32;
            this.btnDecimal.Text = ".";
            this.btnDecimal.UseVisualStyleBackColor = true;
            this.btnDecimal.Click += new System.EventHandler(this.btnDecimal_Click);
            // 
            // btnEquals
            // 
            this.btnEquals.Location = new System.Drawing.Point(212, 345);
            this.btnEquals.Name = "btnEquals";
            this.btnEquals.Size = new System.Drawing.Size(56, 33);
            this.btnEquals.TabIndex = 6;
            this.btnEquals.Text = "=";
            this.btnEquals.UseVisualStyleBackColor = true;
            this.btnEquals.Click += new System.EventHandler(this.btnEquals_Click);
            // 
            // lblMemory
            // 
            this.lblMemory.AutoSize = true;
            this.lblMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemory.Location = new System.Drawing.Point(212, 103);
            this.lblMemory.Name = "lblMemory";
            this.lblMemory.Size = new System.Drawing.Size(37, 13);
            this.lblMemory.TabIndex = 4;
            this.lblMemory.Text = "Mem:";
            // 
            // lblMemVal
            // 
            this.lblMemVal.AutoSize = true;
            this.lblMemVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemVal.Location = new System.Drawing.Point(255, 103);
            this.lblMemVal.Name = "lblMemVal";
            this.lblMemVal.Size = new System.Drawing.Size(0, 13);
            this.lblMemVal.TabIndex = 5;
            // 
            // lblHistory
            // 
            this.lblHistory.AutoSize = true;
            this.lblHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHistory.Location = new System.Drawing.Point(364, 37);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(65, 20);
            this.lblHistory.TabIndex = 2;
            this.lblHistory.Text = "History";
            // 
            // tbxHistory
            // 
            this.tbxHistory.Location = new System.Drawing.Point(308, 75);
            this.tbxHistory.Multiline = true;
            this.tbxHistory.Name = "tbxHistory";
            this.tbxHistory.ReadOnly = true;
            this.tbxHistory.Size = new System.Drawing.Size(200, 303);
            this.tbxHistory.TabIndex = 3;
            this.tbxHistory.TabStop = false;
            this.tbxHistory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnModulus
            // 
            this.btnModulus.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnModulus.Location = new System.Drawing.Point(26, 143);
            this.btnModulus.Name = "btnModulus";
            this.btnModulus.Size = new System.Drawing.Size(56, 33);
            this.btnModulus.TabIndex = 10;
            this.btnModulus.Text = "%";
            this.btnModulus.UseVisualStyleBackColor = true;
            this.btnModulus.Click += new System.EventHandler(this.btnOperator_click);
            // 
            // Calculator
            // 
            this.AcceptButton = this.btnEquals;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClearAll;
            this.ClientSize = new System.Drawing.Size(540, 405);
            this.Controls.Add(this.btnModulus);
            this.Controls.Add(this.tbxHistory);
            this.Controls.Add(this.lblHistory);
            this.Controls.Add(this.lblMemVal);
            this.Controls.Add(this.lblMemory);
            this.Controls.Add(this.btnEquals);
            this.Controls.Add(this.btnDecimal);
            this.Controls.Add(this.btnZero);
            this.Controls.Add(this.btnPosNeg);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.btnThree);
            this.Controls.Add(this.btnTwo);
            this.Controls.Add(this.btnOne);
            this.Controls.Add(this.btnSubtract);
            this.Controls.Add(this.btnSix);
            this.Controls.Add(this.btnFive);
            this.Controls.Add(this.btnFour);
            this.Controls.Add(this.btnMultiply);
            this.Controls.Add(this.btnNine);
            this.Controls.Add(this.btnEight);
            this.Controls.Add(this.btnSeven);
            this.Controls.Add(this.btnDivide);
            this.Controls.Add(this.btnSquareRoot);
            this.Controls.Add(this.btnSquare);
            this.Controls.Add(this.btnPower);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnClearBox);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnMemStore);
            this.Controls.Add(this.btnMemRestore);
            this.Controls.Add(this.btnMemClear);
            this.Controls.Add(this.lblInputOutput);
            this.Controls.Add(this.tbxInputOutput);
            this.KeyPreview = true;
            this.Name = "Calculator";
            this.Text = "Dan Hunt\'s Mediocre Calculator";
            this.Load += new System.EventHandler(this.Calculator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxInputOutput;
        private System.Windows.Forms.Label lblInputOutput;
        private System.Windows.Forms.Button btnMemStore;
        private System.Windows.Forms.Button btnMemRestore;
        private System.Windows.Forms.Button btnMemClear;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnClearBox;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnPower;
        private System.Windows.Forms.Button btnSquare;
        private System.Windows.Forms.Button btnSquareRoot;
        private System.Windows.Forms.Button btnDivide;
        private System.Windows.Forms.Button btnSeven;
        private System.Windows.Forms.Button btnEight;
        private System.Windows.Forms.Button btnNine;
        private System.Windows.Forms.Button btnMultiply;
        private System.Windows.Forms.Button btnFour;
        private System.Windows.Forms.Button btnFive;
        private System.Windows.Forms.Button btnSix;
        private System.Windows.Forms.Button btnSubtract;
        private System.Windows.Forms.Button btnOne;
        private System.Windows.Forms.Button btnTwo;
        private System.Windows.Forms.Button btnThree;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnPosNeg;
        private System.Windows.Forms.Button btnZero;
        private System.Windows.Forms.Button btnDecimal;
        private System.Windows.Forms.Button btnEquals;
        private System.Windows.Forms.Label lblMemory;
        private System.Windows.Forms.Label lblMemVal;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.TextBox tbxHistory;
        private System.Windows.Forms.Button btnModulus;
    }
}

