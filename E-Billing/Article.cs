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
    public partial class Article : Form
    {
        OleDbConnection con = new OleDbConnection();
        public Article()
        {
            InitializeComponent();
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + System.Environment.CurrentDirectory + "\\ebilling.accdb";
            updateGridView();
            fillFinancialYear();
        }

        private void fillFinancialYear()
        {
             txtFinancialYear.Text= GetCurrentFinancialYear();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtArticleName.Text = "";
            txtUGPrice.Text = "";
            chkIsActive.Checked = true;
            updateGridView();
        }

        private void Article_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ebillingDataSet.tblArticle' table. You can move, or remove it, as needed.            
        }

        private void btnAddArticle_Click(object sender, EventArgs e)
        {
            if (validateAddArticle() == false)
            {
                return;
            }

            OleDbTransaction trans = null;
            try
            {
                con.Open();
                trans = con.BeginTransaction();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Transaction = trans;
                cmd.Connection = con;
                cmd.CommandText = "insert into tblArticle (ArticleName,FinancialYear,PGRate,UGRate,isActive) values(@articlename,@FinancialYear,@PGRate,@UGRate,@isActive)";
                cmd.Parameters.AddWithValue("@articlename", txtArticleName.Text);
                cmd.Parameters.AddWithValue("@FinancialYear", txtFinancialYear.Text);
                cmd.Parameters.AddWithValue("@PGRate", Decimal.Parse(txtPGPrice.Text));
                cmd.Parameters.AddWithValue("@UGRate", Decimal.Parse(txtUGPrice.Text));
                cmd.Parameters.AddWithValue("@isActive", chkIsActive.Checked);                
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Particular Saved..!!");
                }
                trans.Commit();
                updateGridView();
            }            
            catch (OleDbException ex)
            {
                if (ex.ErrorCode == -2147467259)
                {
                    MessageBox.Show("A Record with this Particular name and financial year already exist.");
                }
                trans.Rollback();
            }
            finally
            {                
                con.Close();
            }            
        }

        private bool validateAddArticle()
        {
            bool returnvalue = true;
            if (txtArticleName.Text.Trim() == "")
            {
                MessageBox.Show("Particular name is empty..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                returnvalue = false;
            }
            if (txtFinancialYear.Text.Trim() == "")
            {
                MessageBox.Show("Financial Year is empty..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                returnvalue = false;
            }
            if (txtUGPrice.Text.Trim() == "")
            {
                MessageBox.Show("UG Price is empty..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                returnvalue = false;
            }
            if (txtPGPrice.Text.Trim() == "")
            {
                MessageBox.Show("PG Price is empty..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                returnvalue = false;
            }
            return returnvalue;
        }

        private bool validateDeleteArticle()
        {
            bool returnvalue = true;
            if (txtArticleName.Text.Trim() == "")
            {
                MessageBox.Show("Particular name is empty..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                returnvalue = false;
            }
            if (txtFinancialYear.Text.Trim() == "")
            {
                MessageBox.Show("Financial Year is empty..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                returnvalue = false;
            }            
            return returnvalue;
        }

        private void updateGridView()
        {
            if(con.State==ConnectionState.Closed) con.Open();            
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand("SELECT ArticleName, FinancialYear, UGRate, PGRate, EntryDate, isActive FROM tblArticle order by EntryDate DESC", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
                        
            grvArticle.DataSource = dt;
            con.Close();
        }

        private void txtUGPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void txtPGPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        public static string GetCurrentFinancialYear()
        {
            int CurrentYear = DateTime.Today.Year;
            int PreviousYear = DateTime.Today.Year - 1;
            int NextYear = DateTime.Today.Year + 1;
            string PreYear = PreviousYear.ToString();
            string NexYear = NextYear.ToString();
            string CurYear = CurrentYear.ToString();
            string FinYear = null;

            if (DateTime.Today.Month > 3)
                FinYear = CurYear + "-" + NexYear;
            else
                FinYear = PreYear + "-" + CurYear;
            return FinYear.Trim();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (validateAddArticle() == false)
            {
                return;
            }

            OleDbTransaction trans = null;
            try
            {
                con.Open();
                trans = con.BeginTransaction();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Transaction = trans;
                cmd.Connection = con;
                cmd.CommandText = "update tblArticle set PGRate=@PGRate,UGRate=@UGRate,isActive=@isActive where articlename='"+txtArticleName.Text.Trim()+"' and FinancialYear='"+txtFinancialYear.Text.Trim()+"'";                                
                cmd.Parameters.AddWithValue("@PGRate", Decimal.Parse(txtPGPrice.Text));
                cmd.Parameters.AddWithValue("@UGRate", Decimal.Parse(txtUGPrice.Text));
                cmd.Parameters.AddWithValue("@isActive", chkIsActive.Checked);

                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Particular updated..!!");
                }
                else
                {
                    MessageBox.Show("No Particular found with this Name and Financial Year","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                trans.Commit();
                updateGridView();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (validateDeleteArticle() == false)
            {
                return;
            }

            OleDbTransaction trans = null;
            try
            {
                con.Open();
                trans = con.BeginTransaction();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Transaction = trans;
                cmd.Connection = con;
                cmd.CommandText = "delete from tblArticle where articlename='"+txtArticleName.Text+"' and financialyear='"+txtFinancialYear.Text+"'";                
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Item deleted..!!");
                }
                else
                {
                    MessageBox.Show("No item found with given Particular name and financial year..!!","Delete failed",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                trans.Commit();
                updateGridView();
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
    }
}
