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
                var record = new ReportAssemblyDetailViewModel
                {
                    DetailName = detail.DetailName,
                    Assemblies = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var assembly in assemblies)
                {
                    if (assembly.AssemblyDetails.ContainsKey(detail.Id))
                    {
                        record.Assemblies.Add(new Tuple<string, int>(assembly.AssemblyName,
                            assembly.AssemblyDetails[detail.Id].Item2));
                        record.TotalCount += assembly.AssemblyDetails[detail.Id].Item2;
                    }
                }
                list.Add(record);
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
        public void SaveDetailsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список деталей",
                Details = detailLogic.Read(null)
            });
        }
        public void SaveAssemblyDetailToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список деталей",
                AssemblyDetails = GetAssemblyDetail()
            });
        }

        [Obsolete]
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
    }
}
