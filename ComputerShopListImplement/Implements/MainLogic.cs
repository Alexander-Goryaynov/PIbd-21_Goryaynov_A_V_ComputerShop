using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.Enums;
using ComputerShopBusinessLogic.Interfaces;
using ComputerShopBusinessLogic.ViewModels;
using ComputerShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopListImplement.Implements
{
    public class MainLogic : IMainLogic
    {
        private readonly DataListSingleton source;
        public MainLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<OrderViewModel> GetOrders()
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                string assemblyName = string.Empty;
                for (int j = 0; j < source.Assemblies.Count; ++j)
                {
                    if (source.Assemblies[j].Id == source.Orders[i].AssemblyId)
                    {
                        assemblyName = source.Assemblies[j].AssemblyName;
                        break;
                    }
                }
                result.Add(new OrderViewModel
                {
                    Id = source.Orders[i].Id,
                    AssemblyId = source.Orders[i].AssemblyId,
                    AssemblyName = assemblyName,
                    Count = source.Orders[i].Count,
                    Sum = source.Orders[i].Sum,
                    DateCreate = source.Orders[i].DateCreate,
                    DateImplement = source.Orders[i].DateImplement,
                    Status = source.Orders[i].Status
                });
            }
            return result;
        }
        public void CreateOrder(OrderBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id > maxId)
                {
                    maxId = source.Orders[i].Id;
                }
            }
            source.Orders.Add(new Order
            {
                Id = maxId + 1,
                AssemblyId = model.AssemblyId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Принят
            });
        }
        public void TakeOrderInWork(OrderBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Orders[index].Status != OrderStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            source.Orders[index].Status = OrderStatus.Выполняется;
        }
        public void FinishOrder(OrderBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Orders[index].Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            source.Orders[index].DateImplement = DateTime.Now;
            source.Orders[index].Status = OrderStatus.Готов;
        }
        public void PayOrder(OrderBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Orders[index].Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            source.Orders[index].Status = OrderStatus.Оплачен;
        }

        public void FillWarehouse(WarehouseDetailBindingModel model)
        {
            // проверяем, есть ли такой склад
            int index = -1;
            for (int i = 0; i < source.Warehouses.Count; i++)
            {
                if (source.Warehouses[i].Id == model.WarehouseId)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
                throw new Exception("Склад не найден");

            index = -1;
            for (int i = 0; i < source.Details.Count; i++)
            {
                if (source.Details[i].Id == model.DetailId)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
                throw new Exception("Деталь не найдена");
            WarehouseDetail warehouseDetail = null;
            for (int i = 0; i < source.WarehouseDetails.Count; ++i)
            {
                // ищем на складе самую первую соответствующую запись
                if ((source.WarehouseDetails[i].WarehouseId == model.WarehouseId) &&
                        (source.WarehouseDetails[i].DetailId == model.DetailId))
                {
                    warehouseDetail = source.WarehouseDetails[i];
                    break;
                }
            }
            if (warehouseDetail != null)
            {
                // если нашли, добавляем ещё деталей в запись
                warehouseDetail.Count += model.Count;
            }
            else
            {
                // иначе вычисляем новый Id создаём новую запись
                int maxId = 0;
                for (int i = 0; i < source.WarehouseDetails.Count; ++i)
                {
                    if (source.WarehouseDetails[i].Id > maxId)
                        maxId = source.WarehouseDetails[i].Id;
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
