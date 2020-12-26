
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
            this.numericUpDownConsumablesAmount = new System.Windows.Forms.NumericUpDown();
            this.buttonRemoveConsumables = new System.Windows.Forms.Button();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.buttonAddConsumablesToOrder = new System.Windows.Forms.Button();
            this.buttonAddSupplierToOrder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConsumables)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConsumablesAmount)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.groupBox3.Location = new System.Drawing.Point(3, 265);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(968, 497);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Заказы";
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
            // 
            // buttonEditSupplier
            // 
            this.buttonEditSupplier.Location = new System.Drawing.Point(200, 227);
            this.buttonEditSupplier.Name = "buttonEditSupplier";
            this.buttonEditSupplier.Size = new System.Drawing.Size(75, 23);
            this.buttonEditSupplier.TabIndex = 16;
            this.buttonEditSupplier.Text = "Изменить";
            this.buttonEditSupplier.UseVisualStyleBackColor = true;
            // 
            // buttonCancelSupplier
            // 
            this.buttonCancelSupplier.Location = new System.Drawing.Point(400, 227);
            this.buttonCancelSupplier.Name = "buttonCancelSupplier";
            this.buttonCancelSupplier.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelSupplier.TabIndex = 17;
            this.buttonCancelSupplier.Text = "Отмена";
            this.buttonCancelSupplier.UseVisualStyleBackColor = true;
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
            // 
            // textBoxSupplierNumber
            // 
            this.textBoxSupplierNumber.Location = new System.Drawing.Point(95, 201);
            this.textBoxSupplierNumber.MaxLength = 56;
            this.textBoxSupplierNumber.Name = "textBoxSupplierNumber";
            this.textBoxSupplierNumber.PasswordChar = '*';
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
            this.textBoxSupplierName.MaxLength = 20;
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
            // buttonAddConsumablesToOrder
            // 
            this.buttonAddConsumablesToOrder.Location = new System.Drawing.Point(87, 227);
            this.buttonAddConsumablesToOrder.Name = "buttonAddConsumablesToOrder";
            this.buttonAddConsumablesToOrder.Size = new System.Drawing.Size(107, 23);
            this.buttonAddConsumablesToOrder.TabIndex = 19;
            this.buttonAddConsumablesToOrder.Text = "Добавить в заказ";
            this.buttonAddConsumablesToOrder.UseVisualStyleBackColor = true;
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
    }
}