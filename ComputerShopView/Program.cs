using ComputerShopBusinessLogic.BindingModels;
using ComputerShopBusinessLogic.BusinessLogic;
using ComputerShopBusinessLogic.Interfaces;
using ComputerShopDatabaseImplement.Implements;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace ComputerShopView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }        
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IDetailLogic, DetailLogic>(
                new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IAssemblyLogic, AssemblyLogic>(
                new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderLogic, OrderLogic>(
                new HierarchicalLifetimeManager());
            currentContainer.RegisterType<MainLogic>(
                new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ReportLogic>(
                new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientLogic, ClientLogic>(
                new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IImplementerLogic, ImplementerLogic>(
                new HierarchicalLifetimeManager());
            currentContainer.RegisterType<WorkModeling>(
                new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
