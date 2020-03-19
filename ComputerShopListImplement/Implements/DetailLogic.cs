using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.Interfaces;
using ComputerShopBusinessLogic.ViewModels;
using ComputerShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopListImplement.Implements
{
    public class DetailLogic : IDetailLogic
    {
        private readonly DataListSingleton source;
        public DetailLogic()
        {
            source = DataListSingleton.GetInstance();
        }
        public void CreateOrUpdate(DetailBindingModel model)
        {
            Detail tempDetail = model.Id.HasValue ? null : new Detail { Id = 1 };
            foreach (var detail in source.Details)
            {
                if (detail.DetailName == model.DetailName && detail.Id != model.Id)
                {
                    throw new Exception("Уже есть деталь с таким названием");
                }
                if (!model.Id.HasValue && detail.Id >= tempDetail.Id)
                {
                    tempDetail.Id = detail.Id + 1;
                }
                else if (model.Id.HasValue && detail.Id == model.Id)
                {
                    tempDetail = detail;
                }
            }
            if (model.Id.HasValue)
            {
                if (tempDetail == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempDetail);
            }
            else
            {
                source.Details.Add(CreateModel(model, tempDetail));
            }
        }
        public void Delete(DetailBindingModel model)
        {
            for (int i = 0; i < source.Details.Count; ++i)
            {
                if (source.Details[i].Id == model.Id.Value)
                {
                    source.Details.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Деталь не найдена");
        }
        public List<DetailViewModel> Read(DetailBindingModel model)
        {
            List<DetailViewModel> result = new List<DetailViewModel>();
            foreach (var detail in source.Details)
            {
                if (model != null)
                {
                    if (detail.Id == model.Id)
                    {
                        result.Add(CreateViewModel(detail));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(detail));
            }
            return result;
        }
        private Detail CreateModel(DetailBindingModel model, Detail detail)
        {
            detail.DetailName = model.DetailName;
            return detail;
        }
        private DetailViewModel CreateViewModel(Detail detail)
        {
            return new DetailViewModel
            {
                Id = detail.Id,
                DetailName = detail.DetailName
            };
        }
    }
}
