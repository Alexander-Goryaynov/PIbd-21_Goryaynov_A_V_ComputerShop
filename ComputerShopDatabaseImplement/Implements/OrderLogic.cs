using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.Enums;
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
    public class OrderLogic : IOrderLogic
    {
        public void CreateOrUpdate(OrderBindingModel model)
        {
            using (var context = new ComputerShopDatabase())
            {
                Order element;
                if (model.Id.HasValue)
                {
                    element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    element = new Order();
                    context.Orders.Add(element);
                }
                element.AssemblyId = model.AssemblyId == 0 ? element.AssemblyId : model.AssemblyId;
                element.ClientId = model.ClientId.Value;
                element.ImplementerId = model.ImplementerId;
                element.Count = model.Count;
                element.Sum = model.Sum;
                element.Status = model.Status;
                element.DateCreate = model.DateCreate;
                element.DateImplement = model.DateImplement;
                context.SaveChanges();
            }
        }

        public void Delete(OrderBindingModel model)
        {
            using (var context = new ComputerShopDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Order order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                        if (order != null)
                        {
                            context.Orders.Remove(order);
                        }
                        else
                        {
                            throw new Exception("Элемент не найден");
                        }
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<OrderViewModel> Read(OrderBindingModel model)
        {
            using (var context = new ComputerShopDatabase())
            {
                return context.Orders
                    .Where(rec => model == null || rec.Id == model.Id || 
                    (rec.DateCreate >= model.DateFrom) && (rec.DateCreate <= model.DateTo) ||
                    (model.ClientId == rec.ClientId) || (model.AnyFreeOrders.HasValue &&
                    model.AnyFreeOrders.Value && !rec.ImplementerId.HasValue) ||
                    (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId.Value &&
                    rec.Status == OrderStatus.Выполняется))
                    .Include(order => order.Assembly) 
                    .Include(rec => rec.Implementer)
                    .Select(rec => new OrderViewModel()
                    {
                        Id = rec.Id,
                        AssemblyId = rec.AssemblyId,
                        AssemblyName = rec.Assembly.Name,
                        ClientFIO = rec.Client.FIO,
                        ClientId = rec.ClientId,
                        Count = rec.Count,
                        DateCreate = rec.DateCreate,
                        DateImplement = rec.DateImplement,
                        Status = rec.Status,
                        Sum = rec.Sum,
                        ImplementerId = rec.ImplementerId,
                        ImplementerFIO = rec.Implementer.FIO
                    }).ToList();
            }
        }
    }
}
