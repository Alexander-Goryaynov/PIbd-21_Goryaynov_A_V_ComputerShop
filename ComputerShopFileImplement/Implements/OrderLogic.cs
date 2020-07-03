﻿using ComputerShopBusinessLogic.BindingModels;
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
            order.Count = model.Count;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            order.Status = model.Status;
            order.Sum = model.Sum;
            order.ClientId = model.ClientId;
        }

        public void Delete(OrderBindingModel model)
        {
            var element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id.Value);
            if (element != null)
            {
                source.Orders.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            return source.Orders
            .Where(rec => model == null || (rec.Id == model.Id && model.Id.HasValue) ||
            (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate >=
            model.DateFrom && rec.DateCreate <= model.DateTo) ||
            (rec.ClientId == model.ClientId))
            .Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                AssemblyId = rec.AssemblyId,
                AssemblyName = source.Assemblies
                .FirstOrDefault(recA => recA.Id == rec.AssemblyId)?.AssemblyName,
                Count = rec.Count,
                ClientId = rec.ClientId,
                DateCreate = rec.DateCreate,
                DateImplement = rec.DateImplement,
                Status = rec.Status,
                Sum = rec.Sum,
                ClientFIO = source.Clients.FirstOrDefault(recC => recC.Id == rec.ClientId)?.FIO,                
             }).ToList();
        }
    }
}
