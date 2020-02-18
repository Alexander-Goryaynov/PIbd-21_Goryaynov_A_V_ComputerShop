using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopBusinessLogic.Interfaces
{
    public interface IDetailLogic
    {
        List<DetailViewModel> GetList();
        DetailViewModel GetElement(int id);
        void AddElement(DetailBindingModel model);
        void UpdElement(DetailBindingModel model);
        void DelElement(int id);
    }
}
