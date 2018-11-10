using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Configuration;


namespace E_Billing
{
    public partial class BillCalculation : Form
    {
        OleDbConnection con = new OleDbConnection();        
        public BillCalculation()
        {
            InitializeComponent();
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + System.Environment.CurrentDirectory + "\\ebilling.accdb";
            if (getGSTRate() == 0)
            {
                MessageBox.Show("No GST found.. Please Add GST first.!");
                return;
            }           
        }        

        private void BillCalculation_Load(object sender, EventArgs e)
        {            
            fillArticles();
            lblGSTrate.Text = "";
        }
        private void fillArticles()
        {

            String articlesalreadyadded=getArticleAlreadyAddedInStringFormat();

            DataRow dr;            
            if(con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("select * from tblArticle where isActive=true and (ID NOT IN (" + articlesalreadyadded + "))", con);
            OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "--Select Article--" };
            dt.Rows.InsertAt(dr, 0);

            cmbArticles.ValueMember = "ID";
            cmbArticles.DisplayMember = "ArticleName";
            cmbArticles.DataSource = dt;

            con.Close();  
        }

        private string getArticleAlreadyAddedInStringFormat()
        {
            if (grvArticleWiseBill.Rows.Count==0)
            {
                return "0";
            }

            String articlesalreadyadded = "";
            for (int rows = 0; rows < grvArticleWiseBill.Rows.Count; rows++)
            {
                articlesalreadyadded=articlesalreadyadded+ grvArticleWiseBill.Rows[rows].Cells[0].Value.ToString();
                if (rows != (grvArticleWiseBill.Rows.Count - 1))
                {
                    articlesalreadyadded = articlesalreadyadded + ",";
                }
            }
            return articlesalreadyadded;

        }

