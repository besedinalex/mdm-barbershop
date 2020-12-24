using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BarbershopMDM.Data;
using BarbershopMDM.Data.Repositories;

namespace BarbershopMDM
{
    static class Program
    {
        public static IServiceProvider ServiceProvider { get; set; }

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
            Application.Run(new Form1());
        }

        static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddDbContext<DataContext>();
            services.AddScoped<ISuppliersRepository, SuppliersRepository>();
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
