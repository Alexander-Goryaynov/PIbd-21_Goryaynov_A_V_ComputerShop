using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.Enums;
using ComputerShopBusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopBusinessLogic.BusinessLogic
{
    public class MainLogic
    {
        private readonly IOrderLogic orderLogic;
        private readonly IWarehouseLogic warehouseLogic;
        private readonly object locker = new object();
        public MainLogic(IOrderLogic orderLogic, IWarehouseLogic warehouseLogic)
        {
            this.orderLogic = orderLogic;
            this.warehouseLogic = warehouseLogic;
        }
        public void CreateOrder(CreateOrderBindingModel model)
        {
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                AssemblyId = model.AssemblyId,
                Count = model.Count,
                Sum = model.Sum,
                DateCreate = DateTime.Now,
                Status = OrderStatus.Принят,
                ClientFIO = model.ClientFIO,
                ClientId = model.ClientId
            });            
        }
        public void TakeOrderInWork(ChangeStatusBindingModel model)
        {
            lock (locker)
            {
                var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
                if (order == null)
                {
                    throw new Exception("Не найден заказ");
                }
                if (order.Status != OrderStatus.Принят && order.Status != OrderStatus.НедостаточноДеталей)
                {
                    throw new Exception("Заказ не в статусе \"Принят\" или \"НедостаточноДеталей\"");
                }
                if (order.ImplementerId.HasValue)
                {
                    throw new Exception("У заказа уже есть исполнитель");
                }
                var bookingModel = new OrderBindingModel
                {
                    Id = order.Id,
                    AssemblyId = order.AssemblyId,
                    Count = order.Count,
                    Sum = order.Sum,
                    ClientId = order.ClientId,
                    ClientFIO = order.ClientFIO,
                    DateCreate = order.DateCreate
                };
                try
                {
                    warehouseLogic.DeleteFromWarehouse(order);
                    bookingModel.DateImplement = DateTime.Now;
                    bookingModel.Status = OrderStatus.Выполняется;
                    bookingModel.ImplementerId = model.ImplementerId;
                }
                catch
                {
                    bookingModel.Status = OrderStatus.НедостаточноДеталей;
                }
                orderLogic.CreateOrUpdate(bookingModel);
            }
        }
        public void FinishOrder (ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                AssemblyId = order.AssemblyId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = DateTime.Now,
                Status = OrderStatus.Готов,
                ClientId = order.ClientId,
                ClientFIO = order.ClientFIO,
                ImplementerId = order.ImplementerId,
                ImplementerFIO = order.ImplementerFIO
            });
        }
        public void PayOrder(ChangeStatusBindingModel model)
        {
            var order = orderLogic.Read(new OrderBindingModel { Id = model.OrderId })?[0];
            if (order == null)
            {
                throw new Exception("Не найден заказ");
            }
            if (order.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            orderLogic.CreateOrUpdate(new OrderBindingModel
            {
                Id = order.Id,
                AssemblyId = order.AssemblyId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                Status = OrderStatus.Оплачен,
                ClientId = order.ClientId,
                ClientFIO = order.ClientFIO,
                ImplementerId = order.ImplementerId,
                ImplementerFIO = order.ImplementerFIO
            });
        }
        public void FillWarehouse(WarehouseDetailBindingModel model)
        {
            warehouseLogic.FillWarehouse(model);
        }
    }
}
