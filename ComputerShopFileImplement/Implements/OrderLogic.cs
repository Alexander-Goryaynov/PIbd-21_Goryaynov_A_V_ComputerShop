using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.Enums;
using ComputerShopBusinessLogic.Interfaces;
using ComputerShopBusinessLogic.ViewModels;
using ComputerShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerShopFileImplement.Implements
{
    public class OrderLogic : IOrderLogic
    {
        private readonly FileDataListSingleton source;

        public OrderLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(OrderBindingModel model)
        {
            Order order;
            if (model.Id.HasValue)
            {
                order = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (order == null)
                    throw new Exception("Элемент не найден");
            }
            else
            {
                int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0;
                order = new Order { Id = maxId + 1 };
                source.Orders.Add(order);
            }
            order.AssemblyId = model.AssemblyId;
            order.ClientFIO = model.ClientFIO;
            order.ClientId = model.ClientId.Value;
            order.Count = model.Count;
            order.DateCreate = model.DateCreate;
            order.ImplementerFIO = model.ImplementerFIO;
            order.ImplementerId = model.ImplementerId;
            order.DateImplement = model.DateImplement;
            order.Status = model.Status;
            order.Sum = model.Sum;
        }

        public void Delete(OrderBindingModel model)
        {
            Order order = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (order != null)
            {
                source.Orders.Remove(order);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            return source.Orders
                .Where(rec => model == null ||
                model.Id.HasValue && rec.Id == model.Id &&
                rec.ClientId == model.ClientId ||
                (model.DateTo.HasValue && model.DateFrom.HasValue &&
                rec.DateCreate >= model.DateFrom &&
                rec.DateCreate <= model.DateTo) ||
                (model.ClientId.HasValue &&
                rec.ClientId == model.ClientId) ||
                (model.AnyFreeOrders.HasValue && model.AnyFreeOrders.Value &&
                !(rec.ImplementerFIO != null)) ||
                (model.ImplementerId.HasValue &&
                rec.ImplementerId == model.ImplementerId.Value &&
                rec.Status == OrderStatus.Выполняется))
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    AssemblyId = rec.AssemblyId,
                    AssemblyName = source.Assemblies.FirstOrDefault((r) => r.Id == rec.AssemblyId).AssemblyName,
                    ClientFIO = rec.ClientFIO,
                    ClientId = rec.ClientId,
                    ImplementerId = rec.ImplementerId,
                    ImplementerFIO = (!string.IsNullOrEmpty(rec.ImplementerFIO)) ? rec.ImplementerFIO : string.Empty,
                    Count = rec.Count,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement,
                    Status = rec.Status,
                    Sum = rec.Sum
                }).ToList();
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.Count = model.Count;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            order.AssemblyId = model.AssemblyId;
            order.Status = model.Status;
            order.Sum = model.Sum;
            order.ClientId = model.ClientId;
            order.ClientFIO = model.ClientFIO;
            return order;
        }

        private OrderViewModel CreateViewModel(Order order)
        {
            string assemblyName = source.Assemblies.FirstOrDefault(rec =>
                    rec.Id == order.AssemblyId).AssemblyName;
            return new OrderViewModel
            {
                Id = order.Id,
                Count = order.Count,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                AssemblyName = assemblyName,
                AssemblyId = order.AssemblyId,
                Status = order.Status,
                Sum = order.Sum
            };
        }
    }
}
