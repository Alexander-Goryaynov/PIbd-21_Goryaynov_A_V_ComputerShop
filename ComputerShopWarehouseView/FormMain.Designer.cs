namespace ComputerShopWarehouseView
{
    partial class FormMain
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateWarehouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeWarehouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FillWarehouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteWarehouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateWarehouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 26);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(776, 412);
            this.dataGridView.TabIndex = 1;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateWarehouseToolStripMenuItem,
            this.ChangeWarehouseToolStripMenuItem,
            this.FillWarehouseToolStripMenuItem,
            this.DeleteWarehouseToolStripMenuItem,
            this.UpdateWarehouseToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            
            this.CreateWarehouseToolStripMenuItem.Name = "CreateWarehouseToolStripMenuItem";
            this.CreateWarehouseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.CreateWarehouseToolStripMenuItem.Text = "Создать склад";
            this.CreateWarehouseToolStripMenuItem.Click += new System.EventHandler(this.CreateWarehouseToolStripMenuItem_Click);
           
            this.ChangeWarehouseToolStripMenuItem.Name = "ChangeWarehouseToolStripMenuItem";
            this.ChangeWarehouseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ChangeWarehouseToolStripMenuItem.Text = "Изменить склад";
            this.ChangeWarehouseToolStripMenuItem.Click += new System.EventHandler(this.ChangeWarehouseToolStripMenuItem_Click);
            
            this.FillWarehouseToolStripMenuItem.Name = "FillWarehouseToolStripMenuItem";
            this.FillWarehouseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.FillWarehouseToolStripMenuItem.Text = "Пополнить склад";
            this.FillWarehouseToolStripMenuItem.Click += new System.EventHandler(this.FillWarehouseToolStripMenuItem_Click);
           
            this.DeleteWarehouseToolStripMenuItem.Name = "DeleteWarehouseToolStripMenuItem";
            this.DeleteWarehouseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.DeleteWarehouseToolStripMenuItem.Text = "Удалить склад";
            this.DeleteWarehouseToolStripMenuItem.Click += new System.EventHandler(this.DeleteWarehouseToolStripMenuItem_Click);
            
            this.UpdateWarehouseToolStripMenuItem.Name = "UpdateWarehouseToolStripMenuItem";
            this.UpdateWarehouseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.UpdateWarehouseToolStripMenuItem.Text = "Обновить список";
            this.UpdateWarehouseToolStripMenuItem.Click += new System.EventHandler(this.UpdateWarehouseToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Склады";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateWarehouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ChangeWarehouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FillWarehouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteWarehouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdateWarehouseToolStripMenuItem;
    }
}