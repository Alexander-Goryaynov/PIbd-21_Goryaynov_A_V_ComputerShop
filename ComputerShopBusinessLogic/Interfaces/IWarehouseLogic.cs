using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopBusinessLogic.Interfaces
{
    public interface IWarehouseLogic
    {
        List<WarehouseViewModel> GetList();
        WarehouseViewModel GetElement(int id);
        void AddElement(WarehouseBindingModel model);
        void UpdElement(WarehouseBindingModel model);
        void DelElement(int id);
    }
}
