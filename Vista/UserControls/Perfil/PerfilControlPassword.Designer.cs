namespace Vista.AdminRestaurante
{
    partial class PerfilControlPassword
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
            txtNewPassword = new TextBox();
            txtNewPassword2 = new TextBox();
            txtPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnCambiarPassword = new Button();
            label4 = new Label();
            cbRol = new ComboBox();
            SuspendLayout();
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(108, 148);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(181, 27);
            txtNewPassword.TabIndex = 0;
            // 
            // txtNewPassword2
            // 
            txtNewPassword2.Location = new Point(108, 212);
            txtNewPassword2.Name = "txtNewPassword2";
            txtNewPassword2.Size = new Size(181, 27);
            txtNewPassword2.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(108, 86);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(181, 27);
            txtPassword.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(108, 63);
            label1.Name = "label1";
            label1.Size = new Size(130, 20);
            label1.TabIndex = 3;
            label1.Text = "Contrasena actual:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(109, 125);
            label2.Name = "label2";
            label2.Size = new Size(129, 20);
            label2.TabIndex = 4;
            label2.Text = "Contrasena nueva:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(108, 189);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 5;
            label3.Text = "Reingresar";
            // 
            // btnCambiarPassword
            // 
            btnCambiarPassword.Location = new Point(144, 256);
            btnCambiarPassword.Name = "btnCambiarPassword";
            btnCambiarPassword.Size = new Size(94, 29);
            btnCambiarPassword.TabIndex = 6;
            btnCambiarPassword.Text = "Confirmar";
            btnCambiarPassword.UseVisualStyleBackColor = true;
            btnCambiarPassword.Click += btnCambiarPassword_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(108, 9);
            label4.Name = "label4";
            label4.Size = new Size(31, 20);
            label4.TabIndex = 17;
            label4.Text = "Rol";
            // 
            // cbRol
            // 
            cbRol.FormattingEnabled = true;
            cbRol.Location = new Point(108, 32);
            cbRol.Name = "cbRol";
            cbRol.Size = new Size(155, 28);
            cbRol.TabIndex = 16;
            // 
            // PerfilControlPassword
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label4);
            Controls.Add(cbRol);
            Controls.Add(btnCambiarPassword);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtNewPassword2);
            Controls.Add(txtNewPassword);
            Name = "PerfilControlPassword";
            Size = new Size(399, 313);
            Load += PerfilControlPassword_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNewPassword;
        private TextBox txtNewPassword2;
        private TextBox txtPassword;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnCambiarPassword;
        private Label label4;
        private ComboBox cbRol;
    }
}
