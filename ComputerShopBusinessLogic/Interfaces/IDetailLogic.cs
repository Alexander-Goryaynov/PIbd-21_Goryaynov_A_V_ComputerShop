using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopBusinessLogic.Interfaces
{
    public interface IDetailLogic
    {
        List<DetailViewModel> Read(DetailBindingModel model);
        void CreateOrUpdate(DetailBindingModel model);
        void Delete(DetailBindingModel model);
    }
}
