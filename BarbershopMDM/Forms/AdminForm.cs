using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarbershopMDM.Data.Repositories;

namespace BarbershopMDM.Forms
{
    public partial class AdminForm : Form
    {
        private readonly IEmployeesRepository _employeesRepository;

        public AdminForm()
        {
            _employeesRepository = (IEmployeesRepository)Program.ServiceProvider.GetService(typeof(IEmployeesRepository));

            InitializeComponent();

            dataGridViewUsers.RowHeadersVisible = false;
            dataGridViewUsers.ColumnCount = 3;
            dataGridViewUsers.Columns[0].HeaderText = "ФИО";
            dataGridViewUsers.Columns[1].HeaderText = "Логин";
            dataGridViewUsers.Columns[2].HeaderText = "Должность";
            dataGridViewUsers.Columns[1].Width = 110;
            dataGridViewUsers.Columns[2].Width = 90;

            UpdateDataGridView();

            comboBoxRole.Items.AddRange(new string[] { "Бухгалтер", "Администратор" });
            comboBoxRole.SelectedIndex = 0;
        }

        private async void UpdateDataGridView()
        {
            dataGridViewUsers.Rows.Clear();
            var users = await _employeesRepository.GetEmployees();
            dataGridViewUsers.Columns[0].Width = users.Count > 3 ? 313 : 330;
            foreach (var user in users)
            {
                var role = user.Role.Equals("accountant") ? "Бухгалтер" : user.Role.Equals("manager") ? "Администратор" : "Неизвестно";
                dataGridViewUsers.Rows.Add(new[] { user.Name, user.Login, role });
            }
        }

        private void AdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.LoginForm.Show();

        private async void buttonAdd_Click(object sender, EventArgs e)
        {
            var name = textBoxName.Text;
            var login = textBoxLogin.Text;
            var password = textBoxPassword.Text;

            var message = "";

            if (name.Length < 3)
            {
                message += "Поле \"ФИО\" должно содержать минимум 3 символа.\n";
            }

            if (login.Length < 3)
            {
                message += "Поле \"Логин\" должно содержать минимум 3 символа.\n";
            }

            if (password.Length < 8)
            {
                message += "Поле \"Пароль\" должно содержать минимум 8 символов.\n";
            }

            if (message != "")
            {
                MessageBox.Show(message, "Валидация данных пользователя");
                return;
            }

            var user = new Models.Employee()
            {
                Name = name,
                Login = login,
                Password = password,
                Role = comboBoxRole.SelectedIndex == 0 ? "accountant" : "manager"
            };

            await _employeesRepository.CreateEmployee(user);
            
            UpdateDataGridView();

            textBoxName.Text = "";
            textBoxLogin.Text = "";
            textBoxPassword.Text = "";
        }
    }
}
