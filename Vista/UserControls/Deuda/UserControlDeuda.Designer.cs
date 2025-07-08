namespace Vista.UserControls.Deuda
{
    partial class UserControlDeuda
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
            btnConfirmar = new Button();
            lblDeuda = new Label();
            txtSaldo = new TextBox();
            lbl = new Label();
            SuspendLayout();
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(48, 208);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(94, 29);
            btnConfirmar.TabIndex = 0;
            btnConfirmar.Text = "Pagar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // lblDeuda
            // 
            lblDeuda.AutoSize = true;
            lblDeuda.Location = new Point(37, 56);
            lblDeuda.Name = "lblDeuda";
            lblDeuda.Size = new Size(56, 20);
            lblDeuda.TabIndex = 1;
            lblDeuda.Text = "Deuda:";
            // 
            // txtSaldo
            // 
            txtSaldo.Location = new Point(37, 145);
            txtSaldo.Name = "txtSaldo";
            txtSaldo.Size = new Size(125, 27);
            txtSaldo.TabIndex = 2;
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Location = new Point(37, 122);
            lbl.Name = "lbl";
            lbl.Size = new Size(105, 20);
            lbl.TabIndex = 3;
            lbl.Text = "Saldo a pagar:";
            // 
            // UserControlDeuda
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbl);
            Controls.Add(txtSaldo);
            Controls.Add(lblDeuda);
            Controls.Add(btnConfirmar);
            Name = "UserControlDeuda";
            Size = new Size(225, 416);
            Load += UserControlDeuda_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConfirmar;
        private Label lblDeuda;
        private TextBox txtSaldo;
        private Label lbl;
    }
}
