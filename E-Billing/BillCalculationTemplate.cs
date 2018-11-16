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
    public partial class BillCalculationTemplate : Form
    {
        OleDbConnection con = new OleDbConnection();        
        public BillCalculationTemplate()
        {
            InitializeComponent();
            con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + System.Environment.CurrentDirectory + "\\ebilling.accdb";
            if (getGSTRate() == 0)
            {
                MessageBox.Show("No GST found.. Please Add GST first.!");
                return;
            }
        }

        private void BillCalculationTemplate_Load(object sender, EventArgs e)
        {
            fillClass();
            fillFirms();
            fillFinancialYear();            
        }

        private void fillClass()
        {
            DataRow dr;
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("select * from tblClass", con);
            OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "--Select Class--" };
            dt.Rows.InsertAt(dr, 0);

            cmbClass.ValueMember = "ID";
            cmbClass.DisplayMember = "ClassName";
            cmbClass.DataSource = dt;

            con.Close();
        }
        private void fillFirms()
        {
            DataRow dr;
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("select * from tblFirm", con);
            OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "--Select Firm--" };
            dt.Rows.InsertAt(dr, 0);

            cmbFirm.ValueMember = "ID";
            cmbFirm.DisplayMember = "FirmName";
            cmbFirm.DataSource = dt;

            con.Close();
        }
        private void fillFinancialYear()
        {
            DataRow dr;
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("select distinct financialyear from tblArticle", con);
            OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            dr = dt.NewRow();
            dr.ItemArray = new object[] {"--Select Financial Year--" };
            dt.Rows.InsertAt(dr, 0);

            cmbFinancialYear.ValueMember = "financialyear";
            cmbFinancialYear.DisplayMember = "financialyear";
            cmbFinancialYear.DataSource = dt;

            con.Close();
        }

        private string getClassType()
        {
            if (con.State == ConnectionState.Closed) con.Open();
            OleDbCommand cmd = new OleDbCommand("select type from tblClass where classname='"+cmbClass.Text.Trim()+"'", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            string classtype= "";
            if (dr.Read())
            {
                classtype = dr.GetString(0);
            }
            con.Close();
            return classtype;
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

        private void txtNoofcopies_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }
        }

        private void txttotalpages_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtprintedpages_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }
        }

        private void btnLoadParticulars_Click(object sender, EventArgs e)
        {
            if (ValidateLoadParticulars()!=true)
            {                
                return;
            }
            
            DataTable dt= getAllActiveArticlesByFinancialYear();
            decimal totalamount = Math.Round(fillGridwithitems(dt),2);
            txtTotalAmount.Text =  totalamount.ToString();            
        }

        private decimal fillGridwithitems(DataTable dt)
        {
            decimal totalamount = 0;
            grvArticleWiseBill.Rows.Clear();

            foreach (DataRow row in dt.Rows)
            {
                decimal rate=decimal.Parse(row["Rate"].ToString());
                decimal amount = 0;
                string particularname = row["Particular"].ToString();
                if (particularname == "Printed Pages")
                {
                    amount = rate * decimal.Parse(txtprintedpages.Text);
                }
                else if (particularname == "Lamination")
                {
                    amount = rate * decimal.Parse(txtNoofcopies.Text);
                }
                else if (particularname == "Printing on Title Cover per 100")
                {
                    amount = getAmountForPrintingOnTitleCover(rate, amount);
                }
                else if (particularname == "Title Pasting per 100")
                {
                    amount = getAmountForPrintingOnTitleCover(rate, amount);
                }
                else if (particularname == "Consumption of Paper")
                {
                    amount = getAmountForConsumptionofPaper(amount);
                }
                else if (particularname == "Binding & Stiching")
                {
                    amount = getAmountForBindingAndStiching(rate, amount);
                }

                grvArticleWiseBill.Rows.Add(particularname, rate, amount);
                totalamount = totalamount + amount;
            }
            return totalamount;
        }

        private decimal getAmountForConsumptionofPaper(decimal amount)
        {
            int totalnoofcopies = int.Parse(txtNoofcopies.Text);
            int totalpages = int.Parse(txttotalpages.Text);
            string typeofclass = txtClassType.Text;
            decimal fixedvalue = 16M;
            decimal fixedvalue1 = 1.5M;
            decimal fixedvalue2 = 3.2M;
            decimal fixedvalue3 = 4.2M;            

            decimal figure1 = ((decimal.Parse(totalnoofcopies.ToString()) * decimal.Parse(totalpages.ToString())) / fixedvalue);

            decimal figure2 = (fixedvalue1 * Math.Ceiling(figure1));
            decimal figure3= (figure2/100);
            decimal figure4 = figure1 + Math.Ceiling(figure3);
            amount = figure4 * ((typeofclass == "UG") ? fixedvalue2 : fixedvalue3);

            return amount;
        }

        private decimal getAmountForBindingAndStiching(decimal rate, decimal amount)
        {
            decimal fixvalue = 8.0M;
            int totalpages = int.Parse(txttotalpages.Text);
            int totalnoofcopies = int.Parse(txtNoofcopies.Text);
            int noofcopiesper100 = getNumberofcopiesper100(totalnoofcopies);
            decimal figure1 = Math.Ceiling(totalpages / fixvalue);
            amount = rate * noofcopiesper100 * figure1;
            return amount;
        }

        private decimal getAmountForPrintingOnTitleCover(decimal rate, decimal amount)
        {
            int noofcopies = int.Parse(txtNoofcopies.Text);
            int noofcopiesper100 = getNumberofcopiesper100(noofcopies);
            amount = rate * noofcopiesper100;
            return amount;
        }

        private int getNumberofcopiesper100(int noofcopies)
        {
            int noofcopiesper100 = (noofcopies / 100);
            if ((int.Parse(txtNoofcopies.Text) % 100) > 0)
            {
                noofcopiesper100 = noofcopiesper100 + 1;
            }
            return noofcopiesper100;
        }

        private DataTable getAllActiveArticlesByFinancialYear()
        {
            if (con.State == ConnectionState.Closed) con.Open();
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection=con;

            if(txtClassType.Text=="UG")
                cmd.CommandText="SELECT ArticleName as [Particular], UGRate as [Rate] from tblArticle where isActive=true and financialyear='"+cmbFinancialYear.Text+"'";
            else if(txtClassType.Text=="PG")
                cmd.CommandText="SELECT ArticleName as [Particular], PGRate as [Rate] from tblArticle where isActive=true and financialyear='"+cmbFinancialYear.Text+"'";

                OleDbDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);
            con.Close();

            return dt;
        }


        public bool ValidateLoadParticulars()
        {
            bool returnvalue = true;
            if (cmbClass.SelectedIndex == 0)
            {
                MessageBox.Show("Please select class name..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                returnvalue = false;
            }
            else if (cmbFinancialYear.SelectedIndex== 0)
            {
                MessageBox.Show("Please select financial year..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                returnvalue = false;
            }
            else if ((txtNoofcopies.Text == "0") || (txtNoofcopies.Text == ""))
            {
                MessageBox.Show("Please enter no of copies..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                returnvalue = false;
            }
            else if ((txttotalpages.Text == "0") || (txttotalpages.Text == ""))
            {
                MessageBox.Show("Please enter total pages..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                returnvalue = false;
            }
            else if ((txtprintedpages.Text == "0") || (txtprintedpages.Text == ""))
            {
                MessageBox.Show("Please enter printed pages..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                returnvalue = false;
            }
            else if (int.Parse(txtprintedpages.Text) > int.Parse(txttotalpages.Text))
            {
                MessageBox.Show("Printed pages cannot be more than total pages..!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                returnvalue = false;
            }
            return returnvalue;
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClass.SelectedIndex != 0)
            {
                txtClassType.Text = getClassType();
            }
            else
            {
                txtClassType.Text = "";
            }
        }

        private void chkotherdeduction_CheckedChanged(object sender, EventArgs e)
        {
            if (chkotherdeduction.Checked == true)
            {
                pnlOtherDeduction.Visible = true;    
            }
            else
            {
                pnlOtherDeduction.Visible = false;
            }
        }

       
        
    }
}
