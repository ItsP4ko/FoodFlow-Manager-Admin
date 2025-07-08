namespace Vista.UserControls
{
    partial class reporteControl
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
            DateTimePickerInicio = new DateTimePicker();
            DateTimePickerFin = new DateTimePicker();
            NumericUpDownTopN = new NumericUpDown();
            BtnGenerarReporte = new Button();
            ((System.ComponentModel.ISupportInitialize)NumericUpDownTopN).BeginInit();
            SuspendLayout();
            // 
            // DateTimePickerInicio
            // 
            DateTimePickerInicio.Location = new Point(20, 58);
            DateTimePickerInicio.Name = "DateTimePickerInicio";
            DateTimePickerInicio.Size = new Size(250, 27);
            DateTimePickerInicio.TabIndex = 0;
            // 
            // DateTimePickerFin
            // 
            DateTimePickerFin.Location = new Point(20, 113);
            DateTimePickerFin.Name = "DateTimePickerFin";
            DateTimePickerFin.Size = new Size(250, 27);
            DateTimePickerFin.TabIndex = 1;
            // 
            // NumericUpDownTopN
            // 
            NumericUpDownTopN.Location = new Point(20, 163);
            NumericUpDownTopN.Name = "NumericUpDownTopN";
            NumericUpDownTopN.Size = new Size(150, 27);
            NumericUpDownTopN.TabIndex = 2;
            // 
            // BtnGenerarReporte
            // 
            BtnGenerarReporte.Location = new Point(20, 223);
            BtnGenerarReporte.Name = "BtnGenerarReporte";
            BtnGenerarReporte.Size = new Size(150, 29);
            BtnGenerarReporte.TabIndex = 3;
            BtnGenerarReporte.Text = "Generar Reporte";
            BtnGenerarReporte.UseVisualStyleBackColor = true;
            BtnGenerarReporte.Click += BtnGenerarReporte_Click;
            // 
            // reporteControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(BtnGenerarReporte);
            Controls.Add(NumericUpDownTopN);
            Controls.Add(DateTimePickerFin);
            Controls.Add(DateTimePickerInicio);
            Name = "reporteControl";
            Size = new Size(653, 317);
            ((System.ComponentModel.ISupportInitialize)NumericUpDownTopN).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DateTimePicker DateTimePickerInicio;
        private DateTimePicker DateTimePickerFin;
        private NumericUpDown NumericUpDownTopN;
        private Button BtnGenerarReporte;
    }
}
