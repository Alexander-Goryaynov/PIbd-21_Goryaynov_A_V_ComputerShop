using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity;

namespace ComputerShopView
{
    public partial class FormImplementer : Form
    {
        public int? Id { set; get; }
        public string ImplementerFIO { set; get; }
        public int ImplementerWorkTime { set; get; }
        public int ImplementerDelay { set; get; }

        public FormImplementer()
        {
            InitializeComponent();
        }

        private void FormImplementer_Load(object sender, EventArgs e)
        {
            if (ImplementerFIO != null)
            {
                textBoxFIO.Text = ImplementerFIO;
                textBoxWorkingTime.Text = ImplementerWorkTime.ToString();
                textBoxPauseTime.Text = ImplementerDelay.ToString();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxFIO.Text.ToString()) ||
                !string.IsNullOrEmpty(textBoxWorkingTime.Text.ToString()) ||
                !string.IsNullOrEmpty(textBoxPauseTime.Text.ToString()))
            {
                ImplementerFIO = textBoxFIO.Text.ToString();
                ImplementerWorkTime = Convert.ToInt32(textBoxWorkingTime.Text);
                ImplementerDelay = Convert.ToInt32(textBoxPauseTime.Text);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
