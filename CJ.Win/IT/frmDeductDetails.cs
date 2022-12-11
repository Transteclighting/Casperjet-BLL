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
    public partial class frmDeductDetails : Form
    {
        string str = ConfigurationManager.AppSettings["ConnectionString"];
        public frmDeductDetails(int TranID,int code)
        {
            InitializeComponent();
        }

        private void frmDeductDetails_Load(object sender, EventArgs e)
        {
            int TranID = frmITDeductList.TranID;
            int Code= frmITDeductList.Code;
            loaddata(TranID, Code);

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            dataGridView1.Columns.Add(chk);
            chk.HeaderText = "Check Data";
            chk.Name = "chk";
           // dataGridView1.Rows[1].Cells[1].Value = true;


        }

        public void loaddata(int TranID,int Code)
        {
            //string connectionstring = "Provider=SQLOLEDB.1;Initial Catalog=BLLSysDB;Data Source=10.168.14.36; User ID=BLLSysCon; Password=bllconnection;";
           
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbConnection con = new OleDbConnection(str);

            string Sql = @"select TranID,DeductionAmount,InstallmentNo,Format(InstallmentMonth,'MMM-yyyy') as Month, 
                        Status = case When Isactive = 1 then 'Active' else 'Inactive' End ,Remarks from t_ITEquipmentDeductDetails where DSRCode ="+Code+" and TranID ="+TranID+" ";

            cmd.CommandText = Sql;
            cmd.CommandType = CommandType.Text;
            con.Open();
            OleDbDataAdapter adp = new OleDbDataAdapter(Sql, con);
            DataSet ds = new DataSet();
           
            adp.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
     
            if (Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["chk"].Value) == true)

            {
                dataGridView1.Rows[e.RowIndex].Cells["chk"].Value = false;
            }
            else
            {
                dataGridView1.Rows[e.RowIndex].Cells["chk"].Value = true;
            }
        
    }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells["chk"].Value) == true)

            {
                dataGridView1.Rows[e.RowIndex].Cells["chk"].Value = false;
            }
            else
            {
                dataGridView1.Rows[e.RowIndex].Cells["chk"].Value = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["chk"].Value);
                if (isSelected)
                {
                    message += Environment.NewLine;
                    message += row.Cells["InstallmentNo"].Value.ToString();

                    int DataID=Convert.ToInt32( row.Cells["DataID"].Value);
                    OleDbCommand cmd = DBController.Instance.GetCommand();
                    OleDbConnection con = new OleDbConnection(str);

                    string Sql = @"Update t_ITEquipmentDeductDetails set IsActive=2 Where DataID="+row.Cells["DataID"].Value+"";
                    cmd.CommandText = Sql;
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    cmd.ExecuteScalar();
                    con.Close();
                }
               
            }

            MessageBox.Show("Tab Dechedule Has been Deactivated for Following Installment No " + message);

            int TranID = frmITDeductList.TranID;
            int Code = frmITDeductList.Code;
            loaddata(TranID, Code);
          




        }
    }
}
