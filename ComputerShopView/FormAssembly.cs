using ComputerShopBusinessLogic.BindingModels;
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
using ComputerShopBusinessLogic.Interfaces;
using Unity;

namespace ComputerShopView
{
    public partial class FormAssembly : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IAssemblyLogic logic;
        private int? id;
        private List<AssemblyDetailViewModel> AssemblyDetails;
        public FormAssembly(IAssemblyLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAssemblyDetail>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.ModelView != null)
                {
                    if (id.HasValue)
                    {
                        form.ModelView.AssemblyId = id.Value;
                    }
                    AssemblyDetails.Add(form.ModelView);
                }
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormAssemblyDetail>();
                form.ModelView = AssemblyDetails[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    AssemblyDetails[dataGridView.SelectedRows[0].Cells[0].RowIndex] = form.ModelView;
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        AssemblyDetails.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (AssemblyDetails == null || AssemblyDetails.Count == 0)
            {
                MessageBox.Show("Заполните детали", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<AssemblyDetailBindingModel> AssemblyDetailBM = new List<AssemblyDetailBindingModel>();
                for (int i = 0; i < AssemblyDetails.Count; ++i)
                {
                    AssemblyDetailBM.Add(new AssemblyDetailBindingModel
                    {
                        Id = AssemblyDetails[i].Id,
                        AssemblyId = AssemblyDetails[i].AssemblyId,
                        DetailId = AssemblyDetails[i].DetailId,
                        Count = AssemblyDetails[i].Count
                    });
                }
                if (id.HasValue)
                {
                    logic.UpdElement(new AssemblyBindingModel
                    {
                        Id = id.Value,
                        AssemblyName = textBoxName.Text,
                        Price = Convert.ToDecimal(textBoxPrice.Text),
                        AssemblyDetails = AssemblyDetailBM
                    });
                }
                else
                {
                    logic.AddElement(new AssemblyBindingModel
                    {
                        AssemblyName = textBoxName.Text,
                        Price = Convert.ToDecimal(textBoxPrice.Text),
                        AssemblyDetails = AssemblyDetailBM
                    });
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

        private void FormAssembly_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    AssemblyViewModel view = logic.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.AssemblyName;
                        textBoxPrice.Text = view.Price.ToString();
                        AssemblyDetails = view.AssemblyDetails;
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
                AssemblyDetails = new List<AssemblyDetailViewModel>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (AssemblyDetails != null)
                {
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = AssemblyDetails;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
