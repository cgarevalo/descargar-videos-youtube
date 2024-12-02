namespace Aplicacion
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mspMenu = new MenuStrip();
            audioToolStripMenuItem = new ToolStripMenuItem();
            descargarAudioToolStripMenuItem = new ToolStripMenuItem();
            videoToolStripMenuItem = new ToolStripMenuItem();
            descargarVideoToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            label2 = new Label();
            pbxImagenRelleno = new PictureBox();
            label3 = new Label();
            mspMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxImagenRelleno).BeginInit();
            SuspendLayout();
            // 
            // mspMenu
            // 
            mspMenu.Items.AddRange(new ToolStripItem[] { audioToolStripMenuItem, videoToolStripMenuItem });
            mspMenu.Location = new Point(0, 0);
            mspMenu.Name = "mspMenu";
            mspMenu.Size = new Size(467, 24);
            mspMenu.TabIndex = 0;
            mspMenu.Text = "menuStrip1";
            // 
            // audioToolStripMenuItem
            // 
            audioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { descargarAudioToolStripMenuItem });
            audioToolStripMenuItem.Name = "audioToolStripMenuItem";
            audioToolStripMenuItem.Size = new Size(51, 20);
            audioToolStripMenuItem.Text = "Audio";
            // 
            // descargarAudioToolStripMenuItem
            // 
            descargarAudioToolStripMenuItem.Name = "descargarAudioToolStripMenuItem";
            descargarAudioToolStripMenuItem.Size = new Size(159, 22);
            descargarAudioToolStripMenuItem.Text = "Descargar audio";
            descargarAudioToolStripMenuItem.Click += descargarAudioToolStripMenuItem_Click;
            // 
            // videoToolStripMenuItem
            // 
            videoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { descargarVideoToolStripMenuItem });
            videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            videoToolStripMenuItem.Size = new Size(49, 20);
            videoToolStripMenuItem.Text = "Video";
            // 
            // descargarVideoToolStripMenuItem
            // 
            descargarVideoToolStripMenuItem.Name = "descargarVideoToolStripMenuItem";
            descargarVideoToolStripMenuItem.Size = new Size(158, 22);
            descargarVideoToolStripMenuItem.Text = "Descargar video";
            descargarVideoToolStripMenuItem.Click += descargarVideoToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 37);
            label1.Name = "label1";
            label1.Size = new Size(416, 32);
            label1.TabIndex = 1;
            label1.Text = "Para descargar un video u audio, vaya";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 74);
            label2.Name = "label2";
            label2.Size = new Size(413, 32);
            label2.TabIndex = 2;
            label2.Text = "a la opción correspondiente de arriba";
            // 
            // pbxImagenRelleno
            // 
            pbxImagenRelleno.Location = new Point(12, 152);
            pbxImagenRelleno.Name = "pbxImagenRelleno";
            pbxImagenRelleno.Size = new Size(416, 258);
            pbxImagenRelleno.SizeMode = PictureBoxSizeMode.Zoom;
            pbxImagenRelleno.TabIndex = 3;
            pbxImagenRelleno.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 119);
            label3.Name = "label3";
            label3.Size = new Size(396, 13);
            label3.TabIndex = 4;
            label3.Text = "NOTA: no puede descargar ni convertir, si el video tiene  restricción de edad";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(467, 422);
            Controls.Add(label3);
            Controls.Add(pbxImagenRelleno);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(mspMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Convertidor y descargador de videos";
            Load += FormMain_Load;
            mspMenu.ResumeLayout(false);
            mspMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxImagenRelleno).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mspMenu;
        private ToolStripMenuItem audioToolStripMenuItem;
        private ToolStripMenuItem descargarAudioToolStripMenuItem;
        private ToolStripMenuItem videoToolStripMenuItem;
        private ToolStripMenuItem descargarVideoToolStripMenuItem;
        private Label label1;
        private Label label2;
        private PictureBox pbxImagenRelleno;
        private Label label3;
    }
}
