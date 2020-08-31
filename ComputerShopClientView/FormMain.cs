using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComputerShopBusinessLogic.ViewModels;

namespace ComputerShopClientView
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            LoadList();
        }
        private void UpdateDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormUpdateData();
            form.ShowDialog();
        }

        private void CreateOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormCreateOrder();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadList();
            }
        }

        private void ShowMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormMessages();
            form.ShowDialog();
        }

        private void RefreshOrderListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            try
            {
                dataGridView.DataSource = APIClient.GetRequest<List<OrderViewModel>>(
                        $"api/main/getorders?clientId={Program.Client.Id}");
                dataGridView.Columns[0].Visible = false;
                dataGridView.Columns[1].Visible = false;
                dataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;               
                dataGridView.Columns[4].Visible = false;
                dataGridView.Columns[9].Visible = false;
                dataGridView.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridView.Columns[11].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
