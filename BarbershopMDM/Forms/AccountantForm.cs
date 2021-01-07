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
    public partial class AccountantForm : Form
    {
        private readonly int _currentUserId;
        private readonly IConsumablesRepository _consumablesRepository;
        private readonly ISuppliersRepository _suppliersRepository;
        private readonly IOrdersRepository _ordersRepository;

        public AccountantForm(int userId)
        {
            _currentUserId = userId;
            _consumablesRepository = (IConsumablesRepository)Program.ServiceProvider.GetService(typeof(IConsumablesRepository));
            _suppliersRepository = (ISuppliersRepository)Program.ServiceProvider.GetService(typeof(ISuppliersRepository));
            _ordersRepository = (IOrdersRepository)Program.ServiceProvider.GetService(typeof(IOrdersRepository));

            InitializeComponent();

            dataGridViewConsumables.RowHeadersVisible = false;
            dataGridViewConsumables.ColumnCount = 3;
            dataGridViewConsumables.Columns[0].HeaderText = "Код";
            dataGridViewConsumables.Columns[1].HeaderText = "Наименование";
            dataGridViewConsumables.Columns[2].HeaderText = "Кол-во";
            dataGridViewConsumables.Columns[0].Width = 50;
            dataGridViewConsumables.Columns[2].Width = 50;

            dataGridViewSuppliers.RowHeadersVisible = false;
            dataGridViewSuppliers.ColumnCount = 3;
            dataGridViewSuppliers.Columns[0].HeaderText = "ОГРН";
            dataGridViewSuppliers.Columns[1].HeaderText = "Наименование";
            dataGridViewSuppliers.Columns[2].HeaderText = "Телефон";
            dataGridViewSuppliers.Columns[0].Width = 86;
            dataGridViewSuppliers.Columns[2].Width = 100;

            numericUpDownORGN.Controls[0].Visible = false;
            numericUpDownORGN.Controls[1].Width -= 4;
            numericUpDownConsumablesAmount.Controls[0].Visible = false;
            numericUpDownConsumablesAmount.Controls[1].Width -= 4;
        }

        private async Task UpdateDataGridViewConsumables()
        {
            var consumables = await _consumablesRepository.GetConsumables();
            dataGridViewConsumables.Rows.Clear();
            dataGridViewConsumables.Columns[1].Width = consumables.Count > 4 ? 348 : 365;
            foreach (var consumable in consumables)
            {
                dataGridViewConsumables.Rows.Add(new[] { consumable.Id.ToString(), consumable.Name, consumable.CurrentAmount.ToString() });
            }
            ClearDataGridViewConsumablesSelection();
        }

        private async Task UpdateDataGridViewSuppliers()
        {
            var suppliers = await _suppliersRepository.GetSuppliers();
            dataGridViewSuppliers.Rows.Clear();
            dataGridViewSuppliers.Columns[1].Width = suppliers.Count > 4 ? 262 : 279;
            foreach (var supplier in suppliers)
            {
                dataGridViewSuppliers.Rows.Add(new[] { supplier.OGRN.ToString(), supplier.Name, supplier.ContactNumber });
            }
            ClearDataGridViewSuppliersSelection();
        }

        private void ClearDataGridViewConsumablesSelection()
        {
            dataGridViewConsumables.ClearSelection();
            dataGridViewConsumables.CurrentCell = null;
            ClearConsumablesValues();
        }

        private void ClearDataGridViewSuppliersSelection()
        {
            dataGridViewSuppliers.ClearSelection();
            dataGridViewSuppliers.CurrentCell = null;
            ClearSuppliersValues();
        }

        private void ClearConsumablesValues()
        {
            textBoxConsumablesId.Text = "";
            textBoxConsumablesName.Text = "";
            numericUpDownConsumablesAmount.Value = 0;
        }

        private void ClearSuppliersValues()
        {
            numericUpDownORGN.Value = 0;
            textBoxSupplierName.Text = "";
            textBoxSupplierNumber.Text = "";
        }

        private bool VerifyConsumablesValues(out string name, out int amount)
        {
            name = textBoxConsumablesName.Text;
            amount = Convert.ToInt32(numericUpDownConsumablesAmount.Value);

            var message = "";
            message += name.Length < 2 ? "Поле \"Наименование\" должно содержать минимум 2 символа." : "";

            if (!message.Equals(""))
            {
                MessageBox.Show(message, "Валидация данных о расходных материалах");
                return false;
            }
            return true;
        }

        private bool VerifySupplierValues(out ulong ogrn, out string name, out string number)
        {
            ogrn = Convert.ToUInt64(numericUpDownORGN.Value);
            name = textBoxSupplierName.Text;
            number = textBoxSupplierNumber.Text;

            var numberRegex = new System.Text.RegularExpressions.Regex(@"^(\s*)?(\+)?([- _():=+]?\d[- _():=+]?){10,14}(\s*)?$");

            var message = "";
            message += ogrn < 1000000000000 ? "Поле \"ОГРН\" должно иметь 13 цифр.\n" : "";
            message += name.Length < 3 ? "Поле \"Наименование\" должно содержать минимум 3 символа.\n" : "";
            message += !numberRegex.IsMatch(number) ? "Поле \"Номер\" должно содержать валидный номер телефона, например, +7 (999) 999-99-99." : "";

            if (!message.Equals(""))
            {
                MessageBox.Show(message, "Валидация данных о поставщике");
                return false;
            }
            return true;
        }

        private async void ButtonAddConsumables_Click(object sender, EventArgs e)
        {
            if (!VerifyConsumablesValues(out var name, out var amount))
            {
                return;
            }

            var consumable = new Models.Consumables()
            {
                Name = name,
                CurrentAmount = amount
            };

            await _consumablesRepository.CreateConsumable(consumable);
            await UpdateDataGridViewConsumables();
        }

        private async void ButtonEditConsumables_Click(object sender, EventArgs e)
        {
            if (!VerifyConsumablesValues(out var name, out var amount))
            {
                return;
            }

            var consumable = await _consumablesRepository.GetConsumable(Convert.ToInt32(textBoxConsumablesId.Text));
            consumable.Name = name;
            consumable.CurrentAmount = amount;

            await _consumablesRepository.UpdateConsumable(consumable);
            await UpdateDataGridViewConsumables();
        }

        private async void ButtonRemoveConsumables_Click(object sender, EventArgs e)
        {
            var consumablesId = Convert.ToInt32(textBoxConsumablesId.Text);
            var ordersContents = await _ordersRepository.GetOrderContentsWithConsumables(consumablesId);
            if (ordersContents.Count > 0)
            {
                MessageBox.Show("Нельзя удалить материалы, указанные в заказах.");
                return;
            }
            var consumable = await _consumablesRepository.GetConsumable(consumablesId);
            await _consumablesRepository.RemoveConsumable(consumable);
            await UpdateDataGridViewConsumables();
        }

        private void ButtonCancelConsumables_Click(object sender, EventArgs e)
        {
            ClearDataGridViewConsumablesSelection();
        }

        private async void ButtonAddSupplier_Click(object sender, EventArgs e)
        {
            if (!VerifySupplierValues(out var orgn, out var name, out var number))
            {
                return;
            }

            var supplier = new Models.Supplier()
            {
                OGRN = orgn,
                Name = name,
                ContactNumber = number
            };

            await _suppliersRepository.CreateSupplier(supplier);
            await UpdateDataGridViewSuppliers();
        }

        private async void ButtonEditSupplier_Click(object sender, EventArgs e)
        {
            if (!VerifySupplierValues(out var orgn, out var name, out var number))
            {
                return;
            }

            var supplier = await _suppliersRepository.GetSupplierByOGRN(orgn);
            supplier.Name = name;
            supplier.ContactNumber = number;

            await _suppliersRepository.UpdateSupplier(supplier);
            await UpdateDataGridViewSuppliers();
        }

        private async void ButtonRemoveSupplier_Click(object sender, EventArgs e)
        {
            var orgn = Convert.ToUInt64(numericUpDownORGN.Value);
            var supplier = await _suppliersRepository.GetSupplierByOGRN(orgn);
            var supplierOrders = await _ordersRepository.GetSupplierOrders(supplier.Id);
            if (supplierOrders.Count > 0)
            {
                MessageBox.Show("Нельзя удалить поставщика, который числится в заказах.");
                return;
            }
            await _suppliersRepository.RemoveSupplier(supplier);
            await UpdateDataGridViewSuppliers();
        }

        private void ButtonCancelSupplier_Click(object sender, EventArgs e)
        {
            ClearDataGridViewSuppliersSelection();
        }

        private void DataGridViewConsumables_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRows = dataGridViewConsumables.SelectedRows;

            var consumablesSelected = selectedRows.Count > 0;
            buttonAddConsumables.Enabled = !consumablesSelected;
            buttonAddConsumablesToOrder.Enabled = consumablesSelected;
            buttonEditConsumables.Enabled = consumablesSelected;
            buttonRemoveConsumables.Enabled = consumablesSelected;

            if (consumablesSelected)
            {
                var selectedRow = selectedRows[0];
                textBoxConsumablesId.Text = selectedRow.Cells[0].Value.ToString();
                textBoxConsumablesName.Text = selectedRow.Cells[1].Value.ToString();
                numericUpDownConsumablesAmount.Value = Convert.ToInt32(selectedRow.Cells[2].Value.ToString());
            }
        }

        private void DataGridViewSuppliers_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRows = dataGridViewSuppliers.SelectedRows;

            var supplierSelected = selectedRows.Count > 0;
            buttonAddSupplier.Enabled = !supplierSelected;
            buttonAddSupplierToOrder.Enabled = supplierSelected;
            buttonEditSupplier.Enabled = supplierSelected;
            buttonRemoveSupplier.Enabled = supplierSelected;
            numericUpDownORGN.Enabled = !supplierSelected;

            if (supplierSelected)
            {
                var selectedRow = selectedRows[0];
                numericUpDownORGN.Value = Convert.ToUInt64(selectedRow.Cells[0].Value.ToString());
                textBoxSupplierName.Text = selectedRow.Cells[1].Value.ToString();
                textBoxSupplierNumber.Text = selectedRow.Cells[2].Value.ToString();
            }
        }

        private async void AccountantForm_Shown(object sender, EventArgs e)
        {
            await UpdateDataGridViewConsumables();
            await UpdateDataGridViewSuppliers();
            DataGridViewConsumables_SelectionChanged(sender, e);
            DataGridViewSuppliers_SelectionChanged(sender, e);
        }

        private void AccountantForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.LoginForm.Show();
        }
    }
}
