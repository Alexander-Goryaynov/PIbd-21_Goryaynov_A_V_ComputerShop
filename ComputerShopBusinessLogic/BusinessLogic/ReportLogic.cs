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
        private readonly IAssemblyLogic assemblyLogic;
        private readonly IOrderLogic orderLogic;
        private readonly IWarehouseLogic warehouseLogic;
        public ReportLogic(IAssemblyLogic assemblyLogic,
            IOrderLogic orderLogic, IWarehouseLogic warehouseLogic)
        {
            this.assemblyLogic = assemblyLogic;
            this.orderLogic = orderLogic;
            this.warehouseLogic = warehouseLogic;
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
                        TotalCount = ad.Value.Item2
                    };
                    list.Add(record);
                }
            }
            return list;
        }
        public List<ReportWarehouseDetailViewModel> GetWarehouseDetail()
        {
            var warehouses = warehouseLogic.GetList();
            var list = new List<ReportWarehouseDetailViewModel>();
            foreach (var warehouse in warehouses)
            {
                foreach (var wd in warehouse.WarehouseDetails)
                {
                    var record = new ReportWarehouseDetailViewModel
                    {
                        WarehouseName = warehouse.Name,
                        DetailName = wd.DetailName,
                        Count = wd.Count
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
        public void SaveWarehousesToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список складов",
                Warehouses = warehouseLogic.GetList()
            });
        }

        public void SaveAssemblyDetailToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                Orders = GetOrders(model)
            });
        }

        public void SaveWarehouseDetailsToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список деталей по складам",
                Warehouses = warehouseLogic.GetList()
            });
        }

        [Obsolete]
        public void SaveDetailsToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список деталей",
                AssemblyDetails = null,
                WarehouseDetail = GetWarehouseDetail()
            });
        }

        [Obsolete]
        public void SaveAssembliesToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Детали сборок",
                AssemblyDetails = GetAssemblyDetail()
            });
        }
    }
}
