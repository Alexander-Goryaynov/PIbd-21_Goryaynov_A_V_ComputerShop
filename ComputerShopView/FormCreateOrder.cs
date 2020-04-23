using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.BusinessLogic;
using ComputerShopBusinessLogic.Interfaces;
using ComputerShopBusinessLogic.ViewModels;
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
    public partial class FormCreateOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IAssemblyLogic logicA;
        private readonly MainLogic logicM;
        private readonly IClientLogic logicC;
        public FormCreateOrder(IAssemblyLogic logicA, MainLogic logicM, IClientLogic logicC)
        {
            InitializeComponent();
            this.logicA = logicA;
            this.logicM = logicM;
            this.logicC = logicC;
        }

        private void comboBoxAssembly_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void CalcSum()
        {
            if (comboBoxAssembly.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxAssembly.SelectedValue);
                    AssemblyViewModel assembly = logicA.Read(new AssemblyBindingModel { Id = id })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * assembly?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                List<AssemblyViewModel> assembliesList = logicA.Read(null);
                if (assembliesList != null)
                {
                    comboBoxAssembly.DisplayMember = "AssemblyName";
                    comboBoxAssembly.ValueMember = "Id";
                    comboBoxAssembly.DataSource = assembliesList;
                    comboBoxAssembly.SelectedItem = null;
                }
                List<ClientViewModel> clientsList = logicC.Read(null);
                if (clientsList != null)
                {
                    comboBoxClient.DisplayMember = "FIO";
                    comboBoxClient.DataSource = clientsList;
                    comboBoxClient.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxAssembly.SelectedValue == null)
            {
                MessageBox.Show("Выберите сборку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxClient.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logicM.CreateOrder(new CreateOrderBindingModel
                {
                    AssemblyId = Convert.ToInt32(comboBoxAssembly.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text),
                    ClientId = (comboBoxClient.SelectedItem as ClientViewModel).Id,
                    ClientFIO = (comboBoxClient.SelectedItem as ClientViewModel).FIO
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
    }
}
