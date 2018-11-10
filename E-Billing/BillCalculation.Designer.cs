namespace E_Billing
{
    partial class BillCalculation
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
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grvArticleWiseBill = new System.Windows.Forms.DataGridView();
            this.ArticleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArticleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArticleRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.lblArticles = new System.Windows.Forms.Label();
            this.cmbArticles = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblGSTrate = new System.Windows.Forms.Label();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.txtGSTAmount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvArticleWiseBill)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBillNo
            // 
            this.txtBillNo.Location = new System.Drawing.Point(100, 21);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(541, 20);
            this.txtBillNo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bill No.";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.grvArticleWiseBill);
            this.panel1.Location = new System.Drawing.Point(381, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 395);
            this.panel1.TabIndex = 12;
            // 
            // grvArticleWiseBill
            // 
            this.grvArticleWiseBill.AllowUserToAddRows = false;
            this.grvArticleWiseBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvArticleWiseBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ArticleID,
            this.ArticleName,
            this.ArticleRate,
            this.Qty,
            this.Amount});
            this.grvArticleWiseBill.Location = new System.Drawing.Point(13, 11);
            this.grvArticleWiseBill.Name = "grvArticleWiseBill";
            this.grvArticleWiseBill.ReadOnly = true;
            this.grvArticleWiseBill.Size = new System.Drawing.Size(570, 369);
            this.grvArticleWiseBill.TabIndex = 18;
            this.grvArticleWiseBill.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grvArticleWiseBill_RowsAdded);
            this.grvArticleWiseBill.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.grvArticleWiseBill_RowsRemoved);
            // 
            // ArticleID
            // 
            this.ArticleID.HeaderText = "ArticleID";
            this.ArticleID.Name = "ArticleID";
            this.ArticleID.ReadOnly = true;
            this.ArticleID.Visible = false;
            // 
            // ArticleName
            // 
            this.ArticleName.HeaderText = "ArticleName";
            this.ArticleName.Name = "ArticleName";
            this.ArticleName.ReadOnly = true;
            // 
            // ArticleRate
            // 
            this.ArticleRate.HeaderText = "ArticleRate";
            this.ArticleRate.Name = "ArticleRate";
            this.ArticleRate.ReadOnly = true;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(102, 190);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(265, 30);
            this.btnAdd.TabIndex = 27;
            this.btnAdd.Text = "Add to List";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(16, 391);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(139, 47);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Confirm and Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(210, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 47);
            this.button1.TabIndex = 29;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(230, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Qty";
            // 
            // txtQty
            // 
            this.txtQty.Enabled = false;
            this.txtQty.Location = new System.Drawing.Point(259, 113);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(109, 20);
            this.txtQty.TabIndex = 34;
            this.txtQty.Text = "0";
            this.txtQty.TextChanged += new System.EventHandler(this.txtQty_TextChanged);
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(61, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Rate";
            // 
            // txtRate
            // 
            this.txtRate.Enabled = false;
            this.txtRate.Location = new System.Drawing.Point(101, 114);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(127, 20);
            this.txtRate.TabIndex = 32;
            this.txtRate.Text = "0";
            // 
            // lblArticles
            // 
            this.lblArticles.AutoSize = true;
            this.lblArticles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArticles.Location = new System.Drawing.Point(10, 82);
            this.lblArticles.Name = "lblArticles";
            this.lblArticles.Size = new System.Drawing.Size(89, 13);
            this.lblArticles.TabIndex = 31;
            this.lblArticles.Text = "Choose Article";
            // 
            // cmbArticles
            // 
            this.cmbArticles.FormattingEnabled = true;
            this.cmbArticles.Location = new System.Drawing.Point(101, 79);
            this.cmbArticles.Name = "cmbArticles";
            this.cmbArticles.Size = new System.Drawing.Size(271, 21);
            this.cmbArticles.TabIndex = 30;
            this.cmbArticles.SelectedIndexChanged += new System.EventHandler(this.cmbArticles_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(48, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.Enabled = false;
            this.txtAmount.Location = new System.Drawing.Point(102, 152);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(265, 20);
            this.txtAmount.TabIndex = 38;
            this.txtAmount.Text = "0";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblGSTrate);
            this.panel2.Controls.Add(this.txtGrandTotal);
            this.panel2.Controls.Add(this.txtTotalAmount);
            this.panel2.Controls.Add(this.txtGSTAmount);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(13, 237);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(355, 121);
            this.panel2.TabIndex = 40;
            // 
            // lblGSTrate
            // 
            this.lblGSTrate.AutoSize = true;
            this.lblGSTrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGSTrate.ForeColor = System.Drawing.Color.Red;
            this.lblGSTrate.Location = new System.Drawing.Point(276, 49);
            this.lblGSTrate.Name = "lblGSTrate";
            this.lblGSTrate.Size = new System.Drawing.Size(32, 13);
            this.lblGSTrate.TabIndex = 41;
            this.lblGSTrate.Text = "GST";
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.Enabled = false;
            this.txtGrandTotal.Location = new System.Drawing.Point(115, 77);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.Size = new System.Drawing.Size(224, 20);
            this.txtGrandTotal.TabIndex = 40;
            this.txtGrandTotal.Text = "0";
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Enabled = false;
            this.txtTotalAmount.Location = new System.Drawing.Point(115, 17);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.Size = new System.Drawing.Size(224, 20);
            this.txtTotalAmount.TabIndex = 39;
            this.txtTotalAmount.Text = "0";
            // 
            // txtGSTAmount
            // 
            this.txtGSTAmount.Enabled = false;
            this.txtGSTAmount.Location = new System.Drawing.Point(115, 46);
            this.txtGSTAmount.Name = "txtGSTAmount";
            this.txtGSTAmount.Size = new System.Drawing.Size(155, 20);
            this.txtGSTAmount.TabIndex = 33;
            this.txtGSTAmount.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Grand Total";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "GST";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total Amount";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.DarkRed;
            this.button2.Location = new System.Drawing.Point(867, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 30);
            this.button2.TabIndex = 42;
            this.button2.Text = "Reset All";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BillCalculation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 474);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRate);
            this.Controls.Add(this.lblArticles);
            this.Controls.Add(this.cmbArticles);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBillNo);
            this.Name = "BillCalculation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BillCalculation";
            this.Load += new System.EventHandler(this.BillCalculation_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvArticleWiseBill)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView grvArticleWiseBill;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label lblArticles;
        private System.Windows.Forms.ComboBox cmbArticles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArticleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArticleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArticleRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.TextBox txtGSTAmount;
        private System.Windows.Forms.Label lblGSTrate;
        private System.Windows.Forms.Button button2;
    }
}