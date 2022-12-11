using System;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.DMS;
using System.Data.OleDb;

namespace CJ.Win.IT
{
    public partial class frmScheduler : Form
    {
        public int TranID;
        public int DataID;
        public frmScheduler()
        {
            InitializeComponent();
        }
        private void txtdsrcode_TextChanged(object sender, EventArgs e)
        {

            
            string sql = @"Select isnull(DSRName,null) as DSRName ,cc.SerialNo,convert(Date,bb.TranDate) as AssignDate ,cc.ITAssetID,bb.TranID 
            from t_DMSDSRDetails aa,t_ITEquipmentTran bb, t_ITAsset cc
            where aa.DSRCode = bb.EmployeeID and bb.EmployeeID = cc.CurEmployeeID and DSRCode like '" +txtdsrcode.Text+"' ";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                  
                    string Name= (string)reader["DSRName"];
                    if (Name == null)
                    {
                        lbldsr.Text = "";
                        txtdsrcode.ForeColor = Color.Red;
                    }
                    else
                        lbldsr.Text = Name;
                    string IMEI = (string)reader["SerialNo"];

                    if (IMEI == null)
                    {
                        txtIMEI.Text = "";
                    }
                    else txtIMEI.Text = IMEI;
                    string AssignDate = (string)reader["AssignDate"];

                    if (AssignDate == null)
                    {
                        dtAssign.Text = "";
                    }
                    else dtAssign.Text = AssignDate;
                    int AssetID = (int)reader["ITAssetID"];
                    if (AssetID == null)
                    {
                        txtAssetNo.Text = "";
                    }
                    else txtAssetNo.Text = AssetID.ToString();

                    TranID = (int)reader["TranID"];
                }

