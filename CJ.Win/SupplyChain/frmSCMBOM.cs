using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.SupplyChain;
using CJ.Class.BasicData;
using CJ.Class.Library;

namespace CJ.Win.SupplyChain
{
    public partial class frmSCMBOM : Form
    {
        public DSBOM _oDSBOM;
        DSBOM _oDSBOMFill = new DSBOM();
        SCMBOM _oSCMBOM;
        SCMOrder _oSCMOrder;
        SCMBOMs _oSCMBOMs;
        Product _oProduct;
        //int nProductID;
        public int _nCount = 0;
        public string _sBOMList = "";
        
        public frmSCMBOM()
        {
            InitializeComponent();

        }
        private void frmSCMBOM_Load(object sender, EventArgs e)
        {

        }

        public void ShowDialog(DSBOM oDSBOM, int nOrderID, int nProductID)
        {
            _oDSBOM = new DSBOM();
            _oDSBOM = oDSBOM;

            lblText.Text = "Available BOM List";
            CJ.Class.DBController.Instance.OpenNewConnection();

            _oProduct = new Product();
            _oProduct.ProductID = nProductID;
            _oProduct.RefreshByProductID();
            lblOrderID.Text = Convert.ToString(nOrderID);
            lblProductCode.Text = _oProduct.ProductCode;
            lblProductName.Text = _oProduct.ProductName;


            _oSCMBOMs = new SCMBOMs();
            _oSCMBOMs.GetBOMList(nProductID);


            foreach (SCMBOM oSCMBOM in _oSCMBOMs)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvBOMQty);
                oRow.Cells[0].Value = oSCMBOM.BOMDescription.ToString();
                oRow.Cells[1].Value = 0;
                oRow.Cells[2].Value = oSCMBOM.BOMID.ToString();
                oRow.Cells[3].Value = nProductID;

                dgvBOMQty.Rows.Add(oRow);
            }
            CJ.Class.DBController.Instance.CloseConnection();           
            this.ShowDialog();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int nBOMQty = 0;
            _oDSBOM.Clear();
            for (int i = 0; i < dgvBOMQty.Rows.Count; i++)
            {
                DSBOM.BOMItemRow oRow = _oDSBOM.BOMItem.NewBOMItemRow();
                oRow.ProductID = Convert.ToInt32(dgvBOMQty.Rows[i].Cells[3].Value);
                oRow.OrderId = Convert.ToInt32(lblOrderID.Text);
                oRow.BOMID = Convert.ToInt32(dgvBOMQty.Rows[i].Cells[2].Value);
                oRow.BOMQty = Convert.ToInt32(dgvBOMQty.Rows[i].Cells[1].Value);
                _oDSBOM.BOMItem.AddBOMItemRow(oRow);
                _oDSBOM.AcceptChanges();

                if (_sBOMList != "")
                {
                    _sBOMList = _sBOMList + " | ";
                }
                _sBOMList = _sBOMList + dgvBOMQty.Rows[i].Cells[0].Value + "-" + dgvBOMQty.Rows[i].Cells[1].Value;
            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}