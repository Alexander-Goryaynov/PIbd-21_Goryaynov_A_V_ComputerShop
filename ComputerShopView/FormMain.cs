using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.BusinessLogic;
using ComputerShopBusinessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity;

namespace ComputerShopView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly MainLogic logic;
        private readonly IOrderLogic orderLogic;
        private readonly ReportLogic reportLogic;
        private readonly WorkModeling work;
        public FormMain(MainLogic logic, IOrderLogic orderLogic, 
            ReportLogic reportLogic, WorkModeling work)
        {
            InitializeComponent();
            this.logic = logic;
            this.orderLogic = orderLogic;
            this.reportLogic = reportLogic;
            this.work = work;
        }
        private void LoadData()
        {
            try
            {
                var list = orderLogic.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[5].FillWeight = 1f;
                    dataGridView.Columns[3].FillWeight = 1f;
                    dataGridView.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[10].Visible = false;
                    dataGridView.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView.Columns[7].FillWeight = 1f;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void деталиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDetails>();
            form.ShowDialog();
        }

        private void сборкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAssemblies>();
            form.ShowDialog();
        }

        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCreateOrder>();
            form.ShowDialog();
            LoadData();
        }

        private void buttonPayOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    logic.PayOrder(new ChangeStatusBindingModel { OrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void складыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormWarehouses>();
            form.ShowDialog();
        }

        private void пополнитьСкладToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormFillWarehouse>();
            form.ShowDialog();
        }
        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    reportLogic.SaveAssembliesToWordFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        private void orderDatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportOrders>();
            form.ShowDialog();
        }

        private void assemblyDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportAssemblyDetails>();
            form.ShowDialog();
        }

        private void списокСкладовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    reportLogic.SaveWarehousesToWordFile(new ReportBindingModel { FileName = dialog.FileName });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void деталиПоСкладамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportWarehouseDetail>();
            form.ShowDialog();
        }

        private void деталиПоСкладамPdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportDetail>();
            form.ShowDialog();
        }
        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormClients>();
            form.ShowDialog();
        }

        private void исполнителиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormImplementers>();
            form.ShowDialog();
        }

        private void запускРаботToolStripMenuItem_Click(object sender, EventArgs e)
        {
            work.DoWork();
        }

        private void исполнителиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormImplementers>();
            form.ShowDialog();
        }

        private void запускРаботToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            work.DoWork();
        }
    }
}
