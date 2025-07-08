namespace Vista.Usuarios.AdminCocina
{
    partial class PedidosAdminCocina
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
            DGVPedidosAdminCocina = new DataGridView();
            menuStrip1 = new MenuStrip();
            volverToolStripMenuItem = new ToolStripMenuItem();
            buscarToolStripMenuItem = new ToolStripMenuItem();
            porUsuarioToolStripMenuItem = new ToolStripMenuItem();
            toolStripTxtUsuario = new ToolStripTextBox();
            porIdToolStripMenuItem = new ToolStripMenuItem();
            toolStripTxtIdPedido = new ToolStripTextBox();
            btnEntrarDGV = new Button();
            btnVolverDGV = new Button();
            btnConfirmar = new Button();
            ((System.ComponentModel.ISupportInitialize)DGVPedidosAdminCocina).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // DGVPedidosAdminCocina
            // 
            DGVPedidosAdminCocina.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVPedidosAdminCocina.EditMode = DataGridViewEditMode.EditOnEnter;
            DGVPedidosAdminCocina.Location = new Point(165, 45);
            DGVPedidosAdminCocina.Name = "DGVPedidosAdminCocina";
            DGVPedidosAdminCocina.RowHeadersWidth = 51;
            DGVPedidosAdminCocina.Size = new Size(776, 393);
            DGVPedidosAdminCocina.TabIndex = 0;
            DGVPedidosAdminCocina.CellClick += DGVPedidosAdminCocina_CellClick;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { volverToolStripMenuItem, buscarToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(953, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // volverToolStripMenuItem
            // 
            volverToolStripMenuItem.Name = "volverToolStripMenuItem";
            volverToolStripMenuItem.Size = new Size(64, 24);
            volverToolStripMenuItem.Text = "Volver";
            volverToolStripMenuItem.Click += volverToolStripMenuItem_Click;
            // 
            // buscarToolStripMenuItem
            // 
            buscarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { porUsuarioToolStripMenuItem, porIdToolStripMenuItem });
            buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            buscarToolStripMenuItem.Size = new Size(66, 24);
            buscarToolStripMenuItem.Text = "Buscar";
            // 
            // porUsuarioToolStripMenuItem
            // 
            porUsuarioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripTxtUsuario });
            porUsuarioToolStripMenuItem.Name = "porUsuarioToolStripMenuItem";
            porUsuarioToolStripMenuItem.Size = new Size(138, 26);
            porUsuarioToolStripMenuItem.Text = "Por dni";
            // 
            // toolStripTxtUsuario
            // 
            toolStripTxtUsuario.Name = "toolStripTxtUsuario";
            toolStripTxtUsuario.Size = new Size(100, 27);
            toolStripTxtUsuario.TextChanged += toolStripTxtUsuario_TextChanged;
            // 
            // porIdToolStripMenuItem
            // 
            porIdToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripTxtIdPedido });
            porIdToolStripMenuItem.Name = "porIdToolStripMenuItem";
            porIdToolStripMenuItem.Size = new Size(138, 26);
            porIdToolStripMenuItem.Text = "Por Id";
            // 
            // toolStripTxtIdPedido
            // 
            toolStripTxtIdPedido.Name = "toolStripTxtIdPedido";
            toolStripTxtIdPedido.Size = new Size(100, 27);
            toolStripTxtIdPedido.TextChanged += toolStripTxtIdPedido_TextChanged;
            // 
            // btnEntrarDGV
            // 
            btnEntrarDGV.Location = new Point(880, 409);
            btnEntrarDGV.Name = "btnEntrarDGV";
            btnEntrarDGV.Size = new Size(61, 29);
            btnEntrarDGV.TabIndex = 2;
            btnEntrarDGV.Text = "Entrar";
            btnEntrarDGV.UseVisualStyleBackColor = true;
            btnEntrarDGV.Click += btnEntrarDGV_Click;
            // 
            // btnVolverDGV
            // 
            btnVolverDGV.Location = new Point(815, 409);
            btnVolverDGV.Name = "btnVolverDGV";
            btnVolverDGV.Size = new Size(59, 29);
            btnVolverDGV.TabIndex = 3;
            btnVolverDGV.Text = "Vovler";
            btnVolverDGV.UseVisualStyleBackColor = true;
            btnVolverDGV.Click += btnVolverDGV_Click;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(27, 232);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(94, 29);
            btnConfirmar.TabIndex = 4;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // PedidosAdminCocina
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(953, 450);
            Controls.Add(btnConfirmar);
            Controls.Add(btnVolverDGV);
            Controls.Add(btnEntrarDGV);
            Controls.Add(DGVPedidosAdminCocina);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "PedidosAdminCocina";
            Text = "PedidosAdminCocina";
            Load += PedidosAdminCocina_Load;
            ((System.ComponentModel.ISupportInitialize)DGVPedidosAdminCocina).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem volverToolStripMenuItem;
        private ToolStripMenuItem buscarToolStripMenuItem;
        private ToolStripMenuItem porUsuarioToolStripMenuItem;
        private ToolStripTextBox toolStripTxtUsuario;
        private ToolStripMenuItem porIdToolStripMenuItem;
        private ToolStripTextBox toolStripTxtIdPedido;
        private Button btnEntrarDGV;
        private Button btnVolverDGV;
        public DataGridView DGVPedidosAdminCocina;
        private Button btnConfirmar;
    }
}