﻿
namespace BarbershopMDM.Forms
{
    partial class AccountantForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewConsumables = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAddConsumablesToOrder = new System.Windows.Forms.Button();
            this.buttonRemoveConsumables = new System.Windows.Forms.Button();
            this.numericUpDownConsumablesAmount = new System.Windows.Forms.NumericUpDown();
            this.buttonEditConsumables = new System.Windows.Forms.Button();
            this.buttonCancelConsumables = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAddConsumables = new System.Windows.Forms.Button();
            this.textBoxConsumablesId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxConsumablesName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonAbortOrder = new System.Windows.Forms.Button();
            this.numericUpDownOrderCost = new System.Windows.Forms.NumericUpDown();
            this.textBoxOrderTimeCompleted = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxOrderFinisher = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxOrderTimeOrdered = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxOrderOrderer = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxOrderSupplier = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxOrderId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonUpdateOrder = new System.Windows.Forms.Button();
            this.buttonCancelOrder = new System.Windows.Forms.Button();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonRemoveOrderConsumables = new System.Windows.Forms.Button();
            this.numericUpDownOrderConsumablesAmount = new System.Windows.Forms.NumericUpDown();
            this.buttonCancelOrderConsumables = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewOrderConsumables = new System.Windows.Forms.DataGridView();
            this.buttonUpdateOrderConsumables = new System.Windows.Forms.Button();
            this.textBoxOrderConsumablesId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxOrderConsumablesName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonAddSupplierToOrder = new System.Windows.Forms.Button();
            this.numericUpDownORGN = new System.Windows.Forms.NumericUpDown();
            this.buttonRemoveSupplier = new System.Windows.Forms.Button();
            this.buttonEditSupplier = new System.Windows.Forms.Button();
            this.buttonCancelSupplier = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewSuppliers = new System.Windows.Forms.DataGridView();
            this.buttonAddSupplier = new System.Windows.Forms.Button();
            this.textBoxSupplierNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSupplierName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsumables)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConsumablesAmount)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOrderCost)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOrderConsumablesAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderConsumables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownORGN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSuppliers)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewConsumables
            // 
            this.dataGridViewConsumables.AllowUserToAddRows = false;
            this.dataGridViewConsumables.AllowUserToDeleteRows = false;
            this.dataGridViewConsumables.AllowUserToResizeColumns = false;
            this.dataGridViewConsumables.AllowUserToResizeRows = false;
            this.dataGridViewConsumables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewConsumables.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewConsumables.Name = "dataGridViewConsumables";
            this.dataGridViewConsumables.ReadOnly = true;
            this.dataGridViewConsumables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewConsumables.Size = new System.Drawing.Size(469, 124);
            this.dataGridViewConsumables.TabIndex = 1;
            this.dataGridViewConsumables.SelectionChanged += new System.EventHandler(this.DataGridViewConsumables_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAddConsumablesToOrder);
            this.groupBox1.Controls.Add(this.buttonRemoveConsumables);
            this.groupBox1.Controls.Add(this.numericUpDownConsumablesAmount);
            this.groupBox1.Controls.Add(this.buttonEditConsumables);
            this.groupBox1.Controls.Add(this.buttonCancelConsumables);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dataGridViewConsumables);
            this.groupBox1.Controls.Add(this.buttonAddConsumables);
            this.groupBox1.Controls.Add(this.textBoxConsumablesId);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxConsumablesName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 256);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Расходные материалы";
            // 
            // buttonAddConsumablesToOrder
            // 
            this.buttonAddConsumablesToOrder.Location = new System.Drawing.Point(87, 227);
            this.buttonAddConsumablesToOrder.Name = "buttonAddConsumablesToOrder";
            this.buttonAddConsumablesToOrder.Size = new System.Drawing.Size(107, 23);
            this.buttonAddConsumablesToOrder.TabIndex = 19;
            this.buttonAddConsumablesToOrder.Text = "Добавить в заказ";
            this.buttonAddConsumablesToOrder.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveConsumables
            // 
            this.buttonRemoveConsumables.Location = new System.Drawing.Point(281, 227);
            this.buttonRemoveConsumables.Name = "buttonRemoveConsumables";
            this.buttonRemoveConsumables.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveConsumables.TabIndex = 15;
            this.buttonRemoveConsumables.Text = "Удалить";
            this.buttonRemoveConsumables.UseVisualStyleBackColor = true;
            this.buttonRemoveConsumables.Click += new System.EventHandler(this.ButtonRemoveConsumables_Click);
            // 
            // numericUpDownConsumablesAmount
            // 
            this.numericUpDownConsumablesAmount.Location = new System.Drawing.Point(107, 201);
            this.numericUpDownConsumablesAmount.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.numericUpDownConsumablesAmount.Name = "numericUpDownConsumablesAmount";
            this.numericUpDownConsumablesAmount.Size = new System.Drawing.Size(368, 20);
            this.numericUpDownConsumablesAmount.TabIndex = 18;
            // 
            // buttonEditConsumables
            // 
            this.buttonEditConsumables.Location = new System.Drawing.Point(200, 227);
            this.buttonEditConsumables.Name = "buttonEditConsumables";
            this.buttonEditConsumables.Size = new System.Drawing.Size(75, 23);
            this.buttonEditConsumables.TabIndex = 16;
            this.buttonEditConsumables.Text = "Изменить";
            this.buttonEditConsumables.UseVisualStyleBackColor = true;
            this.buttonEditConsumables.Click += new System.EventHandler(this.ButtonEditConsumables_Click);
            // 
            // buttonCancelConsumables
            // 
            this.buttonCancelConsumables.Location = new System.Drawing.Point(400, 227);
            this.buttonCancelConsumables.Name = "buttonCancelConsumables";
            this.buttonCancelConsumables.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelConsumables.TabIndex = 17;
            this.buttonCancelConsumables.Text = "Отмена";
            this.buttonCancelConsumables.UseVisualStyleBackColor = true;
            this.buttonCancelConsumables.Click += new System.EventHandler(this.ButtonCancelConsumables_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Кол-во на складе";
            // 
            // buttonAddConsumables
            // 
            this.buttonAddConsumables.Location = new System.Drawing.Point(6, 227);
            this.buttonAddConsumables.Name = "buttonAddConsumables";
            this.buttonAddConsumables.Size = new System.Drawing.Size(75, 23);
            this.buttonAddConsumables.TabIndex = 11;
            this.buttonAddConsumables.Text = "Добавить";
            this.buttonAddConsumables.UseVisualStyleBackColor = true;
            this.buttonAddConsumables.Click += new System.EventHandler(this.ButtonAddConsumables_Click);
            // 
            // textBoxConsumablesId
            // 
            this.textBoxConsumablesId.Enabled = false;
            this.textBoxConsumablesId.Location = new System.Drawing.Point(107, 149);
            this.textBoxConsumablesId.MaxLength = 200;
            this.textBoxConsumablesId.Name = "textBoxConsumablesId";
            this.textBoxConsumablesId.ReadOnly = true;
            this.textBoxConsumablesId.Size = new System.Drawing.Size(368, 20);
            this.textBoxConsumablesId.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Наименование";
            // 
            // textBoxConsumablesName
            // 
            this.textBoxConsumablesName.Location = new System.Drawing.Point(107, 175);
            this.textBoxConsumablesName.MaxLength = 200;
            this.textBoxConsumablesName.Name = "textBoxConsumablesName";
            this.textBoxConsumablesName.Size = new System.Drawing.Size(368, 20);
            this.textBoxConsumablesName.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Код";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 496);
            this.panel1.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.dataGridViewOrders);
            this.groupBox3.Location = new System.Drawing.Point(3, 265);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(968, 497);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Заказы";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonAbortOrder);
            this.groupBox5.Controls.Add(this.numericUpDownOrderCost);
            this.groupBox5.Controls.Add(this.textBoxOrderTimeCompleted);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.textBoxOrderFinisher);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.textBoxOrderTimeOrdered);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.textBoxOrderOrderer);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.textBoxOrderSupplier);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.textBoxOrderId);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.buttonUpdateOrder);
            this.groupBox5.Controls.Add(this.buttonCancelOrder);
            this.groupBox5.Controls.Add(this.buttonCreateOrder);
            this.groupBox5.Location = new System.Drawing.Point(6, 19);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(475, 256);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Заказ";
            // 
            // buttonAbortOrder
            // 
            this.buttonAbortOrder.Location = new System.Drawing.Point(168, 227);
            this.buttonAbortOrder.Name = "buttonAbortOrder";
            this.buttonAbortOrder.Size = new System.Drawing.Size(75, 23);
            this.buttonAbortOrder.TabIndex = 33;
            this.buttonAbortOrder.Text = "Отменить";
            this.buttonAbortOrder.UseVisualStyleBackColor = true;
            // 
            // numericUpDownOrderCost
            // 
            this.numericUpDownOrderCost.Location = new System.Drawing.Point(112, 71);
            this.numericUpDownOrderCost.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.numericUpDownOrderCost.Name = "numericUpDownOrderCost";
            this.numericUpDownOrderCost.Size = new System.Drawing.Size(357, 20);
            this.numericUpDownOrderCost.TabIndex = 32;
            // 
            // textBoxOrderTimeCompleted
            // 
            this.textBoxOrderTimeCompleted.Enabled = false;
            this.textBoxOrderTimeCompleted.Location = new System.Drawing.Point(112, 175);
            this.textBoxOrderTimeCompleted.MaxLength = 200;
            this.textBoxOrderTimeCompleted.Name = "textBoxOrderTimeCompleted";
            this.textBoxOrderTimeCompleted.ReadOnly = true;
            this.textBoxOrderTimeCompleted.Size = new System.Drawing.Size(357, 20);
            this.textBoxOrderTimeCompleted.TabIndex = 30;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 178);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 13);
            this.label16.TabIndex = 31;
            this.label16.Text = "Дата принятия";
            // 
            // textBoxOrderFinisher
            // 
            this.textBoxOrderFinisher.Enabled = false;
            this.textBoxOrderFinisher.Location = new System.Drawing.Point(112, 149);
            this.textBoxOrderFinisher.MaxLength = 200;
            this.textBoxOrderFinisher.Name = "textBoxOrderFinisher";
            this.textBoxOrderFinisher.ReadOnly = true;
            this.textBoxOrderFinisher.Size = new System.Drawing.Size(357, 20);
            this.textBoxOrderFinisher.TabIndex = 28;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 152);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "Принял";
            // 
            // textBoxOrderTimeOrdered
            // 
            this.textBoxOrderTimeOrdered.Enabled = false;
            this.textBoxOrderTimeOrdered.Location = new System.Drawing.Point(112, 123);
            this.textBoxOrderTimeOrdered.MaxLength = 200;
            this.textBoxOrderTimeOrdered.Name = "textBoxOrderTimeOrdered";
            this.textBoxOrderTimeOrdered.ReadOnly = true;
            this.textBoxOrderTimeOrdered.Size = new System.Drawing.Size(357, 20);
            this.textBoxOrderTimeOrdered.TabIndex = 26;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 126);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Дата оформления";
            // 
            // textBoxOrderOrderer
            // 
            this.textBoxOrderOrderer.Enabled = false;
            this.textBoxOrderOrderer.Location = new System.Drawing.Point(112, 97);
            this.textBoxOrderOrderer.MaxLength = 200;
            this.textBoxOrderOrderer.Name = "textBoxOrderOrderer";
            this.textBoxOrderOrderer.ReadOnly = true;
            this.textBoxOrderOrderer.Size = new System.Drawing.Size(357, 20);
            this.textBoxOrderOrderer.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Оформил";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(33, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Цена";
            // 
            // textBoxOrderSupplier
            // 
            this.textBoxOrderSupplier.Enabled = false;
            this.textBoxOrderSupplier.Location = new System.Drawing.Point(112, 45);
            this.textBoxOrderSupplier.MaxLength = 200;
            this.textBoxOrderSupplier.Name = "textBoxOrderSupplier";
            this.textBoxOrderSupplier.ReadOnly = true;
            this.textBoxOrderSupplier.Size = new System.Drawing.Size(357, 20);
            this.textBoxOrderSupplier.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Поставщик";
            // 
            // textBoxOrderId
            // 
            this.textBoxOrderId.Enabled = false;
            this.textBoxOrderId.Location = new System.Drawing.Point(112, 19);
            this.textBoxOrderId.MaxLength = 200;
            this.textBoxOrderId.Name = "textBoxOrderId";
            this.textBoxOrderId.ReadOnly = true;
            this.textBoxOrderId.Size = new System.Drawing.Size(357, 20);
            this.textBoxOrderId.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Код";
            // 
            // buttonUpdateOrder
            // 
            this.buttonUpdateOrder.Location = new System.Drawing.Point(87, 227);
            this.buttonUpdateOrder.Name = "buttonUpdateOrder";
            this.buttonUpdateOrder.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateOrder.TabIndex = 15;
            this.buttonUpdateOrder.Text = "Обновить";
            this.buttonUpdateOrder.UseVisualStyleBackColor = true;
            // 
            // buttonCancelOrder
            // 
            this.buttonCancelOrder.Location = new System.Drawing.Point(394, 227);
            this.buttonCancelOrder.Name = "buttonCancelOrder";
            this.buttonCancelOrder.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelOrder.TabIndex = 17;
            this.buttonCancelOrder.Text = "Отмена";
            this.buttonCancelOrder.UseVisualStyleBackColor = true;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(6, 227);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateOrder.TabIndex = 11;
            this.buttonCreateOrder.Text = "Оформить";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonRemoveOrderConsumables);
            this.groupBox4.Controls.Add(this.numericUpDownOrderConsumablesAmount);
            this.groupBox4.Controls.Add(this.buttonCancelOrderConsumables);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.dataGridViewOrderConsumables);
            this.groupBox4.Controls.Add(this.buttonUpdateOrderConsumables);
            this.groupBox4.Controls.Add(this.textBoxOrderConsumablesId);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.textBoxOrderConsumablesName);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(487, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(475, 256);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Расходные материалы";
            // 
            // buttonRemoveOrderConsumables
            // 
            this.buttonRemoveOrderConsumables.Location = new System.Drawing.Point(87, 227);
            this.buttonRemoveOrderConsumables.Name = "buttonRemoveOrderConsumables";
            this.buttonRemoveOrderConsumables.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveOrderConsumables.TabIndex = 15;
            this.buttonRemoveOrderConsumables.Text = "Убрать";
            this.buttonRemoveOrderConsumables.UseVisualStyleBackColor = true;
            // 
            // numericUpDownOrderConsumablesAmount
            // 
            this.numericUpDownOrderConsumablesAmount.Location = new System.Drawing.Point(101, 201);
            this.numericUpDownOrderConsumablesAmount.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.numericUpDownOrderConsumablesAmount.Name = "numericUpDownOrderConsumablesAmount";
            this.numericUpDownOrderConsumablesAmount.Size = new System.Drawing.Size(368, 20);
            this.numericUpDownOrderConsumablesAmount.TabIndex = 18;
            // 
            // buttonCancelOrderConsumables
            // 
            this.buttonCancelOrderConsumables.Location = new System.Drawing.Point(394, 227);
            this.buttonCancelOrderConsumables.Name = "buttonCancelOrderConsumables";
            this.buttonCancelOrderConsumables.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelOrderConsumables.TabIndex = 17;
            this.buttonCancelOrderConsumables.Text = "Отмена";
            this.buttonCancelOrderConsumables.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 204);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Кол-во в заказе";
            // 
            // dataGridViewOrderConsumables
            // 
            this.dataGridViewOrderConsumables.AllowUserToAddRows = false;
            this.dataGridViewOrderConsumables.AllowUserToDeleteRows = false;
            this.dataGridViewOrderConsumables.AllowUserToResizeColumns = false;
            this.dataGridViewOrderConsumables.AllowUserToResizeRows = false;
            this.dataGridViewOrderConsumables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderConsumables.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewOrderConsumables.Name = "dataGridViewOrderConsumables";
            this.dataGridViewOrderConsumables.ReadOnly = true;
            this.dataGridViewOrderConsumables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrderConsumables.Size = new System.Drawing.Size(463, 124);
            this.dataGridViewOrderConsumables.TabIndex = 1;
            // 
            // buttonUpdateOrderConsumables
            // 
            this.buttonUpdateOrderConsumables.Location = new System.Drawing.Point(6, 227);
            this.buttonUpdateOrderConsumables.Name = "buttonUpdateOrderConsumables";
            this.buttonUpdateOrderConsumables.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateOrderConsumables.TabIndex = 11;
            this.buttonUpdateOrderConsumables.Text = "Изменить";
            this.buttonUpdateOrderConsumables.UseVisualStyleBackColor = true;
            // 
            // textBoxOrderConsumablesId
            // 
            this.textBoxOrderConsumablesId.Enabled = false;
            this.textBoxOrderConsumablesId.Location = new System.Drawing.Point(101, 149);
            this.textBoxOrderConsumablesId.MaxLength = 200;
            this.textBoxOrderConsumablesId.Name = "textBoxOrderConsumablesId";
            this.textBoxOrderConsumablesId.ReadOnly = true;
            this.textBoxOrderConsumablesId.Size = new System.Drawing.Size(368, 20);
            this.textBoxOrderConsumablesId.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 178);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Наименование";
            // 
            // textBoxOrderConsumablesName
            // 
            this.textBoxOrderConsumablesName.Location = new System.Drawing.Point(101, 175);
            this.textBoxOrderConsumablesName.MaxLength = 200;
            this.textBoxOrderConsumablesName.Name = "textBoxOrderConsumablesName";
            this.textBoxOrderConsumablesName.ReadOnly = true;
            this.textBoxOrderConsumablesName.Size = new System.Drawing.Size(368, 20);
            this.textBoxOrderConsumablesName.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Код";
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.AllowUserToAddRows = false;
            this.dataGridViewOrders.AllowUserToDeleteRows = false;
            this.dataGridViewOrders.AllowUserToResizeColumns = false;
            this.dataGridViewOrders.AllowUserToResizeRows = false;
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Location = new System.Drawing.Point(6, 281);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.ReadOnly = true;
            this.dataGridViewOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrders.Size = new System.Drawing.Size(956, 210);
            this.dataGridViewOrders.TabIndex = 2;
            this.dataGridViewOrders.SelectionChanged += new System.EventHandler(this.DataGridViewOrders_SelectionChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonAddSupplierToOrder);
            this.groupBox2.Controls.Add(this.numericUpDownORGN);
            this.groupBox2.Controls.Add(this.buttonRemoveSupplier);
            this.groupBox2.Controls.Add(this.buttonEditSupplier);
            this.groupBox2.Controls.Add(this.buttonCancelSupplier);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dataGridViewSuppliers);
            this.groupBox2.Controls.Add(this.buttonAddSupplier);
            this.groupBox2.Controls.Add(this.textBoxSupplierNumber);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBoxSupplierName);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(490, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(481, 256);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Поставщики";
            // 
            // buttonAddSupplierToOrder
            // 
            this.buttonAddSupplierToOrder.Location = new System.Drawing.Point(87, 227);
            this.buttonAddSupplierToOrder.Name = "buttonAddSupplierToOrder";
            this.buttonAddSupplierToOrder.Size = new System.Drawing.Size(107, 23);
            this.buttonAddSupplierToOrder.TabIndex = 20;
            this.buttonAddSupplierToOrder.Text = "Указать в заказе";
            this.buttonAddSupplierToOrder.UseVisualStyleBackColor = true;
            // 
            // numericUpDownORGN
            // 
            this.numericUpDownORGN.Location = new System.Drawing.Point(95, 149);
            this.numericUpDownORGN.Maximum = new decimal(new int[] {
            1316134911,
            2328,
            0,
            0});
            this.numericUpDownORGN.Name = "numericUpDownORGN";
            this.numericUpDownORGN.Size = new System.Drawing.Size(380, 20);
            this.numericUpDownORGN.TabIndex = 0;
            // 
            // buttonRemoveSupplier
            // 
            this.buttonRemoveSupplier.Location = new System.Drawing.Point(281, 227);
            this.buttonRemoveSupplier.Name = "buttonRemoveSupplier";
            this.buttonRemoveSupplier.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveSupplier.TabIndex = 15;
            this.buttonRemoveSupplier.Text = "Удалить";
            this.buttonRemoveSupplier.UseVisualStyleBackColor = true;
            this.buttonRemoveSupplier.Click += new System.EventHandler(this.ButtonRemoveSupplier_Click);
            // 
            // buttonEditSupplier
            // 
            this.buttonEditSupplier.Location = new System.Drawing.Point(200, 227);
            this.buttonEditSupplier.Name = "buttonEditSupplier";
            this.buttonEditSupplier.Size = new System.Drawing.Size(75, 23);
            this.buttonEditSupplier.TabIndex = 16;
            this.buttonEditSupplier.Text = "Изменить";
            this.buttonEditSupplier.UseVisualStyleBackColor = true;
            this.buttonEditSupplier.Click += new System.EventHandler(this.ButtonEditSupplier_Click);
            // 
            // buttonCancelSupplier
            // 
            this.buttonCancelSupplier.Location = new System.Drawing.Point(400, 227);
            this.buttonCancelSupplier.Name = "buttonCancelSupplier";
            this.buttonCancelSupplier.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelSupplier.TabIndex = 17;
            this.buttonCancelSupplier.Text = "Отмена";
            this.buttonCancelSupplier.UseVisualStyleBackColor = true;
            this.buttonCancelSupplier.Click += new System.EventHandler(this.ButtonCancelSupplier_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Телефон";
            // 
            // dataGridViewSuppliers
            // 
            this.dataGridViewSuppliers.AllowUserToAddRows = false;
            this.dataGridViewSuppliers.AllowUserToDeleteRows = false;
            this.dataGridViewSuppliers.AllowUserToResizeColumns = false;
            this.dataGridViewSuppliers.AllowUserToResizeRows = false;
            this.dataGridViewSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSuppliers.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewSuppliers.Name = "dataGridViewSuppliers";
            this.dataGridViewSuppliers.ReadOnly = true;
            this.dataGridViewSuppliers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSuppliers.Size = new System.Drawing.Size(469, 124);
            this.dataGridViewSuppliers.TabIndex = 1;
            this.dataGridViewSuppliers.SelectionChanged += new System.EventHandler(this.DataGridViewSuppliers_SelectionChanged);
            // 
            // buttonAddSupplier
            // 
            this.buttonAddSupplier.Location = new System.Drawing.Point(6, 227);
            this.buttonAddSupplier.Name = "buttonAddSupplier";
            this.buttonAddSupplier.Size = new System.Drawing.Size(75, 23);
            this.buttonAddSupplier.TabIndex = 11;
            this.buttonAddSupplier.Text = "Добавить";
            this.buttonAddSupplier.UseVisualStyleBackColor = true;
            this.buttonAddSupplier.Click += new System.EventHandler(this.ButtonAddSupplier_Click);
            // 
            // textBoxSupplierNumber
            // 
            this.textBoxSupplierNumber.Location = new System.Drawing.Point(95, 201);
            this.textBoxSupplierNumber.MaxLength = 56;
            this.textBoxSupplierNumber.Name = "textBoxSupplierNumber";
            this.textBoxSupplierNumber.Size = new System.Drawing.Size(380, 20);
            this.textBoxSupplierNumber.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Наименование";
            // 
            // textBoxSupplierName
            // 
            this.textBoxSupplierName.Location = new System.Drawing.Point(95, 175);
            this.textBoxSupplierName.MaxLength = 200;
            this.textBoxSupplierName.Name = "textBoxSupplierName";
            this.textBoxSupplierName.Size = new System.Drawing.Size(380, 20);
            this.textBoxSupplierName.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "ОГРН";
            // 
            // AccountantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 520);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountantForm";
            this.Text = "ИС Парикмахерская. Бухгалтер";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AccountantForm_FormClosed);
            this.Shown += new System.EventHandler(this.AccountantForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsumables)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConsumablesAmount)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOrderCost)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOrderConsumablesAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderConsumables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownORGN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSuppliers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewConsumables;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxConsumablesId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxConsumablesName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRemoveConsumables;
        private System.Windows.Forms.Button buttonEditConsumables;
        private System.Windows.Forms.Button buttonCancelConsumables;
        private System.Windows.Forms.Button buttonAddConsumables;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonRemoveSupplier;
        private System.Windows.Forms.Button buttonEditSupplier;
        private System.Windows.Forms.Button buttonCancelSupplier;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewSuppliers;
        private System.Windows.Forms.Button buttonAddSupplier;
        private System.Windows.Forms.TextBox textBoxSupplierNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxSupplierName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDownORGN;
        private System.Windows.Forms.NumericUpDown numericUpDownConsumablesAmount;
        private System.Windows.Forms.Button buttonAddConsumablesToOrder;
        private System.Windows.Forms.Button buttonAddSupplierToOrder;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button buttonRemoveOrderConsumables;
        private System.Windows.Forms.NumericUpDown numericUpDownOrderConsumablesAmount;
        private System.Windows.Forms.Button buttonCancelOrderConsumables;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridViewOrderConsumables;
        private System.Windows.Forms.Button buttonUpdateOrderConsumables;
        private System.Windows.Forms.TextBox textBoxOrderConsumablesId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxOrderConsumablesName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonUpdateOrder;
        private System.Windows.Forms.Button buttonCancelOrder;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.TextBox textBoxOrderTimeCompleted;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxOrderFinisher;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxOrderTimeOrdered;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxOrderOrderer;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxOrderSupplier;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxOrderId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDownOrderCost;
        private System.Windows.Forms.Button buttonAbortOrder;
    }
}