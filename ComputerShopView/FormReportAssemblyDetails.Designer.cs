namespace ComputerShopView
{
    partial class FormReportAssemblyDetails
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnDetail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAssembly = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnDetail,
            this.ColumnAssembly,
            this.ColumnCount});
            this.dataGridView.Location = new System.Drawing.Point(12, 56);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(776, 382);
            this.dataGridView.TabIndex = 0;
            // 
            // ColumnDetail
            // 
            this.ColumnDetail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnDetail.HeaderText = "Деталь";
            this.ColumnDetail.Name = "ColumnDetail";
            this.ColumnDetail.ReadOnly = true;
            // 
            // ColumnAssembly
            // 
            this.ColumnAssembly.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnAssembly.HeaderText = "Сборка";
            this.ColumnAssembly.Name = "ColumnAssembly";
            this.ColumnAssembly.ReadOnly = true;
            // 
            // ColumnCount
            // 
            this.ColumnCount.HeaderText = "Количество";
            this.ColumnCount.Name = "ColumnCount";
            this.ColumnCount.ReadOnly = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 12);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(148, 31);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Сохранить в Excel";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // FormReportAssemblyDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormReportAssemblyDetails";
            this.Text = "Детали по сборкам";
            this.Load += new System.EventHandler(this.FormReportAssemblyDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAssembly;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCount;
        private System.Windows.Forms.Button buttonSave;
    }
}