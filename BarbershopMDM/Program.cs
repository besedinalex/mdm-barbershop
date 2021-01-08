using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BarbershopMDM.Forms;
using BarbershopMDM.Data;
using BarbershopMDM.Data.Repositories;

namespace BarbershopMDM
{
    static class Program
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public static Form LoginForm { get; set; }
        public static int UserId { get; set; }

        [STAThread]
        static void Main()
        {
            using (var db = new DataContext())
            {
                db.Database.Migrate();
            }

            ConfigureServices();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm = new LoginForm();
            Application.Run(LoginForm);
        }

        static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddDbContext<DataContext>();
            services.AddScoped<ISuppliersRepository, SuppliersRepository>();
            services.AddScoped<IConsumablesRepository, ConsumablesRepository>();
            services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
