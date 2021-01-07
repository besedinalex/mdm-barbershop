using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarbershopMDM.Models;
using BarbershopMDM.Data.Repositories;

namespace BarbershopMDM.Forms
{
    public partial class AccountantForm : Form
    {
        private readonly int _currentUserId;
        private readonly IConsumablesRepository _consumablesRepository;
        private readonly ISuppliersRepository _suppliersRepository;
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IOrdersRepository _ordersRepository;

        private int SelectedOrderId { get; set; }
        private string CurrentUserName { get; set; }
        private ulong ChosenSupplierOGRN { get; set; }
        private List<Consumables> ChosenConsumables { get; set; }

        public AccountantForm(int userId)
        {
            _currentUserId = userId;
            _consumablesRepository = (IConsumablesRepository)Program.ServiceProvider.GetService(typeof(IConsumablesRepository));
            _suppliersRepository = (ISuppliersRepository)Program.ServiceProvider.GetService(typeof(ISuppliersRepository));
            _employeesRepository = (IEmployeesRepository)Program.ServiceProvider.GetService(typeof(IEmployeesRepository));
            _ordersRepository = (IOrdersRepository)Program.ServiceProvider.GetService(typeof(IOrdersRepository));

            SelectedOrderId = 0;
            CurrentUserName = "";
            ChosenSupplierOGRN = 0;
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
            textBoxOrderOrderer.Text = CurrentUserName;
            textBoxOrderTimeOrdered.Text = DateTime.Now.Date.ToShortDateString();
            textBoxOrderFinisher.Text = "";
            textBoxOrderTimeCompleted.Text = "";

            ChosenSupplierOGRN = 0;
            ChosenConsumables.Clear();
            UpdateDataGridViewOrderConsumables();
        }

        private void ClearOrderConsumablesValues()
        {
            textBoxOrderConsumablesId.Text = "";
            textBoxOrderConsumablesName.Text = "";
            numericUpDownOrderConsumablesAmount.Value = 0;
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

        private bool VerifyOrderData(out int cost)
        {
            cost = Convert.ToInt32(numericUpDownOrderCost.Value);
            var emptyConsumable = ChosenConsumables.FirstOrDefault(x => x.CurrentAmount == 0);

            var message = "";
            message += cost == 0 ? "Стоимость заказа должна быть больше нуля рублей.\n" : "";
            message += ChosenConsumables.Count == 0 ? "В заказе должен присутствовать хотя бы один материал.\n"
                : emptyConsumable != null ? "В заказе присутствует материал с нулевым количеством.\n" : "";
            message += ChosenSupplierOGRN == 0 ? "Необходимо выбрать поставщика.\n" : "";

            if (!message.Equals(""))
            {
                MessageBox.Show(message, "Валидация данных о заказе");
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

            var consumable = new Consumables()
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
            if (!VerifySupplierValues(out var ogrn, out var name, out var number))
            {
                return;
            }

            var supplier = await _suppliersRepository.GetSupplierByOGRN(ogrn);
            if (supplier != null)
            {
                MessageBox.Show("Поставщик с таким ОГРН уже есть в базе.");
                return;
            }

            supplier = new Supplier()
            {
                OGRN = ogrn,
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

        private void ButtonAddConsumablesToOrder_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(textBoxConsumablesId.Text);
            var existingConsumable = ChosenConsumables.FirstOrDefault(x => x.Id == id);
            if (existingConsumable != null)
            {
                return;
            }

            var consumable = new Consumables()
            {
                Id = id,
                Name = textBoxConsumablesName.Text,
                CurrentAmount = 0
            };
            ChosenConsumables.Add(consumable);
            UpdateDataGridViewOrderConsumables();
        }

        private void ButtonUpdateOrderConsumables_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(textBoxOrderConsumablesId.Text);
            var existingConsumable = ChosenConsumables.FirstOrDefault(x => x.Id == id);
            existingConsumable.CurrentAmount = Convert.ToInt32(numericUpDownOrderConsumablesAmount.Value);
            UpdateDataGridViewOrderConsumables();
        }

        private void ButtonRemoveOrderConsumables_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(textBoxOrderConsumablesId.Text);
            var existingConsumable = ChosenConsumables.FirstOrDefault(x => x.Id == id);
            ChosenConsumables.Remove(existingConsumable);
            UpdateDataGridViewOrderConsumables();
        }

        private void ButtonCancelOrderConsumables_Click(object sender, EventArgs e)
        {
            ClearDataGridViewOrderConsumablesSelection();
        }

        private void ButtonAddSupplierToOrder_Click(object sender, EventArgs e)
        {
            textBoxOrderSupplier.Text = textBoxSupplierName.Text;
            ChosenSupplierOGRN = Convert.ToUInt64(numericUpDownORGN.Value);
        }

        private async void ButtonCreateOrder_Click(object sender, EventArgs e)
        {
            if (!VerifyOrderData(out var cost))
            {
                return;
            }

            var supplier = await _suppliersRepository.GetSupplierByOGRN(ChosenSupplierOGRN);
            var order = new Order()
            {
                SupplierId = supplier.Id,
                Cost = cost,
                OrdererId = _currentUserId,
                TimeOrdered = DateTime.Now
            };
            var orderId = await _ordersRepository.CreateOrder(order);
            var orderContent = new List<OrderContent>();
            ChosenConsumables.ForEach(x =>
            {
                var orderConsumable = new OrderContent()
                {
                    OrderId = orderId,
                    ConsumablesId = x.Id,
                    ConsumablesAmount = x.CurrentAmount
                };
                orderContent.Add(orderConsumable);
            });
            await _ordersRepository.CreateOrderContent(orderContent);
            await UpdateDataGridViewOrders();
        }

        private async void ButtonAbortOrder_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(textBoxOrderId.Text);
            var order = await _ordersRepository.GetOrder(id);
            await _ordersRepository.RemoveOrder(order);
            await UpdateDataGridViewOrders();
        }

