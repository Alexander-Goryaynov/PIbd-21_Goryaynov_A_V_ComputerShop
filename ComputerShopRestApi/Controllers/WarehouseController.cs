using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.Interfaces;
using ComputerShopBusinessLogic.ViewModels;
using ComputerShopDatabaseImplement.Models;
using ComputerShopRestApi.Models;
using DocumentFormat.OpenXml.EMMA;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ComputerShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseLogic _warehouse;
        private readonly IDetailLogic _detail;

        public WarehouseController(IWarehouseLogic warehouse, IDetailLogic detail)
        {
            _warehouse = warehouse;
            _detail = detail;
        }

        [HttpGet]
        public List<WarehouseModel> GetWarehousesList() => _warehouse.GetList()?.Select(rec => Convert(rec)).ToList();
        [HttpGet]
        public List<DetailViewModel> GetDetailsList() => _detail.Read(null)?.ToList();
        [HttpGet]
        public WarehouseModel GetWarehouse(int warehouseId) => Convert(_warehouse.GetElement(warehouseId));
        [HttpPost]
        public void CreateOrUpdateWarehouse(WarehouseBindingModel model)
        {
            if (model.Id.HasValue)
            {
                _warehouse.UpdElement(model);
            }
            else
            {
                _warehouse.AddElement(model);
            }
        }
        [HttpPost]
        public void DeleteWarehouse(WarehouseBindingModel model) => _warehouse.DelElement(model);
        [HttpPost]
        public void FillWarehouse(WarehouseDetailBindingModel model) => _warehouse.FillWarehouse(model);
        private WarehouseModel Convert(WarehouseViewModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new WarehouseModel
            {
                Id = model.Id,
                Name = model.Name,
                WarehouseDetails = model.WarehouseDetails
            };
        }
    }
}