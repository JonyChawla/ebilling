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
    public partial class Firm : Form
    {
        OleDbConnection con = new OleDbConnection();
        public Firm()
        {
            InitializeComponent();
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + System.Environment.CurrentDirectory + "\\ebilling.accdb";
            updateGridView();            
        }

        private void updateGridView()
        {
            if (con.State == ConnectionState.Closed) con.Open();
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand("SELECT FirmName,EntryDate FROM tblFirm order by EntryDate DESC", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            grvFirm.DataSource = dt;
            con.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateSaveFirm() == false)
            {
                return;
            }

            if (isFirmNameExist(txtFirmName.Text.Trim()))
            {
                MessageBox.Show("Firm name Already exist..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                cmd.CommandText = "insert into tblFirm (FirmName) values(@FirmName)";
                cmd.Parameters.AddWithValue("@FirmName", txtFirmName.Text.Trim());                
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Firm Saved..!!");
                }
                trans.Commit();
                updateGridView();
            }
            catch (OleDbException ex)
            {
                if (ex.ErrorCode == -2147467259)
                {
                    MessageBox.Show("A Firm with this Name already exist..");
                }
                trans.Rollback();
            }
            finally
            {
                con.Close();
            }
        }

        private bool isFirmNameExist(String firmname)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("select firmname from tblfirm where firmname='" + firmname + "'", con);
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

        private bool validateSaveFirm()
        {
            bool returnvalue = true;
            if (txtFirmName.Text.Trim() == "")
            {
                MessageBox.Show("Firm name is empty..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                returnvalue = false;
            }            
            return returnvalue;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (validateSaveFirm() == false)
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
                cmd.CommandText = "delete from tblfirm where firmname='" + txtFirmName.Text.Trim() + "'";
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Item deleted..!!");
                }
                else
                {
                    MessageBox.Show("No item found with given firm name", "Delete failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
