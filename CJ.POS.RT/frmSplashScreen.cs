﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.POS.RT.Security;

namespace CJ.POS.RT
{
    public partial class frmSplashScreen : Form
    {
        public frmSplashScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 1;
            if (progressBar1.Value == 100)
            {
                this.Hide();
                timer1.Enabled = false;
                frmLogin ofrm = new frmLogin();
                ofrm.ShowDialog();
                

            }
        }

    }
}
