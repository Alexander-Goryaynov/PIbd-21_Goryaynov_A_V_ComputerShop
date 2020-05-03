using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.ViewModels;
using ComputerShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopListImplement.Implements
{
    public class ImplementerLogic
    {
        private readonly DataListSingleton source;

        public ImplementerLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(ImplementerBindingModel model)
        {
            Implementer tempImplementer = new Implementer { Id = 1 };

            bool exists = false;

            foreach (var implementer in source.Implementers)
            {
                if (implementer.Id >= tempImplementer.Id)
                {
                    tempImplementer.Id = implementer.Id + 1;
                }
                else if (implementer.Id == model.Id)
                {
                    tempImplementer = implementer;
                    exists = true;
                    break;
                }
            }
            if (exists)
            {
                CreateModel(model, tempImplementer);
            }
            else
            {
                source.Implementers.Add(CreateModel(model, tempImplementer));
            }
        }

        public void Delete(ImplementerBindingModel model)
        {
            for (int i = 0; i < source.Implementers.Count; ++i)
            {
                if (source.Implementers[i].Id == model.Id)
                {
                    source.Implementers.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<ImplementerViewModel> Read(ImplementerBindingModel model)
        {
            List<ImplementerViewModel> result = new List<ImplementerViewModel>();
            foreach (var implementer in source.Implementers)
            {
                if (model != null)
                {
                    if (implementer.Id == model.Id)
                    {
                        result.Add(CreateViewModel(implementer));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(implementer));
            }
            return result;
        }

        private Implementer CreateModel(ImplementerBindingModel model, Implementer Implementer)
        {
            Implementer.FIO = model.FIO;
            Implementer.WorkingTime = model.WorkingTime;
            Implementer.PauseTime = model.PauseTime;
            return Implementer;
        }

        private ImplementerViewModel CreateViewModel(Implementer Implementer)
        {
            return new ImplementerViewModel
            {
                Id = Implementer.Id,
                FIO = Implementer.FIO,
                WorkingTime = Implementer.WorkingTime,
                PauseTime = Implementer.PauseTime
            };
        }
    }
}
