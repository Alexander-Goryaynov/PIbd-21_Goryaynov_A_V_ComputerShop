using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.BusinessLogic;
using Microsoft.Reporting.WinForms;
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
    public partial class FormReportDetail : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly ReportLogic logic;
        public FormReportDetail(ReportLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        [Obsolete]
        private void ButtonToPdf_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        logic.SaveDetailsToPdfFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
                        });

                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                var dataSource = logic.GetWarehouseDetail();
                ReportDataSource source = new ReportDataSource("DataSetWarehouseDetail", dataSource);
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormReportDetail_Load(object sender, EventArgs e)
        {

        }
    }
}
