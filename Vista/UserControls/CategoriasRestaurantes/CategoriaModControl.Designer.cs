namespace Vista.UserControls.CategoriasRestaurantes
{
    partial class CategoriaModControl
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
            label3 = new Label();
            label1 = new Label();
            btnMod = new Button();
            txtNombre = new TextBox();
            cbEstado = new ComboBox();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 165);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 20;
            label3.Text = "Estado";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 50);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 18;
            label1.Text = "Nombre";
            // 
            // btnMod
            // 
            btnMod.Location = new Point(68, 241);
            btnMod.Name = "btnMod";
            btnMod.Size = new Size(101, 29);
            btnMod.TabIndex = 17;
            btnMod.Text = "Modificar";
            btnMod.UseVisualStyleBackColor = true;
            btnMod.Click += btnMod_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(46, 73);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(151, 27);
            txtNombre.TabIndex = 15;
            // 
            // cbEstado
            // 
            cbEstado.FormattingEnabled = true;
            cbEstado.Location = new Point(46, 188);
            cbEstado.Name = "cbEstado";
            cbEstado.Size = new Size(151, 28);
            cbEstado.TabIndex = 14;
            // 
            // CategoriaModControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(btnMod);
            Controls.Add(txtNombre);
            Controls.Add(cbEstado);
            Name = "CategoriaModControl";
            Size = new Size(243, 321);
            Load += CategoriaModControl_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label1;
        private Button btnMod;
        private TextBox txtNombre;
        private ComboBox cbEstado;
    }
}
