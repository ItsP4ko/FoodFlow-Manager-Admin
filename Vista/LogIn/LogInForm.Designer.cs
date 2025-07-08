namespace Vista.LogIn
{
    partial class LogIn
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
            pnLog = new Panel();
            lblRegistro = new Label();
            SuspendLayout();
            // 
            // pnLog
            // 
            pnLog.Location = new Point(12, 25);
            pnLog.Name = "pnLog";
            pnLog.Size = new Size(320, 237);
            pnLog.TabIndex = 6;
            // 
            // lblRegistro
            // 
            lblRegistro.AutoSize = true;
            lblRegistro.Location = new Point(124, 265);
            lblRegistro.Name = "lblRegistro";
            lblRegistro.Size = new Size(77, 20);
            lblRegistro.TabIndex = 7;
            lblRegistro.Text = "Registarse";
            lblRegistro.Click += lblRegistro_Click;
            // 
            // LogIn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 451);
            Controls.Add(lblRegistro);
            Controls.Add(pnLog);
            Name = "LogIn";
            Text = "LogIn";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel pnLog;
        private Label lblRegistro;
    }
}