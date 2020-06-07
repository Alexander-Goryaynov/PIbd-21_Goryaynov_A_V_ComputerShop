using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.Interfaces;
using ComputerShopBusinessLogic.ViewModels;
using ComputerShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerShopFileImplement.Implements
{
    public class ImplementerLogic : IImplementerLogic
    {
        private readonly FileDataListSingleton source;

        public ImplementerLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(ImplementerBindingModel model)
        {
            Implementer tmp = source.Implementers.FirstOrDefault(rec =>
                    rec.FIO == model.FIO && rec.Id != model.Id);
            if (tmp != null)
            {
                throw new Exception("Уже есть такой исполнитель");
            }
            if (model.Id.HasValue)
            {
                tmp = source.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
                if (tmp == null)
                {
                    throw new Exception("Исполнитель не найден");
                }
            }
            else
            {
                int maxId = source.Implementers.Count > 0 ? source.Implementers.Max(rec => rec.Id) : 0;
                tmp = new Implementer { Id = maxId + 1 };
                source.Implementers.Add(tmp);
            }
            tmp.FIO = model.FIO;
        }

        public void Delete(ImplementerBindingModel model)
        {
            Implementer implementer = source.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
            if (implementer != null)
            {
                source.Implementers.Remove(implementer);
            }
            else
            {
                throw new Exception("Исполнитель не найден");
            }
        }

        public List<ImplementerViewModel> Read(ImplementerBindingModel model)
        {
            return source.Implementers
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new ImplementerViewModel
            {
                Id = rec.Id,
                FIO = rec.FIO
            })
            .ToList();
        }
    }
}
