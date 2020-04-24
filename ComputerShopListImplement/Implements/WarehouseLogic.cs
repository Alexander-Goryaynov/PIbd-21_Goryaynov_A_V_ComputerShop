using System;
using System.Collections.Generic;
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

        public bool AreDetailsAvailable(int assemblyId, int count)
        {
            throw new NotImplementedException();
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
                        WarehouseName = source.Warehouses[i].WarehouseName,
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
                    WarehouseName = source.Warehouses[i].WarehouseName,
                    WarehouseDetails = warehouseDetails
                });
            }
            return result;
        }

        public void FillWarehouse(WarehouseDetailBindingModel model)
        {
            int foundItemIndex = -1;
            for (int i = 0; i < source.WarehouseDetails.Count; ++i)
            {
                if (source.WarehouseDetails[i].DetailId == model.DetailId
                    && source.WarehouseDetails[i].WarehouseId == model.WarehouseId)
                {
                    foundItemIndex = i;
                    break;
                }
            }
            if (foundItemIndex != -1)
            {
                source.WarehouseDetails[foundItemIndex].Count =
                    source.WarehouseDetails[foundItemIndex].Count + model.Count;
            }
            else
            {
                int maxId = 0;
                for (int i = 0; i < source.WarehouseDetails.Count; ++i)
                {
                    if (source.WarehouseDetails[i].Id > maxId)
                    {
                        maxId = source.WarehouseDetails[i].Id;
                    }
                }
                source.WarehouseDetails.Add(new WarehouseDetail
                {
                    Id = maxId + 1,
                    WarehouseId = model.WarehouseId,
                    DetailId = model.DetailId,
                    Count = model.Count
                });
            }
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
            int index = -1;
            for (int i = 0; i < source.WarehouseDetails.Count; i++)
            {
                if (source.WarehouseDetails[i].DetailId == model.DetailId &&
                    source.WarehouseDetails[i].WarehouseId == model.WarehouseId)
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
            {
                source.WarehouseDetails[index].Count += model.Count;
            }
            else
            {
                int maxId = 0;
                for (int i = 0; i < source.WarehouseDetails.Count; i++)
                {
                    if (source.WarehouseDetails[i].Id > maxId)
                    {
                        maxId = source.WarehouseDetails[i].Id;
                    }
                }
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
