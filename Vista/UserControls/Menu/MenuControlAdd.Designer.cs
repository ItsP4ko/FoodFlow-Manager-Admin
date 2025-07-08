namespace Vista.UserControls.Menu
{
    partial class MenuControlAdd
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
            ofdMenu = new OpenFileDialog();
            btnCargar = new Button();
            cbCategoria = new ComboBox();
            lblCategoria = new Label();
            SuspendLayout();
            // 
            // ofdMenu
            // 
            ofdMenu.FileName = "Menu";
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(71, 225);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(94, 29);
            btnCargar.TabIndex = 1;
            btnCargar.Text = "Cargar";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += btnCargar_Click;
            // 
            // cbCategoria
            // 
            cbCategoria.FormattingEnabled = true;
            cbCategoria.Location = new Point(46, 172);
            cbCategoria.Name = "cbCategoria";
            cbCategoria.Size = new Size(151, 28);
            cbCategoria.TabIndex = 2;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(46, 149);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(74, 20);
            lblCategoria.TabIndex = 3;
            lblCategoria.Text = "Categoria";
            // 
            // MenuControlAdd
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblCategoria);
            Controls.Add(cbCategoria);
            Controls.Add(btnCargar);
            Name = "MenuControlAdd";
            Size = new Size(243, 321);
            Load += MenuControlAdd_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private OpenFileDialog ofdMenu;
        private Button btnCargar;
        private ComboBox cbCategoria;
        private Label lblCategoria;
    }
}
