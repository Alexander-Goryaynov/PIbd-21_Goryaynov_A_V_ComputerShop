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
        public List<Detail> Details { get; set; }
        public List<Order> Orders { get; set; }
        public List<Assembly> Assemblies { get; set; }
        public List<AssemblyDetail> AssemblyDetails { get; set; }
        private FileDataListSingleton()
        {
            Details = LoadDetails();
            Orders = LoadOrders();
            Assemblies = LoadAssemblies();
            AssemblyDetails = LoadAssemblyDetails();
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
        private void SaveDetails()
        {
            if (Details != null)
            {
                var xElement = new XElement("Details");
                foreach (var Detail in Details)
                {
                    xElement.Add(new XElement("Detail",
                    new XAttribute("Id", Detail.Id),
                    new XElement("DetailName", Detail.DetailName)));
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
    }
}
