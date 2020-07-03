using ComputerShopBusinessLogic.Enums;
using ComputerShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ComputerShopFileImplement
{
    public class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string DetailFileName = "Detail.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string AssemblyFileName = "Assembly.xml";
        private readonly string AssemblyDetailFileName = "AssemblyDetail.xml";
        private readonly string WarehouseFileName = "Warehouse.xml";
        private readonly string WarehouseDetailFileName = "WarehouseDetail.xml";
        private readonly string ClientFileName = "Client.xml";
        public List<Detail> Details { get; set; }
        public List<Order> Orders { get; set; }
        public List<Assembly> Assemblies { get; set; }
        public List<AssemblyDetail> AssemblyDetails { get; set; }
        public List<Warehouse> Warehouses { get; set; }
        public List<WarehouseDetail> WarehouseDetails { get; set; }
        public List<Client> Clients { get; set; }
        private FileDataListSingleton()
        {
            Details = LoadDetails();
            Orders = LoadOrders();
            Assemblies = LoadAssemblies();
            AssemblyDetails = LoadAssemblyDetails();
            Warehouses = LoadWarehouses();
            WarehouseDetails = LoadWarehouseDetails();
            Clients = LoadClients();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveDetails();
            SaveOrders();
            SaveAssemblies();
            SaveAssemblyDetails();
            SaveWarehouses();
            SaveWarehouseDetails();
            SaveClients();
        }
        private List<Detail> LoadDetails()
        {
            var list = new List<Detail>();
            if (File.Exists(DetailFileName))
            {
                XDocument xDocument = XDocument.Load(DetailFileName);
                var xElements = xDocument.Root.Elements("Detail").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Detail
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        DetailName = elem.Element("DetailName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        AssemblyId = Convert.ToInt32(elem.Element("AssemblyId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        DateImplement = string.IsNullOrEmpty(elem.Element("DateImplement").Value) ? (DateTime?)null : 
                                Convert.ToDateTime(elem.Element("DateImplement").Value),
                    });
                }
            }
            return list;
        }
        private List<Assembly> LoadAssemblies()
        {
            var list = new List<Assembly>();
            if (File.Exists(AssemblyFileName))
            {
                XDocument xDocument = XDocument.Load(AssemblyFileName);
                var xElements = xDocument.Root.Elements("Assembly").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Assembly
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        AssemblyName = elem.Element("AssemblyName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value)
                    });
                }
            }
            return list;
        }
        private List<AssemblyDetail> LoadAssemblyDetails()
        {
            var list = new List<AssemblyDetail>();
            if (File.Exists(AssemblyDetailFileName))
            {
                XDocument xDocument = XDocument.Load(AssemblyDetailFileName);
                var xElements = xDocument.Root.Elements("AssemblyDetail").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new AssemblyDetail
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        AssemblyId = Convert.ToInt32(elem.Element("AssemblyId").Value),
                        DetailId = Convert.ToInt32(elem.Element("DetailId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }
            return list;
        }
        private List<Warehouse> LoadWarehouses()
        {
            var list = new List<Warehouse>();
            if (File.Exists(WarehouseFileName))
            {
                XDocument xDocument = XDocument.Load(WarehouseFileName);
                var xElements = xDocument.Root.Elements("Warehouse").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Warehouse
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        WarehouseName = elem.Element("WarehouseName").Value
                    });
                }
            }
            return list;
        }
        private List<WarehouseDetail> LoadWarehouseDetails()
        {
            var list = new List<WarehouseDetail>();
            if (File.Exists(WarehouseDetailFileName))
            {
                XDocument xDocument = XDocument.Load(WarehouseDetailFileName);
                var xElements = xDocument.Root.Elements("WarehouseDetails").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new WarehouseDetail
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        WarehouseId = Convert.ToInt32(elem.Element("WarehouseId").Value),
                        DetailId = Convert.ToInt32(elem.Element("DetailId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value)
                    });
                }
            }
            return list;
        }
        private List<Client> LoadClients()
        {
            var list = new List<Client>();
            if (File.Exists(ClientFileName))
            {
                XDocument xDocument = XDocument.Load(ClientFileName);
                var xElements = xDocument.Root.Elements("Client").ToList();
                foreach (var element in xElements)
                {
                    list.Add(new Client
                    {
                        Id = Convert.ToInt32(element.Attribute("Id").Value),
                        FIO = element.Element("FIO").Value,
                        Email = element.Element("Email").Value,
                        Password = element.Element("Password").Value
                    });
                }
            }
            return list;
        }
        private void SaveDetails()
        {
            if (Details != null)
            {
                var xElement = new XElement("Details");
                foreach (var detail in Details)
                {
                    xElement.Add(new XElement("Detail",
                    new XAttribute("Id", detail.Id),
                    new XElement("DetailName", detail.DetailName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(DetailFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("AssemblyId", order.AssemblyId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SaveAssemblies()
        {
            if (Assemblies != null)
            {
                var xElement = new XElement("Assemblies");
                foreach (var assembly in Assemblies)
                {
                    xElement.Add(new XElement("Assembly",
                    new XAttribute("Id", assembly.Id),
                    new XElement("AssemblyName", assembly.AssemblyName),
                    new XElement("Price", assembly.Price)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(AssemblyFileName);
            }
        }
        private void SaveAssemblyDetails()
        {
            if (AssemblyDetails != null)
            {
                var xElement = new XElement("AssemblyDetails");
                foreach (var assemblyDetail in AssemblyDetails)
                {
                    xElement.Add(new XElement("AssemblyDetail",
                    new XAttribute("Id", assemblyDetail.Id),
                    new XElement("AssemblyId", assemblyDetail.AssemblyId),
                    new XElement("DetailId", assemblyDetail.DetailId),
                    new XElement("Count", assemblyDetail.Count)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(AssemblyDetailFileName);
            }
        }
        private void SaveWarehouses()
        {
            if (Warehouses != null)
            {
                var xElement = new XElement("Warehouses");
                foreach (var warehouse in Warehouses)
                {
                    xElement.Add(new XElement("Warehouse",
                    new XAttribute("Id", warehouse.Id),
                    new XElement("WarehouseName", warehouse.WarehouseName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(WarehouseFileName);
            }
        }
        private void SaveWarehouseDetails()
        {
            if (WarehouseDetails != null)
            {
                var xElement = new XElement("WarehouseDetails");
                foreach (var warehouseDetail in WarehouseDetails)
                {
                    xElement.Add(new XElement("WarehouseDetails",
                    new XAttribute("Id", warehouseDetail.Id),
                    new XElement("WarehouseId", warehouseDetail.WarehouseId),
                    new XElement("DetailId", warehouseDetail.DetailId),
                    new XElement("Count", warehouseDetail.Count)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(WarehouseDetailFileName);
            }
        }
        private void SaveClients()
        {
            if (Clients != null)
            {
                var xElement = new XElement("Clients");
                foreach (var client in Clients)
                {
                    xElement.Add(new XElement("Client",
                    new XAttribute("Id", client.Id),
                    new XElement("FIO", client.FIO),
                    new XElement("Email", client.Email),
                    new XElement("Password", client.Password)
                    ));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ClientFileName);
            }
        }
    }
}
