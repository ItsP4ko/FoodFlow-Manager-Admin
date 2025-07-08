namespace Vista.Usuarios.AdminAdmin
{
    partial class Cadetes_abm_Form
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
            volverToolStripMenuItem = new ToolStripMenuItem();
            agregarToolStripMenuItem = new ToolStripMenuItem();
            modificarToolStripMenuItem = new ToolStripMenuItem();
            eliminarToolStripMenuItem = new ToolStripMenuItem();
            dgvCadetes = new DataGridView();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtDni = new TextBox();
            buscarDniToolStripMenuItem = new ToolStripMenuItem();
            txtDniSearch = new ToolStripTextBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCadetes).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { volverToolStripMenuItem, agregarToolStripMenuItem, modificarToolStripMenuItem, eliminarToolStripMenuItem, buscarDniToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // volverToolStripMenuItem
            // 
            volverToolStripMenuItem.Name = "volverToolStripMenuItem";
            volverToolStripMenuItem.Size = new Size(64, 24);
            volverToolStripMenuItem.Text = "Volver";
            volverToolStripMenuItem.Click += volverToolStripMenuItem_Click;
            // 
            // agregarToolStripMenuItem
            // 
            agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            agregarToolStripMenuItem.Size = new Size(77, 24);
            agregarToolStripMenuItem.Text = "Agregar";
            agregarToolStripMenuItem.Click += agregarToolStripMenuItem_Click;
            // 
            // modificarToolStripMenuItem
            // 
            modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            modificarToolStripMenuItem.Size = new Size(87, 24);
            modificarToolStripMenuItem.Text = "Modificar";
            modificarToolStripMenuItem.Click += modificarToolStripMenuItem_Click;
            // 
            // eliminarToolStripMenuItem
            // 
            eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            eliminarToolStripMenuItem.Size = new Size(77, 24);
            eliminarToolStripMenuItem.Text = "Eliminar";
            eliminarToolStripMenuItem.Click += eliminarToolStripMenuItem_Click;
            // 
            // dgvCadetes
            // 
            dgvCadetes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCadetes.Location = new Point(282, 69);
            dgvCadetes.Name = "dgvCadetes";
            dgvCadetes.RowHeadersWidth = 51;
            dgvCadetes.Size = new Size(497, 355);
            dgvCadetes.TabIndex = 1;
            dgvCadetes.CellClick += dgvCadetes_CellClick;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(27, 92);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(125, 27);
            txtNombre.TabIndex = 2;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(27, 151);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(125, 27);
            txtApellido.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 69);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 4;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 128);
            label2.Name = "label2";
            label2.Size = new Size(66, 20);
            label2.TabIndex = 5;
            label2.Text = "Apellido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 186);
            label3.Name = "label3";
            label3.Size = new Size(32, 20);
            label3.TabIndex = 7;
            label3.Text = "Dni";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(27, 209);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(125, 27);
            txtDni.TabIndex = 6;
            // 
            // buscarDniToolStripMenuItem
            // 
            buscarDniToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { txtDniSearch });
            buscarDniToolStripMenuItem.Name = "buscarDniToolStripMenuItem";
            buscarDniToolStripMenuItem.Size = new Size(93, 24);
            buscarDniToolStripMenuItem.Text = "Buscar Dni";
            // 
            // txtDniSearch
            // 
            txtDniSearch.Name = "txtDniSearch";
            txtDniSearch.Size = new Size(100, 27);
            txtDniSearch.TextChanged += txtDniSearch_TextChanged;
            // 
            // Cadetes_abm_Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(txtDni);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(dgvCadetes);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Cadetes_abm_Form";
            Text = "Cadetes_abm_Form";
            Load += Cadetes_abm_Form_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCadetes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem volverToolStripMenuItem;
        private ToolStripMenuItem agregarToolStripMenuItem;
        private ToolStripMenuItem modificarToolStripMenuItem;
        private ToolStripMenuItem eliminarToolStripMenuItem;
        private DataGridView dgvCadetes;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtDni;
        private ToolStripMenuItem buscarDniToolStripMenuItem;
        private ToolStripTextBox txtDniSearch;
    }
}