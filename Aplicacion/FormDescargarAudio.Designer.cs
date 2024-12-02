namespace Aplicacion
{
    partial class FormDescargarAudio
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
            txtUrlAudio = new TextBox();
            btnGuardar = new Button();
            pbrProgreso = new ProgressBar();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(121, 15);
            label1.TabIndex = 0;
            label1.Text = "Pegue la Url del video";
            // 
            // txtUrlAudio
            // 
            txtUrlAudio.Location = new Point(12, 27);
            txtUrlAudio.Name = "txtUrlAudio";
            txtUrlAudio.Size = new Size(361, 23);
            txtUrlAudio.TabIndex = 1;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(100, 94);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(199, 42);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // pbrProgreso
            // 
            pbrProgreso.Location = new Point(144, 65);
            pbrProgreso.Name = "pbrProgreso";
            pbrProgreso.Size = new Size(100, 23);
            pbrProgreso.Style = ProgressBarStyle.Marquee;
            pbrProgreso.TabIndex = 3;
            pbrProgreso.Visible = false;
            // 
            // FormDescargarAudio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 148);
            Controls.Add(pbrProgreso);
            Controls.Add(btnGuardar);
            Controls.Add(txtUrlAudio);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormDescargarAudio";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Convertir video de youtube a audio .m4a";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtUrlAudio;
        private Button btnGuardar;
        private ProgressBar pbrProgreso;
    }
}