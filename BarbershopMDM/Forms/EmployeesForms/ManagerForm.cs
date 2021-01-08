using System;
using System.Linq;
using System.Windows.Forms;
using BarbershopMDM.Models;
using BarbershopMDM.Data.Repositories;

namespace BarbershopMDM.Forms.EmployeesForms
{
    public partial class ManagerForm : EmployeeForm
    {
        public ManagerForm() : base()
        {
            _consumablesRepository = (IConsumablesRepository)Program.ServiceProvider.GetService(typeof(IConsumablesRepository));
            _suppliersRepository = (ISuppliersRepository)Program.ServiceProvider.GetService(typeof(ISuppliersRepository));
            _employeesRepository = (IEmployeesRepository)Program.ServiceProvider.GetService(typeof(IEmployeesRepository));
            _ordersRepository = (IOrdersRepository)Program.ServiceProvider.GetService(typeof(IOrdersRepository));

            InitializeComponent();
        }

        private async void ButtonEditConsumables_Click(object sender, EventArgs e)
        {
            var consumable = await _consumablesRepository.GetConsumable(Convert.ToInt32(textBoxConsumablesId.Text));
            consumable.CurrentAmount = Convert.ToInt32(numericUpDownConsumablesAmount.Value);

            await _consumablesRepository.UpdateConsumable(consumable);
            await UpdateDataGridViewConsumables();
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
            order.FinisherId = Program.UserId;
            order.TimeCompleted = DateTime.Now;
            await _ordersRepository.UpdateOrder(order);

            var consumables = await _consumablesRepository.GetConsumables();
            var orderContent = await _ordersRepository.GetOrdersContent(order.Id);
            orderContent.ForEach(x => consumables.FirstOrDefault(y => x.ConsumablesId == y.Id).CurrentAmount += x.ConsumablesAmount);
            await _consumablesRepository.UpdateConsumables(consumables);
            await UpdateDataGridViewOrders();
            await UpdateDataGridViewConsumables();
        }

        override protected void DataGridViewConsumables_SelectionChanged(object sender, EventArgs e)
        {
            base.DataGridViewConsumables_SelectionChanged(sender, e);
            var consumablesSelected = dataGridViewConsumables.SelectedRows.Count > 0;
            buttonEditConsumables.Enabled = consumablesSelected;
            numericUpDownConsumablesAmount.ReadOnly = !consumablesSelected;
        }

        override protected async void DataGridViewOrders_SelectionChanged(object sender, EventArgs e)
        {
            base.DataGridViewOrders_SelectionChanged(sender, e);

            ChosenConsumables.Clear();

            var orderSelected = dataGridViewOrders.SelectedRows.Count > 0;
            if (orderSelected)
            {
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
    }
}
