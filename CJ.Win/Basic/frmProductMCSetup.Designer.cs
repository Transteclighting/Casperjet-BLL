
namespace CJ.Win.Basic
{
    partial class frmProductMCSetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCode = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txterpcode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtlabour = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtfactory = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtmatrial = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtcogs = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtdbinc = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtretail = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtadv = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtreplacement = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtfright = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtdbtax = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtroyality = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtyearinc = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txttemainc = new System.Windows.Forms.TextBox();
            this.lvwProductMC = new System.Windows.Forms.ListView();
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colERPCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCOGS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVCMaterial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVCVariableFactory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVCDirectLabor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFreightCost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReplacement = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAdvertisement = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTPRetailOffer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTPDBIncentive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTPTeamIncentive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTPYearlyIncentive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRoyality = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDistributorTax = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnApply = new System.Windows.Forms.Button();
            this.dtpEffectiveDate = new System.Windows.Forms.DateTimePicker();
            this.label59 = new System.Windows.Forms.Label();
            this.ctlProduct1 = new CJ.Win.ctlProduct();
            this.SuspendLayout();
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(39, 18);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(44, 13);
            this.lblCode.TabIndex = 18;
            this.lblCode.Text = "Product";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(42, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 13);
            this.label13.TabIndex = 54;
            this.label13.Text = "ERP Code";
            // 
            // txterpcode
            // 
            this.txterpcode.Location = new System.Drawing.Point(110, 49);
            this.txterpcode.Name = "txterpcode";
            this.txterpcode.Size = new System.Drawing.Size(92, 20);
            this.txterpcode.TabIndex = 55;
            this.txterpcode.Text = "0";
            this.txterpcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 161);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 13);
            this.label12.TabIndex = 52;
            this.label12.Text = "Direct Labour";
            // 
            // txtlabour
            // 
            this.txtlabour.Location = new System.Drawing.Point(110, 154);
            this.txtlabour.Name = "txtlabour";
            this.txtlabour.Size = new System.Drawing.Size(92, 20);
            this.txtlabour.TabIndex = 53;
            this.txtlabour.Text = "0";
            this.txtlabour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(37, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 50;
            this.label11.Text = "VC_Factory";
            // 
            // txtfactory
            // 
            this.txtfactory.Location = new System.Drawing.Point(110, 128);
            this.txtfactory.Name = "txtfactory";
            this.txtfactory.Size = new System.Drawing.Size(92, 20);
            this.txtfactory.TabIndex = 51;
            this.txtfactory.Text = "0";
            this.txtfactory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(41, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 48;
            this.label10.Text = "VC_Matrial";
            // 
            // txtmatrial
            // 
            this.txtmatrial.Location = new System.Drawing.Point(110, 102);
            this.txtmatrial.Name = "txtmatrial";
            this.txtmatrial.Size = new System.Drawing.Size(92, 20);
            this.txtmatrial.TabIndex = 49;
            this.txtmatrial.Text = "0";
            this.txtmatrial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 46;
            this.label9.Text = "COGS";
            // 
            // txtcogs
            // 
            this.txtcogs.Location = new System.Drawing.Point(110, 75);
            this.txtcogs.Name = "txtcogs";
            this.txtcogs.Size = new System.Drawing.Size(92, 20);
            this.txtcogs.TabIndex = 47;
            this.txtcogs.Text = "0";
            this.txtcogs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 285);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 13);
            this.label18.TabIndex = 64;
            this.label18.Text = "DB Incentive (%)";
            // 
            // txtdbinc
            // 
            this.txtdbinc.Location = new System.Drawing.Point(110, 285);
            this.txtdbinc.Name = "txtdbinc";
            this.txtdbinc.Size = new System.Drawing.Size(92, 20);
            this.txtdbinc.TabIndex = 65;
            this.txtdbinc.Text = "0";
            this.txtdbinc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(28, 261);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 13);
            this.label17.TabIndex = 62;
            this.label17.Text = "TP- Retail (%)";
            // 
            // txtretail
            // 
            this.txtretail.Location = new System.Drawing.Point(110, 258);
            this.txtretail.Name = "txtretail";
            this.txtretail.Size = new System.Drawing.Size(92, 20);
            this.txtretail.TabIndex = 63;
            this.txtretail.Text = "0";
            this.txtretail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(14, 235);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 13);
            this.label16.TabIndex = 60;
            this.label16.Text = "Advertisment (%)";
            // 
            // txtadv
            // 
            this.txtadv.Location = new System.Drawing.Point(110, 232);
            this.txtadv.Name = "txtadv";
            this.txtadv.Size = new System.Drawing.Size(92, 20);
            this.txtadv.TabIndex = 61;
            this.txtadv.Text = "0";
            this.txtadv.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 209);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 13);
            this.label15.TabIndex = 58;
            this.label15.Text = "Replacement (%)";
            // 
            // txtreplacement
            // 
            this.txtreplacement.Location = new System.Drawing.Point(110, 206);
            this.txtreplacement.Name = "txtreplacement";
            this.txtreplacement.Size = new System.Drawing.Size(92, 20);
            this.txtreplacement.TabIndex = 59;
            this.txtreplacement.Text = "0";
            this.txtreplacement.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(25, 187);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(74, 13);
            this.label14.TabIndex = 56;
            this.label14.Text = "Fright Cost (%)";
            // 
            // txtfright
            // 
            this.txtfright.Location = new System.Drawing.Point(110, 180);
            this.txtfright.Name = "txtfright";
            this.txtfright.Size = new System.Drawing.Size(92, 20);
            this.txtfright.TabIndex = 57;
            this.txtfright.Text = "0";
            this.txtfright.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(7, 397);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(92, 13);
            this.label23.TabIndex = 72;
            this.label23.Text = "Distributor Tax (%)";
            // 
            // txtdbtax
            // 
            this.txtdbtax.Location = new System.Drawing.Point(110, 394);
            this.txtdbtax.Name = "txtdbtax";
            this.txtdbtax.Size = new System.Drawing.Size(92, 20);
            this.txtdbtax.TabIndex = 73;
            this.txtdbtax.Text = "0";
            this.txtdbtax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(38, 367);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(61, 13);
            this.label22.TabIndex = 70;
            this.label22.Text = "Royality (%)";
            // 
            // txtroyality
            // 
            this.txtroyality.Location = new System.Drawing.Point(110, 365);
            this.txtroyality.Name = "txtroyality";
            this.txtroyality.Size = new System.Drawing.Size(92, 20);
            this.txtroyality.TabIndex = 71;
            this.txtroyality.Text = "0";
            this.txtroyality.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(1, 342);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(100, 13);
            this.label20.TabIndex = 68;
            this.label20.Text = "Yearly Incentive (%)";
            // 
            // txtyearinc
            // 
            this.txtyearinc.Location = new System.Drawing.Point(110, 339);
            this.txtyearinc.Name = "txtyearinc";
            this.txtyearinc.Size = new System.Drawing.Size(92, 20);
            this.txtyearinc.TabIndex = 69;
            this.txtyearinc.Text = "0";
            this.txtyearinc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(1, 316);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(98, 13);
            this.label19.TabIndex = 66;
            this.label19.Text = "Team Incentive (%)";
            // 
            // txttemainc
            // 
            this.txttemainc.Location = new System.Drawing.Point(110, 313);
            this.txttemainc.Name = "txttemainc";
            this.txttemainc.Size = new System.Drawing.Size(92, 20);
            this.txttemainc.TabIndex = 67;
            this.txttemainc.Text = "0";
            this.txttemainc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lvwProductMC
            // 
            this.lvwProductMC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProductMC.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colERPCode,
            this.colCOGS,
            this.colVCMaterial,
            this.colVCVariableFactory,
            this.colVCDirectLabor,
            this.colFreightCost,
            this.colReplacement,
            this.colAdvertisement,
            this.colTPRetailOffer,
            this.colTPDBIncentive,
            this.colTPTeamIncentive,
            this.colTPYearlyIncentive,
            this.colRoyality,
            this.colDistributorTax});
            this.lvwProductMC.FullRowSelect = true;
            this.lvwProductMC.GridLines = true;
            this.lvwProductMC.HideSelection = false;
            this.lvwProductMC.Location = new System.Drawing.Point(211, 49);
            this.lvwProductMC.Name = "lvwProductMC";
            this.lvwProductMC.Size = new System.Drawing.Size(789, 361);
            this.lvwProductMC.TabIndex = 74;
            this.lvwProductMC.UseCompatibleStateImageBehavior = false;
            this.lvwProductMC.View = System.Windows.Forms.View.Details;
            this.lvwProductMC.SelectedIndexChanged += new System.EventHandler(this.lvwProductMC_SelectedIndexChanged);
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 150;
            // 
            // colERPCode
            // 
            this.colERPCode.Text = "ERP Code";
            // 
            // colCOGS
            // 
            this.colCOGS.Text = "COGS";
            // 
            // colVCMaterial
            // 
            this.colVCMaterial.Text = "Material";
            this.colVCMaterial.Width = 51;
            // 
            // colVCVariableFactory
            // 
            this.colVCVariableFactory.Text = "Factory";
            // 
            // colVCDirectLabor
            // 
            this.colVCDirectLabor.Text = "Labor";
            this.colVCDirectLabor.Width = 52;
            // 
            // colFreightCost
            // 
            this.colFreightCost.Text = "Freight Cost";
            this.colFreightCost.Width = 70;
            // 
            // colReplacement
            // 
            this.colReplacement.Text = "Replacement";
            // 
            // colAdvertisement
            // 
            this.colAdvertisement.Text = "Advertisement";
            // 
            // colTPRetailOffer
            // 
            this.colTPRetailOffer.Text = "TP Retail";
            // 
            // colTPDBIncentive
            // 
            this.colTPDBIncentive.Text = "TP DB Inc.";
            this.colTPDBIncentive.Width = 59;
            // 
            // colTPTeamIncentive
            // 
            this.colTPTeamIncentive.Text = "TP Team Inc.";
            // 
            // colTPYearlyIncentive
            // 
            this.colTPYearlyIncentive.Text = "TP Yearly Inc.";
            // 
            // colRoyality
            // 
            this.colRoyality.Text = "Royality";
            // 
            // colDistributorTax
            // 
            this.colDistributorTax.Text = "Distributor Tax";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(922, 416);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 75;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click_1);
            // 
            // dtpEffectiveDate
            // 
            this.dtpEffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEffectiveDate.Location = new System.Drawing.Point(905, 18);
            this.dtpEffectiveDate.Name = "dtpEffectiveDate";
            this.dtpEffectiveDate.Size = new System.Drawing.Size(92, 20);
            this.dtpEffectiveDate.TabIndex = 77;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(824, 18);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(75, 13);
            this.label59.TabIndex = 76;
            this.label59.Text = "Effective Date";
            // 
            // ctlProduct1
            // 
            this.ctlProduct1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ctlProduct1.Location = new System.Drawing.Point(110, 12);
            this.ctlProduct1.Name = "ctlProduct1";
            this.ctlProduct1.Size = new System.Drawing.Size(511, 31);
            this.ctlProduct1.TabIndex = 17;
            this.ctlProduct1.ChangeSelection += new System.EventHandler(this.ctlProduct1_ChangeSelection);
            this.ctlProduct1.Load += new System.EventHandler(this.ctlProduct1_Load);
            // 
            // frmProductMCSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 450);
            this.Controls.Add(this.ctlProduct1);
            this.Controls.Add(this.dtpEffectiveDate);
            this.Controls.Add(this.label59);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lvwProductMC);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtdbtax);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtroyality);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtyearinc);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txttemainc);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtdbinc);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtretail);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtadv);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtreplacement);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtfright);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txterpcode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtlabour);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtfactory);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtmatrial);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtcogs);
            this.Controls.Add(this.lblCode);
            this.Name = "frmProductMCSetup";
            this.Text = "frmProductMCSetup";
            this.Load += new System.EventHandler(this.frmProductMCSetup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCode;
        private ctlProduct ctlProduct1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txterpcode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtlabour;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtfactory;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtmatrial;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtcogs;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtdbinc;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtretail;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtadv;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtreplacement;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtfright;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtdbtax;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtroyality;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtyearinc;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txttemainc;
        private System.Windows.Forms.ListView lvwProductMC;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colERPCode;
        private System.Windows.Forms.ColumnHeader colCOGS;
        private System.Windows.Forms.ColumnHeader colVCMaterial;
        private System.Windows.Forms.ColumnHeader colVCVariableFactory;
        private System.Windows.Forms.ColumnHeader colVCDirectLabor;
        private System.Windows.Forms.ColumnHeader colFreightCost;
        private System.Windows.Forms.ColumnHeader colReplacement;
        private System.Windows.Forms.ColumnHeader colAdvertisement;
        private System.Windows.Forms.ColumnHeader colTPRetailOffer;
        private System.Windows.Forms.ColumnHeader colTPDBIncentive;
        private System.Windows.Forms.ColumnHeader colTPTeamIncentive;
        private System.Windows.Forms.ColumnHeader colTPYearlyIncentive;
        private System.Windows.Forms.ColumnHeader colRoyality;
        private System.Windows.Forms.ColumnHeader colDistributorTax;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.DateTimePicker dtpEffectiveDate;
        private System.Windows.Forms.Label label59;
    }
}