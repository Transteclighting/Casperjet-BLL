using CJ.Class;
using Microsoft.Office.Interop.Excel;
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
using Microsoft.Office.Interop;

namespace CJ.Win.DMS
{
    public partial class frmDMSSalaryProcess : Form
    {
        string connectionstring = ConfigurationManager.AppSettings["ConnectionString"];
        public frmDMSSalaryProcess()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbConnection con = new OleDbConnection(connectionstring);


            if (txtWD.Text =="" || txtCD.Text=="")
            {
                MessageBox.Show("Please Set Working Day & CalenderDay", " Warning !! ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string DT = dateTimePicker1.Value.ToString("dd-MMM-yyyy");
                string Sql = "";

                if (checkData(DT) > 1)
                {
                    Sql =   @" Select DSR.Area,DSR.Territory,DSR.CustomerName,DSR.DSRCode,DSR.DSRID,DSR.DSRName,DSR.Designation,DSR.JoiningDate, 
                             DSR.FixedSalary,DSR.VariableSalary,DSR.DailyTADA,DSR.MobileBill,Main.TargetTO,Main.SalesTO,Main.TabDeduction,Main.ExcessInternet,Repair,LWP,Others,Addition 
                             from(Select DSRID, TargetTO, SalesTO, TABDeduction, ExcessInternet, Repair, LWP, Others, Addition, SalaryMonth from t_DMSDSRSalaryProcess) as Main 
                             left join ( 
                             Select AreaShortName as Area, TerritoryShortName as Territory, CustomerName, DSRCode, DSRID, DSRName, b.Designation, 
                             convert(date, b.JoiningDate) as JoiningDate, b.FixedSalary, b.VariableSalary,b.DailyTADA,b.MobileBill 
                             from v_CustomerDetails a, t_DMSDSRDetails b where a.CustomerID = b.CustomerID  and b.IsCurrent = 1 
                             ) as DSR on DSR.DSRID = Main.DSRID where SalaryMonth = '"+DT+"' ";
                }
                else
                {

                  

                     Sql = "Select * from ( " +
                    "Select Main.* ,Sales.Target,Sales.Sales,isnull(TABDeduct.DeductionAmount, 0) as TAB,0 as ExcessInternet,0 as RepairDeduction,0 as LWP,0 as Others, 0 as Addition,'' as Remarks from " +
                    "(Select " +
                    //"--RegionName, AreaName, TerritoryName, CustomerCode, " +
                    "AreaShortName as Area,TerritoryShortName as Territory,CustomerName, DSRCode, DSRID, DSRName,b.Designation,  convert(date, b.JoiningDate) as JoiningDate " +
                    ", b.FixedSalary, 0 as VariableSalary,DailyTADA,MobileBill from v_CustomerDetails a, t_DMSDSRDetails b " +
                    "where a.CustomerID = b.CustomerID  and b.IsCurrent = 1) as Main " +
                    "inner join " +
                    "(Select DSRID, Sum(Target) as Target, Sum(Sales) as Sales " +
                    " from( " +
                    //"-----------------Current Month Target-------------- " +
                    "select c.DSRID, sum(TSMTGTTO) as Target, 0 as Sales from t_DMSTargetTO a, t_DMSRoute b, t_DMSDSRDetails c " +
                    "where TGTDate between '"+DT+"'  and  DATEADD(mm, DATEDIFF(mm, 0, convert(date,'"+DT+ "')) +1, 0) and  TGTDate <DATEADD(mm, DATEDIFF(mm, 0, convert(date,'" + DT + "')) +1, 0)  " +
                    "and a.RouteID = b.RouteID and b.DSRID = c.DSRID group by c.DSRID " +
                    //"---------------- - Current Month Target End-------------- " +
                    " Union all " +
                    //"---------------- - MTD Delivery Start---- - " +
                    " select c.DSRID, 0 as Target, sum(DeliveryAmount) As Sales from t_DMSorder a, t_DMSRoute b, t_DMSDSRDetails c " +
                    " where  DeliveryDate between   '"+DT+"'  and   DATEADD(mm, DATEDIFF(mm, 0, convert(date,'" + DT + "')) +1, 0) and DeliveryDate < DATEADD(mm, DATEDIFF(mm, 0, convert(date,'" + DT + "')) +1, 0) " +
                    " and a.BeatID = b.RouteID and b.DSRID = c.DSRID group by c.DSRID " +
                    //" ---------------- - MTD Delivery End---- - " +
                    ") as Q1 Group by DSRID) as Sales on Main.DSRID = Sales.DSRID left join (select DSRCODE, DeductionAmount from t_ITEquipmentDeductDetails where InstallmentMonth = '"+DT+"' ) as TABDeduct on Main.DSRCode = TABDeduct.DSRCode) as Main ";
                }
                cmd.CommandText = Sql;
                cmd.CommandType = CommandType.Text;
                con.Open();
                OleDbDataAdapter adp = new OleDbDataAdapter(Sql, con);
                DataSet ds = new DataSet();

                adp.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[10].Visible = false;
                dataGridView1.Columns[11].Visible = false;
                dataGridView1.Columns[12].Visible = false;
                dataGridView1.Columns[13].Visible = false;
                con.Close();


            }
        }

