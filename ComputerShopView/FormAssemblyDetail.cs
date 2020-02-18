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
    public partial class FormAssemblyDetail : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public AssemblyDetailViewModel ModelView { get; set; }
        private readonly IDetailLogic logic;
        public FormAssemblyDetail(IDetailLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxDetail.SelectedValue == null)
            {
                MessageBox.Show("Выберите деталь", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (ModelView == null)
                {
                    ModelView = new AssemblyDetailViewModel
                    {
                        DetailId = Convert.ToInt32(comboBoxDetail.SelectedValue),
                        DetailName = comboBoxDetail.Text,
                        Count = Convert.ToInt32(textBoxCount.Text)
                    };
                }
                else
                {
                    ModelView.Count = Convert.ToInt32(textBoxCount.Text);
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormAssemblyDetail_Load(object sender, EventArgs e)
        {
            try
            {
                List<DetailViewModel> list = logic.GetList();
                if (list != null)
                {
                    comboBoxDetail.DisplayMember = "DetailName";
                    comboBoxDetail.ValueMember = "Id";
                    comboBoxDetail.DataSource = list;
                    comboBoxDetail.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (ModelView != null)
            {
                comboBoxDetail.Enabled = false;
                comboBoxDetail.SelectedValue = ModelView.DetailId;
                textBoxCount.Text = ModelView.Count.ToString();
            }
        }
    }
}
