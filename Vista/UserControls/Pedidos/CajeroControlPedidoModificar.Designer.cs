namespace Vista.UserControls.Pedidos
{
    partial class CajeroControlPedidoModificar
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
            btnAgregarPedido = new Button();
            label2 = new Label();
            txtIdPedido = new TextBox();
            label4 = new Label();
            txtDni = new TextBox();
            dgvPedido = new DataGridView();
            dgvLineas = new DataGridView();
            btnLineaEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPedido).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLineas).BeginInit();
            SuspendLayout();
            // 
            // btnAgregarPedido
            // 
            btnAgregarPedido.Location = new Point(20, 352);
            btnAgregarPedido.Name = "btnAgregarPedido";
            btnAgregarPedido.Size = new Size(125, 29);
            btnAgregarPedido.TabIndex = 2;
            btnAgregarPedido.Text = "Eliminar Pedido";
            btnAgregarPedido.UseVisualStyleBackColor = true;
            btnAgregarPedido.Click += btnEliminarPedido_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 79);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 10;
            label2.Text = "Buscar por Id:";
            // 
            // txtIdPedido
            // 
            txtIdPedido.Location = new Point(20, 102);
            txtIdPedido.Name = "txtIdPedido";
            txtIdPedido.Size = new Size(125, 27);
            txtIdPedido.TabIndex = 9;
            txtIdPedido.TextChanged += txtPlato_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 22);
            label4.Name = "label4";
            label4.Size = new Size(82, 20);
            label4.TabIndex = 13;
            label4.Text = "Dni Cliente";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(20, 45);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(125, 27);
            txtDni.TabIndex = 12;
            txtDni.TextChanged += txtDni_TextChanged;
            // 
            // dgvPedido
            // 
            dgvPedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedido.Location = new Point(236, 3);
            dgvPedido.Name = "dgvPedido";
            dgvPedido.RowHeadersWidth = 51;
            dgvPedido.Size = new Size(722, 671);
            dgvPedido.TabIndex = 17;
            dgvPedido.CellClick += dgvPedido_CellClick;
            // 
            // dgvLineas
            // 
            dgvLineas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLineas.Location = new Point(964, 3);
            dgvLineas.Name = "dgvLineas";
            dgvLineas.RowHeadersWidth = 51;
            dgvLineas.Size = new Size(483, 671);
            dgvLineas.TabIndex = 18;
            dgvLineas.CellClick += dgvLineas_CellClick;
            // 
            // btnLineaEliminar
            // 
            btnLineaEliminar.Location = new Point(20, 304);
            btnLineaEliminar.Name = "btnLineaEliminar";
            btnLineaEliminar.Size = new Size(125, 29);
            btnLineaEliminar.TabIndex = 19;
            btnLineaEliminar.Text = "Eliminar Linea";
            btnLineaEliminar.UseVisualStyleBackColor = true;
            btnLineaEliminar.Click += btnLineaEliminar_Click;
            // 
            // CajeroControlPedidoModificar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnLineaEliminar);
            Controls.Add(dgvLineas);
            Controls.Add(dgvPedido);
            Controls.Add(label4);
            Controls.Add(txtDni);
            Controls.Add(label2);
            Controls.Add(txtIdPedido);
            Controls.Add(btnAgregarPedido);
            Name = "CajeroControlPedidoModificar";
            Size = new Size(1770, 688);
            Load += CajeroControlPedidoModificar_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPedido).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLineas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAgregarPedido;
        private Label label2;
        private TextBox txtIdPedido;
        private Label label4;
        private TextBox txtDni;
        private DataGridView dgvPedido;
        private DataGridView dgvLineas;
        private Button btnLineaEliminar;
    }
}
