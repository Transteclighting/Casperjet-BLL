
namespace CJ.Win.Basic
{
    partial class frmProductMCSet
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
            this.ctlProduct1 = new CJ.Control.ctlProduct();
            this.label1 = new System.Windows.Forms.Label();
            this.txterpcode = new System.Windows.Forms.TextBox();
            this.txtcogs = new System.Windows.Forms.TextBox();
            this.txtmatrial = new System.Windows.Forms.TextBox();
            this.txtfactory = new System.Windows.Forms.TextBox();
            this.txtlabour = new System.Windows.Forms.TextBox();
            this.txtfright = new System.Windows.Forms.TextBox();
            this.txtreplacement = new System.Windows.Forms.TextBox();
            this.txtadv = new System.Windows.Forms.TextBox();
            this.txtretail = new System.Windows.Forms.TextBox();
            this.txtdbinc = new System.Windows.Forms.TextBox();
            this.txttemainc = new System.Windows.Forms.TextBox();
            this.txtyearinc = new System.Windows.Forms.TextBox();
            this.txtroyality = new System.Windows.Forms.TextBox();
            this.txtdbtax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dtpEffectiveDate = new System.Windows.Forms.DateTimePicker();
            this.lvwProductMC = new System.Windows.Forms.ListView();
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colerpcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCOGS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMaterial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFactory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLabour = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFrightCost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReplacement = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsAdv = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRetail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTeam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colYearly = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRoyality = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTax = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctlProduct1
            // 
            this.ctlProduct1.Location = new System.Drawing.Point(145, 12);
            this.ctlProduct1.Name = "ctlProduct1";
            this.ctlProduct1.Size = new System.Drawing.Size(441, 25);
            this.ctlProduct1.TabIndex = 0;
            this.ctlProduct1.ChangeSelection += new System.EventHandler(this.ctlProduct1_ChangeSelection);
            this.ctlProduct1.Load += new System.EventHandler(this.frmProductMCSet_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Product Code";
            // 
            // txterpcode
            // 
            this.txterpcode.Location = new System.Drawing.Point(145, 44);
            this.txterpcode.Name = "txterpcode";
            this.txterpcode.Size = new System.Drawing.Size(124, 20);
            this.txterpcode.TabIndex = 2;
            // 
            // txtcogs
            // 
            this.txtcogs.Location = new System.Drawing.Point(145, 70);
            this.txtcogs.Name = "txtcogs";
            this.txtcogs.Size = new System.Drawing.Size(124, 20);
            this.txtcogs.TabIndex = 3;
            // 
            // txtmatrial
            // 
            this.txtmatrial.Location = new System.Drawing.Point(145, 96);
            this.txtmatrial.Name = "txtmatrial";
            this.txtmatrial.Size = new System.Drawing.Size(124, 20);
            this.txtmatrial.TabIndex = 4;
            // 
            // txtfactory
            // 
            this.txtfactory.Location = new System.Drawing.Point(145, 122);
            this.txtfactory.Name = "txtfactory";
            this.txtfactory.Size = new System.Drawing.Size(124, 20);
            this.txtfactory.TabIndex = 5;
            // 
            // txtlabour
            // 
            this.txtlabour.Location = new System.Drawing.Point(145, 148);
            this.txtlabour.Name = "txtlabour";
            this.txtlabour.Size = new System.Drawing.Size(124, 20);
            this.txtlabour.TabIndex = 6;
            // 
            // txtfright
            // 
            this.txtfright.Location = new System.Drawing.Point(145, 174);
            this.txtfright.Name = "txtfright";
            this.txtfright.Size = new System.Drawing.Size(124, 20);
            this.txtfright.TabIndex = 7;
            // 
            // txtreplacement
            // 
            this.txtreplacement.Location = new System.Drawing.Point(145, 200);
            this.txtreplacement.Name = "txtreplacement";
            this.txtreplacement.Size = new System.Drawing.Size(124, 20);
            this.txtreplacement.TabIndex = 8;
            // 
            // txtadv
            // 
            this.txtadv.Location = new System.Drawing.Point(145, 226);
            this.txtadv.Name = "txtadv";
            this.txtadv.Size = new System.Drawing.Size(124, 20);
            this.txtadv.TabIndex = 9;
            // 
            // txtretail
            // 
            this.txtretail.Location = new System.Drawing.Point(145, 252);
            this.txtretail.Name = "txtretail";
            this.txtretail.Size = new System.Drawing.Size(124, 20);
            this.txtretail.TabIndex = 10;
            // 
            // txtdbinc
            // 
            this.txtdbinc.Location = new System.Drawing.Point(145, 278);
            this.txtdbinc.Name = "txtdbinc";
            this.txtdbinc.Size = new System.Drawing.Size(124, 20);
            this.txtdbinc.TabIndex = 11;
            // 
            // txttemainc
            // 
            this.txttemainc.Location = new System.Drawing.Point(145, 304);
            this.txttemainc.Name = "txttemainc";
            this.txttemainc.Size = new System.Drawing.Size(124, 20);
            this.txttemainc.TabIndex = 12;
            // 
            // txtyearinc
            // 
            this.txtyearinc.Location = new System.Drawing.Point(145, 330);
            this.txtyearinc.Name = "txtyearinc";
            this.txtyearinc.Size = new System.Drawing.Size(124, 20);
            this.txtyearinc.TabIndex = 13;
            // 
            // txtroyality
            // 
            this.txtroyality.Location = new System.Drawing.Point(145, 356);
            this.txtroyality.Name = "txtroyality";
            this.txtroyality.Size = new System.Drawing.Size(124, 20);
            this.txtroyality.TabIndex = 14;
            // 
            // txtdbtax
            // 
            this.txtdbtax.Location = new System.Drawing.Point(145, 382);
            this.txtdbtax.Name = "txtdbtax";
            this.txtdbtax.Size = new System.Drawing.Size(124, 20);
            this.txtdbtax.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "ERP Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "COGS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "VC Material";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Variable Factory";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Direct Labor";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Freight Cost (%) ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(46, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Replacement (%)";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(41, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Advertisement (%)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(64, 255);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "TP Retail (%)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(56, 281);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "TP DB Inc. (%)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(44, 307);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "TP Team Inc. (%)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(42, 333);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 13);
            this.label13.TabIndex = 27;
            this.label13.Text = "TP Yearly Inc. (%)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(71, 356);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Royality (%)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(47, 382);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "Distributor Tax (%)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(769, 12);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(75, 13);
            this.label16.TabIndex = 30;
            this.label16.Text = "Effective Date";
            // 
            // dtpEffectiveDate
            // 
            this.dtpEffectiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEffectiveDate.Location = new System.Drawing.Point(850, 12);
            this.dtpEffectiveDate.Name = "dtpEffectiveDate";
            this.dtpEffectiveDate.Size = new System.Drawing.Size(95, 20);
            this.dtpEffectiveDate.TabIndex = 31;
            // 
            // lvwProductMC
            // 
            this.lvwProductMC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProductMC.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colerpcode,
            this.colCOGS,
            this.colMaterial,
            this.colFactory,
            this.colLabour,
            this.colFrightCost,
            this.colReplacement,
            this.colIsAdv,
            this.colRetail,
            this.colDB,
            this.colTeam,
            this.colYearly,
            this.colRoyality,
            this.colTax});
            this.lvwProductMC.FullRowSelect = true;
            this.lvwProductMC.GridLines = true;
            this.lvwProductMC.HideSelection = false;
            this.lvwProductMC.Location = new System.Drawing.Point(275, 44);
            this.lvwProductMC.Name = "lvwProductMC";
            this.lvwProductMC.Size = new System.Drawing.Size(670, 358);
            this.lvwProductMC.TabIndex = 32;
            this.lvwProductMC.UseCompatibleStateImageBehavior = false;
            this.lvwProductMC.View = System.Windows.Forms.View.Details;
            this.lvwProductMC.SelectedIndexChanged += new System.EventHandler(this.ctlProduct1_ChangeSelection);
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 97;
            // 
            // colerpcode
            // 
            this.colerpcode.Text = "ERP Code";
            this.colerpcode.Width = 89;
            // 
            // colCOGS
            // 
            this.colCOGS.Text = "COGS";
            this.colCOGS.Width = 70;
            // 
            // colMaterial
            // 
            this.colMaterial.Text = "Material";
            this.colMaterial.Width = 75;
            // 
            // colFactory
            // 
            this.colFactory.Text = "Factory";
            this.colFactory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colFactory.Width = 75;
            // 
            // colLabour
            // 
            this.colLabour.Text = "Labour";
            this.colLabour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colLabour.Width = 75;
            // 
            // colFrightCost
            // 
            this.colFrightCost.Text = "Fright Cost";
            this.colFrightCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colFrightCost.Width = 75;
            // 
            // colReplacement
            // 
            this.colReplacement.Text = "Replacement";
            this.colReplacement.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colReplacement.Width = 75;
            // 
            // colIsAdv
            // 
            this.colIsAdv.Text = "Adertisment";
            this.colIsAdv.Width = 53;
            // 
            // colRetail
            // 
            this.colRetail.Text = "TP Retail";
            // 
            // colDB
            // 
            this.colDB.Text = "DB Inc.";
            // 
            // colTeam
            // 
            this.colTeam.Text = "Team Inc";
            // 
            // colYearly
            // 
            this.colYearly.Text = "Yearly Inc.";
            // 
            // colRoyality
            // 
            this.colRoyality.Text = "Royality";
            // 
            // colTax
            // 
            this.colTax.Text = "DB Tax";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(839, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 23);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmProductMCSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lvwProductMC);
            this.Controls.Add(this.dtpEffectiveDate);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtdbtax);
            this.Controls.Add(this.txtroyality);
            this.Controls.Add(this.txtyearinc);
            this.Controls.Add(this.txttemainc);
            this.Controls.Add(this.txtdbinc);
            this.Controls.Add(this.txtretail);
            this.Controls.Add(this.txtadv);
            this.Controls.Add(this.txtreplacement);
            this.Controls.Add(this.txtfright);
            this.Controls.Add(this.txtlabour);
            this.Controls.Add(this.txtfactory);
            this.Controls.Add(this.txtmatrial);
            this.Controls.Add(this.txtcogs);
            this.Controls.Add(this.txterpcode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctlProduct1);
            this.Name = "frmProductMCSet";
            this.Text = "frmProductMCSet";
            this.Load += new System.EventHandler(this.frmProductMCSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CJ.Control.ctlProduct ctlProduct1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txterpcode;
        private System.Windows.Forms.TextBox txtcogs;
        private System.Windows.Forms.TextBox txtmatrial;
        private System.Windows.Forms.TextBox txtfactory;
        private System.Windows.Forms.TextBox txtlabour;
        private System.Windows.Forms.TextBox txtfright;
        private System.Windows.Forms.TextBox txtreplacement;
        private System.Windows.Forms.TextBox txtadv;
        private System.Windows.Forms.TextBox txtretail;
        private System.Windows.Forms.TextBox txtdbinc;
        private System.Windows.Forms.TextBox txttemainc;
        private System.Windows.Forms.TextBox txtyearinc;
        private System.Windows.Forms.TextBox txtroyality;
        private System.Windows.Forms.TextBox txtdbtax;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dtpEffectiveDate;
        private System.Windows.Forms.ListView lvwProductMC;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colerpcode;
        private System.Windows.Forms.ColumnHeader colCOGS;
        private System.Windows.Forms.ColumnHeader colMaterial;
        private System.Windows.Forms.ColumnHeader colFactory;
        private System.Windows.Forms.ColumnHeader colLabour;
        private System.Windows.Forms.ColumnHeader colFrightCost;
        private System.Windows.Forms.ColumnHeader colReplacement;
        private System.Windows.Forms.ColumnHeader colIsAdv;
        private System.Windows.Forms.ColumnHeader colRetail;
        private System.Windows.Forms.ColumnHeader colDB;
        private System.Windows.Forms.ColumnHeader colTeam;
        private System.Windows.Forms.ColumnHeader colYearly;
        private System.Windows.Forms.ColumnHeader colRoyality;
        private System.Windows.Forms.ColumnHeader colTax;
        private System.Windows.Forms.Button btnSave;
    }
}