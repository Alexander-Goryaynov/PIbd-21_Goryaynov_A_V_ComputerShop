using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity;

namespace ComputerShopView
{
    public partial class FormImplementers : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IImplementerLogic logic;

        public FormImplementers(IImplementerLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormImplementers_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dataGridView.DataSource = logic.Read(null);
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var form = Container.Resolve<FormImplementer>();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    logic.CreateOrUpdate(new ImplementerBindingModel()
                    {
                        FIO = form.ImplementerFIO,
                        WorkingTime = form.ImplementerWorkTime,
                        PauseTime = form.ImplementerDelay
                    });
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count == 1)
                {
                    var form = Container.Resolve<FormImplementer>();
                    form.ImplementerFIO = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
                    form.ImplementerWorkTime = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[2].Value);
                    form.ImplementerDelay = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[3].Value);
                    form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        logic.CreateOrUpdate(new ImplementerBindingModel()
                        {
                            Id = form.Id,
                            FIO = form.ImplementerFIO,
                            WorkingTime = form.ImplementerWorkTime,
                            PauseTime = form.ImplementerDelay
                        });
                        LoadData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView.SelectedRows.Count == 1)
                {
                    logic.Delete(new ImplementerBindingModel()
                    {
                        Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value),
                        FIO = dataGridView.SelectedRows[0].Cells[1].Value.ToString(),
                        WorkingTime = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[2].Value),
                        PauseTime = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[3].Value)
                    });
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
