using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarbershopMDM.Models;
using BarbershopMDM.Data.Repositories;

namespace BarbershopMDM.Forms
{
    public partial class ManagerForm : Form
    {
        private readonly int _currentUserId;
        private readonly IConsumablesRepository _consumablesRepository;
        private readonly ISuppliersRepository _suppliersRepository;
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IOrdersRepository _ordersRepository;

        private List<Consumables> ChosenConsumables { get; set; }

        public ManagerForm(int userId)
        {
            _currentUserId = userId;
            _consumablesRepository = (IConsumablesRepository)Program.ServiceProvider.GetService(typeof(IConsumablesRepository));
            _suppliersRepository = (ISuppliersRepository)Program.ServiceProvider.GetService(typeof(ISuppliersRepository));
            _employeesRepository = (IEmployeesRepository)Program.ServiceProvider.GetService(typeof(IEmployeesRepository));
            _ordersRepository = (IOrdersRepository)Program.ServiceProvider.GetService(typeof(IOrdersRepository));

            ChosenConsumables = new List<Consumables>();

            InitializeComponent();

            // Consumables menu
            dataGridViewConsumables.RowHeadersVisible = false;
            dataGridViewConsumables.ColumnCount = 3;
            dataGridViewConsumables.Columns[0].HeaderText = "Код";
            dataGridViewConsumables.Columns[1].HeaderText = "Наименование";
            dataGridViewConsumables.Columns[2].HeaderText = "Кол-во";
            dataGridViewConsumables.Columns[0].Width = 50;
            dataGridViewConsumables.Columns[2].Width = 50;
            numericUpDownConsumablesAmount.Controls[0].Visible = false;
            numericUpDownConsumablesAmount.Controls[1].Width -= 4;

            // Suppliers menu
            dataGridViewSuppliers.RowHeadersVisible = false;
            dataGridViewSuppliers.ColumnCount = 3;
            dataGridViewSuppliers.Columns[0].HeaderText = "ОГРН";
            dataGridViewSuppliers.Columns[1].HeaderText = "Наименование";
            dataGridViewSuppliers.Columns[2].HeaderText = "Телефон";
            dataGridViewSuppliers.Columns[0].Width = 86;
            dataGridViewSuppliers.Columns[2].Width = 100;
            numericUpDownORGN.Controls[0].Visible = false;
            numericUpDownORGN.Controls[1].Width -= 4;

            // Order menu
            numericUpDownOrderCost.Controls[0].Visible = false;
            numericUpDownOrderCost.Controls[1].Width -= 4;

            // Order consumables menu
            dataGridViewOrderConsumables.RowHeadersVisible = false;
            dataGridViewOrderConsumables.ColumnCount = 3;
            dataGridViewOrderConsumables.Columns[0].HeaderText = "Код";
            dataGridViewOrderConsumables.Columns[1].HeaderText = "Наименование";
            dataGridViewOrderConsumables.Columns[2].HeaderText = "Кол-во";
            dataGridViewOrderConsumables.Columns[0].Width = 50;
            dataGridViewOrderConsumables.Columns[2].Width = 50;
            numericUpDownOrderConsumablesAmount.Controls[0].Visible = false;
            numericUpDownOrderConsumablesAmount.Controls[1].Width -= 4;

            // Orders menu
            dataGridViewOrders.RowHeadersVisible = false;
            dataGridViewOrders.ColumnCount = 7;
            dataGridViewOrders.Columns[0].HeaderText = "Код";
            dataGridViewOrders.Columns[1].HeaderText = "Поставщик";
            dataGridViewOrders.Columns[2].HeaderText = "Цена (руб)";
            dataGridViewOrders.Columns[3].HeaderText = "Оформил(а)";
            dataGridViewOrders.Columns[4].HeaderText = "Время офор.";
            dataGridViewOrders.Columns[5].HeaderText = "Принял(а)";
            dataGridViewOrders.Columns[6].HeaderText = "Время прин.";
            dataGridViewOrders.Columns[0].Width = 50;
            dataGridViewOrders.Columns[2].Width = 84;
            dataGridViewOrders.Columns[4].Width = 100;
            dataGridViewOrders.Columns[6].Width = 100;
        }

