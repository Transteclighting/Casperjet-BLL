namespace CJ.Report
{
    partial class frmPrintPreviewWithoutPrintExport
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
            this.crvPrintPreview = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvPrintPreview
            // 
            this.crvPrintPreview.ActiveViewIndex = -1;
            this.crvPrintPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvPrintPreview.DisplayGroupTree = false;
            this.crvPrintPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvPrintPreview.Location = new System.Drawing.Point(0, 0);
            this.crvPrintPreview.Name = "crvPrintPreview";
            this.crvPrintPreview.SelectionFormula = "";
            this.crvPrintPreview.Size = new System.Drawing.Size(555, 446);
            this.crvPrintPreview.TabIndex = 2;
            this.crvPrintPreview.ViewTimeSelectionFormula = "";
            // 
            // frmPrintPreviewWithoutPrintExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 446);
            this.Controls.Add(this.crvPrintPreview);
            this.Name = "frmPrintPreviewWithoutPrintExport";
            this.Text = "Print Preview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvPrintPreview;
    }
}