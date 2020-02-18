using System;
using System.Collections.Generic;
using System.Text;
using ComputerShopBusinessLogic.ViewModels;
using ComputerShopBusinessLogic.BindingModels;

namespace ComputerShopBusinessLogic.Interfaces
{
    public interface IAssemblyLogic
    {
        List<AssemblyViewModel> GetList();
        AssemblyViewModel GetElement(int id);
        void AddElement(AssemblyBindingModel model);
        void UpdElement(AssemblyBindingModel model);
        void DelElement(int id);
    }
}
