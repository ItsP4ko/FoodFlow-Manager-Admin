namespace Vista.AdminAdmin
{
    partial class RolesPermisosVista
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
            dataGridViewRoles = new DataGridView();
            menuStrip1 = new MenuStrip();
            MenuTool = new ToolStripMenuItem();
            crearRolToolStripMenuItem = new ToolStripMenuItem();
            modificarRolToolStripMenuItem = new ToolStripMenuItem();
            eliminarRolToolStripMenuItem = new ToolStripMenuItem();
            asignarPermisosToolStripMenuItem = new ToolStripMenuItem();
            todosPermisosDeRolToolStripMenuItem = new ToolStripMenuItem();
            permisosToolStripMenuItem = new ToolStripMenuItem();
            crearPermisoToolStripMenuItem = new ToolStripMenuItem();
            eliminarPermisoToolStripMenuItem = new ToolStripMenuItem();
            modificarPermisoToolStripMenuItem = new ToolStripMenuItem();
            buscarToolStripMenuItem = new ToolStripMenuItem();
            rolToolStripMenuItem = new ToolStripMenuItem();
            tsSearchRol = new ToolStripTextBox();
            permisoToolStripMenuItem = new ToolStripMenuItem();
            tsTextBoxSearchPermiso = new ToolStripTextBox();
            dgvPermisos = new DataGridView();
            textBoxRoleName = new TextBox();
            label1 = new Label();
            buttonCreateRole = new Button();
            cbRoles = new ComboBox();
            panel1 = new Panel();
            label2 = new Label();
            verTodosPermisosToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRoles).BeginInit();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPermisos).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewRoles
            // 
            dataGridViewRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRoles.Location = new Point(321, 33);
            dataGridViewRoles.Name = "dataGridViewRoles";
            dataGridViewRoles.RowHeadersWidth = 51;
            dataGridViewRoles.Size = new Size(439, 224);
            dataGridViewRoles.TabIndex = 0;
            dataGridViewRoles.SelectionChanged += dataGridViewRoles_SelectionChanged;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { MenuTool, permisosToolStripMenuItem, buscarToolStripMenuItem, verTodosPermisosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Margin = new Padding(0, 15, 0, 15);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(772, 28);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // MenuTool
            // 
            MenuTool.DropDownItems.AddRange(new ToolStripItem[] { crearRolToolStripMenuItem, modificarRolToolStripMenuItem, eliminarRolToolStripMenuItem, asignarPermisosToolStripMenuItem, todosPermisosDeRolToolStripMenuItem });
            MenuTool.Name = "MenuTool";
            MenuTool.Size = new Size(59, 24);
            MenuTool.Text = "Roles";
            // 
            // crearRolToolStripMenuItem
            // 
            crearRolToolStripMenuItem.Name = "crearRolToolStripMenuItem";
            crearRolToolStripMenuItem.Size = new Size(237, 26);
            crearRolToolStripMenuItem.Text = "Crear Rol";
            crearRolToolStripMenuItem.Click += crearRolToolStripMenuItem_Click;
            // 
            // modificarRolToolStripMenuItem
            // 
            modificarRolToolStripMenuItem.Name = "modificarRolToolStripMenuItem";
            modificarRolToolStripMenuItem.Size = new Size(237, 26);
            modificarRolToolStripMenuItem.Text = "Modificar Rol";
            modificarRolToolStripMenuItem.Click += modificarRolToolStripMenuItem_Click;
            // 
            // eliminarRolToolStripMenuItem
            // 
            eliminarRolToolStripMenuItem.Name = "eliminarRolToolStripMenuItem";
            eliminarRolToolStripMenuItem.Size = new Size(237, 26);
            eliminarRolToolStripMenuItem.Text = "Eliminar Rol";
            eliminarRolToolStripMenuItem.Click += eliminarRolToolStripMenuItem_Click;
            // 
            // asignarPermisosToolStripMenuItem
            // 
            asignarPermisosToolStripMenuItem.Name = "asignarPermisosToolStripMenuItem";
            asignarPermisosToolStripMenuItem.Size = new Size(237, 26);
            asignarPermisosToolStripMenuItem.Text = "Asignar Permisos";
            asignarPermisosToolStripMenuItem.Click += asignarPermisosToolStripMenuItem_Click;
            // 
            // todosPermisosDeRolToolStripMenuItem
            // 
            todosPermisosDeRolToolStripMenuItem.Name = "todosPermisosDeRolToolStripMenuItem";
            todosPermisosDeRolToolStripMenuItem.Size = new Size(237, 26);
            todosPermisosDeRolToolStripMenuItem.Text = "Todos Permisos de rol";
            todosPermisosDeRolToolStripMenuItem.Click += todosPermisosDeRolToolStripMenuItem_Click;
            // 
            // permisosToolStripMenuItem
            // 
            permisosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { crearPermisoToolStripMenuItem, eliminarPermisoToolStripMenuItem, modificarPermisoToolStripMenuItem });
            permisosToolStripMenuItem.Name = "permisosToolStripMenuItem";
            permisosToolStripMenuItem.Size = new Size(81, 24);
            permisosToolStripMenuItem.Text = "Permisos";
            permisosToolStripMenuItem.Click += permisosToolStripMenuItem_Click;
            // 
            // crearPermisoToolStripMenuItem
            // 
            crearPermisoToolStripMenuItem.Name = "crearPermisoToolStripMenuItem";
            crearPermisoToolStripMenuItem.Size = new Size(212, 26);
            crearPermisoToolStripMenuItem.Text = "Crear Permiso";
            crearPermisoToolStripMenuItem.Click += crearPermisoToolStripMenuItem_Click;
            // 
            // eliminarPermisoToolStripMenuItem
            // 
            eliminarPermisoToolStripMenuItem.Name = "eliminarPermisoToolStripMenuItem";
            eliminarPermisoToolStripMenuItem.Size = new Size(212, 26);
            eliminarPermisoToolStripMenuItem.Text = "Eliminar Permiso";
            eliminarPermisoToolStripMenuItem.Click += eliminarPermisoToolStripMenuItem_Click;
            // 
            // modificarPermisoToolStripMenuItem
            // 
            modificarPermisoToolStripMenuItem.Name = "modificarPermisoToolStripMenuItem";
            modificarPermisoToolStripMenuItem.Size = new Size(212, 26);
            modificarPermisoToolStripMenuItem.Text = "Modificar Permiso";
            modificarPermisoToolStripMenuItem.Click += modificarPermisoToolStripMenuItem_Click;
            // 
            // buscarToolStripMenuItem
            // 
            buscarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { rolToolStripMenuItem, permisoToolStripMenuItem });
            buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            buscarToolStripMenuItem.Size = new Size(66, 24);
            buscarToolStripMenuItem.Text = "Buscar";
            buscarToolStripMenuItem.Click += buscarToolStripMenuItem_Click;
            // 
            // rolToolStripMenuItem
            // 
            rolToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsSearchRol });
            rolToolStripMenuItem.Name = "rolToolStripMenuItem";
            rolToolStripMenuItem.Size = new Size(224, 26);
            rolToolStripMenuItem.Text = "Rol";
            // 
            // tsSearchRol
            // 
            tsSearchRol.Name = "tsSearchRol";
            tsSearchRol.Size = new Size(100, 27);
            tsSearchRol.TextChanged += tsSearchRol_TextChanged;
            // 
            // permisoToolStripMenuItem
            // 
            permisoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { tsTextBoxSearchPermiso });
            permisoToolStripMenuItem.Name = "permisoToolStripMenuItem";
            permisoToolStripMenuItem.Size = new Size(224, 26);
            permisoToolStripMenuItem.Text = "Permiso";
            // 
            // tsTextBoxSearchPermiso
            // 
            tsTextBoxSearchPermiso.Name = "tsTextBoxSearchPermiso";
            tsTextBoxSearchPermiso.Size = new Size(100, 27);
            tsTextBoxSearchPermiso.TextChanged += tsTextBoxSearchPermiso_TextChanged;
            // 
            // dgvPermisos
            // 
            dgvPermisos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPermisos.Location = new Point(321, 263);
            dgvPermisos.Name = "dgvPermisos";
            dgvPermisos.RowHeadersWidth = 51;
            dgvPermisos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPermisos.Size = new Size(439, 256);
            dgvPermisos.TabIndex = 6;
            // 
            // textBoxRoleName
            // 
            textBoxRoleName.Location = new Point(79, 207);
            textBoxRoleName.Name = "textBoxRoleName";
            textBoxRoleName.Size = new Size(125, 27);
            textBoxRoleName.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 207);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 7;
            label1.Text = "Nombre:";
            // 
            // buttonCreateRole
            // 
            buttonCreateRole.Location = new Point(61, 271);
            buttonCreateRole.Name = "buttonCreateRole";
            buttonCreateRole.Size = new Size(161, 28);
            buttonCreateRole.TabIndex = 1;
            buttonCreateRole.Text = "Completar";
            buttonCreateRole.UseVisualStyleBackColor = true;
            buttonCreateRole.Click += ButtonCreateRole_Click;
            // 
            // cbRoles
            // 
            cbRoles.FormattingEnabled = true;
            cbRoles.Location = new Point(71, 159);
            cbRoles.Name = "cbRoles";
            cbRoles.Size = new Size(151, 28);
            cbRoles.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cbRoles);
            panel1.Controls.Add(buttonCreateRole);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBoxRoleName);
            panel1.Location = new Point(12, 33);
            panel1.Name = "panel1";
            panel1.Size = new Size(303, 486);
            panel1.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 167);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 9;
            label2.Text = "Roles:";
            // 
            // verTodosPermisosToolStripMenuItem
            // 
            verTodosPermisosToolStripMenuItem.Name = "verTodosPermisosToolStripMenuItem";
            verTodosPermisosToolStripMenuItem.Size = new Size(150, 24);
            verTodosPermisosToolStripMenuItem.Text = "Ver Todos Permisos";
            verTodosPermisosToolStripMenuItem.Click += verTodosPermisosToolStripMenuItem_Click;
            // 
            // RolesPermisosVista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(772, 531);
            Controls.Add(panel1);
            Controls.Add(dgvPermisos);
            Controls.Add(menuStrip1);
            Controls.Add(dataGridViewRoles);
            Name = "RolesPermisosVista";
            Text = "RolesPermisos";
            ((System.ComponentModel.ISupportInitialize)dataGridViewRoles).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPermisos).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewRoles;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem MenuTool;
        private ToolStripMenuItem crearRolToolStripMenuItem;
        private ToolStripMenuItem modificarRolToolStripMenuItem;
        private ToolStripMenuItem eliminarRolToolStripMenuItem;
        private ToolStripMenuItem asignarPermisosToolStripMenuItem;
        private ToolStripMenuItem permisosToolStripMenuItem;
        private ToolStripMenuItem crearPermisoToolStripMenuItem;
        private ToolStripMenuItem eliminarPermisoToolStripMenuItem;
        private ToolStripMenuItem modificarPermisoToolStripMenuItem;
        private DataGridView dgvPermisos;
        private ToolStripMenuItem buscarToolStripMenuItem;
        private ToolStripMenuItem permisoToolStripMenuItem;
        private ToolStripTextBox tsTextBoxSearchPermiso;
        private ToolStripMenuItem rolToolStripMenuItem;
        private ToolStripTextBox tsSearchRol;
        private ToolStripMenuItem todosPermisosDeRolToolStripMenuItem;
        private TextBox textBoxRoleName;
        private Label label1;
        private Button buttonCreateRole;
        private ComboBox cbRoles;
        private Panel panel1;
        private Label label2;
        private ToolStripMenuItem verTodosPermisosToolStripMenuItem;
    }
}