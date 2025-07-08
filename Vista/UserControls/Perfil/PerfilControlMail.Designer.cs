namespace Vista.AdminRestaurante.UserControls
{
    partial class PerfilControlMail
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
            btnCambiarMail = new Button();
            label1 = new Label();
            txtMail = new TextBox();
            label4 = new Label();
            cbRol = new ComboBox();
            SuspendLayout();
            // 
            // btnCambiarMail
            // 
            btnCambiarMail.Location = new Point(125, 157);
            btnCambiarMail.Name = "btnCambiarMail";
            btnCambiarMail.Size = new Size(94, 29);
            btnCambiarMail.TabIndex = 13;
            btnCambiarMail.Text = "Confirmar";
            btnCambiarMail.UseVisualStyleBackColor = true;
            btnCambiarMail.Click += btnCambiarMail_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(86, 86);
            label1.Name = "label1";
            label1.Size = new Size(88, 20);
            label1.TabIndex = 10;
            label1.Text = "Nuevo Mail:";
            // 
            // txtMail
            // 
            txtMail.Location = new Point(86, 109);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(181, 27);
            txtMail.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(86, 32);
            label4.Name = "label4";
            label4.Size = new Size(31, 20);
            label4.TabIndex = 15;
            label4.Text = "Rol";
            // 
            // cbRol
            // 
            cbRol.FormattingEnabled = true;
            cbRol.Location = new Point(86, 55);
            cbRol.Name = "cbRol";
            cbRol.Size = new Size(151, 28);
            cbRol.TabIndex = 14;
            // 
            // PerfilControlMail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label4);
            Controls.Add(cbRol);
            Controls.Add(btnCambiarMail);
            Controls.Add(label1);
            Controls.Add(txtMail);
            Name = "PerfilControlMail";
            Size = new Size(354, 263);
            Load += PerfilControlMail_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCambiarMail;
        private Label label1;
        private TextBox txtMail;
        private Label label4;
        private ComboBox cbRol;
    }
}
