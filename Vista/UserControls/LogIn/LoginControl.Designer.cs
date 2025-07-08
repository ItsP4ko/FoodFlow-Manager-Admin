namespace Vista.UserControls.LogIn
{
    partial class LoginControl
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
            label2 = new Label();
            label1 = new Label();
            txtPassword = new TextBox();
            txtUsuario = new TextBox();
            btnIniciar = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 127);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 10;
            label2.Text = "Contrasena";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 67);
            label1.Name = "label1";
            label1.Size = new Size(59, 20);
            label1.TabIndex = 9;
            label1.Text = "Usuario";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(62, 150);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(192, 27);
            txtPassword.TabIndex = 8;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(62, 90);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(192, 27);
            txtUsuario.TabIndex = 7;
            // 
            // btnIniciar
            // 
            btnIniciar.Location = new Point(104, 204);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(94, 29);
            btnIniciar.TabIndex = 6;
            btnIniciar.Text = "Iniciar";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // LoginControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtUsuario);
            Controls.Add(btnIniciar);
            Name = "LoginControl";
            Size = new Size(320, 237);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label1;
        private TextBox txtPassword;
        private TextBox txtUsuario;
        private Button btnIniciar;
    }
}
