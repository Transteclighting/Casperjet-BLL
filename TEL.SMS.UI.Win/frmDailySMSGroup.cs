using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;
using TEL.SMS.BO.DA;


namespace CJ.Win
{
    public partial class frmDailySMSGroup : Form
    {
        int nIndex;
        public frmDailySMSGroup()
        {
            InitializeComponent();
        }

        private void frmDailySMSGroup_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }
        private void LoadCombo()
        {
            
            cmbDailySMSGroup.Items.Clear();
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();
           
            try
            {
                cmd.CommandText = "SELECT SMSGroupName FROM t_SMSGroup";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    cmbDailySMSGroup.Items.Add(reader["SMSGroupName"].ToString());

                }

                reader.Close();
                DBController.Instance.CloseConnection();
            }
            catch (Exception ex)
            {
                throw (ex);
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            cmbDailySMSGroup.Items.Clear();
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            
          
            try
            {
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
               
                cmd.CommandText = "Update t_SMSAutoParam Set ParamName=?  "
                               + " Where ID =1 ";
                cmd.CommandType = CommandType.Text;
              
                cmd.Parameters.AddWithValue("ParamName", nIndex);
               
               

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                DBController.Instance.CloseConnection();
                MessageBox.Show("Saved Successfully");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void cmbDailySMSGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
             nIndex=cmbDailySMSGroup.SelectedIndex;
        }

        
    }
}