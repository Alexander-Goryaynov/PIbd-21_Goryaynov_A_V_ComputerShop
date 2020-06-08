using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.HelperModels;
using ComputerShopBusinessLogic.Interfaces;
using ComputerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerShopBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IAssemblyLogic assemblyLogic;
        private readonly IOrderLogic orderLogic;
        public ReportLogic(IAssemblyLogic assemblyLogic, IDetailLogic detailLogic,
            IOrderLogic orderLogic)
        {
            this.assemblyLogic = assemblyLogic;
            this.orderLogic = orderLogic;
        }
        public List<ReportAssemblyDetailViewModel> GetAssemblyDetail()
        {
            var assemblies = assemblyLogic.Read(null);
            var list = new List<ReportAssemblyDetailViewModel>();
            foreach (var assembly in assemblies)
            {
                foreach (var ad in assembly.AssemblyDetails)
                {
                    var record = new ReportAssemblyDetailViewModel
                    {
                        AssemblyName = assembly.AssemblyName,
                        DetailName = ad.Value.Item1,
                        Count = ad.Value.Item2
                    };
                    list.Add(record);
                }
            }
            return list;
        }
        public List<IGrouping<DateTime, OrderViewModel>> GetOrders(ReportBindingModel model)
        {
            var list = orderLogic.Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .GroupBy(rec => rec.DateCreate.Date)
            .OrderBy(rec => rec.Key)
            .ToList();
            return list;
        }
        public void SaveAssembliesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список сборок",
                Assemblies = assemblyLogic.Read(null)
            });
        }
        public void SaveOrdersToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrders(model)
            });
        }

        [Obsolete]
        public void SaveAssemblyDetailsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список деталей по сборкам",
                AssemblyDetails = GetAssemblyDetail()
            });
        }
    }
}
