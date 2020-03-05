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
    public class DetailLogic : IDetailLogic
    {
        private readonly FileDataListSingleton source;
        public DetailLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(DetailBindingModel model)
        {
            Detail element = source.Details.FirstOrDefault(rec => rec.DetailName == model.DetailName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть деталь с таким названием");
            }
            if (model.Id.HasValue)
            {
                element = source.Details.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Details.Count > 0 ? source.Details.Max(rec => rec.Id) : 0;
                element = new Detail { Id = maxId + 1 };
                source.Details.Add(element);
            }
            element.DetailName = model.DetailName;
        }
        public void Delete(DetailBindingModel model)
        {
            Detail element = source.Details.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Details.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public List<DetailViewModel> Read(DetailBindingModel model)
        {
            return source.Details
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new DetailViewModel
            {
                Id = rec.Id,
                DetailName = rec.DetailName
            })
            .ToList();
        }
    }
}
