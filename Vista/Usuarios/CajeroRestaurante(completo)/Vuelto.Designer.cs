namespace Vista.Usuarios.CajeroRestaurante
{
    partial class Vuelto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vuelto));
            btnContinuar = new Button();
            txtMonto = new TextBox();
            label1 = new Label();
            lblTotal = new Label();
            SuspendLayout();
            // 
            // btnContinuar
            // 
            resources.ApplyResources(btnContinuar, "btnContinuar");
            btnContinuar.Name = "btnContinuar";
            btnContinuar.UseVisualStyleBackColor = true;
            btnContinuar.Click += btnContinuar_Click;
            // 
            // txtMonto
            // 
            resources.ApplyResources(txtMonto, "txtMonto");
            txtMonto.Name = "txtMonto";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // lblTotal
            // 
            resources.ApplyResources(lblTotal, "lblTotal");
            lblTotal.Name = "lblTotal";
            // 
            // Vuelto
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTotal);
            Controls.Add(label1);
            Controls.Add(txtMonto);
            Controls.Add(btnContinuar);
            Name = "Vuelto";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnContinuar;
        private TextBox txtMonto;
        private Label label1;
        private Label lblTotal;
    }
}