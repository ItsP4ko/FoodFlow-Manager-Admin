namespace Vista.UserControls.CategoriasRestaurantes
{
    partial class CategoriaAddControl
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
            label1 = new Label();
            btnadd = new Button();
            txtNombre = new TextBox();
            label3 = new Label();
            cbEstado = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 29);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 13;
            label1.Text = "Nombre";
            // 
            // btnadd
            // 
            btnadd.Location = new Point(68, 241);
            btnadd.Name = "btnadd";
            btnadd.Size = new Size(94, 29);
            btnadd.TabIndex = 12;
            btnadd.Text = "Agregar";
            btnadd.UseVisualStyleBackColor = true;
            btnadd.Click += btnadd_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(46, 52);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(151, 27);
            txtNombre.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 94);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 15;
            label3.Text = "Estado";
            // 
            // cbEstado
            // 
            cbEstado.FormattingEnabled = true;
            cbEstado.Location = new Point(46, 117);
            cbEstado.Name = "cbEstado";
            cbEstado.Size = new Size(151, 28);
            cbEstado.TabIndex = 14;
            // 
            // CategoriaAddControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label3);
            Controls.Add(cbEstado);
            Controls.Add(label1);
            Controls.Add(btnadd);
            Controls.Add(txtNombre);
            Name = "CategoriaAddControl";
            Size = new Size(243, 321);
            Load += CategoriaAddControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnadd;
        private TextBox txtNombre;
        private Label label3;
        private ComboBox cbEstado;
    }
}
