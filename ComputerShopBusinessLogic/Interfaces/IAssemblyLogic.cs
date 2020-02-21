using System;
using System.Collections.Generic;
using System.Text;
using ComputerShopBusinessLogic.ViewModels;
using ComputerShopBusinessLogic.BindingModels;

namespace ComputerShopBusinessLogic.Interfaces
{
    public interface IAssemblyLogic
    {        
        List<AssemblyViewModel> Read(AssemblyBindingModel model);
        void CreateOrUpdate(AssemblyBindingModel model);
        void Delete(AssemblyBindingModel model);        
    }
}
