using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.Interfaces;
using ComputerShopBusinessLogic.ViewModels;
using ComputerShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopListImplement.Implements
{
    public class ImplementerLogic : IImplementerLogic
    {
        private readonly DataListSingleton source;

        public ImplementerLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(ImplementerBindingModel model)
        {
            Implementer temp = model.Id.HasValue ? null : new Implementer
            {
                Id = 1
            };
            foreach (var implementer in source.Implementers)
            {
                if (implementer.FIO == model.FIO && implementer.Id != model.Id)
                {
                    throw new Exception("Уже есть такой исполнитель");
                }
                if (!model.Id.HasValue && implementer.Id >= temp.Id)
                {
                    temp.Id = implementer.Id + 1;
                }
                else if (model.Id.HasValue && implementer.Id == model.Id)
                {
                    temp = implementer;
                }
            }
            if (model.Id.HasValue)
            {
                if (temp == null)
                {
                    throw new Exception("Исполнитель не найден");
                }
                CreateModel(model, temp);
            }
            else
            {
                source.Implementers.Add(CreateModel(model, temp));
            }
        }

        public void Delete(ImplementerBindingModel model)
        {
            for (int i = 0; i < source.Implementers.Count; ++i)
            {
                if (source.Implementers[i].Id == model.Id.Value)
                {
                    source.Implementers.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Исполнитель не найден");
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

        private Implementer CreateModel(ImplementerBindingModel model, Implementer implementer)
        {
            implementer.FIO = model.FIO;
            return implementer;
        }

        private ImplementerViewModel CreateViewModel(Implementer implementer)
        {
            return new ImplementerViewModel
            {
                Id = implementer.Id,
                FIO = implementer.FIO
            };
        }
    }
}
