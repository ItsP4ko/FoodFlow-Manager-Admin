namespace Vista.Usuarios.AdminRestaurante
{
    partial class ReportesFormRestaurantes
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
            panel = new FlowLayoutPanel();
            menuStrip1 = new MenuStrip();
            volverToolStripMenuItem = new ToolStripMenuItem();
            productosToolStripMenuItem = new ToolStripMenuItem();
            tiemposToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel
            // 
            panel.Location = new Point(12, 41);
            panel.Name = "panel";
            panel.Size = new Size(653, 317);
            panel.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { volverToolStripMenuItem, productosToolStripMenuItem, tiemposToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(677, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // volverToolStripMenuItem
            // 
            volverToolStripMenuItem.Name = "volverToolStripMenuItem";
            volverToolStripMenuItem.Size = new Size(63, 24);
            volverToolStripMenuItem.Text = "volver";
            // 
            // productosToolStripMenuItem
            // 
            productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            productosToolStripMenuItem.Size = new Size(89, 24);
            productosToolStripMenuItem.Text = "Productos";
            productosToolStripMenuItem.Click += productosToolStripMenuItem_Click;
            // 
            // tiemposToolStripMenuItem
            // 
            tiemposToolStripMenuItem.Name = "tiemposToolStripMenuItem";
            tiemposToolStripMenuItem.Size = new Size(80, 24);
            tiemposToolStripMenuItem.Text = "Tiempos";
            // 
            // ReportesFormRestaurantes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(677, 370);
            Controls.Add(panel);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ReportesFormRestaurantes";
            Text = "ReportesFormRestaurantes";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel panel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem volverToolStripMenuItem;
        private ToolStripMenuItem productosToolStripMenuItem;
        private ToolStripMenuItem tiemposToolStripMenuItem;
    }
}