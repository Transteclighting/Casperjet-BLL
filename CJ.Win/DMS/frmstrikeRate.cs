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
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop;
namespace CJ.Win.DMS
{
    public partial class frmstrikeRate : Form
    {
        string str = ConfigurationManager.AppSettings["ConnectionString"];
        public string datefrom = "";
        public string dateto = "";
        public frmstrikeRate()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
       
            string fromMonth = dateTimePicker1.Text;
            string toMonth =   Convert.ToDateTime( dateTimePicker1.Text).AddMonths(+1).ToString("MMM-yyyy");
           
            datefrom = "01-"+ fromMonth;
            dateto = "01-"+ toMonth;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbConnection con = new OleDbConnection(str);

            string Sql = @"
            Select AreaName,TerritoryName,CustomerName,DSRCode,DSRName,
            sum(TTOutlet) as No_Outlet,round(sum(MTDMemo),0) as MTDMemo,
            round( (cast(sum(MTDMemo) as float ) / cast(sum(TTOutlet) as float)*100),0)  as StrikeRate
            from
            (
            select RegionName,AreaName,Areaid,TerritoryID,TerritoryName,CustomerName,DSRCode,DSRName,RouteCode,MTDMemo,TTOutlet
            from
            (
            select RegionName,AreaName,Areaid,TerritoryID,TerritoryName,CustomerName,DSRCOde,DSRName,RouteCode
            from v_CustomerDetails a, t_DMSDSR b, t_DMSRoute c
            where a.CustomerID=b.DistributorID and b.DSRID=c.DSRID
            ) as Cust
            left outer join
            (
            Select BeatID, MTDMemo,TTOutlet
            from
            (
            select BeatID,count(OutletID) as MTDMemo
            from
            (
            select BeatID, OutletID,sum(DeliveryAmount) as DelAmount
            from t_DMSOrder
            where DeliveryDate between '"+datefrom+@"' and '"+dateto+ @"' and DeliveryDate< '" + dateto + @"'
            and IsDelivered=1 and DeliveryAmount>0
            group by BeatID,OutletID
            ) as mm group by BeatID
            ) as main
            left outer join
            (
            select RouteID, COUNT(RetailID) as TTOutlet
            from t_DMSClusterOutlet where IsActive=1
            group by RouteID
            ) as OL on main.BeatID=OL.RouteID
            ) as Val on Cust.RouteCode=Val.BeatID
            ) as final
            where DSRCode>0 and  TTOutlet>0
            group by  AreaName,TerritoryName,CustomerName,DSRCode,DSRName
            Order by  AreaName,TerritoryName,CustomerName
            ";

            cmd.CommandText = Sql;
            cmd.CommandType = CommandType.Text;
            con.Open();
            OleDbDataAdapter adp = new OleDbDataAdapter(Sql, con);
            DataSet ds = new DataSet();

            adp.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            dataGridView1.Columns.Add(chk);
            chk.HeaderText = "Exception";
            chk.Name = "chk";
        }
        private void button2_Click(object sender, EventArgs e)
        {



                if (CheckData() > 0)
                {
                    MessageBox.Show("Data Already Exists.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    int count = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        count = count + 1;
                        int Exception = 0;
                        bool isSelected = Convert.ToBoolean(row.Cells["chk"].Value);
                        if (isSelected)
                        {
                            Exception = 1;
                        }

                        OleDbCommand cmd = DBController.Instance.GetCommand();
                        OleDbConnection con = new OleDbConnection(str);
                        string Sql = @"insert into t_DMSStrikeRate Values(?,?,?,?)";
                        cmd.CommandText = Sql;
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("DSRCode", row.Cells[3].Value);
                        cmd.Parameters.AddWithValue("SalesMonth", datefrom);
                        cmd.Parameters.AddWithValue("StrikeRate", row.Cells[7].Value);
                        cmd.Parameters.AddWithValue("Exception", Exception);
                        con.Open();
                        cmd.ExecuteScalar();
                        con.Close();
                    }
                    MessageBox.Show(count + "  DSR Strike Rate Has been Saved. ");
                }

        }


        public int CheckData()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbConnection con = new OleDbConnection(str);
            DBController.Instance.OpenNewConnection();
            string Sql = @"select Count( DataID) from t_DMSStrikeRate where SalesMonth='"+datefrom+"' ";
            cmd.CommandText = Sql;
            cmd.CommandType = CommandType.Text;        
            int count =Convert.ToInt32( cmd.ExecuteScalar());
            return count;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmWDUploader wd = new frmWDUploader();
            wd.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 4)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[3].Value.ToString().Contains(textBox1.Text.Trim()))
                    {
                        dataGridView1.CurrentRow.Selected = false;
                        dataGridView1.Rows[row.Index].Selected = true;
                        int index = row.Index;
                        dataGridView1.FirstDisplayedScrollingRowIndex = index;
                        break;
                    }
                }
            }
        }

        private void frmstrikeRate_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            //  Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            //  // creating new WorkBook within Excel application  
            //  Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            //  // creating new Excelsheet in workbook  
            //  Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            //  // see the excel sheet behind the program  
            //  app.Visible = true;
            //  // get the reference of first sheet. By default its name is Sheet1.  
            //  // store its reference to worksheet  
            //  worksheet = workbook.Sheets["Sheet1"];
            ////  worksheet = workbook.ActiveSheet;
            //  // changing the name of active sheet  
            //  worksheet.Name = "Exported from gridview";
            //  // storing header part in Excel  
            //  for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            //  {
            //      worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            //  }
            //  // storing Each row and column value to excel sheet  
            //  for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            //  {
            //      for (int j = 0; j < dataGridView1.Columns.Count; j++)
            //      {
            //          worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
            //      }
            //  }
            //  // save the application  
            //  workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            //  // Exit from the application  
            //  app.Quit();


            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            object Missing = Type.Missing;
            Workbook workbook = excel.Workbooks.Add(Missing);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
            int StartCol = 1;
            int StartRow = 1;
            for (int j = 0; j < dataGridView1.Columns.Count; j++)
            {
                Range myRange = (Range)sheet1.Cells[StartRow, StartCol + j];
                myRange.Value2 = dataGridView1.Columns[j].HeaderText;
            }
            StartRow++;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {

                    Range myRange = (Range)sheet1.Cells[StartRow + i, StartCol + j];
                    myRange.Value2 = dataGridView1[j, i].Value == null ? "" : dataGridView1[j, i].Value;
                    myRange.Select();
                }
            }
        }

    
    }
}