        private void ButtonCancelOrder_Click(object sender, EventArgs e)
        {
            ClearDataGridViewOrdersSelection();
        }

        private void DataGridViewConsumables_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRows = dataGridViewConsumables.SelectedRows;

            var consumablesSelected = selectedRows.Count > 0;
            buttonAddConsumables.Enabled = !consumablesSelected;
            buttonAddConsumablesToOrder.Enabled = consumablesSelected && SelectedOrderId == 0;
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
            buttonAddSupplierToOrder.Enabled = supplierSelected && SelectedOrderId == 0;
            buttonEditSupplier.Enabled = supplierSelected;
            buttonRemoveSupplier.Enabled = supplierSelected;
            numericUpDownORGN.ReadOnly = !supplierSelected;

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
            SelectedOrderId = 0;
            ChosenSupplierOGRN = 0;
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

                SelectedOrderId = Convert.ToInt32(textBoxOrderId.Text);
                var orderContent = await _ordersRepository.GetOrdersContent(SelectedOrderId);
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

            buttonCreateOrder.Enabled = !orderSelected;
            buttonAbortOrder.Enabled = orderSelected && textBoxOrderFinisher.Text.Equals("");

            UpdateDataGridViewOrderConsumables();

            DataGridViewConsumables_SelectionChanged(sender, e);
            DataGridViewSuppliers_SelectionChanged(sender, e);
            DataGridViewOrderConsumables_SelectionChanged(sender, e);
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

            buttonUpdateOrderConsumables.Enabled = orderConsumablesSelected && SelectedOrderId == 0;
            buttonRemoveOrderConsumables.Enabled = orderConsumablesSelected && SelectedOrderId == 0;
            numericUpDownOrderConsumablesAmount.Enabled = orderConsumablesSelected && SelectedOrderId == 0;
        }

        private async void AccountantForm_Shown(object sender, EventArgs e)
        {
            var user = await _employeesRepository.GetEmployee(_currentUserId);
            CurrentUserName = user.Name;

            await UpdateDataGridViewConsumables();
            await UpdateDataGridViewSuppliers();
            await UpdateDataGridViewOrders();
            UpdateDataGridViewOrderConsumables();
            DataGridViewOrders_SelectionChanged(sender, e);
        }

        private void AccountantForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.LoginForm.Show();
        }
    }
}
