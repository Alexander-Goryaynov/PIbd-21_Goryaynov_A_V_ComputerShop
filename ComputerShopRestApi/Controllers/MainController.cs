using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.BusinessLogic;
using ComputerShopBusinessLogic.Interfaces;
using ComputerShopBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ComputerShopRestApi.Models;

namespace ComputerShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;
        private readonly IAssemblyLogic _assembly;
        private readonly MainLogic _main;
        public MainController(IOrderLogic order, IAssemblyLogic assembly, MainLogic main)
        {
            _order = order;
            _assembly = assembly;
            _main = main;
        }
        [HttpGet]
        public List<AssemblyModel> GetAssemblyList() => _assembly.Read(null)?.Select(rec =>
            Convert(rec)).ToList();
        [HttpGet]
        public AssemblyModel GetAssembly(int assemblyId) => Convert(_assembly.Read(
            new AssemblyBindingModel { Id = assemblyId })?[0]);
        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(
            new OrderBindingModel { ClientId = clientId });
        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) =>
            _main.CreateOrder(model);
        private AssemblyModel Convert(AssemblyViewModel model)
        {
            if (model == null) 
                return null;
            return new AssemblyModel
            {
                Id = model.Id,
                AssemblyName = model.AssemblyName,
                Price = model.Price
            };
        }
    }
}