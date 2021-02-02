using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BarbershopMDM.Models;
using BarbershopMDM.Data.Repositories;

namespace BarbershopMDM.Forms.EmployeesForms
{
    public partial class AccountantForm : EmployeeForm
    {
        private int SelectedOrderId { get; set; }
        private string CurrentUserName { get; set; }
        private ulong ChosenSupplierOGRN { get; set; }

        public AccountantForm() : base()
        {
            _consumablesRepository = (IConsumablesRepository)Program.ServiceProvider.GetService(typeof(IConsumablesRepository));
            _suppliersRepository = (ISuppliersRepository)Program.ServiceProvider.GetService(typeof(ISuppliersRepository));
            _employeesRepository = (IEmployeesRepository)Program.ServiceProvider.GetService(typeof(IEmployeesRepository));
            _ordersRepository = (IOrdersRepository)Program.ServiceProvider.GetService(typeof(IOrdersRepository));

            SelectedOrderId = 0;
            CurrentUserName = "";
            ChosenSupplierOGRN = 0;

            InitializeComponent();
        }

        protected override void ClearOrdersValues()
        {
            base.ClearOrdersValues();

            textBoxOrderOrderer.Text = CurrentUserName;
            textBoxOrderTimeOrdered.Text = DateTime.Now.Date.ToShortDateString();
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
            var name = textBoxConsumablesName.Text;
            var amount = Convert.ToInt32(numericUpDownConsumablesAmount.Value);

            if (name.Length < 2)
            {
                MessageBox.Show("Поле \"Наименование\" должно содержать минимум 2 символа.", "Валидация данных о расходных материалах");
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
            var consumable = await _consumablesRepository.GetConsumable(Convert.ToInt32(textBoxConsumablesId.Text));
            consumable.CurrentAmount = Convert.ToInt32(numericUpDownConsumablesAmount.Value);

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

            var confirm = MessageBox.Show("Вы уверены, что хотите удалить расходный материал?",
                "Подтверждение удаления расходного материала", MessageBoxButtons.YesNo);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            var consumable = await _consumablesRepository.GetConsumable(consumablesId);
            await _consumablesRepository.RemoveConsumable(consumable);
            await UpdateDataGridViewConsumables();
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

            var confirm = MessageBox.Show("Вы уверены, что хотите удалить поставщика?", "Подтверждение удаления поставщика",
                MessageBoxButtons.YesNo);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            await _suppliersRepository.RemoveSupplier(supplier);
            await UpdateDataGridViewSuppliers();
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
                OrdererId = Program.UserId,
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
            var confirm =
                MessageBox.Show("Вы уверены, что хотите отменить заказ?", "Подтверждение отмены заказа", MessageBoxButtons.YesNo);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            var id = Convert.ToInt32(textBoxOrderId.Text);
            var order = await _ordersRepository.GetOrder(id);
            await _ordersRepository.RemoveOrder(order);
            await UpdateDataGridViewOrders();
        }

        override protected void DataGridViewConsumables_SelectionChanged(object sender, EventArgs e)
        {
            base.DataGridViewConsumables_SelectionChanged(sender, e);
            var consumablesSelected = dataGridViewConsumables.SelectedRows.Count > 0;
            buttonAddConsumables.Enabled = !consumablesSelected;
            buttonAddConsumablesToOrder.Enabled = consumablesSelected && SelectedOrderId == 0;
            buttonEditConsumables.Enabled = consumablesSelected;
            buttonRemoveConsumables.Enabled = consumablesSelected;
            textBoxConsumablesName.ReadOnly = consumablesSelected;
        }

        override protected void DataGridViewSuppliers_SelectionChanged(object sender, EventArgs e)
        {
            base.DataGridViewSuppliers_SelectionChanged(sender, e);
            var supplierSelected = dataGridViewSuppliers.SelectedRows.Count > 0;
            buttonAddSupplier.Enabled = !supplierSelected;
            buttonAddSupplierToOrder.Enabled = supplierSelected && SelectedOrderId == 0;
            buttonEditSupplier.Enabled = supplierSelected;
            buttonRemoveSupplier.Enabled = supplierSelected;
            numericUpDownORGN.ReadOnly = supplierSelected;
        }

        override protected async void DataGridViewOrders_SelectionChanged(object sender, EventArgs e)
        {
            base.DataGridViewOrders_SelectionChanged(sender, e);

            SelectedOrderId = 0;
            ChosenSupplierOGRN = 0;
            ChosenConsumables.Clear();

            var orderSelected = dataGridViewOrders.SelectedRows.Count > 0;
            if (orderSelected)
            {
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
            numericUpDownOrderCost.ReadOnly = orderSelected;
            numericUpDownOrderConsumablesAmount.ReadOnly = orderSelected;

            UpdateDataGridViewOrderConsumables();

            DataGridViewConsumables_SelectionChanged(sender, e);
            DataGridViewSuppliers_SelectionChanged(sender, e);
            DataGridViewOrderConsumables_SelectionChanged(sender, e);
        }

        override protected void DataGridViewOrderConsumables_SelectionChanged(object sender, EventArgs e)
        {
            base.DataGridViewOrderConsumables_SelectionChanged(sender, e);
            var orderConsumablesSelected = dataGridViewOrderConsumables.SelectedRows.Count > 0;
            buttonUpdateOrderConsumables.Enabled = orderConsumablesSelected && SelectedOrderId == 0;
            buttonRemoveOrderConsumables.Enabled = orderConsumablesSelected && SelectedOrderId == 0;
        }

        private async void AccountantForm_Shown(object sender, EventArgs e)
        {
            CurrentUserName = (await _employeesRepository.GetEmployee(Program.UserId)).Name;

            await UpdateDataGridViewConsumables();
            await UpdateDataGridViewSuppliers();
            await UpdateDataGridViewOrders();
            UpdateDataGridViewOrderConsumables();
            DataGridViewOrders_SelectionChanged(sender, e);
        }
    }
}
