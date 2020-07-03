using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ComputerShopWarehouseView
{
    public partial class FormWarehouse : Form
    {
        public int Id { set { id = value; } }
        private int? id;
        private List<WarehouseDetailViewModel> warehouseDetails;
        public FormWarehouse()
        {
            InitializeComponent();
        }
        private void FormWarehouse_Load(object sender, EventArgs e)
        {
            dataGridView.Columns.Add("Id", "Id");
            dataGridView.Columns.Add("Деталь", "Деталь");
            dataGridView.Columns.Add("Количество", "Количество");
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (id.HasValue)
            {
                try
                {
                    WarehouseViewModel view = APIWarehouse.GetRequest<WarehouseViewModel>($"api/warehouse/getwarehouse?warehouseId={id.Value}");
                    if (view != null)
                    {
                        warehouseNameTextBox.Text = view.Name;
                        warehouseDetails = view.WarehouseDetails;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                warehouseDetails = new List<WarehouseDetailViewModel>();
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(warehouseNameTextBox.Text))
            {
                MessageBox.Show("Заполните поле Название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                APIWarehouse.PostRequest("api/warehouse/createorupdatewarehouse", new WarehouseBindingModel
                {
                    Id = id,
                    WarehouseName = warehouseNameTextBox.Text
                });

                MessageBox.Show("Склад создан", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LoadData()
        {
            try
            {
                if (warehouseDetails != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var warehouseDetail in warehouseDetails)
                    {
                        dataGridView.Rows.Add(new object[] { warehouseDetail.Id,
                            warehouseDetail.DetailName, warehouseDetail.Count });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
