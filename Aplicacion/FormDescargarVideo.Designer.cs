namespace Aplicacion
{
    partial class FormDescargarVideo
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
            label1 = new Label();
            txtUrlVideo = new TextBox();
            pbrProgresoVideo = new ProgressBar();
            btnGuardarVideo = new Button();
            cboCalidadVideo = new ComboBox();
            label2 = new Label();
            btnVerDatosVideo = new Button();
            lblSize = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 9);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 0;
            label1.Text = "Pegue la URL:";
            // 
            // txtUrlVideo
            // 
            txtUrlVideo.Location = new Point(57, 27);
            txtUrlVideo.Name = "txtUrlVideo";
            txtUrlVideo.Size = new Size(253, 23);
            txtUrlVideo.TabIndex = 1;
            // 
            // pbrProgresoVideo
            // 
            pbrProgresoVideo.Location = new Point(151, 113);
            pbrProgresoVideo.Name = "pbrProgresoVideo";
            pbrProgresoVideo.Size = new Size(100, 23);
            pbrProgresoVideo.Style = ProgressBarStyle.Marquee;
            pbrProgresoVideo.TabIndex = 2;
            pbrProgresoVideo.Visible = false;
            // 
            // btnGuardarVideo
            // 
            btnGuardarVideo.Location = new Point(57, 192);
            btnGuardarVideo.Name = "btnGuardarVideo";
            btnGuardarVideo.Size = new Size(299, 78);
            btnGuardarVideo.TabIndex = 3;
            btnGuardarVideo.Text = "Guardar";
            btnGuardarVideo.UseVisualStyleBackColor = true;
            btnGuardarVideo.Click += btnGuardarVideo_Click;
            // 
            // cboCalidadVideo
            // 
            cboCalidadVideo.FormattingEnabled = true;
            cboCalidadVideo.Location = new Point(57, 84);
            cboCalidadVideo.Name = "cboCalidadVideo";
            cboCalidadVideo.Size = new Size(299, 23);
            cboCalidadVideo.TabIndex = 4;
            cboCalidadVideo.Visible = false;
            cboCalidadVideo.SelectedIndexChanged += cboCalidadVideo_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 66);
            label2.Name = "label2";
            label2.Size = new Size(95, 15);
            label2.TabIndex = 5;
            label2.Text = "Calidad de video";
            label2.Visible = false;
            // 
            // btnVerDatosVideo
            // 
            btnVerDatosVideo.Location = new Point(316, 27);
            btnVerDatosVideo.Name = "btnVerDatosVideo";
            btnVerDatosVideo.Size = new Size(40, 23);
            btnVerDatosVideo.TabIndex = 6;
            btnVerDatosVideo.Text = "Ver";
            btnVerDatosVideo.UseVisualStyleBackColor = true;
            btnVerDatosVideo.Click += btnVerDatosVideo_Click;
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Location = new Point(113, 149);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(0, 15);
            lblSize.TabIndex = 7;
            // 
            // FormDescargarVideo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 282);
            Controls.Add(lblSize);
            Controls.Add(btnVerDatosVideo);
            Controls.Add(label2);
            Controls.Add(cboCalidadVideo);
            Controls.Add(btnGuardarVideo);
            Controls.Add(pbrProgresoVideo);
            Controls.Add(txtUrlVideo);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormDescargarVideo";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Descargar video de youtube";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtUrlVideo;
        private ProgressBar pbrProgresoVideo;
        private Button btnGuardarVideo;
        private ComboBox cboCalidadVideo;
        private Label label2;
        private Button btnVerDatosVideo;
        private Label lblSize;
    }
}