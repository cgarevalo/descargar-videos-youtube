using ApplicationBusiness;
using Entity;
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
    public partial class FormDescargarVideo : Form
    {
        private readonly VideoDownloader _videoDownloader;
        private readonly VideoObtenerDatos _videoDatos;

        public FormDescargarVideo(VideoDownloader videoDownloader, VideoObtenerDatos videoObtener)
        {
            InitializeComponent();
            _videoDownloader = videoDownloader;
            _videoDatos = videoObtener;
        }

        private async void btnGuardarVideo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUrlVideo.Text))
            {
                MessageBox.Show("Primero pegue la URL.");
                return;
            }
            if (!txtUrlVideo.Text.StartsWith("https://www.youtube.com/"))
            {
                MessageBox.Show("Ingrese una URL de youtube válida.");
                Resetear();
                return;
            }
            if (!(cboCalidadVideo.SelectedIndex != -1))
            {
                MessageBox.Show("Presione el botón 'Ver' para poder seleccionar una calidad de video.");
                return;
            }

            string videoUrl = txtUrlVideo.Text;
            string videoQuality = cboCalidadVideo.SelectedValue.ToString();

            if (string.IsNullOrEmpty(videoQuality))
            {
                MessageBox.Show("Por favor, selecciona una calidad de video.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string folderPath = ObtenerRuta();
            if (string.IsNullOrEmpty(folderPath))
                return;

            IniciarProgressBar();

            try
            {
                await _videoDownloader.ExecuteAsync(videoUrl, folderPath, videoQuality);
                MessageBox.Show("Video descargado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al descargar el video: {ex.Message}.");
            }
            finally
            {
                Resetear();
            }
        }

        private async void btnVerDatosVideo_Click(object sender, EventArgs e)
        {
            // Evitar que se ejecute la búsqueda si el texto está vacío
            if (string.IsNullOrWhiteSpace(txtUrlVideo.Text))
            {
                cboCalidadVideo.DataSource = null;
                return;
            }

            // Evita que se ejecute la busqueda si no es una url de youtube
            if (!txtUrlVideo.Text.StartsWith("https://www.youtube.com/"))
            {
                MessageBox.Show("Ingrese una URL de youtube válida.");
                Resetear();
                return;
            }

            try
            {
                IniciarProgressBar();

                var streams = await _videoDatos.ExecuteAsync(txtUrlVideo.Text);

                if (streams != null && streams.Any())
                {
                    // Filtrar flujos de video y audio
                    var videoStreams = streams.Where(s => s.StreamType == "Video").ToList();

                    // Asigna los datos al ComboBox
                    cboCalidadVideo.DataSource = videoStreams;
                    cboCalidadVideo.DisplayMember = "Quality"; // El texto que se mostrará
                    cboCalidadVideo.ValueMember = "Quality"; // Usar la URL como valor

                    pbrProgresoVideo.Visible = false;
                    btnGuardarVideo.Enabled = true;
                    cboCalidadVideo.Visible = true;
                }
                else
                {
                    // Si no se encontraron flujos, limpiar el ComboBox
                    cboCalidadVideo.DataSource = null;
                }

                bool noVaciarTxt = false, noVaciarCbo = false;
                Resetear(noVaciarTxt, noVaciarCbo);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del video: {ex.Message}");
                Resetear();
            }
        }

        private async void cboCalidadVideo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCalidadVideo.SelectedItem is StreamInfo selectedStream)
            {
                var datos = await _videoDatos.ExecuteAsync(txtUrlVideo.Text);
                var audioStream = datos.FirstOrDefault(a => a.StreamType == "Audio");

                if (audioStream == null)
                {
                    MessageBox.Show("Sin flujo de audio o video");
                    return;
                }

                double fullSize = selectedStream.Size + audioStream.Size;

                // Mostrar el peso del video en un Label
                lblSize.Text = $"Tamaño aproximado: {fullSize:F2} MB";
            }
            else
            {
                lblSize.Text = "Tamaño: No disponible";
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

        private void IniciarProgressBar()
        {
            btnGuardarVideo.Enabled = false;
            btnVerDatosVideo.Enabled = false;
            pbrProgresoVideo.Visible = true;
            pbrProgresoVideo.Style = ProgressBarStyle.Marquee; // Cambia el estilo a indeterminado
        }

        private void Resetear(bool txtCondicion = true, bool cboCondicion = true)
        {
            btnGuardarVideo.Enabled = true;
            btnVerDatosVideo.Enabled = true;
            pbrProgresoVideo.Visible = false;
            if (txtCondicion)
                txtUrlVideo.Text = string.Empty;
            if (cboCondicion)
            {
                cboCalidadVideo.DataSource = null;
                cboCalidadVideo.Visible = false;
            }

            lblSize.Text = string.Empty;
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
    }
}