namespace ComputerShopView
{
    partial class FormReportDetail
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
            this.components = new System.ComponentModel.Container();
            this.ReportWarehouseDetailViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ButtonToPdf = new System.Windows.Forms.Button();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.WarehouseDetailViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ReportWarehouseDetailViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseDetailViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ReportWarehouseDetailViewModelBindingSource
            // 
            this.ReportWarehouseDetailViewModelBindingSource.DataSource = typeof(ComputerShopBusinessLogic.ViewModels.ReportWarehouseDetailViewModel);
            // 
            // ButtonToPdf
            // 
            this.ButtonToPdf.Location = new System.Drawing.Point(544, 10);
            this.ButtonToPdf.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ButtonToPdf.Name = "ButtonToPdf";
            this.ButtonToPdf.Size = new System.Drawing.Size(130, 31);
            this.ButtonToPdf.TabIndex = 1;
            this.ButtonToPdf.Text = "В Pdf";
            this.ButtonToPdf.UseVisualStyleBackColor = true;
            this.ButtonToPdf.Click += new System.EventHandler(this.ButtonToPdf_Click);
            // 
            // reportViewer
            // 
           
            this.reportViewer.LocalReport.ReportEmbeddedResource = "ComputerShopView.ReportWarehouseDetail.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(8, 50);
            this.reportViewer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(667, 327);
            this.reportViewer.TabIndex = 2;
            this.reportViewer.Load += new System.EventHandler(this.ReportViewer_Load);
            // 
            // WarehouseDetailViewModelBindingSource
            // 
            this.WarehouseDetailViewModelBindingSource.DataSource = typeof(ComputerShopBusinessLogic.ViewModels.WarehouseDetailViewModel);
            // 
            // FormReportDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 379);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.ButtonToPdf);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormReportDetail";
            this.Text = "Детали по складам";
            ((System.ComponentModel.ISupportInitialize)(this.ReportWarehouseDetailViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WarehouseDetailViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource ReportWarehouseDetailViewModelBindingSource;
        private System.Windows.Forms.Button ButtonToPdf;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.BindingSource WarehouseDetailViewModelBindingSource;
    }
}