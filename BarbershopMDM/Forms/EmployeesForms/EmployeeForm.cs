using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarbershopMDM.Models;
using BarbershopMDM.Data.Repositories;

namespace BarbershopMDM.Forms.EmployeesForms
{
    public partial class EmployeeForm : Form
    {
        protected IConsumablesRepository _consumablesRepository;
        protected ISuppliersRepository _suppliersRepository;
        protected IEmployeesRepository _employeesRepository;
        protected IOrdersRepository _ordersRepository;

        protected List<Consumables> ChosenConsumables { get; set; }

        public EmployeeForm()
        {
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

        protected async Task UpdateDataGridViewConsumables()
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

        protected async Task UpdateDataGridViewSuppliers()
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

        protected async Task UpdateDataGridViewOrders()
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

        protected void UpdateDataGridViewOrderConsumables()
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

        protected void ClearDataGridViewConsumablesSelection()
        {
            dataGridViewConsumables.ClearSelection();
            dataGridViewConsumables.CurrentCell = null;
            ClearConsumablesValues();
        }

        protected void ClearDataGridViewSuppliersSelection()
        {
            dataGridViewSuppliers.ClearSelection();
            dataGridViewSuppliers.CurrentCell = null;
            ClearSuppliersValues();
        }

        protected void ClearDataGridViewOrdersSelection()
        {
            dataGridViewOrders.ClearSelection();
            dataGridViewOrders.CurrentCell = null;
            ClearOrdersValues();
        }

        protected void ClearDataGridViewOrderConsumablesSelection()
        {
            dataGridViewOrderConsumables.ClearSelection();
            dataGridViewOrderConsumables.CurrentCell = null;
            ClearOrderConsumablesValues();
        }

        protected void ClearConsumablesValues()
        {
            textBoxConsumablesId.Text = "";
            textBoxConsumablesName.Text = "";
            numericUpDownConsumablesAmount.Value = 0;
        }

        protected void ClearSuppliersValues()
        {
            numericUpDownORGN.Value = 0;
            textBoxSupplierName.Text = "";
            textBoxSupplierNumber.Text = "";
        }

        virtual protected void ClearOrdersValues()
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

        protected void ClearOrderConsumablesValues()
        {
            textBoxOrderConsumablesId.Text = "";
            textBoxOrderConsumablesName.Text = "";
            numericUpDownOrderConsumablesAmount.Value = 0;
        }

        protected void ButtonCancelConsumables_Click(object sender, EventArgs e)
        {
            ClearDataGridViewConsumablesSelection();
        }

        protected void ButtonCancelSupplier_Click(object sender, EventArgs e)
        {
            ClearDataGridViewSuppliersSelection();
        }

        protected void ButtonCancelOrderConsumables_Click(object sender, EventArgs e)
        {
            ClearDataGridViewOrderConsumablesSelection();
        }

        protected void ButtonCancelOrder_Click(object sender, EventArgs e)
        {
            ClearDataGridViewOrdersSelection();
        }

        virtual protected void DataGridViewConsumables_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRows = dataGridViewConsumables.SelectedRows;
            if (selectedRows.Count > 0)
            {
                var selectedRow = selectedRows[0];
                textBoxConsumablesId.Text = selectedRow.Cells[0].Value.ToString();
                textBoxConsumablesName.Text = selectedRow.Cells[1].Value.ToString();
                numericUpDownConsumablesAmount.Value = Convert.ToInt32(selectedRow.Cells[2].Value.ToString());
            }
        }

        virtual protected void DataGridViewSuppliers_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRows = dataGridViewSuppliers.SelectedRows;
            if (selectedRows.Count > 0)
            {
                var selectedRow = selectedRows[0];
                numericUpDownORGN.Value = Convert.ToUInt64(selectedRow.Cells[0].Value.ToString());
                textBoxSupplierName.Text = selectedRow.Cells[1].Value.ToString();
                textBoxSupplierNumber.Text = selectedRow.Cells[2].Value.ToString();
            }
        }

        virtual protected void DataGridViewOrders_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRows = dataGridViewOrders.SelectedRows;
            if (selectedRows.Count > 0)
            {
                var selectedRow = selectedRows[0];
                textBoxOrderId.Text = selectedRow.Cells[0].Value.ToString();
                textBoxOrderSupplier.Text = selectedRow.Cells[1].Value.ToString();
                numericUpDownOrderCost.Value = Convert.ToInt32(selectedRow.Cells[2].Value.ToString());
                textBoxOrderOrderer.Text = selectedRow.Cells[3].Value.ToString();
                textBoxOrderTimeOrdered.Text = selectedRow.Cells[4].Value.ToString();
                textBoxOrderFinisher.Text = selectedRow.Cells[5].Value.ToString();
                textBoxOrderTimeCompleted.Text = selectedRow.Cells[6].Value.ToString();
            }
        }

        virtual protected void DataGridViewOrderConsumables_SelectionChanged(object sender, EventArgs e)
        {
            var selectedRows = dataGridViewOrderConsumables.SelectedRows;
            if (selectedRows.Count > 0)
            {
                var selectedRow = selectedRows[0];
                textBoxOrderConsumablesId.Text = selectedRow.Cells[0].Value.ToString();
                textBoxOrderConsumablesName.Text = selectedRow.Cells[1].Value.ToString();
                numericUpDownOrderConsumablesAmount.Value = Convert.ToInt32(selectedRow.Cells[2].Value.ToString());
            }
        }

        protected void AccountantForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.LoginForm.Show();
        }
    }
}
