namespace ComputerShopView
{
    partial class FormReportWarehouseDetail
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
            this.buttonSaveToExcel = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.columnWarehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSaveToExcel
            // 
            this.buttonSaveToExcel.Location = new System.Drawing.Point(430, 10);
            this.buttonSaveToExcel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSaveToExcel.Name = "buttonSaveToExcel";
            this.buttonSaveToExcel.Size = new System.Drawing.Size(128, 24);
            this.buttonSaveToExcel.TabIndex = 0;
            this.buttonSaveToExcel.Text = "Сохранить в Excel";
            this.buttonSaveToExcel.UseVisualStyleBackColor = true;
            this.buttonSaveToExcel.Click += new System.EventHandler(this.ButtonSaveToExcel_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnWarehouse,
            this.columnDetail,
            this.columnCount});
            this.dataGridView.Location = new System.Drawing.Point(5, 46);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(590, 312);
            this.dataGridView.TabIndex = 1;
            // 
            // ColumnWarehouse
            // 
            this.columnWarehouse.HeaderText = "Склад";
            this.columnWarehouse.MinimumWidth = 6;
            this.columnWarehouse.Name = "ColumnWarehouse";
            this.columnWarehouse.ReadOnly = true;
            this.columnWarehouse.Width = 125;
            this.columnWarehouse.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnWarehouse.FillWeight = 100;
            // 
            // ColumnDetail
            // 
            this.columnDetail.HeaderText = "Деталь";
            this.columnDetail.MinimumWidth = 6;
            this.columnDetail.Name = "ColumnDetail";
            this.columnDetail.ReadOnly = true;
            this.columnDetail.Width = 125;
            this.columnDetail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnDetail.FillWeight = 200;
            // 
            // ColumnCount
            // 
            this.columnCount.HeaderText = "Кол-во";
            this.columnCount.MinimumWidth = 6;
            this.columnCount.Name = "ColumnCount";
            this.columnCount.ReadOnly = true;
            this.columnCount.Width = 125;
            // 
            // FormReportWarehouseDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.buttonSaveToExcel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormReportWarehouseDetail";
            this.Text = "Детали по складам";
            this.Load += new System.EventHandler(this.FormReportWarehouseDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSaveToExcel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnWarehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCount;
    }
}