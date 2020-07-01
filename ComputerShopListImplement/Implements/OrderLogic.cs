using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.Enums;
using ComputerShopBusinessLogic.Interfaces;
using ComputerShopBusinessLogic.ViewModels;
using ComputerShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
                if ((model != null) && (order.Id == model.Id) ||
                    (model.DateFrom.HasValue) && (model.DateTo.HasValue) && 
                    (order.DateCreate >= model.DateFrom) && (order.DateCreate <= model.DateTo) ||
                    (model.ClientId.HasValue) && (order.ClientId == model.ClientId) ||
                    (model.AnyFreeOrders.HasValue) && (model.AnyFreeOrders.Value) ||
                    (model.ImplementerId.HasValue) && (order.ImplementerId == model.ImplementerId) &&
                    (order.Status == OrderStatus.Выполняется))
                {                    
                    result.Add(CreateViewModel(order));
                    break;                    
                }
                result.Add(CreateViewModel(order));
            }
            return result;
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            Assembly assembly = null;
            foreach (var a in source.Assemblies)
            {
                if (a.Id == model.AssemblyId)
                {
                    assembly = a;
                    break;
                }
            }
            Client client = null;
            foreach (var c in source.Clients)
            {
                if (c.Id == model.ClientId)
                {
                    client = c;
                    break;
                }
            }
            Implementer implementer = null;
            foreach (var i in source.Implementers)
            {
                if (i.Id == model.ImplementerId)
                {
                    implementer = i;
                    break;
                }
            }
            if (assembly == null || client == null ||
                model.ImplementerId.HasValue && implementer == null)
            {
                throw new Exception("Элемент не найден");
            }
            order.Count = model.Count;
            order.ClientId = model.ClientId.Value;
            order.DateCreate = model.DateCreate;
            order.ImplementerId = (int)model.ImplementerId;
            order.DateImplement = model.DateImplement;
            order.AssemblyId = model.AssemblyId;
            order.Status = model.Status;
            order.Sum = model.Count * assembly.Price;
            return order;
        }

        private OrderViewModel CreateViewModel(Order order)
        {
            Assembly assembly = null;
            foreach (var a in source.Assemblies)
            {
                if (a.Id == order.AssemblyId)
                {
                    assembly = a;
                    break;
                }
            }
            Client client = null;
            foreach (var c in source.Clients)
            {
                if (c.Id == order.ClientId)
                {
                    client = c;
                    break;
                }
            }
            Implementer implementer = null;
            foreach (var i in source.Implementers)
            {
                if (i.Id == order.ImplementerId)
                {
                    implementer = i;
                    break;
                }
            }
            if (assembly == null || client == null ||
                implementer == null)
            {
                throw new Exception("Элемент не найден");
            }
            return new OrderViewModel
            {
                Id = order.Id,
                Count = order.Count,
                ClientFIO = client.FIO,
                ClientId = order.ClientId,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                AssemblyName = assembly.AssemblyName,
                AssemblyId = order.AssemblyId,
                Status = order.Status,
                Sum = order.Sum,
                ImplementerId = order.ImplementerId,
                ImplementerFIO = implementer.FIO,
            };
        }
    }
}
