using CJ.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CJ.Win.Distribution
{
    public partial class frmAutoIndent : Form
    {
        AutoIndent oAutoIndents = new AutoIndent();
        public frmAutoIndent(AutoIndent oAutoIndents)
        {
            this.oAutoIndents = oAutoIndents;
            InitializeComponent();
        }


        private void frmAutoIndent_Load(object sender, EventArgs e)
        {
            txtAutoIndentID.Text = oAutoIndents.AutoIndentID.ToString();
            txtCustCode.Text = oAutoIndents.CustomerCode;
            txtCustName.Text = oAutoIndents.CustomerName;
            txtDeliveryAdd.Text = oAutoIndents.DeliveryAddress;
            AutoIndentDetails oAutoIndentDetail = new AutoIndentDetails();
            var list = oAutoIndentDetail.Refresh().Where(a=>a.AutoIndentID == oAutoIndents.AutoIndentID);
            foreach(var v in list)
            {
                v.AdjustedTPAmount = Math.Round((v.AdjustedTPAmount * v.Quantity * v.UnitPrice), 2); 
                v.AdjustedPWAmount = Math.Round((v.AdjustedPWAmount * v.Quantity * v.UnitPrice), 2);
                v.AdjustedDPAmount = Math.Round((v.AdjustedDPAmount * v.Quantity * v.UnitPrice), 2);
            }
            //dgvLineItem.DataSource = list.ToList();
            Products product = new Products();

            foreach (var v in list)
            {
                if (v.Quantity > 0)
                {
                    int rowId = dgvLineItem.Rows.Add();
                    DataGridViewRow row = dgvLineItem.Rows[rowId];
                    row.Cells["ProductName"].Value = product.GetProductNameByID(v.ProductID);
                    row.Cells["UnitPrice"].Value = v.UnitPrice.ToString();
                    row.Cells["Quantity"].Value = v.Quantity.ToString();
                    row.Cells["ConfirmedQuantity"].Value = v.ConfirmQuantity.ToString();
                    row.Cells["GrossAmount"].Value = (v.ConfirmQuantity * v.UnitPrice).ToString();
                    row.Cells["DP"].Value = v.AdjustedDPAmount.ToString();
                    row.Cells["TP"].Value = v.AdjustedTPAmount;
                    row.Cells["PW"].Value = v.AdjustedPWAmount.ToString();
                    row.Cells["PromotionalDiscount"].Value = v.PromotionalDiscount.ToString();
                    row.Cells["NetQuantity"].Value = ((v.ConfirmQuantity * v.UnitPrice) - (v.AdjustedDPAmount - v.AdjustedTPAmount - v.AdjustedPWAmount)).ToString();
                }
            }
            double total = 0;
            for (int rows = 0; rows < dgvLineItem.Rows.Count; rows++)
            {
                for (int col = 0; col < dgvLineItem.Rows[rows].Cells.Count; col++)
                {
                    if(col==9)
                    {
                        string value = dgvLineItem.Rows[rows].Cells[col].Value.ToString();
                        total += Double.Parse(value);
                    }
                    

                }
            }
            txtTotalAmount.Text = total.ToString();
            string[] token = total.ToString().Split('.');
            lblAmountInWord.Text = NumberToWords(Int32.Parse(token[0])).Trim();

        }
        public string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }
    }
}
