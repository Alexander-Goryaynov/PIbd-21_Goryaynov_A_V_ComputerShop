using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.Interfaces;
using ComputerShopBusinessLogic.ViewModels;
using ComputerShopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerShopDatabaseImplement.Implements
{
    public class ImplementerLogic : IImplementerLogic
    {
        public void CreateOrUpdate(ImplementerBindingModel model)
        {
            using (var context = new ComputerShopDatabase())
            {
                Implementer implementer = context.Implementers.FirstOrDefault(rec =>
                        rec.FIO == model.FIO && rec.Id != model.Id);
                if (implementer != null)
                {
                    throw new Exception("Уже есть такой исполнитель");
                }
                if (model.Id.HasValue)
                {
                    implementer = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
                    if (implementer == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                }
                else
                {
                    implementer = new Implementer();
                    context.Implementers.Add(implementer);
                }
                implementer.FIO = model.FIO;
                implementer.WorkingTime = model.WorkingTime;
                implementer.PauseTime = model.PauseTime;
                context.SaveChanges();
            }
        }

        public void Delete(ImplementerBindingModel model)
        {
            using (var context = new ComputerShopDatabase())
            {
                Implementer implementer = context.Implementers.FirstOrDefault(rec => rec.Id == model.Id);

                if (implementer != null)
                {
                    context.Implementers.Remove(implementer);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        public List<ImplementerViewModel> Read(ImplementerBindingModel model)
        {
            using (var context = new ComputerShopDatabase())
            {
                return context.Implementers
                .Where(rec => (model == null) || (rec.Id == model.Id))
                .Select(rec => new ImplementerViewModel
                {
                    Id = rec.Id,
                    FIO = rec.FIO,
                    WorkingTime = rec.WorkingTime,
                    PauseTime = rec.PauseTime
                })
                .ToList();
            }
        }
    }
}
