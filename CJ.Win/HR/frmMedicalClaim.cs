using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;

namespace CJ.Win.HR
{
    public partial class frmMedicalClaim : Form
    {
        public frmMedicalClaim()
        {
            InitializeComponent();
        }

        private void frmMedicalClaim_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }


        private void LoadCombos()
        {

            //Claim Type
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.MedicalClaimType)))
            {
                cboClaimType.Items.Add(Enum.GetName(typeof(Dictionary.MedicalClaimType), GetEnum));
            }
            cboClaimType.SelectedIndex = (int)Dictionary.MedicalClaimType.Medical_Allowance;
        }
    }
}