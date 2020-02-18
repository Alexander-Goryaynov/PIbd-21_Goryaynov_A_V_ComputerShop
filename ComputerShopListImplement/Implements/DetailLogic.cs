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
        public List<DetailViewModel> GetList()
        {
            List<DetailViewModel> result = new List<DetailViewModel>();
            for (int i = 0; i < source.Details.Count; ++i)
            {
                result.Add(new DetailViewModel
                {
                    Id = source.Details[i].Id,
                    DetailName = source.Details[i].DetailName
                });
            }
            return result;
        }
        public DetailViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Details.Count; ++i)
            {
                if (source.Details[i].Id == id)
                {
                    return new DetailViewModel
                    {
                        Id = source.Details[i].Id,
                        DetailName = source.Details[i].DetailName
                    };
                }
            }
            throw new Exception("Деталь не найдена");
        }
        public void AddElement(DetailBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Details.Count; ++i)
            {
                if (source.Details[i].Id > maxId)
                {
                    maxId = source.Details[i].Id;
                }
                if (source.Details[i].DetailName == model.DetailName)
                {
                    throw new Exception("Уже есть деталь с таким названием");
                }
            }
            source.Details.Add(new Detail
            {
                Id = maxId + 1,
                DetailName = model.DetailName
            });
        }
        public void UpdElement(DetailBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Details.Count; ++i)
            {
                if (source.Details[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Details[i].DetailName == model.DetailName && source.Details[i].Id != model.Id)
                {
                    throw new Exception("Уже есть деталь с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Деталь не найдена");
            }
            source.Details[index].DetailName = model.DetailName;
        }
        public void DelElement(int id)
        {
            for (int i = 0; i < source.Details.Count; ++i)
            {
                if (source.Details[i].Id == id)
                {
                    source.Details.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Деталь не найдена");
        }
    }
}
