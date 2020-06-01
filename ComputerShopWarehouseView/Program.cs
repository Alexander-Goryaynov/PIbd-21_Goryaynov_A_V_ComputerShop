using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerShopWarehouseView
{
    static class Program
    {
        public static bool IsLogined { get; set; }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            APIWarehouse.Connect();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = new FormAuthorization();
            form.ShowDialog();
            if (IsLogined)
            {
                Application.Run(new FormMain());
            }
        }
    }
}
