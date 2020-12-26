using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarbershopMDM.Forms
{
    public partial class AccountantForm : Form
    {
        private readonly int _currentUserId;

        public AccountantForm(int userId)
        {
            InitializeComponent();

            _currentUserId = userId;
        }

        private void AccountantForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.LoginForm.Show();
        }
    }
}
