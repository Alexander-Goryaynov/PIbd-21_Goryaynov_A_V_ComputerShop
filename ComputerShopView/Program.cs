using ComputerShopBusinessLogic.Interfaces;
using ComputerShopListImplement.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            currentContainer.RegisterType<IMainLogic, MainLogic>(
                new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
