namespace Vista.UserControls.Menu
{
    partial class MenuControlEliminar
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
            cbCategoria = new ComboBox();
            btnEliminar = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // cbCategoria
            // 
            cbCategoria.FormattingEnabled = true;
            cbCategoria.Location = new Point(46, 172);
            cbCategoria.Name = "cbCategoria";
            cbCategoria.Size = new Size(151, 28);
            cbCategoria.TabIndex = 4;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(71, 225);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 149);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 5;
            label1.Text = "Categoria";
            // 
            // MenuControlEliminar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(cbCategoria);
            Controls.Add(btnEliminar);
            Name = "MenuControlEliminar";
            Size = new Size(243, 321);
            Load += MenuControlEliminar_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbCategoria;
        private Button btnEliminar;
        private Label label1;
    }
}
