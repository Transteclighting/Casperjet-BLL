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
using System.Configuration;

namespace CJ.Win.IT
{
    public partial class frmITDeductList : Form
    {
        public static int TranID;
        public static int Code;
        public frmITDeductList()
        {
            InitializeComponent();
        }

        private void frmITDeductList_Load(object sender, EventArgs e)
        {
          
            string connectionstring = ConfigurationManager.AppSettings["ConnectionString"];
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbConnection con = new OleDbConnection(connectionstring);
            DBController.Instance.OpenNewConnection();
            string Sql = @"select TranID,Convert(Date,TranDate) as TranDate,IMEI,
            aa.DSRCode,DSRName,AssetValue,DeductionAmount,
            TotalInstallment,Convert(date, InstallmentMonth) as StartDate, 
            Status =case when aa.IsActive = 1 then 'Active' else 'Inactive' end
            from t_ITEquipmentDeduct aa, t_DMSDSR bb
            where aa.DSRCode = bb.DSRCode";

            cmd.CommandText = Sql;
            cmd.CommandType = CommandType.Text;
            con.Open();
            OleDbDataAdapter adp = new OleDbDataAdapter(Sql,con);
            DataSet ds = new DataSet();
          
            adp.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

          
           
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ID = (Int32)dataGridView1.CurrentRow.Cells[0].Value;
            int _Code = (Int32)dataGridView1.CurrentRow.Cells[3].Value;

            TranID = ID;
            Code = _Code;

            frmDeductDetails ds = new frmDeductDetails(TranID, Code);
            ds.ShowDialog();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ID = (Int32)dataGridView1.CurrentRow.Cells[0].Value;
            int _Code = (Int32)dataGridView1.CurrentRow.Cells[3].Value;

            TranID = ID;
            Code = _Code;

            frmDeductDetails ds = new frmDeductDetails(TranID,Code);
            ds.ShowDialog();

        
        }

        private void button2_Click(object sender, EventArgs e)
        {


                if (dataGridView1.SelectedRows.Count == 0 && dataGridView1.SelectedRows.Count > 1)
                {
                    MessageBox.Show("Please Select Onr Row First");
                }

                else
                {
                    int ID = (Int32)dataGridView1.CurrentRow.Cells[0].Value;
                    int _Code = (Int32)dataGridView1.CurrentRow.Cells[3].Value;


                if (MessageBox.Show("Do You Want to Inactive Schedule For "+_Code+"", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Updatet_ITEquipmentDeduct(ID, _Code);
                    Updatet_ITEquipmentDeductDetails(ID, _Code);

                }
                else
                {
                    MessageBox.Show("Updatetion Cancelled .", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
         
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int ID = (Int32)dataGridView1.CurrentRow.Cells[0].Value;
            int _Code = (Int32)dataGridView1.CurrentRow.Cells[3].Value;

            TranID = ID;
            Code = _Code;

            frmDeductDetails ds = new frmDeductDetails(TranID, Code);
            ds.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void Updatet_ITEquipmentDeduct(int TranID, int DSRCode)
        {
            try
            {
                OleDbCommand cmdd = DBController.Instance.GetCommand();
                DBController.Instance.getNewConnection();
                string Sql1 = @"Update t_ITEquipmentDeduct set IsActive=0 where TranID=" + TranID + " and DSRCode=" + DSRCode + " ";
                cmdd.CommandText = Sql1;
                cmdd.CommandType = CommandType.Text;
                cmdd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Updatet_ITEquipmentDeductDetails(int TranID, int DSRCode)
        {
            try
            {
                OleDbCommand cmdd = DBController.Instance.GetCommand();
                DBController.Instance.getNewConnection();
                string Sql1 = @"Update t_ITEquipmentDeductDetails set IsActive=0 where TranID=" + TranID + " and DSRCode=" + DSRCode + " ";
                cmdd.CommandText = Sql1;
                cmdd.CommandType = CommandType.Text;
                cmdd.ExecuteNonQuery();
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
          
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int ID = (Int32)dataGridView1.CurrentRow.Cells[0].Value;
            int _Code = (Int32)dataGridView1.CurrentRow.Cells[3].Value;

            TranID = ID;
            Code = _Code;
            this.Close();
            //frmEdictScheduler ss = new frmEdictScheduler(TranID, Code);
            //ss.ShowDialog();
        }
    }
}
