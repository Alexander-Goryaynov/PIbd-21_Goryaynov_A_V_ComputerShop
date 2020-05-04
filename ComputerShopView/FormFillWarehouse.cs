using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.BusinessLogic;
using ComputerShopBusinessLogic.Interfaces;
using ComputerShopFileImplement.Models;
using ComputerShopListImplement.Implements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace ComputerShopView
{
    public partial class FormFillWarehouse : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IDetailLogic logicD;
        private readonly MainLogic logicM;
        private readonly IWarehouseLogic logicW;
        public FormFillWarehouse(IDetailLogic logicD, MainLogic logicM, IWarehouseLogic logicW)
        {
            InitializeComponent();
            this.logicD = logicD;
            this.logicM = logicM;
            this.logicW = logicW;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните количество", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxWarehouse.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (comboBoxDetail.SelectedValue == null)
            {
                MessageBox.Show("Выберите деталь", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            try
            {
                int warehouseId = Convert.ToInt32(comboBoxWarehouse.SelectedValue);
                int detailId = Convert.ToInt32(comboBoxDetail.SelectedValue);
                int count = Convert.ToInt32(textBoxCount.Text);

                logicM.FillWarehouse(new WarehouseDetailBindingModel
                {
                    WarehouseId = warehouseId,
                    DetailId = detailId,
                    Count = count
                });
                MessageBox.Show("Склад успешно пополнен", "Сообщение",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormFillWarehouse_Load(object sender, EventArgs e)
        {
            try
            {
                var warehouseList = logicW.GetList();
                comboBoxWarehouse.DataSource = warehouseList;
                comboBoxWarehouse.DisplayMember = "WarehouseName";
                comboBoxWarehouse.ValueMember = "Id";
                var detailList = logicD.Read(null);
                comboBoxDetail.DataSource = detailList;
                comboBoxDetail.DisplayMember = "DetailName";
                comboBoxDetail.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }
}
