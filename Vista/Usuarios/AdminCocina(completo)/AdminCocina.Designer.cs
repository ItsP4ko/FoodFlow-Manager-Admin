namespace Vista.Usuarios.AdminCocina
{
    partial class AdminCocina
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
            menuStrip1 = new MenuStrip();
            pedidosToolStripMenuItem = new ToolStripMenuItem();
            extrasToolStripMenuItem = new ToolStripMenuItem();
            agregarToolStripExtra = new ToolStripMenuItem();
            modificarToolStripExtra = new ToolStripMenuItem();
            buscarToolStripMenuItem = new ToolStripMenuItem();
            toolStripTextBox1 = new ToolStripTextBox();
            platosToolStripMenuItem = new ToolStripMenuItem();
            agregraToolStripMenuItem = new ToolStripMenuItem();
            modificarToolStripMenuItem1 = new ToolStripMenuItem();
            buscarToolStripMenuItem1 = new ToolStripMenuItem();
            categoriaToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripTxtCategoria = new ToolStripTextBox();
            nombreToolStripMenuItem = new ToolStripMenuItem();
            toolStripTxtPlato = new ToolStripTextBox();
            categoriaToolStripMenuItem = new ToolStripMenuItem();
            agregarToolStripMenuItem = new ToolStripMenuItem();
            modificarToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            gmailToolStripMenuItem = new ToolStripMenuItem();
            whatsAppToolStripMenuItem = new ToolStripMenuItem();
            pnlBotones = new Panel();
            pnlContenido = new Panel();
            btnSalir = new Button();
            menuStrip1.SuspendLayout();
            pnlContenido.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { pedidosToolStripMenuItem, extrasToolStripMenuItem, platosToolStripMenuItem, categoriaToolStripMenuItem, ayudaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // pedidosToolStripMenuItem
            // 
            pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            pedidosToolStripMenuItem.Size = new Size(75, 24);
            pedidosToolStripMenuItem.Text = "Pedidos";
            pedidosToolStripMenuItem.Click += pedidosToolStripMenuItem_Click;
            // 
            // extrasToolStripMenuItem
            // 
            extrasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { agregarToolStripExtra, modificarToolStripExtra, buscarToolStripMenuItem });
            extrasToolStripMenuItem.Name = "extrasToolStripMenuItem";
            extrasToolStripMenuItem.Size = new Size(62, 24);
            extrasToolStripMenuItem.Text = "Extras";
            // 
            // agregarToolStripExtra
            // 
            agregarToolStripExtra.Name = "agregarToolStripExtra";
            agregarToolStripExtra.Size = new Size(201, 26);
            agregarToolStripExtra.Text = "Agregar";
            agregarToolStripExtra.Click += agregarToolStripExtra_Click;
            // 
            // modificarToolStripExtra
            // 
            modificarToolStripExtra.Name = "modificarToolStripExtra";
            modificarToolStripExtra.Size = new Size(201, 26);
            modificarToolStripExtra.Text = "Modificar Precio";
            modificarToolStripExtra.Click += modificarToolStripExtra_Click;
            // 
            // buscarToolStripMenuItem
            // 
            buscarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripTextBox1 });
            buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            buscarToolStripMenuItem.Size = new Size(201, 26);
            buscarToolStripMenuItem.Text = "Buscar";
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.Size = new Size(100, 27);
            toolStripTextBox1.TextChanged += toolStripTextBox1_TextChanged;
            // 
            // platosToolStripMenuItem
            // 
            platosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { agregraToolStripMenuItem, modificarToolStripMenuItem1, buscarToolStripMenuItem1 });
            platosToolStripMenuItem.Name = "platosToolStripMenuItem";
            platosToolStripMenuItem.Size = new Size(63, 24);
            platosToolStripMenuItem.Text = "Platos";
            // 
            // agregraToolStripMenuItem
            // 
            agregraToolStripMenuItem.Name = "agregraToolStripMenuItem";
            agregraToolStripMenuItem.Size = new Size(224, 26);
            agregraToolStripMenuItem.Text = "Agregra";
            agregraToolStripMenuItem.Click += agregraToolStripMenuItem_Click;
            // 
            // modificarToolStripMenuItem1
            // 
            modificarToolStripMenuItem1.Name = "modificarToolStripMenuItem1";
            modificarToolStripMenuItem1.Size = new Size(224, 26);
            modificarToolStripMenuItem1.Text = "Modificar";
            modificarToolStripMenuItem1.Click += modificarToolStripMenuItem1_Click;
            // 
            // buscarToolStripMenuItem1
            // 
            buscarToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { categoriaToolStripMenuItem1, nombreToolStripMenuItem });
            buscarToolStripMenuItem1.Name = "buscarToolStripMenuItem1";
            buscarToolStripMenuItem1.Size = new Size(224, 26);
            buscarToolStripMenuItem1.Text = "Buscar";
            // 
            // categoriaToolStripMenuItem1
            // 
            categoriaToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { toolStripTxtCategoria });
            categoriaToolStripMenuItem1.Name = "categoriaToolStripMenuItem1";
            categoriaToolStripMenuItem1.Size = new Size(224, 26);
            categoriaToolStripMenuItem1.Text = "Categoria";
            // 
            // toolStripTxtCategoria
            // 
            toolStripTxtCategoria.Name = "toolStripTxtCategoria";
            toolStripTxtCategoria.Size = new Size(100, 27);
            toolStripTxtCategoria.TextChanged += toolStripTxtCategoria_TextChanged;
            // 
            // nombreToolStripMenuItem
            // 
            nombreToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripTxtPlato });
            nombreToolStripMenuItem.Name = "nombreToolStripMenuItem";
            nombreToolStripMenuItem.Size = new Size(224, 26);
            nombreToolStripMenuItem.Text = "Nombre";
            // 
            // toolStripTxtPlato
            // 
            toolStripTxtPlato.Name = "toolStripTxtPlato";
            toolStripTxtPlato.Size = new Size(100, 27);
            toolStripTxtPlato.TextChanged += toolStripTxtPlato_TextChanged;
            // 
            // categoriaToolStripMenuItem
            // 
            categoriaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { agregarToolStripMenuItem, modificarToolStripMenuItem });
            categoriaToolStripMenuItem.Name = "categoriaToolStripMenuItem";
            categoriaToolStripMenuItem.Size = new Size(88, 24);
            categoriaToolStripMenuItem.Text = "Categoria";
            // 
            // agregarToolStripMenuItem
            // 
            agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            agregarToolStripMenuItem.Size = new Size(224, 26);
            agregarToolStripMenuItem.Text = "Agregar";
            agregarToolStripMenuItem.Click += agregarToolStripMenuItem_Click;
            // 
            // modificarToolStripMenuItem
            // 
            modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            modificarToolStripMenuItem.Size = new Size(224, 26);
            modificarToolStripMenuItem.Text = "Modificar";
            modificarToolStripMenuItem.Click += modificarToolStripMenuItem_Click;
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gmailToolStripMenuItem, whatsAppToolStripMenuItem });
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(65, 24);
            ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // gmailToolStripMenuItem
            // 
            gmailToolStripMenuItem.Name = "gmailToolStripMenuItem";
            gmailToolStripMenuItem.Size = new Size(161, 26);
            gmailToolStripMenuItem.Text = "Gmail";
            gmailToolStripMenuItem.Click += gmailToolStripMenuItem_Click;
            // 
            // whatsAppToolStripMenuItem
            // 
            whatsAppToolStripMenuItem.Name = "whatsAppToolStripMenuItem";
            whatsAppToolStripMenuItem.Size = new Size(161, 26);
            whatsAppToolStripMenuItem.Text = "WhatsApp";
            whatsAppToolStripMenuItem.Click += whatsAppToolStripMenuItem_Click;
            // 
            // pnlBotones
            // 
            pnlBotones.Location = new Point(0, 31);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(225, 416);
            pnlBotones.TabIndex = 2;
            // 
            // pnlContenido
            // 
            pnlContenido.Controls.Add(btnSalir);
            pnlContenido.Location = new Point(231, 31);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Size = new Size(569, 422);
            pnlContenido.TabIndex = 3;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(706, 390);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(94, 29);
            btnSalir.TabIndex = 0;
            btnSalir.Text = "Cerrar";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // AdminCocina
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlContenido);
            Controls.Add(pnlBotones);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "AdminCocina";
            Text = "AdminCocina";
            Load += AdminCocina_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            pnlContenido.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem pedidosToolStripMenuItem;
        private ToolStripMenuItem extrasToolStripMenuItem;
        private ToolStripMenuItem platosToolStripMenuItem;
        private ToolStripMenuItem agregarToolStripExtra;
        private ToolStripMenuItem modificarToolStripExtra;
        private ToolStripMenuItem eliminarToolStripExtra;
        private ToolStripMenuItem agregraToolStripMenuItem;
        private ToolStripMenuItem modificarToolStripMenuItem1;
        private ToolStripMenuItem eliminarToolStripMenuItem1;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private Panel pnlBotones;
        private Panel pnlContenido;
        private Button btnSalir;
        private ToolStripMenuItem gmailToolStripMenuItem;
        private ToolStripMenuItem whatsAppToolStripMenuItem;
        private ToolStripMenuItem buscarToolStripMenuItem;
        private ToolStripTextBox toolStripTextBox1;
        private ToolStripMenuItem buscarToolStripMenuItem1;
        private ToolStripMenuItem categoriaToolStripMenuItem;
        private ToolStripMenuItem agregarToolStripMenuItem;
        private ToolStripMenuItem modificarToolStripMenuItem;
        private ToolStripMenuItem categoriaToolStripMenuItem1;
        private ToolStripTextBox toolStripTxtCategoria;
        private ToolStripMenuItem nombreToolStripMenuItem;
        private ToolStripTextBox toolStripTxtPlato;
    }
}