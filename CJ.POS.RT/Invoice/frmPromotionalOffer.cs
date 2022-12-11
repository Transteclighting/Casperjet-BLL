using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.POS.RT.Invoice
{
    public partial class frmPromotionalOffer : Form
    {
        string _sPromoNo;
        string _sPromoName;
        string _sPromoType;
        string _sPromoSlab;
        int _nOfferID;
        int _nSlabID;
        int _nPromoID;
        public bool _Flag = false;
        bool _FlagMultiOffer = false;
        public int nOfferID = 0;
        public string sOfferDescription = "";
        int nIndex = 0;

        ConsumerPromotionEngines _oConsumerPromotionEngines;
        public frmPromotionalOffer(string sPromoNo, string sPromoName, string sPromoType, string sPromoSlab, int nOfferID, int nSlabID, int nPromoID)
        {
            _sPromoNo = sPromoNo;
            _sPromoName = sPromoName;
            _sPromoType = sPromoType;
            _sPromoSlab = sPromoSlab;
            _nOfferID = nOfferID;
            _nSlabID = nSlabID;
            _nPromoID = nPromoID;

            InitializeComponent();
        }

        private void frmPromotionalOffer_Load(object sender, EventArgs e)
        {
            lblPromoType.Text = _sPromoType;
            lblPromoNo.Text = _sPromoNo;
            lblPromoName.Text = _sPromoName;
            lblSlab.Text = _sPromoSlab;

            _oConsumerPromotionEngines = new ConsumerPromotionEngines();
            if (_sPromoType == "CP")
            {
                _oConsumerPromotionEngines.GetPromoOffer(_nPromoID, _nSlabID);
            }
            else
            {
                _oConsumerPromotionEngines.GetPromoOfferTP(_nPromoID, _nSlabID);
            }
            
            cmbOffer.Items.Clear();
            if (_oConsumerPromotionEngines.Count != 1)
            {
                cmbOffer.Items.Add("-- Select an offer --");
                _FlagMultiOffer = true;
            }
            foreach (ConsumerPromotionEngine _oCPE in _oConsumerPromotionEngines)
            {
                cmbOffer.Items.Add(_oCPE.OfferDesctiption);
            }

            cmbOffer.SelectedIndex = 0;
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                if (_FlagMultiOffer)
                {
                    nIndex = cmbOffer.SelectedIndex - 1;
                }
                else
                {
                    nIndex = cmbOffer.SelectedIndex;
                }
                nOfferID = _oConsumerPromotionEngines[nIndex].OfferID;
                sOfferDescription = cmbOffer.Text;
                _Flag = true;
                this.Close();
            }
        }

        private bool UIValidation()
        {
            if (_FlagMultiOffer)
            {
                if (cmbOffer.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select an Offer", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbOffer.Focus();
                    return false;
                }
            }
            return true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
