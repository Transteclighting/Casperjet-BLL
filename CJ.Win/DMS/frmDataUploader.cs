using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Plan;
using CJ.Class.Library;
using CJ.Class.DMS;


namespace CJ.Win.DMS
{
    public partial class frmDataUploader : Form
    {
        private DataTable _oDT;
        int nCount = 0;        
        public frmDataUploader()
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
            this.dgvData.DataSource = _oDT.DefaultView;
            this.Text = "Load From XL [" + _oDT.Rows.Count + "]";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (UIValidation()==true)
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

        private  bool ValidateNull()
        {
            int count = 0;
            foreach (DataGridViewRow rw in this.dgvData.Rows)
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
            if (ValidateNull() == true)
            {
                int i = 0;
                string sSql = "";
               
                OleDbCommand cmd = DBController.Instance.GetCommand();
                DBController.Instance.OpenNewConnection();
                DataGridViewRow oDGVRow;
                //DBController.Instance.BeginNewTransaction();
                try
                {
                    DMSClusterOutlet oOutlet = new DMSClusterOutlet();

                    foreach (DataGridViewRow oRow in dgvData.Rows)
                    {

                        oOutlet.RetailID_TempTable = Convert.ToInt32(oRow.Cells[0].Value);
                        oOutlet.CustomerID = Convert.ToInt32(oRow.Cells[1].Value);
                        oOutlet.RouteID = Convert.ToInt32(oRow.Cells[2].Value);
                        oOutlet.RetailName = Convert.ToString(oRow.Cells[3].Value).Replace("'", "");
                        oOutlet.RetailAddress = Convert.ToString(oRow.Cells[4].Value).Replace("'","");
                        oOutlet.ThanaNameSurvey = Convert.ToString(oRow.Cells[5].Value).Replace("'","");
                        oOutlet.DistrictName = Convert.ToString(oRow.Cells[6].Value).Replace("'","");
                        oOutlet.TownName = Convert.ToString(oRow.Cells[7].Value).Replace("'","");
                        oOutlet.ThanaName = Convert.ToString(oRow.Cells[8].Value).Replace("'", "");
                        oOutlet.TownType = Convert.ToString(oRow.Cells[9].Value);
                        oOutlet.TownRankID = Convert.ToInt32(oRow.Cells[10].Value);
                        oOutlet.Admin = Convert.ToString(oRow.Cells[11].Value);
                        oOutlet.ProprietorName = Convert.ToString(oRow.Cells[12].Value).Replace("'", "");
                        oOutlet.MarketName = Convert.ToString(oRow.Cells[13].Value).Replace("'", "");
                        oOutlet.MarketType = Convert.ToString(oRow.Cells[14].Value);
                        oOutlet.MarketLocation = Convert.ToString(oRow.Cells[15].Value);
                        oOutlet.RetailTypeID = Convert.ToInt32(oRow.Cells[16].Value);
                        oOutlet.RetailType = Convert.ToString(oRow.Cells[17].Value);
                        oOutlet.RetailTypeShort = Convert.ToString(oRow.Cells[18].Value);
                        oOutlet.Mobile01 = Convert.ToString(oRow.Cells[19].Value);
                        oOutlet.Mobile02 = Convert.ToString(oRow.Cells[20].Value);
                        oOutlet.Mobile03 = Convert.ToString(oRow.Cells[21].Value);
                        oOutlet.TNT = Convert.ToString(oRow.Cells[22].Value);
                        oOutlet.MapSerialno = Convert.ToString(oRow.Cells[23].Value);
                        oOutlet.SlabOutlet = Convert.ToInt32(oRow.Cells[24].Value);
                        oOutlet.ProductAvail = Convert.ToString(oRow.Cells[25].Value);
                        oOutlet.IsActive = Convert.ToInt32(oRow.Cells[26].Value);
                        oOutlet.ElectricianName = Convert.ToString(oRow.Cells[27].Value);
                        oOutlet.ElectricianContactNo = Convert.ToString(oRow.Cells[28].Value);
                        oOutlet.MinPotential = Convert.ToDouble(oRow.Cells[29].Value);
                        oOutlet.Latitude = Convert.ToDecimal(oRow.Cells[30].Value);
                        oOutlet.Longitude = Convert.ToDecimal(oRow.Cells[31].Value);
                        int bl = Convert.ToInt32(oRow.Cells[32].Value);
                        if (bl == 0)
                        {
                            oOutlet.IsLocationConfirm = false;
                        }
                        else
                        {
                            oOutlet.IsLocationConfirm = true;
                        }

                        oOutlet.Tier = Convert.ToString(oRow.Cells[33].Value);
                        oOutlet.RetailGroupID = Convert.ToInt32(oRow.Cells[34].Value);
                        oOutlet.Add();
                        if (chkManual.Checked == false)
                        {
                            oOutlet.Update();
                        }
                        nCount++;


                    }

                    MessageBox.Show(" Data save successfully \n Total Inserted Data " + nCount + "");
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error Inserting Data: " + ex + "");
                    throw (ex);
                }
                
     
            }
            else
            {
                MessageBox.Show("You Have Empty Cell in Rows", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        
    }
}
