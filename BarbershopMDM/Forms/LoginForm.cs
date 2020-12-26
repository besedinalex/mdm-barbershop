using System;
using System.Windows.Forms;
using BarbershopMDM.Data.Repositories;

namespace BarbershopMDM.Forms
{
    public partial class LoginForm : Form
    {
        private readonly IEmployeesRepository _employeesRepo;

        public LoginForm()
        {
            _employeesRepo = (IEmployeesRepository)Program.ServiceProvider.GetService(typeof(IEmployeesRepository));
            InitializeComponent();
        }

        private async void ButtonEnter_Click(object sender, EventArgs e)
        {
            var login = textBoxLogin.Text;
            var password = textBoxPassword.Text;

            if (login == "administrator")
            {
                if (password == "adminaccesspassword")
                {
                    Hide();
                    new AdminForm().ShowDialog();
                    return;
                }
                MessageBox.Show("Неверный логин или пароль.");
                return;
            }

            var user = await _employeesRepo.GetEmployee(login);
            if (user == null || user.Password != password)
            {
                MessageBox.Show("Неверный логин или пароль.");
                return;
            }

            switch (user.Role)
            {
                case "accountant":
                    Hide();
                    new AccountantForm(user.Id).ShowDialog();
                    break;
                case "manager":
                    Hide();
                    new ManagerForm().ShowDialog();
                    break;
                default:
                    MessageBox.Show("Ошибка 1: Неопознанная роль пользователя.");
                    break;
            }
        }

        private void LoginForm_VisibleChanged(object sender, EventArgs e)
        {
            textBoxPassword.Text = "";
        }
    }
}
