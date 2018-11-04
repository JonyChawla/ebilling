﻿using System;
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
        }

        private void txtArticlePrice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtArticleName.Text = "";
            txtArticlePrice.Text = "";
            chkIsActive.Checked = true;
        }

        private void Article_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ebillingDataSet.tblArticle' table. You can move, or remove it, as needed.            
        }

        private void btnAddArticle_Click(object sender, EventArgs e)
        {
            OleDbTransaction trans = null;
            try
            {
                con.Open();
                trans = con.BeginTransaction();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Transaction = trans;
                cmd.Connection = con;
                cmd.CommandText = "insert into tblArticle (ArticleName,ArticleRate,isActive) values(@articlename,@articlerate,@isActive)";
                cmd.Parameters.AddWithValue("@articlename", txtArticleName.Text);
                cmd.Parameters.AddWithValue("@articlerate",Decimal.Parse(txtArticlePrice.Text));
                cmd.Parameters.AddWithValue("@isActive", chkIsActive.CheckState);
                
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    MessageBox.Show("Article Saved..!!");
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
            if(con.State==ConnectionState.Closed) con.Open();            
            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand("Select Id,ArticleName,ArticleRate,EntryDate,isActive from tblArticle order by EntryDate DESC", con);
            OleDbDataReader dr = cmd.ExecuteReader();
            dt.Load(dr);

            dt.Columns.RemoveAt(0);
            grvArticle.DataSource = dt;
            con.Close();
        }             
    }
}
