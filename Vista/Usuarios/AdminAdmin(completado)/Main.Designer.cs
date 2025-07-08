namespace Vista
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvRestaurantes = new DataGridView();
            txtNombre = new TextBox();
            txtDireccion = new TextBox();
            txtCapacidad = new TextBox();
            MenuTool = new ToolStripMenuItem();
            MenuAgregarR = new ToolStripMenuItem();
            MenuModificarR = new ToolStripMenuItem();
            MenuEliminarR = new ToolStripMenuItem();
            cadetesToolStripMenuItem = new ToolStripMenuItem();
            buscarToolStripMenuItem = new ToolStripMenuItem();
            UsuarioToolStripMenuItem = new ToolStripMenuItem();
            mailToolStripMenuItem = new ToolStripMenuItem();
            toolStripTxtUserMail = new ToolStripTextBox();
            rolToolStripMenuItem = new ToolStripMenuItem();
            toolStripTxtUserRol = new ToolStripTextBox();
            restauranteToolStripMenuItem = new ToolStripMenuItem();
            planesToolStripMenuItem = new ToolStripMenuItem();
            toolStripTxtBuscarRoleRest = new ToolStripTextBox();
            nombreToolStripMenuItem = new ToolStripMenuItem();
            toolStripTxtBuscarNomRest = new ToolStripTextBox();
            cadeteToolStrip = new ToolStripMenuItem();
            toolStripTxtCadete = new ToolStripTextBox();
            menuStrip1 = new MenuStrip();
            gruposToolStripMenuItem = new ToolStripMenuItem();
            dgvTool = new ToolStripMenuItem();
            restaurantesToolStripMenuItem = new ToolStripMenuItem();
            cadetesToolStripMenuItem1 = new ToolStripMenuItem();
            usuariosVerToolStripMenuItem = new ToolStripMenuItem();
            btnAgregarModificar = new Button();
            lblDirecToApell = new Label();
            lblCantToDni = new Label();
            lblNombre = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRestaurantes).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvRestaurantes
            // 
            dgvRestaurantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRestaurantes.Location = new Point(350, 149);
            dgvRestaurantes.Name = "dgvRestaurantes";
            dgvRestaurantes.RowHeadersWidth = 51;
            dgvRestaurantes.Size = new Size(691, 473);
            dgvRestaurantes.TabIndex = 0;
            dgvRestaurantes.CellClick += dgvRestaurantes_CellClick;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 149);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(191, 27);
            txtNombre.TabIndex = 3;
            txtNombre.Visible = false;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(12, 210);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(191, 27);
            txtDireccion.TabIndex = 4;
            txtDireccion.Visible = false;
            // 
            // txtCapacidad
            // 
            txtCapacidad.Location = new Point(12, 275);
            txtCapacidad.Name = "txtCapacidad";
            txtCapacidad.Size = new Size(191, 27);
            txtCapacidad.TabIndex = 5;
            txtCapacidad.Text = "0";
            txtCapacidad.Visible = false;
            // 
            // MenuTool
            // 
            MenuTool.DropDownItems.AddRange(new ToolStripItem[] { MenuAgregarR, MenuModificarR, MenuEliminarR });
            MenuTool.Name = "MenuTool";
            MenuTool.Size = new Size(101, 24);
            MenuTool.Text = "Restaurante";
            // 
            // MenuAgregarR
            // 
            MenuAgregarR.Name = "MenuAgregarR";
            MenuAgregarR.Size = new Size(238, 26);
            MenuAgregarR.Text = "Agregar Restaurante ";
            MenuAgregarR.Click += MenuAgregarModificarR_Click;
            // 
            // MenuModificarR
            // 
            MenuModificarR.Name = "MenuModificarR";
            MenuModificarR.Size = new Size(238, 26);
            MenuModificarR.Text = "Modificar Restaurante";
            MenuModificarR.Click += MenuModificarR_Click;
            // 
            // MenuEliminarR
            // 
            MenuEliminarR.Name = "MenuEliminarR";
            MenuEliminarR.Size = new Size(238, 26);
            MenuEliminarR.Text = "Eliminar Restaurante ";
            MenuEliminarR.Click += MenuEliminarR_Click;
            // 
            // cadetesToolStripMenuItem
            // 
            cadetesToolStripMenuItem.Name = "cadetesToolStripMenuItem";
            cadetesToolStripMenuItem.Size = new Size(76, 24);
            cadetesToolStripMenuItem.Text = "Cadetes";
            cadetesToolStripMenuItem.Click += cadetesToolStripMenuItem_Click;
            // 
            // buscarToolStripMenuItem
            // 
            buscarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { UsuarioToolStripMenuItem, restauranteToolStripMenuItem, cadeteToolStrip });
            buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            buscarToolStripMenuItem.Size = new Size(66, 24);
            buscarToolStripMenuItem.Text = "Buscar";
            // 
            // UsuarioToolStripMenuItem
            // 
            UsuarioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mailToolStripMenuItem, rolToolStripMenuItem });
            UsuarioToolStripMenuItem.Name = "UsuarioToolStripMenuItem";
            UsuarioToolStripMenuItem.Size = new Size(170, 26);
            UsuarioToolStripMenuItem.Text = "Usuario";
            UsuarioToolStripMenuItem.Click += UsuarioToolStripMenuItem_Click;
            // 
            // mailToolStripMenuItem
            // 
            mailToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripTxtUserMail });
            mailToolStripMenuItem.Name = "mailToolStripMenuItem";
            mailToolStripMenuItem.Size = new Size(121, 26);
            mailToolStripMenuItem.Text = "Mail";
            mailToolStripMenuItem.Click += mailToolStripMenuItem_Click;
            // 
            // toolStripTxtUserMail
            // 
            toolStripTxtUserMail.Name = "toolStripTxtUserMail";
            toolStripTxtUserMail.Size = new Size(100, 27);
            toolStripTxtUserMail.TextChanged += toolStripTxtUserMail_TextChanged;
            // 
            // rolToolStripMenuItem
            // 
            rolToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripTxtUserRol });
            rolToolStripMenuItem.Name = "rolToolStripMenuItem";
            rolToolStripMenuItem.Size = new Size(121, 26);
            rolToolStripMenuItem.Text = "Rol";
            rolToolStripMenuItem.Click += rolToolStripMenuItem_Click;
            // 
            // toolStripTxtUserRol
            // 
            toolStripTxtUserRol.Name = "toolStripTxtUserRol";
            toolStripTxtUserRol.Size = new Size(100, 27);
            toolStripTxtUserRol.TextChanged += toolStripTxtUserRol_TextChanged;
            // 
            // restauranteToolStripMenuItem
            // 
            restauranteToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { planesToolStripMenuItem, nombreToolStripMenuItem });
            restauranteToolStripMenuItem.Name = "restauranteToolStripMenuItem";
            restauranteToolStripMenuItem.Size = new Size(170, 26);
            restauranteToolStripMenuItem.Text = "Restaurante";
            restauranteToolStripMenuItem.Click += restauranteToolStripMenuItem_Click;
            // 
            // planesToolStripMenuItem
            // 
            planesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripTxtBuscarRoleRest });
            planesToolStripMenuItem.Name = "planesToolStripMenuItem";
            planesToolStripMenuItem.Size = new Size(147, 26);
            planesToolStripMenuItem.Text = "Planes";
            // 
            // toolStripTxtBuscarRoleRest
            // 
            toolStripTxtBuscarRoleRest.Name = "toolStripTxtBuscarRoleRest";
            toolStripTxtBuscarRoleRest.Size = new Size(100, 27);
            // 
            // nombreToolStripMenuItem
            // 
            nombreToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripTxtBuscarNomRest });
            nombreToolStripMenuItem.Name = "nombreToolStripMenuItem";
            nombreToolStripMenuItem.Size = new Size(147, 26);
            nombreToolStripMenuItem.Text = "Nombre";
            // 
            // toolStripTxtBuscarNomRest
            // 
            toolStripTxtBuscarNomRest.Name = "toolStripTxtBuscarNomRest";
            toolStripTxtBuscarNomRest.Size = new Size(100, 27);
            toolStripTxtBuscarNomRest.TextChanged += toolStripTxtBuscarNomRest_TextChanged;
            // 
            // cadeteToolStrip
            // 
            cadeteToolStrip.DropDownItems.AddRange(new ToolStripItem[] { toolStripTxtCadete });
            cadeteToolStrip.Name = "cadeteToolStrip";
            cadeteToolStrip.Size = new Size(170, 26);
            cadeteToolStrip.Text = "Cadete";
            cadeteToolStrip.Click += cadeteToolStrip_Click;
            // 
            // toolStripTxtCadete
            // 
            toolStripTxtCadete.Name = "toolStripTxtCadete";
            toolStripTxtCadete.Size = new Size(100, 27);
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { MenuTool, cadetesToolStripMenuItem, buscarToolStripMenuItem, gruposToolStripMenuItem, dgvTool });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Margin = new Padding(0, 15, 0, 15);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1053, 28);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.MenuDeactivate += menuStrip1_MenuDeactivate;
            // 
            // gruposToolStripMenuItem
            // 
            gruposToolStripMenuItem.Name = "gruposToolStripMenuItem";
            gruposToolStripMenuItem.Size = new Size(132, 24);
            gruposToolStripMenuItem.Text = "Roles y Permisos";
            gruposToolStripMenuItem.Click += gruposToolStripMenuItem_Click;
            // 
            // dgvTool
            // 
            dgvTool.AccessibleRole = AccessibleRole.None;
            dgvTool.Alignment = ToolStripItemAlignment.Right;
            dgvTool.BackColor = Color.White;
            dgvTool.DropDownItems.AddRange(new ToolStripItem[] { restaurantesToolStripMenuItem, cadetesToolStripMenuItem1, usuariosVerToolStripMenuItem });
            dgvTool.Name = "dgvTool";
            dgvTool.Size = new Size(44, 24);
            dgvTool.Text = "Ver";
            dgvTool.TextAlign = ContentAlignment.TopCenter;
            // 
            // restaurantesToolStripMenuItem
            // 
            restaurantesToolStripMenuItem.Name = "restaurantesToolStripMenuItem";
            restaurantesToolStripMenuItem.Size = new Size(224, 26);
            restaurantesToolStripMenuItem.Text = "Restaurantes";
            // 
            // cadetesToolStripMenuItem1
            // 
            cadetesToolStripMenuItem1.Name = "cadetesToolStripMenuItem1";
            cadetesToolStripMenuItem1.Size = new Size(224, 26);
            cadetesToolStripMenuItem1.Text = "Cadetes";
            cadetesToolStripMenuItem1.Click += cadeteToolStrip_Click;
            // 
            // usuariosVerToolStripMenuItem
            // 
            usuariosVerToolStripMenuItem.Name = "usuariosVerToolStripMenuItem";
            usuariosVerToolStripMenuItem.Size = new Size(224, 26);
            usuariosVerToolStripMenuItem.Text = "Usuarios";
            usuariosVerToolStripMenuItem.Click += UsuarioToolStripMenuItem_Click;
            // 
            // btnAgregarModificar
            // 
            btnAgregarModificar.Location = new Point(49, 329);
            btnAgregarModificar.Name = "btnAgregarModificar";
            btnAgregarModificar.Size = new Size(94, 29);
            btnAgregarModificar.TabIndex = 6;
            btnAgregarModificar.Text = "ok\r\n";
            btnAgregarModificar.UseVisualStyleBackColor = true;
            btnAgregarModificar.Visible = false;
            btnAgregarModificar.Click += btnAgregarModificar_Click;
            // 
            // lblDirecToApell
            // 
            lblDirecToApell.AutoSize = true;
            lblDirecToApell.Location = new Point(12, 187);
            lblDirecToApell.Name = "lblDirecToApell";
            lblDirecToApell.Size = new Size(72, 20);
            lblDirecToApell.TabIndex = 10;
            lblDirecToApell.Text = "Direccion";
            lblDirecToApell.Visible = false;
            // 
            // lblCantToDni
            // 
            lblCantToDni.AutoSize = true;
            lblCantToDni.Location = new Point(12, 252);
            lblCantToDni.Name = "lblCantToDni";
            lblCantToDni.Size = new Size(69, 20);
            lblCantToDni.TabIndex = 11;
            lblCantToDni.Text = "Cantidad";
            lblCantToDni.Visible = false;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(12, 126);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(64, 20);
            lblNombre.TabIndex = 12;
            lblNombre.Text = "Nombre";
            lblNombre.Visible = false;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1053, 626);
            Controls.Add(lblNombre);
            Controls.Add(lblCantToDni);
            Controls.Add(lblDirecToApell);
            Controls.Add(btnAgregarModificar);
            Controls.Add(txtCapacidad);
            Controls.Add(txtDireccion);
            Controls.Add(txtNombre);
            Controls.Add(menuStrip1);
            Controls.Add(dgvRestaurantes);
            MainMenuStrip = menuStrip1;
            Name = "Main";
            Text = "Admin";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRestaurantes).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvRestaurantes;
        private TextBox txtNombre;
        private TextBox txtDireccion;
        private TextBox txtCapacidad;
        private ToolStripMenuItem MenuTool;
        private ToolStripMenuItem MenuAgregarR;
        private ToolStripMenuItem MenuModificarR;
        private ToolStripMenuItem MenuEliminarR;
        private ToolStripMenuItem cadetesToolStripMenuItem;
        private ToolStripMenuItem buscarToolStripMenuItem;
        private ToolStripMenuItem UsuarioToolStripMenuItem;
        private ToolStripMenuItem restauranteToolStripMenuItem;
        private ToolStripMenuItem cadeteToolStrip;
        private MenuStrip menuStrip1;
        private Button btnAgregarModificar;
        private ToolStripMenuItem mailToolStripMenuItem;
        private ToolStripTextBox toolStripTxtUserMail;
        private ToolStripMenuItem rolToolStripMenuItem;
        private ToolStripTextBox toolStripTxtUserRol;
        private ToolStripMenuItem dgvTool;
        private ToolStripMenuItem restaurantesToolStripMenuItem;
        private ToolStripMenuItem cadetesToolStripMenuItem1;
        private ToolStripTextBox toolStripTxtCadete;
        private ToolStripMenuItem usuariosVerToolStripMenuItem;
        private ToolStripMenuItem planesToolStripMenuItem;
        private ToolStripTextBox toolStripTxtBuscarRoleRest;
        private ToolStripMenuItem nombreToolStripMenuItem;
        private ToolStripTextBox toolStripTxtBuscarNomRest;
        private ToolStripMenuItem planToolStripMenuItem;
        private ToolStripMenuItem planToolStripMenuItem1;
        private ToolStripMenuItem agregarPlanToolStripMenuItem;
        private ToolStripMenuItem modificarPlanToolStripMenuItem;
        private ToolStripMenuItem eliminarPlanToolStripMenuItem;
        private ToolStripMenuItem beneficioToolStripMenuItem;
        private ToolStripMenuItem agregarBeneficioToolStripMenuItem;
        private ToolStripMenuItem eliminarBeneficioToolStripMenuItem;
        private ToolStripMenuItem modoficarBeneficioToolStripMenuItem;


        private ToolStripMenuItem planToolStripMenuItem2;

        private ToolStripMenuItem gruposToolStripMenuItem;
        private Label labelNombre;
        private Label lblDirecToApell;
        private Label lblCantToDni;
        private Label lblNombre;
    }
}