        public int checkData(string dt)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            int ID = 0;
            string sSql = "SELECT Count([TranID]) FROM t_DMSDSRSalaryProcess where SalaryMonth='"+dt+"'";
            cmd.CommandText = sSql;
            object maxID = cmd.ExecuteScalar();
            if (maxID == DBNull.Value)
            {
                ID = 1;
            }
            else
            {
                ID = Convert.ToInt32(maxID) + 1;
            }

            return ID;

        }
          

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

            //(dataGridView1.DataSource as DataTable).DefaultView.RowFilter =string.Format("DSRCode like '{0}%' ", Convert.ToInt32( textBox1.Text));
            string searchValue = textBox1.Text;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[3].Value.ToString().Equals(searchValue))
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dt = new DateTime();
            string st = dateTimePicker1.Value.ToShortDateString();
            dt = Convert.ToDateTime(st);
 
            if (dataGridView1.Rows.Count <= 0)
            {
                MessageBox.Show("No Rows Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                OleDbCommand cmd = DBController.Instance.GetCommand();
                try
                {
                    EmptyPrevioussData(dateTimePicker1.Value.ToString("dd-MMM-yyyy"));
                    int ID = 0;
                    string sSql = "SELECT MAX([TranID]) FROM t_DMSDSRSalaryProcess";
                    cmd.CommandText = sSql;
                    object maxID = cmd.ExecuteScalar();
                    if (maxID == DBNull.Value)
                    {
                        ID = 1;
                    }
                    else
                    {
                        ID = Convert.ToInt32(maxID) + 1;
                    }

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        double PerDay = Math.Round(Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value) / Convert.ToInt32(txtCD.Text));
                        double LeaveDeduction = PerDay * Convert.ToInt32(dataGridView1.Rows[i].Cells[17].Value);
                        double TotalDdecution =  Convert.ToInt32(dataGridView1.Rows[i].Cells[14].Value) + Convert.ToInt32(dataGridView1.Rows[i].Cells[15].Value) + Convert.ToInt32(dataGridView1.Rows[i].Cells[16].Value) + Convert.ToInt32(dataGridView1.Rows[i].Cells[18].Value)+LeaveDeduction;
                        
                        string StrQuery = "";

                        //StrQuery = "INSERT INTO t_DMSDSRSalaryTGT(TranID,DSRID,DSRCOde,TargetTO,SalesTO,TotalDay,SalaryDay,WorkingDay,LWP,ExcessInternet,TABDeduction,Repair,Others,TotalDeduction,SalaryMonth) VALUES (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                        //  StrQuery = "INSERT INTO t_DMSDSRSalaryTGT Values(@TranID,@DSRID,@DSRCOde,@TargetTO,@SalesTO,@TotalDay,@SalaryDay,@WorkingDay,@LWP,@ExcessInternet,@TABDeduction,@Repair,@Others,@TotalDeduction,@SalaryMonth)";
                        StrQuery = @"INSERT INTO t_DMSDSRSalaryProcess Values(" + ID+","+ Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value) + ", " + 

                            " " + Convert.ToInt32(dataGridView1.Rows[i].Cells[8].Value) + ", " + 
                            " " + Convert.ToInt32(dataGridView1.Rows[i].Cells[9].Value) + ", " + 
                            " " + Convert.ToInt32(dataGridView1.Rows[i].Cells[10].Value) + ", " +
                            " " + Convert.ToInt32(dataGridView1.Rows[i].Cells[11].Value) + ", " +
                            " " + Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value) + ", " +
                            " " + Convert.ToInt32(dataGridView1.Rows[i].Cells[12].Value) + ", " +
                            " " + Convert.ToInt32(dataGridView1.Rows[i].Cells[13].Value) + ", " +
                            " " +Convert.ToInt32(txtCD.Text)+", " +
                            " "+ Convert.ToInt32(txtWD.Text) + ", " +
                            " " +( Convert.ToInt32(txtWD.Text) - Convert.ToInt32(dataGridView1.Rows[i].Cells[17].Value)) + ", " + 
                            " "+ Convert.ToInt32(dataGridView1.Rows[i].Cells[17].Value) + ", " +
                            " "+ Convert.ToDouble(dataGridView1.Rows[i].Cells[15].Value) + ", " + 
                            " "+ Convert.ToDouble(dataGridView1.Rows[i].Cells[14].Value) + ", " + 
                            " "+ Convert.ToDouble(dataGridView1.Rows[i].Cells[16].Value) + ", " + 
                            " " + Convert.ToDouble(dataGridView1.Rows[i].Cells[18].Value) + ", " +
                            " " + LeaveDeduction + ", " +
                            " " + Convert.ToDouble(dataGridView1.Rows[i].Cells[19].Value) + ", " +
                            " " + Convert.ToDouble(TotalDdecution)+", " +
                            " '" + Convert.ToDateTime(dateTimePicker1.Value.ToString("yyyy-MM-dd")) + "',1,'" + Convert.ToString(dataGridView1.Rows[i].Cells[20].Value) + "')";
                        cmd.CommandText = StrQuery;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        ID = ID + 1;
                    }

                    MessageBox.Show("You Have Successfully Processed Salary for - " + (dateTimePicker1.Value).ToString("MMM-yyyy") + " ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }
            }


            //Export To Excel
            ExporttoExcel();

        }

        public void ExporttoExcel()
        {

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

        private void frmDMSSalaryProcess_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int Days = DateTime.DaysInMonth(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month);
            txtCD.Text = Days.ToString();
            txtWD.Text = Days.ToString();
            if (CheckWorkingDay(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month) != 0)
            {
                txtWD.Text = CheckWorkingDay(dateTimePicker1.Value.Year, dateTimePicker1.Value.Month).ToString();
                txtWD.ReadOnly = true;
            }
            else
            {
                //txtWD.ReadOnly = false;
                txtWD.Text = Days.ToString();
            }
        }

        public void EmptyPrevioussData(string dt)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            int ID = 0;
            string sSql = "Delete FROM t_DMSDSRSalaryProcess where SalaryMonth='" + dt + "'";
            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteScalar();

        }


        private int CheckWorkingDay(int nyear, int nmonth)
        {
            DateTime dt = new DateTime(nyear, nmonth, 1);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int ID = 0;
            string sSql = @"if Exists( Select SalaryDay from t_DMSDSRSalaryProcess where SalaryMonth ='"+dt.ToString("dd-MMM-yyyy")+ @"' group by SalaryDay)
                            Select(Select Distinct SalaryDay from t_DMSDSRSalaryProcess where SalaryMonth = '" + dt.ToString("dd-MMM-yyyy") + @"'  group by SalaryDay) as SalaryDay
                            else 
                            select 0 as SalaryDay";
            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;
            ID=(int)cmd.ExecuteScalar();
            return ID;
        }
    }
}
