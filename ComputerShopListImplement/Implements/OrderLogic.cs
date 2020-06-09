using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.Enums;
using ComputerShopBusinessLogic.Interfaces;
using ComputerShopBusinessLogic.ViewModels;
using ComputerShopListImplement.Models;
using System;
using System.Collections.Generic;

namespace ComputerShopListImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        private readonly DataListSingleton source;
        public OrderLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(OrderBindingModel model)
        {
            Order tempOrder = model.Id.HasValue ? null : new Order { Id = 1 };
            foreach (var order in source.Orders)
            {                
                if (!model.Id.HasValue && order.Id >= tempOrder.Id)
                {
                    tempOrder.Id = order.Id + 1;
                }
                else if (model.Id.HasValue && order.Id == model.Id)
                {
                    tempOrder = order;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempOrder == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempOrder);
            }
            else
            {
                source.Orders.Add(CreateModel(model, tempOrder));
            }
        }

        public void Delete(OrderBindingModel model)
        {
            for (int i = 0; i < source.Orders.Count; ++i)
            {
                if (source.Orders[i].Id == model.Id.Value)
                {
                    source.Orders.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            List<OrderViewModel> result = new List<OrderViewModel>();
            foreach (var order in source.Orders)
            {
                if (model != null)
                {
                    if (order.Id == model.Id && order.ClientId == model.ClientId)
                    {
                        result.Add(CreateViewModel(order));
                        break;
                    }
                    else if (model.DateFrom.HasValue && model.DateTo.HasValue &&
                         order.DateCreate >= model.DateFrom && order.DateCreate <= model.DateTo)
                    {
                        result.Add(CreateViewModel(order));
                    }
                    else if (model.ClientId.HasValue && order.ClientId == model.ClientId)
                    {
                        result.Add(CreateViewModel(order));
                    }
                    else if (model.AnyFreeOrders.HasValue && model.AnyFreeOrders.Value &&
                        !(model.ImplementerFIO != null))
                    {
                        result.Add(CreateViewModel(order));
                    }
                    else if (model.ImplementerId.HasValue &&
                        order.ImplementerId == model.ImplementerId.Value &&
                        order.Status == OrderStatus.Выполняется)
                    {
                        result.Add(CreateViewModel(order));
                    }
                    else if (model.IsLackOfDetails.HasValue &&
                         model.IsLackOfDetails.Value &&
                         order.Status == OrderStatus.НедостаточноДеталей)
                    {
                        result.Add(CreateViewModel(order));
                        continue;
                    }
                    continue;
                }
                result.Add(CreateViewModel(order));
            }
            return result;
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.Count = model.Count;
            order.ClientId = model.ClientId.Value;
            order.ClientFIO = model.ClientFIO;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            order.AssemblyId = model.AssemblyId;
            order.Status = model.Status;
            order.Sum = model.Sum;
            order.ImplementerId = (int)model.ImplementerId;
            order.ImplementerFIO = model.ImplementerFIO;
            return order;
        }

        private OrderViewModel CreateViewModel(Order order)
        {
            string assemblyName = "";
            foreach (var assembly in source.Assemblies)
            {
                if (assembly.Id == order.AssemblyId)
                {
                    assemblyName = assembly.AssemblyName;
                    break;
                }
            }
            return new OrderViewModel
            {
                Id = order.Id,
                Count = order.Count,
                ClientFIO = order.ClientFIO,
                ClientId = order.ClientId,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                AssemblyName = assemblyName,
                AssemblyId = order.AssemblyId,
                Status = order.Status,
                Sum = order.Sum,
                ImplementerId = order.ImplementerId,
                ImplementerFIO = order.ImplementerFIO,
            };
        }
    }
}
