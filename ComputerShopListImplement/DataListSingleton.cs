﻿using ComputerShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerShopListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Detail> Details { get; set; }
        public List<Order> Orders { get; set; }
        public List<Assembly> Assemblies { get; set; }
        public List<AssemblyDetail> AssemblyDetails { get; set; }
        public List<Warehouse> Warehouses { get; set; }
        public List<WarehouseDetail> WarehouseDetails { get; set; }
        public List<Client> Clients { get; set; }
        public List<Implementer> Implementers { get; set; }
        private DataListSingleton()
        {
            Details = new List<Detail>();
            Orders = new List<Order>();
            Assemblies = new List<Assembly>();
            AssemblyDetails = new List<AssemblyDetail>();
            Warehouses = new List<Warehouse>();
            WarehouseDetails = new List<WarehouseDetail>();
            Clients = new List<Client>();
            Implementers = new List<Implementer>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
