namespace Vista.UserControls.Pedidos
{
    partial class CajeroPedidoAdd
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
            dgvPlatos = new DataGridView();
            btnAgregarPedido = new Button();
            txtDireccion = new TextBox();
            txtDni = new TextBox();
            txtPlato = new TextBox();
            lblTotal = new Label();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            btnAsociar = new Button();
            btnVerPedido = new Button();
            btnVerPlatos = new Button();
            dgvExtras = new DataGridView();
            dgvPedido = new DataGridView();
            btnElimLinea = new Button();
            label3 = new Label();
            cbCategoria = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvPlatos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvExtras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPedido).BeginInit();
            SuspendLayout();
            // 
            // dgvPlatos
            // 
            dgvPlatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlatos.Location = new Point(792, 3);
            dgvPlatos.Name = "dgvPlatos";
            dgvPlatos.RowHeadersWidth = 51;
            dgvPlatos.Size = new Size(940, 378);
            dgvPlatos.TabIndex = 0;
            // 
            // btnAgregarPedido
            // 
            btnAgregarPedido.Location = new Point(20, 448);
            btnAgregarPedido.Name = "btnAgregarPedido";
            btnAgregarPedido.Size = new Size(125, 29);
            btnAgregarPedido.TabIndex = 1;
            btnAgregarPedido.Text = "Confirmar";
            btnAgregarPedido.UseVisualStyleBackColor = true;
            btnAgregarPedido.Click += btnAgregarPedido_Click;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(20, 102);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(125, 27);
            txtDireccion.TabIndex = 3;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(20, 45);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(125, 27);
            txtDni.TabIndex = 4;
            // 
            // txtPlato
            // 
            txtPlato.Location = new Point(20, 158);
            txtPlato.Name = "txtPlato";
            txtPlato.Size = new Size(125, 27);
            txtPlato.TabIndex = 5;
            txtPlato.TextChanged += txtPlato_TextChanged;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(20, 348);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(49, 20);
            lblTotal.TabIndex = 6;
            lblTotal.Text = "Total: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 135);
            label2.Name = "label2";
            label2.Size = new Size(94, 20);
            label2.TabIndex = 8;
            label2.Text = "Buscar plato:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 75);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 9;
            label1.Text = "Direccion:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 20);
            label4.Name = "label4";
            label4.Size = new Size(82, 20);
            label4.TabIndex = 11;
            label4.Text = "Dni Cliente";
            // 
            // btnAsociar
            // 
            btnAsociar.Location = new Point(20, 399);
            btnAsociar.Name = "btnAsociar";
            btnAsociar.Size = new Size(125, 29);
            btnAsociar.TabIndex = 12;
            btnAsociar.Text = "Asociar";
            btnAsociar.UseVisualStyleBackColor = true;
            btnAsociar.Click += btnAsociar_Click;
            // 
            // btnVerPedido
            // 
            btnVerPedido.Location = new Point(1667, 348);
            btnVerPedido.Name = "btnVerPedido";
            btnVerPedido.Size = new Size(65, 29);
            btnVerPedido.TabIndex = 13;
            btnVerPedido.Text = "Pedido";
            btnVerPedido.UseVisualStyleBackColor = true;
            btnVerPedido.Click += btnVerPedido_Click;
            // 
            // btnVerPlatos
            // 
            btnVerPlatos.Location = new Point(792, 352);
            btnVerPlatos.Name = "btnVerPlatos";
            btnVerPlatos.Size = new Size(61, 29);
            btnVerPlatos.TabIndex = 14;
            btnVerPlatos.Text = "Platos";
            btnVerPlatos.UseVisualStyleBackColor = true;
            btnVerPlatos.Click += btnVerPlatos_Click;
            // 
            // dgvExtras
            // 
            dgvExtras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExtras.Location = new Point(231, 7);
            dgvExtras.Name = "dgvExtras";
            dgvExtras.RowHeadersWidth = 51;
            dgvExtras.Size = new Size(555, 374);
            dgvExtras.TabIndex = 15;
            dgvExtras.CellValueChanged += DgvExtras_CellValueChanged;
            // 
            // dgvPedido
            // 
            dgvPedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedido.Location = new Point(231, 387);
            dgvPedido.Name = "dgvPedido";
            dgvPedido.RowHeadersWidth = 51;
            dgvPedido.Size = new Size(1028, 298);
            dgvPedido.TabIndex = 16;
            // 
            // btnElimLinea
            // 
            btnElimLinea.Location = new Point(20, 497);
            btnElimLinea.Name = "btnElimLinea";
            btnElimLinea.Size = new Size(125, 29);
            btnElimLinea.TabIndex = 17;
            btnElimLinea.Text = "Eliminar Linea";
            btnElimLinea.UseVisualStyleBackColor = true;
            btnElimLinea.Click += btnElimLinea_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 198);
            label3.Name = "label3";
            label3.Size = new Size(74, 20);
            label3.TabIndex = 22;
            label3.Text = "Categoria";
            // 
            // cbCategoria
            // 
            cbCategoria.FormattingEnabled = true;
            cbCategoria.Location = new Point(20, 221);
            cbCategoria.Name = "cbCategoria";
            cbCategoria.Size = new Size(151, 28);
            cbCategoria.TabIndex = 21;
            cbCategoria.SelectedIndexChanged += cbCategoria_SelectedIndexChanged;
            // 
            // CajeroPedidoAdd
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label3);
            Controls.Add(cbCategoria);
            Controls.Add(btnElimLinea);
            Controls.Add(dgvPedido);
            Controls.Add(dgvExtras);
            Controls.Add(btnVerPlatos);
            Controls.Add(btnVerPedido);
            Controls.Add(btnAsociar);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(lblTotal);
            Controls.Add(txtPlato);
            Controls.Add(txtDni);
            Controls.Add(txtDireccion);
            Controls.Add(btnAgregarPedido);
            Controls.Add(dgvPlatos);
            Name = "CajeroPedidoAdd";
            Size = new Size(1770, 688);
            Load += UserPedidoAdd_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPlatos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvExtras).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPedido).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPlatos;
        private Button btnAgregarPedido;
        private TextBox txtDireccion;
        private TextBox txtDni;
        private TextBox txtPlato;
        private Label lblTotal;
        private Label label2;
        private Label label1;
        private Label label4;
        private Button btnAsociar;
        private Button btnVerPedido;
        private Button btnVerPlatos;
        private DataGridView dgvExtras;
        private DataGridView dgvPedido;
        private Button btnElimLinea;
        private Label label3;
        private ComboBox cbCategoria;
    }
}