        private async Task UpdateDataGridViewConsumables()
        {
            var consumables = await _consumablesRepository.GetConsumables();
            dataGridViewConsumables.Rows.Clear();
            dataGridViewConsumables.Columns[1].Width = consumables.Count > 4 ? 348 : 365;
            foreach (var consumable in consumables)
            {
                dataGridViewConsumables.Rows.Add(new[]
                {
                    consumable.Id.ToString(),
                    consumable.Name,
                    consumable.CurrentAmount.ToString()
                });
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
                dataGridViewSuppliers.Rows.Add(new[]
                {
                    supplier.OGRN.ToString(),
                    supplier.Name,
                    supplier.ContactNumber
                });
            }
            ClearDataGridViewSuppliersSelection();
        }

        private async Task UpdateDataGridViewOrders()
        {
            var orders = await _ordersRepository.GetOrders();
            dataGridViewOrders.Rows.Clear();
            var columnWidth = orders.Count > 8 ? 200 : 206;
            dataGridViewOrders.Columns[1].Width = columnWidth;
            dataGridViewOrders.Columns[3].Width = columnWidth;
            dataGridViewOrders.Columns[5].Width = columnWidth;
            foreach (var order in orders)
            {
                var supplierName = (await _suppliersRepository.GetSupplier(order.SupplierId)).Name;
                var ordererName = (await _employeesRepository.GetEmployee(order.OrdererId)).Name;
                var finisherName = order.FinisherId == null
                    ? ""
                    : (await _employeesRepository.GetEmployee((int)order.FinisherId)).Name;
                dataGridViewOrders.Rows.Add(new[]
                {
                    order.Id.ToString(),
                    supplierName,
                    order.Cost.ToString(),
                    ordererName,
                    order.TimeOrdered.ToString(),
                    finisherName,
                    order.TimeCompleted.ToString()
                });
            }
            ClearDataGridViewOrdersSelection();
        }

