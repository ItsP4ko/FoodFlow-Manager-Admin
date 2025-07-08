namespace Vista.UserControls.Platos
{
    partial class PlatoControlMod
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
            label2 = new Label();
            label1 = new Label();
            btnadd = new Button();
            txtPrecio = new TextBox();
            txtNombre = new TextBox();
            cbEstado = new ComboBox();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 149);
            label3.Name = "label3";
            label3.Size = new Size(54, 20);
            label3.TabIndex = 13;
            label3.Text = "Estado";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 89);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 12;
            label2.Text = "Precio";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 34);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 11;
            label1.Text = "Nombre";
            // 
            // btnadd
            // 
            btnadd.Location = new Point(68, 225);
            btnadd.Name = "btnadd";
            btnadd.Size = new Size(101, 29);
            btnadd.TabIndex = 10;
            btnadd.Text = "Modificar";
            btnadd.UseVisualStyleBackColor = true;
            btnadd.Click += btnadd_Click;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(46, 112);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(151, 27);
            txtPrecio.TabIndex = 9;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(46, 57);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(151, 27);
            txtNombre.TabIndex = 8;
            // 
            // cbEstado
            // 
            cbEstado.FormattingEnabled = true;
            cbEstado.Location = new Point(46, 172);
            cbEstado.Name = "cbEstado";
            cbEstado.Size = new Size(151, 28);
            cbEstado.TabIndex = 7;
            // 
            // PlatoControlMod
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnadd);
            Controls.Add(txtPrecio);
            Controls.Add(txtNombre);
            Controls.Add(cbEstado);
            Name = "PlatoControlMod";
            Size = new Size(243, 321);
            Load += PlatoControlMod_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnadd;
        private TextBox txtPrecio;
        private TextBox txtNombre;
        private ComboBox cbEstado;
    }
}
