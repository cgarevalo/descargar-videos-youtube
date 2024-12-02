using ApplicationBusiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicacion
{
    public partial class FormDescargarAudio : Form
    {
        private readonly AudioDownloader _audioDownloader;

        public FormDescargarAudio(AudioDownloader audioDownloader)
        {
            InitializeComponent();
            _audioDownloader = audioDownloader;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            string videoUrl = txtUrlAudio.Text.Trim();
            if (string.IsNullOrWhiteSpace(videoUrl))
            {
                MessageBox.Show("Primero ingrese la url.");
                return;
            }
            if (!txtUrlAudio.Text.StartsWith("https://www.youtube.com/"))
            {
                MessageBox.Show("Ingrese una URL de youtube válida.");
                Resetear();
                return;
            }

            string folderPath = ObtenerRuta();
            if (string.IsNullOrWhiteSpace(folderPath))
                return;

            if (string.IsNullOrWhiteSpace(videoUrl) || string.IsNullOrEmpty(folderPath))
            {
                MessageBox.Show("Cargue ambos campos.");
                return;
            }

            IniciarProgressBar();

            try
            {
                await _audioDownloader.ExecuteAsync(videoUrl, folderPath);
                MessageBox.Show("Audio descargado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un erro al descargar el audio: {ex.Message}");
            }
            finally
            {
                Resetear();
            }
        }

        private string ObtenerRuta()
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            string path;

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                path = folderBrowserDialog.SelectedPath;

                if (!HasWritePermission(path))
                {
                    MessageBox.Show("No tiene permiso para escribir en la carpeta. Elija otra.");
                    return string.Empty;
                }

                return path;
            }

            return string.Empty;
        }

        // Comprueba si se tiene permiso de escritura en la carpeta
        private bool HasWritePermission(string path)
        {
            try
            {
                var testFilePath = Path.Combine(path, "test.tmp");
                File.Create(testFilePath).Close();
                File.Delete(testFilePath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void IniciarProgressBar()
        {
            btnGuardar.Enabled = false;
            pbrProgreso.Visible = true;
            pbrProgreso.Style = ProgressBarStyle.Marquee; // Cambia el estilo a indeterminado
        }

        private void Resetear()
        {
            btnGuardar.Enabled = true;
            pbrProgreso.Visible = false;
            txtUrlAudio.Text = string.Empty;
        }
    }
}
