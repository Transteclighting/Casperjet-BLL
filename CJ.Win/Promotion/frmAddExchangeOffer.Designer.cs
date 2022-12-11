namespace CJ.Win.Promotion
{
    partial class frmAddExchangeOffer
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimefrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimeTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tvBrand = new System.Windows.Forms.TreeView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tvwShowroom = new System.Windows.Forms.TreeView();
            this.lbTotal = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tvProduct = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.tDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimefrom);
            this.groupBox1.Controls.Add(this.dateTimeTo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(494, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(459, 97);
            this.groupBox1.TabIndex = 141;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "    Effective Date";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(236, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 15);
            this.label1.TabIndex = 141;
            this.label1.Text = "To";
            // 
            // dateTimefrom
            // 
            this.dateTimefrom.CustomFormat = "dd-MMM-yyyy";
            this.dateTimefrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dateTimefrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimefrom.Location = new System.Drawing.Point(85, 41);
            this.dateTimefrom.Name = "dateTimefrom";
            this.dateTimefrom.Size = new System.Drawing.Size(144, 21);
            this.dateTimefrom.TabIndex = 140;
            // 
            // dateTimeTo
            // 
            this.dateTimeTo.CustomFormat = "dd-MMM-yyyy";
            this.dateTimeTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dateTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeTo.Location = new System.Drawing.Point(262, 41);
            this.dateTimeTo.Name = "dateTimeTo";
            this.dateTimeTo.Size = new System.Drawing.Size(144, 21);
            this.dateTimeTo.TabIndex = 142;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(46, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 139;
            this.label2.Text = "From";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(941, 442);
            this.groupBox2.TabIndex = 143;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Exchange Data";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tvBrand);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(621, 20);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(314, 415);
            this.groupBox5.TabIndex = 145;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Brand";
            // 
            // tvBrand
            // 
            this.tvBrand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvBrand.CheckBoxes = true;
            this.tvBrand.Location = new System.Drawing.Point(6, 17);
            this.tvBrand.Name = "tvBrand";
            this.tvBrand.Size = new System.Drawing.Size(302, 389);
            this.tvBrand.TabIndex = 25;
            this.tvBrand.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvBrand_AfterSelect);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tvwShowroom);
            this.groupBox4.Controls.Add(this.lbTotal);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(325, 20);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(296, 415);
            this.groupBox4.TabIndex = 145;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Outlet";
            // 
            // tvwShowroom
            // 
            this.tvwShowroom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvwShowroom.CheckBoxes = true;
            this.tvwShowroom.Location = new System.Drawing.Point(6, 20);
            this.tvwShowroom.Name = "tvwShowroom";
            this.tvwShowroom.Size = new System.Drawing.Size(284, 389);
            this.tvwShowroom.TabIndex = 24;
            this.tvwShowroom.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwShowroom_AfterCheck);
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(46, 52);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(0, 15);
            this.lbTotal.TabIndex = 23;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tvProduct);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(319, 415);
            this.groupBox3.TabIndex = 144;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Product Group";
            // 
            // tvProduct
            // 
            this.tvProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvProduct.CheckBoxes = true;
            this.tvProduct.Location = new System.Drawing.Point(6, 20);
            this.tvProduct.Name = "tvProduct";
            this.tvProduct.Size = new System.Drawing.Size(306, 389);
            this.tvProduct.TabIndex = 25;
            this.tvProduct.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvProduct_AfterCheck);
            this.tvProduct.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvProduct_AfterSelect);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(866, 561);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 42);
            this.button1.TabIndex = 144;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tDescription
            // 
            this.tDescription.Location = new System.Drawing.Point(84, 40);
            this.tDescription.Name = "tDescription";
            this.tDescription.Size = new System.Drawing.Size(351, 20);
            this.tDescription.TabIndex = 147;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(9, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 148;
            this.label4.Text = "Description";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.tDescription);
            this.groupBox6.Location = new System.Drawing.Point(12, 10);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox6.Size = new System.Drawing.Size(466, 97);
            this.groupBox6.TabIndex = 149;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Exchange Details";
            // 
            // frmAddExchangeOffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 609);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAddExchangeOffer";
            this.Text = "ADD Exchange Offer";
            this.Load += new System.EventHandler(this.frmAddExchangeOffer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimefrom;
        private System.Windows.Forms.DateTimePicker dateTimeTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView tvwShowroom;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.TreeView tvBrand;
        private System.Windows.Forms.TextBox tDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView tvProduct;
        private System.Windows.Forms.GroupBox groupBox6;
    }
}