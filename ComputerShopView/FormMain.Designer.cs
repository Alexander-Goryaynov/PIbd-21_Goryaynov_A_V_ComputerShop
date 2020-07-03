namespace ComputerShopView
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.деталиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сборкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warehousesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assembliesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderDatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assemblyDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warehouseDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfWarehouses = new System.Windows.Forms.ToolStripMenuItem();
            this.FillWarehouseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ButtonСreateOrder = new System.Windows.Forms.Button();
            this.ButtonTakeOrderInWork = new System.Windows.Forms.Button();
            this.ButtonOrderReady = new System.Windows.Forms.Button();
            this.ButtonPayOrder = new System.Windows.Forms.Button();
            this.ButtonRef = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.FillWarehouseToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(906, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.деталиToolStripMenuItem,
            this.сборкиToolStripMenuItem,
            this.warehousesToolStripMenuItem,
            this.clientsToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // деталиToolStripMenuItem
            // 
            this.деталиToolStripMenuItem.Name = "деталиToolStripMenuItem";
            this.деталиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.деталиToolStripMenuItem.Text = "Детали";
            this.деталиToolStripMenuItem.Click += new System.EventHandler(this.деталиToolStripMenuItem_Click);
            // 
            // сборкиToolStripMenuItem
            // 
            this.сборкиToolStripMenuItem.Name = "сборкиToolStripMenuItem";
            this.сборкиToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сборкиToolStripMenuItem.Text = "Сборки";
            this.сборкиToolStripMenuItem.Click += new System.EventHandler(this.сборкиToolStripMenuItem_Click);
            // 
            // warehousesToolStripMenuItem
            // 
            this.warehousesToolStripMenuItem.Name = "warehousesToolStripMenuItem";
            this.warehousesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.warehousesToolStripMenuItem.Text = "Склады";
            this.warehousesToolStripMenuItem.Click += new System.EventHandler(this.складыToolStripMenuItem_Click);
            // 
            // clientsToolStripMenuItem
            // 
            this.clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            this.clientsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clientsToolStripMenuItem.Text = "Клиенты";
            this.clientsToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assembliesToolStripMenuItem,
            this.orderDatesToolStripMenuItem,
            this.assemblyDetailsToolStripMenuItem,
            this.detailsToolStripMenuItem,
            this.warehouseDetailsToolStripMenuItem,
            this.listOfWarehouses});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.reportsToolStripMenuItem.Text = "Отчеты";
            // 
            // assembliesToolStripMenuItem
            // 
            this.assembliesToolStripMenuItem.Name = "assembliesToolStripMenuItem";
            this.assembliesToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.assembliesToolStripMenuItem.Text = "Список сборок";
            this.assembliesToolStripMenuItem.Click += new System.EventHandler(this.сборкиToolStripMenuItem_Click);
            // 
            // orderDatesToolStripMenuItem
            // 
            this.orderDatesToolStripMenuItem.Name = "orderDatesToolStripMenuItem";
            this.orderDatesToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.orderDatesToolStripMenuItem.Text = "Список заказов";
            this.orderDatesToolStripMenuItem.Click += new System.EventHandler(this.orderDatesToolStripMenuItem_Click);
            // 
            // assemblyDetailsToolStripMenuItem
            // 
            this.assemblyDetailsToolStripMenuItem.Name = "assemblyDetailsToolStripMenuItem";
            this.assemblyDetailsToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.assemblyDetailsToolStripMenuItem.Text = "Список деталей заказов";
            this.assemblyDetailsToolStripMenuItem.Click += new System.EventHandler(this.assemblyDetailsToolStripMenuItem_Click);
            // 
            // detailsToolStripMenuItem
            // 
            this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
            this.detailsToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.detailsToolStripMenuItem.Text = "Список деталей";
            this.detailsToolStripMenuItem.Click += new System.EventHandler(this.detailsToolStripMenuItem_Click);
            // 
            // warehouseDetailsToolStripMenuItem
            // 
            this.warehouseDetailsToolStripMenuItem.Name = "warehouseDetailsToolStripMenuItem";
            this.warehouseDetailsToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.warehouseDetailsToolStripMenuItem.Text = "Список деталей по складам";
            this.warehouseDetailsToolStripMenuItem.Click += new System.EventHandler(this.деталиПоСкладамToolStripMenuItem_Click);
            // 
            // listOfWarehouses
            // 
            this.listOfWarehouses.Name = "listOfWarehouses";
            this.listOfWarehouses.Size = new System.Drawing.Size(227, 22);
            this.listOfWarehouses.Text = "Список складов";
            this.listOfWarehouses.Click += new System.EventHandler(this.списокСкладовToolStripMenuItem_Click);
            // 
            // FillWarehouseToolStripMenuItem
            // 
            this.FillWarehouseToolStripMenuItem.Name = "FillWarehouseToolStripMenuItem";
            this.FillWarehouseToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.FillWarehouseToolStripMenuItem.Text = "Пополнить склад";
            this.FillWarehouseToolStripMenuItem.Click += new System.EventHandler(this.пополнитьСкладToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(2, 23);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(738, 307);
            this.dataGridView.TabIndex = 1;
            // 
            // ButtonСreateOrder
            // 
            this.ButtonСreateOrder.Location = new System.Drawing.Point(757, 45);
            this.ButtonСreateOrder.Name = "ButtonСreateOrder";
            this.ButtonСreateOrder.Size = new System.Drawing.Size(126, 29);
            this.ButtonСreateOrder.TabIndex = 2;
            this.ButtonСreateOrder.Text = "Создать заказ";
            this.ButtonСreateOrder.UseVisualStyleBackColor = true;
            this.ButtonСreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // ButtonTakeOrderInWork
            // 
            this.ButtonTakeOrderInWork.Location = new System.Drawing.Point(757, 89);
            this.ButtonTakeOrderInWork.Name = "ButtonTakeOrderInWork";
            this.ButtonTakeOrderInWork.Size = new System.Drawing.Size(126, 40);
            this.ButtonTakeOrderInWork.TabIndex = 3;
            this.ButtonTakeOrderInWork.Text = "Отдать на выполнение";
            this.ButtonTakeOrderInWork.UseVisualStyleBackColor = true;
            this.ButtonTakeOrderInWork.Click += new System.EventHandler(this.buttonTakeOrderInWork_Click);
            // 
            // ButtonOrderReady
            // 
            this.ButtonOrderReady.Location = new System.Drawing.Point(757, 144);
            this.ButtonOrderReady.Name = "ButtonOrderReady";
            this.ButtonOrderReady.Size = new System.Drawing.Size(126, 29);
            this.ButtonOrderReady.TabIndex = 4;
            this.ButtonOrderReady.Text = "Заказ готов";
            this.ButtonOrderReady.UseVisualStyleBackColor = true;
            this.ButtonOrderReady.Click += new System.EventHandler(this.buttonOrderReady_Click);
            // 
            // ButtonPayOrder
            // 
            this.ButtonPayOrder.Location = new System.Drawing.Point(757, 189);
            this.ButtonPayOrder.Name = "ButtonPayOrder";
            this.ButtonPayOrder.Size = new System.Drawing.Size(126, 29);
            this.ButtonPayOrder.TabIndex = 5;
            this.ButtonPayOrder.Text = "Заказ оплачен";
            this.ButtonPayOrder.UseVisualStyleBackColor = true;
            this.ButtonPayOrder.Click += new System.EventHandler(this.buttonPayOrder_Click);
            // 
            // ButtonRef
            // 
            this.ButtonRef.Location = new System.Drawing.Point(757, 238);
            this.ButtonRef.Name = "ButtonRef";
            this.ButtonRef.Size = new System.Drawing.Size(126, 29);
            this.ButtonRef.TabIndex = 6;
            this.ButtonRef.Text = "Обновить список";
            this.ButtonRef.UseVisualStyleBackColor = true;
            this.ButtonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 337);
            this.Controls.Add(this.ButtonRef);
            this.Controls.Add(this.ButtonPayOrder);
            this.Controls.Add(this.ButtonOrderReady);
            this.Controls.Add(this.ButtonTakeOrderInWork);
            this.Controls.Add(this.ButtonСreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "Компьютерный магазин";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem деталиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сборкиToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button ButtonСreateOrder;
        private System.Windows.Forms.Button ButtonTakeOrderInWork;
        private System.Windows.Forms.Button ButtonOrderReady;
        private System.Windows.Forms.Button ButtonPayOrder;
        private System.Windows.Forms.Button ButtonRef;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assembliesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orderDatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assemblyDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warehousesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FillWarehouseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warehouseDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listOfWarehouses;
    }
}