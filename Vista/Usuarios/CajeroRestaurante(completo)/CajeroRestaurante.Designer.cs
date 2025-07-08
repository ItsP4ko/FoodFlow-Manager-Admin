namespace Vista.CajeroRestaurante
{
    partial class CajeroRestaurante
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
            menuStrip1 = new MenuStrip();
            realizarPedidoToolStripMenuItem = new ToolStripMenuItem();
            modificarPedidoToolStripMenuItem = new ToolStripMenuItem();
            panelCajero = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { realizarPedidoToolStripMenuItem, modificarPedidoToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1782, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // realizarPedidoToolStripMenuItem
            // 
            realizarPedidoToolStripMenuItem.Name = "realizarPedidoToolStripMenuItem";
            realizarPedidoToolStripMenuItem.Size = new Size(126, 24);
            realizarPedidoToolStripMenuItem.Text = "Realizar Pedido";
            realizarPedidoToolStripMenuItem.Click += realizarPedidoToolStripMenuItem_Click;
            // 
            // modificarPedidoToolStripMenuItem
            // 
            modificarPedidoToolStripMenuItem.Name = "modificarPedidoToolStripMenuItem";
            modificarPedidoToolStripMenuItem.Size = new Size(261, 24);
            modificarPedidoToolStripMenuItem.Text = "Modificar/Eliminar Pedidos Creados";
            modificarPedidoToolStripMenuItem.Click += modificarPedidoToolStripMenuItem_Click;
            // 
            // panelCajero
            // 
            panelCajero.Location = new Point(0, 31);
            panelCajero.Name = "panelCajero";
            panelCajero.Size = new Size(1770, 688);
            panelCajero.TabIndex = 1;
            // 
            // CajeroRestaurante
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1782, 718);
            Controls.Add(panelCajero);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "CajeroRestaurante";
            Text = "CajeroRestaurante";
            Load += CajeroRestaurante_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem realizarPedidoToolStripMenuItem;
        private ToolStripMenuItem modificarPedidoToolStripMenuItem;
        private Panel panelCajero;
    }
}