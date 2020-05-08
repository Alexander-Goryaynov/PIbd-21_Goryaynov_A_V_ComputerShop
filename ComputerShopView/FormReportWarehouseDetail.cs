using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.BusinessLogic;
using ComputerShopBusinessLogic.Interfaces;
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
    public partial class FormReportWarehouseDetail : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        private readonly IWarehouseLogic warehouseLogic;
        public FormReportWarehouseDetail(ReportLogic logic, IWarehouseLogic warehouseLogic)
        {
            InitializeComponent();
            this.logic = logic;
            this.warehouseLogic = warehouseLogic;
        }

        private void ButtonSaveToExcel_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveWarehouseDetailsToExcelFile(new ReportBindingModel { FileName = dialog.FileName });
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void FormReportWarehouseDetail_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var list = warehouseLogic.GetList();
                if (list != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var warehouse in list)
                    {
                        int sum = 0;
                        dataGridView.Rows.Add(new object[] { warehouse.Name, "", "" });
                        foreach (var detail in warehouse.WarehouseDetails)
                        {
                            dataGridView.Rows.Add(new object[] { "", detail.DetailName, detail.Count });
                            sum += detail.Count;
                        }
                        dataGridView.Rows.Add(new object[] { "Итого", "", sum });
                        dataGridView.Rows.Add(new object[] { });
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
