
namespace BarbershopMDM.Forms.EmployeesForms
{
    partial class ManagerForm
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
            this.buttonEditConsumables = new System.Windows.Forms.Button();
            this.buttonFinishOrder = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownORGN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConsumablesAmount)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOrderConsumablesAmount)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOrderCost)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonEditConsumables);
            this.groupBox1.Controls.SetChildIndex(this.label1, 0);
            this.groupBox1.Controls.SetChildIndex(this.textBoxConsumablesName, 0);
            this.groupBox1.Controls.SetChildIndex(this.label2, 0);
            this.groupBox1.Controls.SetChildIndex(this.textBoxConsumablesId, 0);
            this.groupBox1.Controls.SetChildIndex(this.label3, 0);
            this.groupBox1.Controls.SetChildIndex(this.buttonCancelConsumables, 0);
            this.groupBox1.Controls.SetChildIndex(this.numericUpDownConsumablesAmount, 0);
            this.groupBox1.Controls.SetChildIndex(this.buttonEditConsumables, 0);
            // 
            // textBoxConsumablesName
            // 
            this.textBoxConsumablesName.ReadOnly = true;
            // 
            // textBoxSupplierNumber
            // 
            this.textBoxSupplierNumber.ReadOnly = true;
            // 
            // textBoxSupplierName
            // 
            this.textBoxSupplierName.ReadOnly = true;
            // 
            // numericUpDownORGN
            // 
            this.numericUpDownORGN.ReadOnly = true;
            // 
            // numericUpDownOrderConsumablesAmount
            // 
            this.numericUpDownOrderConsumablesAmount.ReadOnly = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonFinishOrder);
            this.groupBox5.Controls.SetChildIndex(this.buttonCancelOrder, 0);
            this.groupBox5.Controls.SetChildIndex(this.label10, 0);
            this.groupBox5.Controls.SetChildIndex(this.textBoxOrderId, 0);
            this.groupBox5.Controls.SetChildIndex(this.label11, 0);
            this.groupBox5.Controls.SetChildIndex(this.textBoxOrderSupplier, 0);
            this.groupBox5.Controls.SetChildIndex(this.label12, 0);
            this.groupBox5.Controls.SetChildIndex(this.label13, 0);
            this.groupBox5.Controls.SetChildIndex(this.textBoxOrderOrderer, 0);
            this.groupBox5.Controls.SetChildIndex(this.label14, 0);
            this.groupBox5.Controls.SetChildIndex(this.textBoxOrderTimeOrdered, 0);
            this.groupBox5.Controls.SetChildIndex(this.label15, 0);
            this.groupBox5.Controls.SetChildIndex(this.textBoxOrderFinisher, 0);
            this.groupBox5.Controls.SetChildIndex(this.label16, 0);
            this.groupBox5.Controls.SetChildIndex(this.textBoxOrderTimeCompleted, 0);
            this.groupBox5.Controls.SetChildIndex(this.numericUpDownOrderCost, 0);
            this.groupBox5.Controls.SetChildIndex(this.buttonFinishOrder, 0);
            // 
            // numericUpDownOrderCost
            // 
            this.numericUpDownOrderCost.ReadOnly = true;
            // 
            // buttonEditConsumables
            // 
            this.buttonEditConsumables.Location = new System.Drawing.Point(6, 227);
            this.buttonEditConsumables.Name = "buttonEditConsumables";
            this.buttonEditConsumables.Size = new System.Drawing.Size(75, 23);
            this.buttonEditConsumables.TabIndex = 19;
            this.buttonEditConsumables.Text = "Изменить";
            this.buttonEditConsumables.UseVisualStyleBackColor = true;
            this.buttonEditConsumables.Click += new System.EventHandler(this.ButtonEditConsumables_Click);
            // 
            // buttonFinishOrder
            // 
            this.buttonFinishOrder.Location = new System.Drawing.Point(6, 227);
            this.buttonFinishOrder.Name = "buttonFinishOrder";
            this.buttonFinishOrder.Size = new System.Drawing.Size(75, 23);
            this.buttonFinishOrder.TabIndex = 33;
            this.buttonFinishOrder.Text = "Принять";
            this.buttonFinishOrder.UseVisualStyleBackColor = true;
            this.buttonFinishOrder.Click += new System.EventHandler(this.ButtonFinishOrder_Click);
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 520);
            this.Name = "ManagerForm";
            this.Text = "ИС Парикмахерская. Администратор";
            this.Shown += new System.EventHandler(this.ManagerForm_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownORGN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownConsumablesAmount)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOrderConsumablesAmount)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOrderCost)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonEditConsumables;
        private System.Windows.Forms.Button buttonFinishOrder;
    }
}