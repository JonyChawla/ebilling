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
    public partial class Class : Form
    {
        OleDbConnection con = new OleDbConnection();
        public Class()
        {
            InitializeComponent();
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + System.Environment.CurrentDirectory + "\\ebilling.accdb";
            updateGridView();
            fillClassType();
        }

        private void fillClassType()
        {
            DataRow dr;
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("select classtype from tblClassType", con);
            OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dr = dt.NewRow();
            dr.ItemArray = new object[] {"--Select Type--"};
            dt.Rows.InsertAt(dr, 0);

            cmbClassType.ValueMember = "classtype";
            cmbClassType.DisplayMember = "classtype";
            cmbClassType.DataSource = dt;

            con.Close();  
        }

        private bool isClassNameExist(String classname)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("select classname from tblClass where classname='" + classname + "'", con);
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

        private void btnSaveClass_Click(object sender, EventArgs e)
        {
            if (validateAddClass() == false)
            {
                return;
            }

            if (isClassNameExist(txtClassName.Text.Trim()))
            {
                MessageBox.Show("Class name Already exist..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                cmd.CommandText = "insert into tblClass (ClassName,Type) values(@ClassName,@Type)";
                cmd.Parameters.AddWithValue("@ClassName", txtClassName.Text.Trim());
                cmd.Parameters.AddWithValue("@Type", cmbClassType.Text);                
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Class Saved..!!");
                }
                trans.Commit();
                updateGridView();
            }
            catch (OleDbException ex)
            {
                if (ex.ErrorCode == -2147467259)
                {
                    MessageBox.Show("A Class with this Name already exist..");
                }
                trans.Rollback();
            }
            finally
            {
                con.Close();
            }
        }

        private bool validateAddClass()
        {
            bool returnvalue = true;
            if (txtClassName.Text.Trim() == "")
            {
                MessageBox.Show("Class name is empty..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                returnvalue = false;
            }
            if (cmbClassType.SelectedIndex==0)
            {
                MessageBox.Show("Select Class Type..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                returnvalue = false;
            }            
            return returnvalue;
        }
        private bool validateDeleteClass()
        {
            bool returnvalue = true;
            if (txtClassName.Text.Trim() == "")
            {
                MessageBox.Show("Class name is empty..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                returnvalue = false;
            }            
            return returnvalue;
        }
        private void updateGridView()
        {
            if (con.State == ConnectionState.Closed) con.Open();
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand("SELECT ClassName,Type,EntryDate FROM tblClass order by EntryDate DESC", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            gvClass.DataSource = dt;
            con.Close();
        }

        private void Class_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (validateAddClass() == false)
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
                cmd.CommandText = "update tblClass set Type=@type where classname='" + txtClassName.Text + "'";
                cmd.Parameters.AddWithValue("@type", cmbClassType.Text);
                
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Class updated..!!");
                }
                else
                {
                    MessageBox.Show("No Class found with this Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (validateDeleteClass() == false)
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
                cmd.CommandText = "delete from tblClass where classname='" + txtClassName.Text.Trim() + "'";
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Item deleted..!!");
                }
                else
                {
                    MessageBox.Show("No item found with given class name..!!", "Delete failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