        private void UpdateDataGridViewOrderConsumables()
        {
            dataGridViewOrderConsumables.Rows.Clear();
            dataGridViewOrderConsumables.Columns[1].Width = ChosenConsumables.Count > 4 ? 342 : 359;
            foreach (var consumable in ChosenConsumables)
            {
                dataGridViewOrderConsumables.Rows.Add(new[]
                {
                    consumable.Id.ToString(),
                    consumable.Name,
                    consumable.CurrentAmount.ToString()
                });
            }
            ClearDataGridViewOrderConsumablesSelection();
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

        private void ClearDataGridViewOrdersSelection()
        {
            dataGridViewOrders.ClearSelection();
            dataGridViewOrders.CurrentCell = null;
            ClearOrdersValues();
        }

        private void ClearDataGridViewOrderConsumablesSelection()
        {
            dataGridViewOrderConsumables.ClearSelection();
            dataGridViewOrderConsumables.CurrentCell = null;
            ClearOrderConsumablesValues();
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

        private void ClearOrdersValues()
        {
            textBoxOrderId.Text = "";
            textBoxOrderSupplier.Text = "";
            numericUpDownOrderCost.Value = 0;
            textBoxOrderOrderer.Text = "";
            textBoxOrderTimeOrdered.Text = "";
            textBoxOrderFinisher.Text = "";
            textBoxOrderTimeCompleted.Text = "";

            ChosenConsumables.Clear();
            UpdateDataGridViewOrderConsumables();
        }

        private void ClearOrderConsumablesValues()
        {
            textBoxOrderConsumablesId.Text = "";
            textBoxOrderConsumablesName.Text = "";
            numericUpDownOrderConsumablesAmount.Value = 0;
        }

        private async void ButtonEditConsumables_Click(object sender, EventArgs e)
        {
            var consumable = await _consumablesRepository.GetConsumable(Convert.ToInt32(textBoxConsumablesId.Text));
            consumable.CurrentAmount = Convert.ToInt32(numericUpDownConsumablesAmount.Value);

            await _consumablesRepository.UpdateConsumable(consumable);
            await UpdateDataGridViewConsumables();
        }

        private void ButtonCancelConsumables_Click(object sender, EventArgs e)
        {
            ClearDataGridViewConsumablesSelection();
        }

        private void ButtonCancelSupplier_Click(object sender, EventArgs e)
        {
            ClearDataGridViewSuppliersSelection();
        }

        private void ButtonCancelOrderConsumables_Click(object sender, EventArgs e)
        {
            ClearDataGridViewOrderConsumablesSelection();
        }

        private async void ButtonFinishOrder_Click(object sender, EventArgs e)
        {
            var message = "Вы уверены, что сейчас хотите завершить заказ?\nОн перестанет быть доступен для последующих изменений.";
            var confirm = MessageBox.Show(message, "Подтверждение принятия заказа", MessageBoxButtons.YesNo);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            var order = await _ordersRepository.GetOrder(Convert.ToInt32(textBoxOrderId.Text));
            order.FinisherId = _currentUserId;
            order.TimeCompleted = DateTime.Now;
            await _ordersRepository.UpdateOrder(order);

            var consumables = await _consumablesRepository.GetConsumables();
            var orderContent = await _ordersRepository.GetOrdersContent(order.Id);
            orderContent.ForEach(x => consumables.FirstOrDefault(y => x.ConsumablesId == y.Id).CurrentAmount += x.ConsumablesAmount);
            await _consumablesRepository.UpdateConsumables(consumables);
            await UpdateDataGridViewOrders();
            await UpdateDataGridViewConsumables();
        }

        private void ButtonCancelOrder_Click(object sender, EventArgs e)
        {
            ClearDataGridViewOrdersSelection();
        }

        private void DataGridViewConsumables_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRows = dataGridViewConsumables.SelectedRows;

            var consumablesSelected = selectedRows.Count > 0;
            buttonEditConsumables.Enabled = consumablesSelected;
            numericUpDownConsumablesAmount.ReadOnly = !consumablesSelected;

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

            if (supplierSelected)
            {
                var selectedRow = selectedRows[0];
                numericUpDownORGN.Value = Convert.ToUInt64(selectedRow.Cells[0].Value.ToString());
                textBoxSupplierName.Text = selectedRow.Cells[1].Value.ToString();
                textBoxSupplierNumber.Text = selectedRow.Cells[2].Value.ToString();
            }
        }

        private async void DataGridViewOrders_SelectionChanged(object sender, EventArgs e)
        {
            ChosenConsumables.Clear();

            var selectedRows = dataGridViewOrders.SelectedRows;

            var orderSelected = selectedRows.Count > 0;

            if (orderSelected)
            {
                var selectedRow = selectedRows[0];
                textBoxOrderId.Text = selectedRow.Cells[0].Value.ToString();
                textBoxOrderSupplier.Text = selectedRow.Cells[1].Value.ToString();
                numericUpDownOrderCost.Value = Convert.ToInt32(selectedRow.Cells[2].Value.ToString());
                textBoxOrderOrderer.Text = selectedRow.Cells[3].Value.ToString();
                textBoxOrderTimeOrdered.Text = selectedRow.Cells[4].Value.ToString();
                textBoxOrderFinisher.Text = selectedRow.Cells[5].Value.ToString();
                textBoxOrderTimeCompleted.Text = selectedRow.Cells[6].Value.ToString();

                var selectedOrderId = Convert.ToInt32(textBoxOrderId.Text);
                var orderContent = await _ordersRepository.GetOrdersContent(selectedOrderId);
                orderContent.ForEach(async x =>
                {
                    var consumable = new Consumables()
                    {
                        Id = x.ConsumablesId,
                        Name = (await _consumablesRepository.GetConsumable(x.ConsumablesId)).Name,
                        CurrentAmount = x.ConsumablesAmount
                    };
                    ChosenConsumables.Add(consumable);
                });
            }

            buttonFinishOrder.Enabled = orderSelected && textBoxOrderFinisher.Text.Equals("");

            UpdateDataGridViewOrderConsumables();
        }

        private void DataGridViewOrderConsumables_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRows = dataGridViewOrderConsumables.SelectedRows;

            var orderConsumablesSelected = selectedRows.Count > 0;

            if (orderConsumablesSelected)
            {
                var selectedRow = selectedRows[0];
                textBoxOrderConsumablesId.Text = selectedRow.Cells[0].Value.ToString();
                textBoxOrderConsumablesName.Text = selectedRow.Cells[1].Value.ToString();
                numericUpDownOrderConsumablesAmount.Value = Convert.ToInt32(selectedRow.Cells[2].Value.ToString());
            }
        }

        private async void ManagerForm_Shown(object sender, EventArgs e)
        {
            await UpdateDataGridViewConsumables();
            await UpdateDataGridViewSuppliers();
            await UpdateDataGridViewOrders();
            UpdateDataGridViewOrderConsumables();
            DataGridViewConsumables_SelectionChanged(sender, e);
            DataGridViewSuppliers_SelectionChanged(sender, e);
            DataGridViewOrders_SelectionChanged(sender, e);
            DataGridViewOrderConsumables_SelectionChanged(sender, e);
        }

        private void ManagerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.LoginForm.Show();
        }
    }
}
