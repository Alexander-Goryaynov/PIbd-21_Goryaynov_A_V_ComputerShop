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
        private Dictionary<int, (string, int)> assemblyDetails;
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
                if (assemblyDetails.ContainsKey(form.Id))
                {
                    assemblyDetails[form.Id] = (form.ComponentName, form.Count);
                }
                else
                {
                    assemblyDetails.Add(form.Id, (form.ComponentName, form.Count));
                }
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormAssemblyDetail>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = assemblyDetails[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    assemblyDetails[form.Id] = (form.ComponentName, form.Count);
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
                        assemblyDetails.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
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
            if (assemblyDetails == null || assemblyDetails.Count == 0)
            {
                MessageBox.Show("Заполните детали", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new AssemblyBindingModel
                {
                    Id = id,
                    AssemblyName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    AssemblyDetails = assemblyDetails
                });
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
                    AssemblyViewModel view = logic.Read(new AssemblyBindingModel {
                        Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.AssemblyName;
                        textBoxPrice.Text = view.Price.ToString();
                        assemblyDetails = view.AssemblyDetails;
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
                assemblyDetails = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            dataGridView.Columns.Clear();
            dataGridView.Columns.Add("Id", "Id");
            dataGridView.Columns.Add("MaterialName", "Материал");
            dataGridView.Columns.Add("Count", "Количество");
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            try
            {
                if (assemblyDetails != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var ad in assemblyDetails)
                    {
                        dataGridView.Rows.Add(new object[] { ad.Key, ad.Value.Item1, ad.Value.Item2 });
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
