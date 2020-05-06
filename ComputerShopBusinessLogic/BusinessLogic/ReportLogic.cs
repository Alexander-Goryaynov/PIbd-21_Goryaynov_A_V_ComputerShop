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
        private readonly IDetailLogic detailLogic;
        private readonly IAssemblyLogic assemblyLogic;
        private readonly IOrderLogic orderLogic;
        public ReportLogic(IAssemblyLogic assemblyLogic, IDetailLogic detailLogic,
            IOrderLogic orderLogic)
        {
            this.assemblyLogic = assemblyLogic;
            this.detailLogic = detailLogic;
            this.orderLogic = orderLogic;
        }
        public List<ReportAssemblyDetailViewModel> GetAssemblyDetail()
        {
            var details = detailLogic.Read(null);
            var assemblies = assemblyLogic.Read(null);
            var list = new List<ReportAssemblyDetailViewModel>();
            foreach (var detail in details)
            {
                foreach (var assembly in assemblies)
                {
                    if (assembly.AssemblyDetails.ContainsKey(detail.Id))
                    {
                        var record = new ReportAssemblyDetailViewModel
                        {
                            AssemblyName = assembly.AssemblyName,
                            DetailName = detail.DetailName,
                            Count = assembly.AssemblyDetails[detail.Id].Item2
                        };
                        list.Add(record);
                    }
                }
            }
            return list;
        }
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return orderLogic.Read(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                AssemblyName = x.AssemblyName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
            .ToList();
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
