using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace E_Billing
{
    public partial class GST : Form
    {
        OleDbConnection con = new OleDbConnection();
        public GST()
        {
            InitializeComponent();
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + System.Environment.CurrentDirectory + "\\ebilling.accdb";
            updateGridView();
        }

        private void txtGST_KeyPress(object sender, KeyPressEventArgs e)
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

        private void GST_Load(object sender, EventArgs e)
        {
            
        }

        private bool validateAddGST()
        {
            bool returnvalue = true;
            if (txtGSTRate.Text.Trim() == "")
            {
                MessageBox.Show("GST Rate is empty..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                returnvalue = false;
            }            
            return returnvalue;
        }

        private void btnAddGST_Click(object sender, EventArgs e)
        {
            if (validateAddGST() == false)
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
                cmd.CommandText = "insert into tblGST (GSTRate) values(@gstrate)";
                cmd.Parameters.AddWithValue("@gstrate", Decimal.Parse(txtGSTRate.Text));
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("GST Saved..!!");
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
        private void updateGridView()
        {
            if (con.State == ConnectionState.Closed) con.Open();
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand("Select Id,GSTRate,EntryDate from tblGST order by EntryDate DESC", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            dt.Columns.RemoveAt(0);
            grvGST.DataSource = dt;
            con.Close();
        }  
               
    }
}