                reader.Close();
               
            }
            catch (Exception ex)
            {
                throw (ex);
            }



        }
        public void CheckSerial(int Code)
        {
            string Sql= "select SerialNo  " +
            " from t_ITAsset aa, t_ITEquipmentTran bb " +
            " where aa.EquipmentID = bb.EquipmentID and bb.EmployeeID = (Select EmployeeID from t_employee where EmployeeCode = '"+Code+"') ";
            string sql = "select count(TranID) from t_ITEquipmentDeduct where IMEI= " + " ("+Sql+") " ;
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            int Serial =Convert.ToInt32( cmd.ExecuteScalar());

            if(Serial !=0)
            {
                //Get the Latest Assigned Person and his Total Paid Amount.
            }
            else
            {
                //Leave the Text field as Editable.
            }

        }
        public void LastUser(string IMEI)
        {
           // string sql="Select * from "
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void txtComPer_TextChanged(object sender, EventArgs e)
        {
            if (txtComPer.Text.Length > 0)
            {
                if (txtAssetVal.Text.Length > 0)
                {
                    if (Convert.ToDouble(txtAssetVal.Text) < Convert.ToDouble(txtComPer.Text))
                    {
                        MessageBox.Show("Amount Can not be Higher than Asset Value");
                        txtComPer.ResetText();
                        txtEmpPer.ResetText();
                    }                    
                    else
                    {
                        txtEmpPer.Text = (Convert.ToDouble(txtAssetVal.Text) - Convert.ToDouble(txtComPer.Text)).ToString();
                    }
                }
            }

            else
            {
                MessageBox.Show("Please Set Companay Share Value First");
                txtComPer.ResetText();
                txtEmpPer.ResetText();
            }
        }
        private void txtTotalIns_TextChanged(object sender, EventArgs e)
        {
            if (txtTotalIns.Text.Length>0)
            {
                double Ins = Math.Round(Convert.ToDouble(txtEmpPer.Text) / Convert.ToDouble(txtTotalIns.Text));
                txtDeduct.Text = Ins.ToString();
            }
            else
            {
                txtDeduct.ResetText();
                txtTotalIns.ResetText();
            }
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //if (dtstart.Value.Month == DateTime.Today.Month || dtstart.Value.Month == DateTime.Today.AddMonths(+1).Month)
            //{

            if (txtdsrcode.Text != "" && txtAssetNo.Text !="" && txtTotalIns.Text !="" && txtDeduct.Text !="" && txtIMEI.Text !="")
            {
                DataIDforBothDeductTable();
                DeductDetailsInsert();
                DeductMasterInsert();
            }
            else
            {
                MessageBox.Show("Please Fill All The Field First","Error !!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            //}
            //else
            //{
            //    MessageBox.Show("Please Select a Valid Start Month. Schedule Can not be Created Previous Than Current month and Later Than Next Month");
            //}
        }
        public void DeductDetailsInsert()
        {
            DateTime dt = Convert.ToDateTime(dtstart.Text);
            for (int i = 1; i <= Convert.ToInt32(txtTotalIns.Text); i++)
            {
                string sql = "INSERT INTO [dbo].[t_ITEquipmentDeductDetails]  " +
                " VALUES(" + DataID + ", Convert(datetime, DateAdd(month, 0, Convert(date, GetDate())))," + Convert.ToInt32(txtdsrcode.Text) + ",  " +
                " " + Convert.ToDouble(txtDeduct.Text) + ", " + i + ", Convert(datetime, DateAdd(month, 0, Convert(date, '" + dt.Date + "'))), 1,' " + txtRemarks.Text + "' )";
                dt = dt.AddMonths(1).Date;

                OleDbCommand cmd = DBController.Instance.GetCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }

        }
        public void DeductMasterInsert()
        {
            DateTime dt = Convert.ToDateTime(dtstart.Text);
            string sql = "INSERT INTO [dbo].[t_ITEquipmentDeduct]  " +
            " VALUES(" + DataID + ", Convert(datetime, DateAdd(month, 0, Convert(date, GetDate()))), " + txtIMEI.Text + ", " + Convert.ToInt32(txtAssetNo.Text) + ",  " + Convert.ToInt32(txtAssetNo.Text) + ", " + Convert.ToInt32(txtdsrcode.Text) + ", " + Convert.ToDouble(txtAssetVal.Text) + ", " + Convert.ToDouble(txtEmpPer.Text) + ",  " +
            " " + Convert.ToDouble(txtComPer.Text) + ", " + Convert.ToDouble(txtDeduct.Text) + ", " + Convert.ToInt32(txtTotalIns.Text) + ", Convert(datetime, DateAdd(month, 0, Convert(date, '" + dt.Date + "'))), 1,' " + txtRemarks.Text + "' )";
            dt = dt.AddMonths(1).Date;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Schedule for " + lbldsr.Text + " has been Created Successfully", "Success");
        }

        public void DataIDforBothDeductTable()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sql = "select isnull(max(TranID), 0)+1 as DataID  from t_ITEquipmentDeduct";
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            DataID = Convert.ToInt32( cmd.ExecuteScalar());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmITDeductList lst = new frmITDeductList();
                lst.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void txtEmpPer_TextChanged(object sender, EventArgs e)
        {
            if(txtAssetVal.Text.Length>0)
            {
                if(txtEmpPer.Text.Length<=0)
                {
                    MessageBox.Show("Set Employee Share Amount .");
                    txtAssetVal.ResetText();
                    txtComPer.ResetText();
                    txtEmpPer.ResetText();

                }

                else
                {
                    txtComPer.Text = (Convert.ToDouble(txtAssetVal.Text) - Convert.ToDouble(txtEmpPer.Text)).ToString();
                }
            }
            else
            {
                MessageBox.Show("Set Asset Value .");
                txtAssetVal.ResetText();
                txtComPer.ResetText();
                txtEmpPer.ResetText();
            }         
        }

        private void frmScheduler_Load(object sender, EventArgs e)
        {

        }
    }
}
