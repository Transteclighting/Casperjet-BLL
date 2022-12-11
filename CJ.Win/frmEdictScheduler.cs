using CJ.Class;
using CJ.Win.IT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CJ.Win
{
    public partial class frmEdictScheduler : Form
    {

        int ID = 0;
        int DSRCode = 0;
        string connectionstring = ConfigurationManager.AppSettings["ConnectionString"];
        public frmEdictScheduler(int TrainID, int DSRCOde)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                updateData(ID, DSRCode);
                DeleteScheduler(ID, DSRCode);
                NewShcedulerInsert(ID);
                MessageBox.Show("Data Updated SuccessFully", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
         
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void frmEdictScheduler_Load(object sender, EventArgs e)
        {
            ID = frmITDeductList.TranID;
            DSRCode = frmITDeductList.Code;
            loaddata(ID, DSRCode);
        }

        private void updateData(int _ID,int _Code)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbConnection con = new OleDbConnection(connectionstring);

            string Sql = @"Update t_ITEquipmentDeduct set AssetValue=" + Convert.ToDouble(txtAssetVal.Text) + @",
                            DSRContribution	=" + Convert.ToDouble(txtEmpPer.Text) + @",
                            CompanyContribution	=" + Convert.ToDouble(txtComPer.Text) + @",
                            DeductionAmount=" + Convert.ToDouble(txtDeduct.Text) + @",
                            TotalInstallment=" + Convert.ToInt16(txtTotalIns.Text) + @",
                            InstallmentMonth='" + Convert.ToDateTime(dtstart.Text).Date.ToString() + @"',	
                            Remarks ='" + txtRemarks.Text + "' where TranID="+_ID+" and DSRCode="+ _Code +"";
;
            cmd.CommandText = Sql;
            cmd.CommandType = CommandType.Text;
            con.Open();
            cmd.ExecuteScalar();
            con.Close();
        }

      
        public void NewShcedulerInsert(int DataID)
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


        public void DeleteScheduler(int DataID, int DSRCode)
        {
           
                string sql = "Delete From t_ITEquipmentDeductDetails where TranID="+DataID+" and DSRCode="+DSRCode+" ";
                OleDbCommand cmd = DBController.Instance.GetCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
         

        }

        private void txtEmpPer_TextChanged(object sender, EventArgs e)
        {
            if (txtAssetVal.Text.Length > 0)
            {
                if (txtEmpPer.Text.Length <= 0)
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
            if (txtTotalIns.Text.Length > 0)
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

        public void loaddata(int TranID, int Code)
        {
         

            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbConnection con = new OleDbConnection(connectionstring);

            string Sql = @"Select a.*,b.DSRName from t_ITEquipmentDeduct a, t_DMSDSRDetails b where a.Tranid="+TranID+" and a.DSRCOde="+Code+"  and a.DSRCode=b.DSRCode";
            cmd.CommandText = Sql;
            cmd.CommandType = CommandType.Text;
            con.Open();
            IDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                txtdsrcode.Text = reader["DSRCode"].ToString();
                lbldsr.Text = reader["DSRName"].ToString();
                txtAssetNo.Text = reader["ITAssetID"].ToString();
                txtIMEI.Text = reader["IMEI"].ToString();
                txtAssetVal.Text = reader["AssetValue"].ToString();
                txtComPer.Text = reader["CompanyContribution"].ToString();
                txtEmpPer.Text = reader["DSRContribution"].ToString();
                txtTotalIns.Text = reader["TotalInstallment"].ToString();
                txtDeduct.Text = reader["DeductionAmount"].ToString();
                dtstart.Text = reader["InstallmentMonth"].ToString();
                txtRemarks.Text = reader["Remarks"].ToString();

                

            }
            reader.Close();
            con.Close();

            }
    }
}
