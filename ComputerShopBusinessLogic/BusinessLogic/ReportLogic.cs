using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.HelperModels;
using ComputerShopBusinessLogic.Interfaces;
using ComputerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputerShopBusinessLogic.BusinessLogic
{
    public class ReportLogic
    {
        private readonly IDetailLogic detailLogic;
        private readonly IAssemblyLogic assemblyLogic;
        private readonly IOrderLogic orderLogic;
        private readonly IWarehouseLogic warehouseLogic;
        public ReportLogic(IAssemblyLogic assemblyLogic, IDetailLogic detailLogic,
            IOrderLogic orderLogic, IWarehouseLogic warehouseLogic)
        {
            this.assemblyLogic = assemblyLogic;
            this.detailLogic = detailLogic;
            this.orderLogic = orderLogic;
            this.warehouseLogic = warehouseLogic;
        }

        public List<ReportAssemblyDetailViewModel> GetAssemblyDetail()
        {
            var details = detailLogic.Read(null);
            var assemblies = assemblyLogic.Read(null);
            var list = new List<ReportAssemblyDetailViewModel>();
            foreach (var assembly in assemblies)
            {
                var record = new ReportAssemblyDetailViewModel
                {
                    AssemblyName = assembly.AssemblyName,
                    Details = new List<(string, int)>(),
                    TotalCount = 0
                };
                foreach (var detail in details)
                {
                    if (assembly.AssemblyDetails.ContainsKey(detail.Id))
                    {
                        record.Details.Add((detail.DetailName,
                            assembly.AssemblyDetails[detail.Id].Item2));
                        record.TotalCount +=
                            assembly.AssemblyDetails[detail.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }
        public List<ReportWarehouseDetailViewModel> GetWarehouseDetail()
        {
            var details = detailLogic.Read(null);
            var warehouses = warehouseLogic.GetList();
            var list = new List<ReportWarehouseDetailViewModel>();
            foreach (var warehouse in warehouses)
            {
                var record = new ReportWarehouseDetailViewModel
                {
                    WarehouseName = warehouse.Name,
                    Details = new List<(string, int)>(),
                    TotalCount = 0
                };
                foreach (var detail in details)
                {
                    var warehouseDetails = warehouse.WarehouseDetails.
                        Find(rec => rec.DetailId == detail.Id);
                    if (warehouseDetails != null)
                    {
                        record.Details.Add((detail.DetailName, warehouseDetails.Count));
                        record.TotalCount += warehouseDetails.Count;
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
        public List<ReportDetailsViewModel> GetFlowers()
        {
            List<ReportDetailsViewModel> result = new List<ReportDetailsViewModel>();
            var warehouses = warehouseLogic.GetList();
            foreach (var warehouse in warehouses)
            {
                var warehouseDetails = warehouse.WarehouseDetails;
                foreach (var wd in warehouseDetails)
                {
                    result.Add(new ReportDetailsViewModel
                    {
                        WarehouseName = warehouse.Name,
                        DetailName = detailLogic.Read(
                            new DetailBindingModel { Id = wd.DetailId })[0].DetailName,
                        Count = wd.Count
                    });
                }
            }
            return result.OrderBy(rec => rec.DetailName).ToList();
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
        public void SaveWarehousesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список складов",
                Warehouses = warehouseLogic.GetList()
            });
        }
        public void SaveWarehouseDetailToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список складов",
                WarehouseDetails = GetWarehouseDetail()
            });
        }
        public void SaveAssemblyDetailToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список деталей по сборкам",
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

        [Obsolete]
        public void SaveFlowersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список цветов",
                Details = GetFlowers()
            });
        }
    }
}
