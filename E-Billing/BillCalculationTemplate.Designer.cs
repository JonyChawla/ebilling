﻿namespace E_Billing
{
    partial class BillCalculationTemplate
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
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblArticles = new System.Windows.Forms.Label();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.dtpAllotmentDate = new System.Windows.Forms.DateTimePicker();
            this.dtpDateofChallan = new System.Windows.Forms.DateTimePicker();
            this.grvArticleWiseBill = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNoofcopies = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtprintedpages = new System.Windows.Forms.TextBox();
            this.txttotalpages = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbFinancialYear = new System.Windows.Forms.ComboBox();
            this.btnLoadParticulars = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtClassType = new System.Windows.Forms.TextBox();
            this.ArticleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grvArticleWiseBill)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(444, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 47;
            this.label4.Text = "Dated of Challan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(456, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "Allotment Date";
            // 
            // lblArticles
            // 
            this.lblArticles.AutoSize = true;
            this.lblArticles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArticles.Location = new System.Drawing.Point(498, 15);
            this.lblArticles.Name = "lblArticles";
            this.lblArticles.Size = new System.Drawing.Size(48, 13);
            this.lblArticles.TabIndex = 41;
            this.lblArticles.Text = "Bill No.";
            // 
            // txtBillNo
            // 
            this.txtBillNo.Location = new System.Drawing.Point(549, 12);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(199, 20);
            this.txtBillNo.TabIndex = 48;
            // 
            // dtpAllotmentDate
            // 
            this.dtpAllotmentDate.Location = new System.Drawing.Point(549, 41);
            this.dtpAllotmentDate.Name = "dtpAllotmentDate";
            this.dtpAllotmentDate.Size = new System.Drawing.Size(200, 20);
            this.dtpAllotmentDate.TabIndex = 49;
            // 
            // dtpDateofChallan
            // 
            this.dtpDateofChallan.Location = new System.Drawing.Point(549, 68);
            this.dtpDateofChallan.Name = "dtpDateofChallan";
            this.dtpDateofChallan.Size = new System.Drawing.Size(200, 20);
            this.dtpDateofChallan.TabIndex = 50;
            // 
            // grvArticleWiseBill
            // 
            this.grvArticleWiseBill.AllowUserToAddRows = false;
            this.grvArticleWiseBill.AllowUserToDeleteRows = false;
            this.grvArticleWiseBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvArticleWiseBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ArticleName,
            this.Rate,
            this.Amount});
            this.grvArticleWiseBill.Location = new System.Drawing.Point(3, 3);
            this.grvArticleWiseBill.Name = "grvArticleWiseBill";
            this.grvArticleWiseBill.ReadOnly = true;
            this.grvArticleWiseBill.Size = new System.Drawing.Size(465, 284);
            this.grvArticleWiseBill.TabIndex = 18;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.grvArticleWiseBill);
            this.panel1.Location = new System.Drawing.Point(293, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(473, 292);
            this.panel1.TabIndex = 51;
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Enabled = false;
            this.txtTotalAmount.Location = new System.Drawing.Point(405, 404);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(306, 20);
            this.txtTotalAmount.TabIndex = 53;
            this.txtTotalAmount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(313, 407);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 52;
            this.label1.Text = "Total Amount";
            // 
            // cmbClass
            // 
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(119, 12);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(132, 21);
            this.cmbClass.TabIndex = 54;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.cmbClass_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 55;
            this.label3.Text = "Class";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.txtNoofcopies);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(8, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(103, 83);
            this.panel2.TabIndex = 63;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.textBox1);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Location = new System.Drawing.Point(-1, 105);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(103, 83);
            this.panel4.TabIndex = 64;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(80, 20);
            this.textBox1.TabIndex = 60;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 59;
            this.label10.Text = "No of Copies";
            // 
            // txtNoofcopies
            // 
            this.txtNoofcopies.Location = new System.Drawing.Point(9, 55);
            this.txtNoofcopies.Name = "txtNoofcopies";
            this.txtNoofcopies.Size = new System.Drawing.Size(80, 20);
            this.txtNoofcopies.TabIndex = 60;
            this.txtNoofcopies.Text = "0";
            this.txtNoofcopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNoofcopies.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoofcopies_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "No of Copies";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtprintedpages);
            this.panel3.Controls.Add(this.txttotalpages);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(117, 103);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(169, 83);
            this.panel3.TabIndex = 64;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(99, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 67;
            this.label8.Text = "Printed";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(23, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 66;
            this.label7.Text = "Total";
            // 
            // txtprintedpages
            // 
            this.txtprintedpages.Location = new System.Drawing.Point(85, 56);
            this.txtprintedpages.Name = "txtprintedpages";
            this.txtprintedpages.Size = new System.Drawing.Size(74, 20);
            this.txtprintedpages.TabIndex = 65;
            this.txtprintedpages.Text = "0";
            this.txtprintedpages.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtprintedpages.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtprintedpages_KeyPress);
            // 
            // txttotalpages
            // 
            this.txttotalpages.Location = new System.Drawing.Point(6, 56);
            this.txttotalpages.Name = "txttotalpages";
            this.txttotalpages.Size = new System.Drawing.Size(73, 20);
            this.txttotalpages.TabIndex = 64;
            this.txttotalpages.Text = "0";
            this.txttotalpages.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txttotalpages.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttotalpages_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(45, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 63;
            this.label6.Text = "No of Pages";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(24, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 66;
            this.label9.Text = "Financial Year";
            // 
            // cmbFinancialYear
            // 
            this.cmbFinancialYear.FormattingEnabled = true;
            this.cmbFinancialYear.Location = new System.Drawing.Point(119, 63);
            this.cmbFinancialYear.Name = "cmbFinancialYear";
            this.cmbFinancialYear.Size = new System.Drawing.Size(132, 21);
            this.cmbFinancialYear.TabIndex = 65;
            // 
            // btnLoadParticulars
            // 
            this.btnLoadParticulars.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadParticulars.ForeColor = System.Drawing.Color.Sienna;
            this.btnLoadParticulars.Location = new System.Drawing.Point(72, 198);
            this.btnLoadParticulars.Name = "btnLoadParticulars";
            this.btnLoadParticulars.Size = new System.Drawing.Size(153, 40);
            this.btnLoadParticulars.TabIndex = 67;
            this.btnLoadParticulars.Text = "Load Items";
            this.btnLoadParticulars.UseVisualStyleBackColor = true;
            this.btnLoadParticulars.Click += new System.EventHandler(this.btnLoadParticulars_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(40, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 72;
            this.label12.Text = "Class Type";
            // 
            // txtClassType
            // 
            this.txtClassType.Enabled = false;
            this.txtClassType.Location = new System.Drawing.Point(119, 38);
            this.txtClassType.Name = "txtClassType";
            this.txtClassType.Size = new System.Drawing.Size(80, 20);
            this.txtClassType.TabIndex = 65;
            this.txtClassType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ArticleName
            // 
            this.ArticleName.HeaderText = "Particular";
            this.ArticleName.Name = "ArticleName";
            this.ArticleName.ReadOnly = true;
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            this.Rate.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // BillCalculationTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 441);
            this.Controls.Add(this.txtClassType);
            this.Controls.Add(this.btnLoadParticulars);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbFinancialYear);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dtpDateofChallan);
            this.Controls.Add(this.dtpAllotmentDate);
            this.Controls.Add(this.txtBillNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblArticles);
            this.Name = "BillCalculationTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BillCalculationTemplate";
            this.Load += new System.EventHandler(this.BillCalculationTemplate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvArticleWiseBill)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblArticles;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.DateTimePicker dtpAllotmentDate;
        private System.Windows.Forms.DateTimePicker dtpDateofChallan;
        private System.Windows.Forms.DataGridView grvArticleWiseBill;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtNoofcopies;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtprintedpages;
        private System.Windows.Forms.TextBox txttotalpages;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbFinancialYear;
        private System.Windows.Forms.Button btnLoadParticulars;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtClassType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArticleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
    }
}