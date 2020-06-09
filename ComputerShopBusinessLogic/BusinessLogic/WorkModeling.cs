using ComputerShopBusinessLogic.BusinessLogic;
using ComputerShopBusinessLogic.Enums;
using ComputerShopBusinessLogic.Interfaces;
using ComputerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ComputerShopBusinessLogic.BindingModels
{
    public class WorkModeling
    {
        private readonly IImplementerLogic implementerLogic;
        private readonly IOrderLogic orderLogic;
        private readonly MainLogic mainLogic;
        private readonly Random rnd;
        public WorkModeling(IImplementerLogic implementerLogic, IOrderLogic orderLogic,
            MainLogic mainLogic)
        {
            this.implementerLogic = implementerLogic;
            this.orderLogic = orderLogic;
            this.mainLogic = mainLogic;
            rnd = new Random(1000);
        }
        public void DoWork()
        {
            var implementers = implementerLogic.Read(null);
            var orders = orderLogic.Read(new OrderBindingModel { AnyFreeOrders = true });
            foreach (var implementer in implementers)
            {
                WorkerWorkAsync(implementer, orders);
            }
        }
        private async void WorkerWorkAsync(ImplementerViewModel implementer, 
            List<OrderViewModel> orders)
        {
            // ищем заказы, которые уже в работе (вдруг исполнителя прервали)
            var runOrders = await Task.Run(() => orderLogic.Read(new OrderBindingModel
            {
                ImplementerId = implementer.Id
            }));
            foreach (var order in runOrders)
            {
                // делаем работу заново
                Thread.Sleep(implementer.WorkingTime * rnd.Next(1, 5) * order.Count);
                mainLogic.FinishOrder(new ChangeStatusBindingModel
                {
                    OrderId = order.Id
                });
                // отдыхаем
                Thread.Sleep(implementer.PauseTime);
            }
            var ordersWithLackOfDetails = orders
               .Where(x => x.Status == OrderStatus.НедостаточноДеталей)
               .Select(x => x)
               .ToList();
            orders.RemoveAll(x => ordersWithLackOfDetails.Contains(x));
            DoWork(implementer, ordersWithLackOfDetails);
            await Task.Run(() =>
            {
                DoWork(implementer, orders);
            });
        }
        private void DoWork(ImplementerViewModel implementer, List<OrderViewModel> orders)
        {

            foreach (var order in orders)
            {
                // пытаемся назначить заказ на исполнителя
                try
                {
                    mainLogic.TakeOrderInWork(new ChangeStatusBindingModel
                    {
                        OrderId = order.Id,
                        ImplementerId = implementer.Id
                    });
                    var isLackOfDetails = orderLogic.Read(new OrderBindingModel
                    {
                        Id = order.Id
                    }).FirstOrDefault().Status == OrderStatus.НедостаточноДеталей;
                    if (isLackOfDetails)
                    {
                        continue;
                    }
                    // делаем работу
                    Thread.Sleep(implementer.WorkingTime * rnd.Next(1, 5) * order.Count);
                    mainLogic.FinishOrder(new ChangeStatusBindingModel
                    {
                        OrderId = order.Id,
                        ImplementerId = implementer.Id
                    });
                    // отдыхаем
                    Thread.Sleep(implementer.PauseTime);
                }
                catch (Exception) { }
            }
        }
    }
}
