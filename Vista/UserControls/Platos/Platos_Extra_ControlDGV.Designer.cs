namespace Vista.AdminRestaurante.UserControls
{
    partial class PlatosControlDGV
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
            dgvPlatos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPlatos).BeginInit();
            SuspendLayout();
            // 
            // dgvPlatos
            // 
            dgvPlatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlatos.Location = new Point(27, 30);
            dgvPlatos.Name = "dgvPlatos";
            dgvPlatos.RowHeadersWidth = 51;
            dgvPlatos.Size = new Size(495, 300);
            dgvPlatos.TabIndex = 0;
            // 
            // PlatosControlDGV
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvPlatos);
            Name = "PlatosControlDGV";
            Size = new Size(549, 375);
            ((System.ComponentModel.ISupportInitialize)dgvPlatos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPlatos;
    }
}