        private void cmbArticles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cmbArticles.SelectedIndex == 0) && (txtQty.Text!=""))
            {
                txtQty.Enabled = true;
                getRateofArticle();
                calculateAmount();
            }
            else
            {
                txtRate.Text = "0";
                txtQty.Text= "0";
                txtQty.Enabled = false;
            }
        }

        private void calculateAmount()
        {
            decimal amount = decimal.Parse(txtQty.Text) * decimal.Parse(txtRate.Text);
            txtAmount.Text = amount.ToString();
        }

        private void getRateofArticle()
        {
            if (con.State==ConnectionState.Closed)  con.Open();
            OleDbCommand cmd = new OleDbCommand("select ArticleRate from tblArticle where ID=" + cmbArticles.SelectedValue, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtRate.Text = dr.GetValue(0).ToString();
            }
            con.Close();
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if(!(txtQty.Text==""))
                calculateAmount();
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }                        
        }

        private void addRowToGrid()
        {            
            grvArticleWiseBill.Rows.Add(cmbArticles.SelectedValue, cmbArticles.Text, txtRate.Text, txtQty.Text, txtAmount.Text);            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(!(cmbArticles.SelectedIndex==0) && (Int32.Parse(txtQty.Text) > 0))
                addRowToGrid();
        }

        private void grvArticleWiseBill_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            updateNetAmount();
            fillArticles();
        }

        private void grvArticleWiseBill_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            updateNetAmount();
            fillArticles();
        }

        private void updateNetAmount()
        {
            decimal gstrate = Math.Round(getGSTRate(), 2);
            setGSTLabelValue(gstrate);

            decimal totalamount = Math.Round(getTotalAmount(), 2);
            decimal gstamount = Math.Round(totalamount*(gstrate/100), 2);
            decimal grandtotal = Math.Round(totalamount+gstamount, 2);
            
            txtTotalAmount.Text = totalamount.ToString();
            txtGSTAmount.Text =  gstamount.ToString();
            txtGrandTotal.Text = grandtotal.ToString();
        }

        private void setGSTLabelValue(decimal gstrate)
        {
            lblGSTrate.Text = "@ " + gstrate + " %";
        }

        private decimal getTotalAmount()
        {
            decimal totalamount = 0;
            for (int rows = 0; rows < grvArticleWiseBill.Rows.Count; rows++)
            {
                decimal value = decimal.Parse(grvArticleWiseBill.Rows[rows].Cells[4].Value.ToString());
                totalamount = totalamount + value;
            }
            return totalamount;
        }

        private decimal getGSTRate()
        {
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("select GSTRate from tblGST where EntryDate=(select max(EntryDate) from tblGST)", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            decimal gstrate = 0;
            if (dr.Read())
            {
                gstrate = dr.GetDecimal(0);
            }
            con.Close();            
            return gstrate;
        }

        private bool isBillNumberExist(String billnumber)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("select BillNo from tblBillCalculation where BillNo='"+billnumber+"'", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }                        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(isBillNumberExist(txtBillNo.Text.Trim()))
            {
                MessageBox.Show("Bill Number Already exist..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (ValidateCalculationSave() == false)
            {
                return;
            }

            OleDbTransaction trans = null;
            decimal gstrate = getGSTRate();
            try
            {
                if(con.State==ConnectionState.Closed) con.Open();
                trans = con.BeginTransaction();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Transaction = trans;
                cmd.Connection = con;
                cmd.CommandText = "insert into tblBillCalculation (BillNo,GSTRate,GSTAmount,TotalBillAmount,GrandTotal) values(@BillNo,@GSTRate,@GSTAmount,@TotalBillAmount,@GrandTotal)";
                cmd.Parameters.AddWithValue("@BillNo", txtBillNo.Text);
                cmd.Parameters.AddWithValue("@GSTRate", gstrate);
                cmd.Parameters.AddWithValue("@GSTAmount", Decimal.Parse(txtGSTAmount.Text));
                cmd.Parameters.AddWithValue("@TotalBillAmount", Decimal.Parse(txtTotalAmount.Text));
                cmd.Parameters.AddWithValue("@GrandTotal", Decimal.Parse(txtGrandTotal.Text));
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    for (int rows = 0; rows < grvArticleWiseBill.Rows.Count; rows++)
                    {                                                
                        OleDbCommand cmdForBillDetail = new OleDbCommand();
                        cmdForBillDetail.Transaction = trans;
                        cmdForBillDetail.Connection = con;
                        cmdForBillDetail.CommandText = "insert into tblBillCalculationDetail (BillNo,ArticleId,ArticleRate,Qty,Amount) values(@BillNo,@ArticleId,@ArticleRate,@Qty,@Amount)";
                        cmdForBillDetail.Parameters.AddWithValue("@BillNo", txtBillNo.Text);
                        cmdForBillDetail.Parameters.AddWithValue("@ArticleId", grvArticleWiseBill.Rows[rows].Cells[0].Value.ToString());
                        cmdForBillDetail.Parameters.AddWithValue("@ArticleRate", Decimal.Parse(grvArticleWiseBill.Rows[rows].Cells[2].Value.ToString()));
                        cmdForBillDetail.Parameters.AddWithValue("@Qty", grvArticleWiseBill.Rows[rows].Cells[3].Value);
                        cmdForBillDetail.Parameters.AddWithValue("@Amount", Decimal.Parse(grvArticleWiseBill.Rows[rows].Cells[4].Value.ToString()));
                        int b = cmdForBillDetail.ExecuteNonQuery();                        
                    }
                }
                trans.Commit();
                MessageBox.Show("Bill Calculation Saved Successfully..!!");
                resetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
                trans.Rollback();
            }
            finally
            {
                con.Close();
            }
        }
        public bool ValidateCalculationSave()
        {
            bool returnvalue = true;
            if (txtBillNo.Text == "")
            {
                MessageBox.Show("Please Enter Bill Number..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                returnvalue = false;
            }
            else if (grvArticleWiseBill.Rows.Count==0)
            {
                MessageBox.Show("No Article added for billing..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                                
                returnvalue = false;
            }
            return returnvalue;
        }
        private void resetAll()
        {
            txtBillNo.Text = "";
            grvArticleWiseBill.Rows.Clear();
            txtRate.Text = "0";
            txtQty.Text = "0";
            txtAmount.Text = "0";
            txtGSTAmount.Text = "0";
            txtGrandTotal.Text = "0";
            txtTotalAmount.Text = "0";
            lblGSTrate.Text = "";
            fillArticles();    
        }

        private void btnSearchBillCalculation_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    if (txtBillNo.Text.Trim() == "")
        //    {
        //        MessageBox.Show("Please enter bill number..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    if (!getBillCalculation())
        //    {
        //        MessageBox.Show("No record found with this Bill Number : "+txtBillNo.Text.Trim(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }
        //    getBillCalculationDetail();
        //}

        //private void getBillCalculationDetail()
        //{            
        //    if (con.State == ConnectionState.Closed) con.Open();
        //    DataTable dt = new DataTable();
        //    OleDbCommand cmd = new OleDbCommand("Select * from tblBillCalculationDetail", con);
        //    OleDbDataReader dr = cmd.ExecuteReader();
        //    dt.Load(dr);

        //    dt.Columns.RemoveAt(0);
        //    grvArticleWiseBill.DataSource = dt;
        //    con.Close();            
        //}

        //private bool getBillCalculation()
        //{
        //    if (con.State == ConnectionState.Closed) con.Open();
        //    OleDbCommand cmd = new OleDbCommand("select * from tblBillCalculation where billno='" + txtBillNo.Text.Trim()+"'", con);
        //    OleDbDataReader dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        txtTotalAmount.Text = dr.GetValue(2).ToString();
        //        lblGSTrate.Text = "@ " + dr.GetValue(3).ToString() + " %";
        //        txtGSTAmount.Text = dr.GetValue(4).ToString();
        //        txtGrandTotal.Text = dr.GetValue(5).ToString();
        //        con.Close();
        //        return true;
        //    }
        //    else
        //    {
        //        con.Close();
        //        return false;
        //    }            
        //}                
    }
}
