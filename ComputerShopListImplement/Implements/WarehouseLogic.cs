using System;
using System.Collections.Generic;
using System.Linq;
using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.Interfaces;
using ComputerShopBusinessLogic.ViewModels;
using ComputerShopListImplement.Models;

namespace ComputerShopListImplement.Implements
{
    public class WarehouseLogic : IWarehouseLogic
    {
        private readonly DataListSingleton source;
        public WarehouseLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void AddElement(WarehouseBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id > maxId)
                {
                    maxId = source.Warehouses[i].Id;
                }
                if (source.Warehouses[i].WarehouseName == model.WarehouseName)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
            }
            source.Warehouses.Add(new Warehouse
            {
                Id = maxId + 1,
                WarehouseName = model.WarehouseName
            });
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.WarehouseDetails.Count; ++i)
            {
                if (source.WarehouseDetails[i].WarehouseId == id)
                {
                    source.WarehouseDetails.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id == id)
                {
                    source.Warehouses.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void DeleteFromWarehouse(int assemblyId, int count)
        {
            throw new NotImplementedException();
        }

        public WarehouseViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                var warehouseDetails = new List<WarehouseDetailViewModel>();
                for (int j = 0; j < source.WarehouseDetails.Count; ++j)
                {
                    if (source.WarehouseDetails[j].WarehouseId == source.Warehouses[i].Id)
                    {
                        string detailName = string.Empty;
                        for (int k = 0; k < source.Details.Count; ++k)
                        {
                            if (source.WarehouseDetails[j].DetailId == source.Details[k].Id)
                            {
                                detailName = source.Details[k].DetailName;
                                break;
                            }
                        }
                        warehouseDetails.Add(new WarehouseDetailViewModel
                        {
                            Id = source.WarehouseDetails[j].Id,
                            WarehouseId = source.WarehouseDetails[j].WarehouseId,
                            DetailId = source.WarehouseDetails[j].DetailId,
                            DetailName = detailName,
                            Count = source.WarehouseDetails[j].Count
                        });
                    }
                }
                if (source.Warehouses[i].Id == id)
                {
                    return new WarehouseViewModel
                    {
                        Id = source.Warehouses[i].Id,
                        Name = source.Warehouses[i].WarehouseName,
                        WarehouseDetails = warehouseDetails
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<WarehouseViewModel> GetList()
        {
            var result = new List<WarehouseViewModel>();
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                var warehouseDetails = new List<WarehouseDetailViewModel>();
                for (int j = 0; j < source.WarehouseDetails.Count; ++j)
                {
                    if (source.WarehouseDetails[j].WarehouseId == source.Warehouses[i].Id)
                    {
                        string detailName = string.Empty;
                        for (int k = 0; k < source.Details.Count; ++k)
                        {
                            if (source.WarehouseDetails[j].DetailId ==
                           source.Details[k].Id)
                            {
                                detailName = source.Details[k].DetailName;
                                break;
                            }
                        }
                        warehouseDetails.Add(new WarehouseDetailViewModel
                        {
                            Id = source.WarehouseDetails[j].Id,
                            WarehouseId = source.WarehouseDetails[j].WarehouseId,
                            DetailId = source.WarehouseDetails[j].DetailId,
                            DetailName = detailName,
                            Count = source.WarehouseDetails[j].Count
                        });
                    }
                }
                result.Add(new WarehouseViewModel
                {
                    Id = source.Warehouses[i].Id,
                    Name = source.Warehouses[i].WarehouseName,
                    WarehouseDetails = warehouseDetails
                });
            }
            return result;
        }

        public void UpdElement(WarehouseBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Warehouses[i].WarehouseName == model.WarehouseName &&
                source.Warehouses[i].Id != model.Id)
                {
                    throw new Exception("Уже есть склад с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Warehouses[index].WarehouseName = model.WarehouseName;
        }
        public void FillWarehouse(WarehouseDetailBindingModel model)
        {
            var item = source.WarehouseDetails.FirstOrDefault(x => x.DetailId == model.DetailId
                    && x.WarehouseId == model.WarehouseId);

            if (item != null)
            {
                item.Count += model.Count;
            }
            else
            {
                int maxId = source.WarehouseDetails.Count > 0 ?
                    source.WarehouseDetails.Max(rec => rec.Id) : 0;
                source.WarehouseDetails.Add(new WarehouseDetail
                {
                    Id = maxId + 1,
                    WarehouseId = model.WarehouseId,
                    DetailId = model.DetailId,
                    Count = model.Count
                });
            }
        }
    }
}
