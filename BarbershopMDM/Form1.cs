using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarbershopMDM
{
    public partial class Form1 : Form
    {
        //private readonly Data.Repositories.ISuppliersRepository _repo;

        public Form1()
        {
            InitializeComponent();
            //_repo = (Data.Repositories.ISuppliersRepository)Program.ServiceProvider.GetService(typeof(Data.Repositories.ISuppliersRepository));
            //_repo.CreateSupplier(new Models.Supplier() { Name = "", OGRN = 13123, ContactNumber = "qq" });
        }
    }
}
