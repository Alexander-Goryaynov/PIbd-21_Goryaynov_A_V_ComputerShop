namespace ComputerShopWarehouseView
{
    partial class FormFillWarehouse
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.comboBoxDetail = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.labelcount = new System.Windows.Forms.Label();
            this.labelDetail = new System.Windows.Forms.Label();
            this.labelWarehouse = new System.Windows.Forms.Label();
            this.labelWarehouse2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(173, 93);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(88, 26);
            this.ButtonCancel.TabIndex = 11;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(91, 93);
            this.ButtonSave.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(79, 26);
            this.ButtonSave.TabIndex = 10;
            this.ButtonSave.Text = "Сохранить";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            
            this.comboBoxDetail.FormattingEnabled = true;
            this.comboBoxDetail.Location = new System.Drawing.Point(97, 33);
            this.comboBoxDetail.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxDetail.Name = "comboBoxDetail";
            this.comboBoxDetail.Size = new System.Drawing.Size(165, 21);
            this.comboBoxDetail.TabIndex = 9;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(97, 60);
            this.textBoxCount.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(165, 20);
            this.textBoxCount.TabIndex = 8;
            // 
            // labelcount
            // 
            this.labelcount.AutoSize = true;
            this.labelcount.Location = new System.Drawing.Point(8, 63);
            this.labelcount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelcount.Name = "labelcount";
            this.labelcount.Size = new System.Drawing.Size(69, 13);
            this.labelcount.TabIndex = 7;
            this.labelcount.Text = "Количество:";
            
            this.labelDetail.AutoSize = true;
            this.labelDetail.Location = new System.Drawing.Point(9, 36);
            this.labelDetail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDetail.Name = "labelDetail";
            this.labelDetail.Size = new System.Drawing.Size(66, 13);
            this.labelDetail.TabIndex = 6;
            this.labelDetail.Text = "Деталь:";
            
            this.labelWarehouse.AutoSize = true;
            this.labelWarehouse.Location = new System.Drawing.Point(9, 10);
            this.labelWarehouse.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWarehouse.Name = "labelWarehouse";
            this.labelWarehouse.Size = new System.Drawing.Size(41, 13);
            this.labelWarehouse.TabIndex = 12;
            this.labelWarehouse.Text = "Склад:";
             
            this.labelWarehouse2.AutoSize = true;
            this.labelWarehouse2.Location = new System.Drawing.Point(101, 10);
            this.labelWarehouse2.Name = "labelWarehouse2";
            this.labelWarehouse2.Size = new System.Drawing.Size(0, 13);
            this.labelWarehouse2.TabIndex = 13;
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 140);
            this.Controls.Add(this.labelWarehouse2);
            this.Controls.Add(this.labelWarehouse);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.comboBoxDetail);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelcount);
            this.Controls.Add(this.labelDetail);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormFillWarehouse";
            this.Text = "Пополнить склад";
            this.Load += new System.EventHandler(this.FormFillWarehouse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.ComboBox comboBoxDetail;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.Label labelcount;
        private System.Windows.Forms.Label labelDetail;
        private System.Windows.Forms.Label labelWarehouse;
        public System.Windows.Forms.Label labelWarehouse2;
    }
}