using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.Interfaces;
using ComputerShopBusinessLogic.ViewModels;
using ComputerShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerShopFileImplement.Implements
{
    public class WarehouseLogic : IWarehouseLogic
    {
        private readonly FileDataListSingleton source;
        public WarehouseLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<WarehouseViewModel> GetList()
        {
            return source.Warehouses.Select(rec => new WarehouseViewModel
            {
                Id = rec.Id,
                WarehouseName = rec.WarehouseName,
                WarehouseDetails = source.WarehouseDetails.Where(z => z.WarehouseId == rec.Id)
                .Select(x => new WarehouseDetailViewModel
                {
                    Id = x.Id,
                    WarehouseId = x.WarehouseId,
                    DetailId = x.DetailId,
                    DetailName = source.Details.FirstOrDefault(y => y.Id == x.DetailId)?.DetailName,
                    Count = x.Count
                }).ToList()
            }).ToList();
        }
        public WarehouseViewModel GetElement(int id)
        {
            var elem = source.Warehouses.FirstOrDefault(x => x.Id == id);
            if (elem == null)
            {
                throw new Exception("Элемент не найден");
            }
            else
            {
                return new WarehouseViewModel
                {
                    Id = id,
                    WarehouseName = elem.WarehouseName,
                    WarehouseDetails = source.WarehouseDetails.Where(z => z.WarehouseId == elem.Id)
                    .Select(x => new WarehouseDetailViewModel
                    {
                        Id = x.Id,
                        WarehouseId = x.WarehouseId,
                        DetailId = x.DetailId,
                        DetailName = source.Details.FirstOrDefault(y => y.Id == x.DetailId)?.DetailName,
                        Count = x.Count
                    }).ToList()
                };
            }
        }
        public void AddElement(WarehouseBindingModel model)
        {

            var elem = source.Warehouses.FirstOrDefault(x => x.WarehouseName == model.WarehouseName);
            if (elem != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            int maxId = source.Warehouses.Count > 0 ? source.Warehouses.Max(rec => rec.Id) : 0;
            source.Warehouses.Add(new Warehouse
            {
                Id = maxId + 1,
                WarehouseName = model.WarehouseName
            });
        }
        public void UpdElement(WarehouseBindingModel model)
        {
            var elem = source.Warehouses.FirstOrDefault(x =>
                x.WarehouseName == model.WarehouseName && x.Id != model.Id);
            if (elem != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            var elemToUpdate = source.Warehouses.FirstOrDefault(x => x.Id == model.Id);
            if (elemToUpdate != null)
            {
                elemToUpdate.WarehouseName = model.WarehouseName;
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public void DelElement(int id)
        {
            var elem = source.Warehouses.FirstOrDefault(x => x.Id == id);
            if (elem != null)            
                source.Warehouses.Remove(elem);            
            else            
                throw new Exception("Элемент не найден");            
        }
        public void FillWarehouse(WarehouseDetailBindingModel model)
        {
            var item = source.WarehouseDetails.FirstOrDefault(x => x.DetailId == model.DetailId &&
                    x.WarehouseId == model.WarehouseId);
            if (item != null)
            {
                item.Count += model.Count;
            }
            else
            {
                int maxId = source.WarehouseDetails.Count > 0 ? source.WarehouseDetails.Max(rec => rec.Id) : 0;
                source.WarehouseDetails.Add(new WarehouseDetail
                {
                    Id = maxId + 1,
                    WarehouseId = model.WarehouseId,
                    DetailId = model.DetailId,
                    Count = model.Count
                });
            }
        }
        public bool AreDetailsAvailable(int assemblyId, int assembliesCount)
        {
            bool result = true;
            var assemblyDetails = source.AssemblyDetails.Where(x => x.AssemblyId == assemblyId);
            if (assemblyDetails.Count() == 0) 
                return false;
            foreach (var elem in assemblyDetails)
            {
                int count = 0;
                var warehouseDetails = source.WarehouseDetails.FindAll(x => x.DetailId == elem.DetailId);
                foreach (var rec in warehouseDetails)
                {
                    count += rec.Count;
                }
                if (count < elem.Count * assembliesCount) 
                    result = false;
            }
            return result;
        }

        public void DeleteFromWarehouse(int assemblyId, int count)
        {
            var assemblyDetails = source.AssemblyDetails.Where(x => x.AssemblyId == assemblyId);
            if (assemblyDetails.Count() == 0) return;
            foreach (var elem in assemblyDetails)
            {
                int present = elem.Count * count;
                var warehouseDetails = source.WarehouseDetails.FindAll(x => x.DetailId == elem.DetailId);
                foreach (var rec in warehouseDetails)
                {
                    int countToDelete = present > rec.Count ? rec.Count : present;
                    rec.Count -= countToDelete;
                    present -= countToDelete;
                    if (present == 0) break;
                }
            }
            return;
        }
    }
}
