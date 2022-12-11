using CJ.Class;
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

namespace CJ.Win.DMS
{
    public partial class frmWDUploader : Form
    {
        string str = ConfigurationManager.AppSettings["ConnectionString"];
        private DataTable _oDT;
        int nCount = 0;
        public frmWDUploader()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.FileName = "";
            this.openFileDialog1.Multiselect = false;
            this.openFileDialog1.Filter = "";
            this.openFileDialog1.Filter = "Excel 2007+ Sheet(*.xlsx)|*.xlsx|Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtBrowseData.Text = this.openFileDialog1.FileName.ToString();
                this.Text = this.openFileDialog1.DefaultExt.ToString();
            }
            LoadSheets();
        }

        private void LoadSheets()
        {
            OleDbConnection oConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtBrowseData.Text + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"");
            oConn.Open();
            OleDbDataAdapter oDataAdapter = new OleDbDataAdapter("SELECT * FROM [RAW$]", oConn);
            DataSet oDS = new DataSet();
            _oDT = new DataTable();
            oDataAdapter.Fill(_oDT);
            this.dataGridView1.DataSource = _oDT.DefaultView;
            this.Text = "Load From XL [" + _oDT.Rows.Count + "]";
            oConn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UIValidation()==true && ValidateNull()==true)
            {
                Save();
                this.Close();
            }
        }

        private bool UIValidation()
        {

            if (_oDT.Rows.Count == 0)
            {
                MessageBox.Show("There is no Data", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
        private bool ValidateNull()
        {
            int count = 0;
            foreach (DataGridViewRow rw in this.dataGridView1.Rows)
            {
                for (int i = 0; i < rw.Cells.Count; i++)
                {
                    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                    {
                        count = count + 1;
                    }
                }
            }

            if (count > 0)
            {
                return false;
            }
            else
                return true;
        }

        private void Save()
        {
           
            string sSql = "";
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            DataGridViewRow oDGVRow;
            DBController.Instance.BeginNewTransaction();
            try
            {
                foreach (DataGridViewRow oRow in dataGridView1.Rows)
                {
                    int DSRID = Convert.ToInt32(oRow.Cells[0].Value);                   
                    int WD = Convert.ToInt32(oRow.Cells[2].Value);
                    int SpcWD = Convert.ToInt32(oRow.Cells[3].Value);
                    int SalaryMonth = Convert.ToDateTime(oRow.Cells[4].Value).Month;
                    int Year = Convert.ToDateTime(oRow.Cells[4].Value).Year;
                    UpdateActualWorkingDay(WD, SpcWD,DSRID,SalaryMonth,Year);
                }

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error Inserting Data: " + ex + "");
                throw (ex);
            }
            DBController.Instance.CommitTransaction();
            MessageBox.Show("Data Updated successfully \n Total Updated Data " + nCount + "");
        }


        public void UpdateActualWorkingDay(int WD,int SpcWD, int DSRID, int SalaryMonth, int Year)
        {
            OleDbCommand cmdd = DBController.Instance.GetCommand();
            OleDbConnection conn = new OleDbConnection(str);
            string Sql1 = @"Update t_DMSDSRBasicSalaryDetails set WorkingdayActual=" + WD+ ",SpcWD="+SpcWD+"  where Month=" + SalaryMonth + " and Year=" + Year+ " and DSRID=" + DSRID + "";
            cmdd.CommandText = Sql1;
            cmdd.CommandType = CommandType.Text;
            conn.Open();
            cmdd.ExecuteNonQuery();
            conn.Close();
            nCount = nCount + 1;
        }
    }
}
