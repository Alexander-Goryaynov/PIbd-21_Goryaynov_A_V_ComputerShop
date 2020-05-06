using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.Interfaces;
using ComputerShopBusinessLogic.ViewModels;
using ComputerShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerShopDatabaseImplement.Implements
{
    public class WarehouseLogic : IWarehouseLogic
    {
        public List<WarehouseViewModel> GetList()
        {
            using (var context = new ComputerShopDatabase())
            {
                return context.Warehouses
                .ToList()
                .Select(rec => new WarehouseViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    WarehouseDetails = context.WarehouseDetails.Include(recWD => recWD.Detail)
                    .Where(recWD => recWD.WarehouseId == rec.Id)
                    .Select(x => new WarehouseDetailViewModel
                {
                    Id = x.Id,
                    WarehouseId = x.WarehouseId,
                    DetailId = x.DetailId,
                    DetailName = context.Details.FirstOrDefault(y => y.Id == x.DetailId).DetailName,
                    Count = x.Count
                })
                .ToList()
                })
            .ToList();
            }
        }

        public WarehouseViewModel GetElement(int id)
        {
            using (var context = new ComputerShopDatabase())
            {
                var elem = context.Warehouses.FirstOrDefault(x => x.Id == id);
                if (elem == null)
                {
                    throw new Exception("Элемент не найден");
                }
                else
                {
                    return new WarehouseViewModel
                    {
                        Id = id,
                        Name = elem.Name,
                        WarehouseDetails = context.WarehouseDetails
                        .Include(recWD => recWD.Detail)
                        .Where(recWD => recWD.WarehouseId == elem.Id)
                        .Select(x => new WarehouseDetailViewModel
                        {
                            Id = x.Id,
                            WarehouseId = x.WarehouseId,
                            DetailId = x.DetailId,
                            DetailName = context.Details.FirstOrDefault(y => y.Id == x.DetailId).DetailName,
                            Count = x.Count
                        }).ToList()
                    };
                }
            }
        }

        public void AddElement(WarehouseBindingModel model)
        {
            using (var context = new ComputerShopDatabase())
            {
                var elem = context.Warehouses.FirstOrDefault(x => x.Name == model.WarehouseName);
                if (elem != null)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
                var warehouse = new Warehouse();
                context.Warehouses.Add(warehouse);
                warehouse.Name = model.WarehouseName;
                context.SaveChanges();
            }
        }

        public void UpdElement(WarehouseBindingModel model)
        {
            using (var context = new ComputerShopDatabase())
            {
                var elem = context.Warehouses.FirstOrDefault(rec => rec.Name == model.WarehouseName &&
                    rec.Id != model.Id);
                if (elem != null)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
                var elemToUpdate = context.Warehouses.FirstOrDefault(x => x.Id == model.Id);
                if (elemToUpdate != null)
                {
                    elemToUpdate.Name = model.WarehouseName;
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public void DelElement(int id)
        {
            using (var context = new ComputerShopDatabase())
            {
                var elem = context.Warehouses.FirstOrDefault(x => x.Id == id);
                if (elem != null)
                {
                    context.Warehouses.Remove(elem);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public void FillWarehouse(WarehouseDetailBindingModel model)
        {
            using (var context = new ComputerShopDatabase())
            {
                var item = context.WarehouseDetails.FirstOrDefault(x => x.DetailId == model.DetailId &&
                    x.WarehouseId == model.WarehouseId);
                if (item != null)
                {
                    item.Count += model.Count;
                }
                else
                {
                    var elem = new WarehouseDetail();
                    context.WarehouseDetails.Add(elem);
                    elem.WarehouseId = model.WarehouseId;
                    elem.DetailId = model.DetailId;
                    elem.Count = model.Count;
                }
                context.SaveChanges();
            }
        }

        public void DeleteFromWarehouse(int assemblyId, int assembliesCount)
        {
            using (var context = new ComputerShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var assemblyDetails = context.AssemblyDetails.Where(x => x.AssemblyId == assemblyId);
                        if (assemblyDetails.Count() == 0) 
                            return;
                        foreach (var elem in assemblyDetails)
                        {
                            int left = elem.Count * assembliesCount;
                            var warehouseDetails = context.WarehouseDetails.Where(x => x.DetailId == elem.DetailId);
                            int available = warehouseDetails.Sum(x => x.Count);
                            if (available < left) 
                                throw new Exception("Недостаточно деталей на складе");
                            foreach (var rec in warehouseDetails)
                            {
                                int toRemove = left > rec.Count ? rec.Count : left;
                                rec.Count -= toRemove;
                                left -= toRemove;
                                if (left == 0) 
                                    break;
                            }
                        }
                        context.SaveChanges();
                        transaction.Commit();
                        return;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
    }
}
