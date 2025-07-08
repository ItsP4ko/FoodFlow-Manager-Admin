namespace Vista.UserControls.Pedidos
{
    partial class PedidosUserControlAdminR
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvPedidos = new DataGridView();
            btnEntrar = new Button();
            btnVollver = new Button();
            txtBuscarId = new TextBox();
            txtBuscraDni = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
            SuspendLayout();
            // 
            // dgvPedidos
            // 
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedidos.Location = new Point(221, 29);
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.RowHeadersWidth = 51;
            dgvPedidos.Size = new Size(558, 364);
            dgvPedidos.TabIndex = 0;
            dgvPedidos.CellClick += dgvPedidos_CellClick;
            // 
            // btnEntrar
            // 
            btnEntrar.Location = new Point(701, 364);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(78, 29);
            btnEntrar.TabIndex = 1;
            btnEntrar.Text = "Ver";
            btnEntrar.UseVisualStyleBackColor = true;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // btnVollver
            // 
            btnVollver.Location = new Point(221, 364);
            btnVollver.Name = "btnVollver";
            btnVollver.Size = new Size(76, 29);
            btnVollver.TabIndex = 2;
            btnVollver.Text = "Volver";
            btnVollver.UseVisualStyleBackColor = true;
            btnVollver.Click += btnVollver_Click;
            // 
            // txtBuscarId
            // 
            txtBuscarId.Location = new Point(18, 72);
            txtBuscarId.Name = "txtBuscarId";
            txtBuscarId.Size = new Size(125, 27);
            txtBuscarId.TabIndex = 3;
            txtBuscarId.TextChanged += txtBuscarId_TextChanged;
            // 
            // txtBuscraDni
            // 
            txtBuscraDni.Location = new Point(18, 145);
            txtBuscraDni.Name = "txtBuscraDni";
            txtBuscraDni.Size = new Size(125, 27);
            txtBuscraDni.TabIndex = 4;
            txtBuscraDni.TextChanged += txtBuscraDni_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 49);
            label1.Name = "label1";
            label1.Size = new Size(71, 20);
            label1.TabIndex = 5;
            label1.Text = "IdPedido:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 122);
            label2.Name = "label2";
            label2.Size = new Size(35, 20);
            label2.TabIndex = 6;
            label2.Text = "Dni:";
            // 
            // PedidosUserControlAdminR
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtBuscraDni);
            Controls.Add(txtBuscarId);
            Controls.Add(btnVollver);
            Controls.Add(btnEntrar);
            Controls.Add(dgvPedidos);
            Name = "PedidosUserControlAdminR";
            Size = new Size(800, 422);
            Load += PedidosUserControlAdminR_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPedidos;
        private Button btnEntrar;
        private Button btnVollver;
        private TextBox txtBuscarId;
        private TextBox txtBuscraDni;
        private Label label1;
        private Label label2;
    }
}
