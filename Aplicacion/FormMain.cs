using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace Aplicacion
{
    public partial class FormMain : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public FormMain(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                // Verificar conexión a Internet
                if (!await HayConexionInternetAsync())
                {
                    MessageBox.Show("No tienes conexión a Internet. Algunas funcionalidades no estarán disponibles.", "Sin conexión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Application.StartupPath: Obtiene el directorio donde se encuentra el ejecutable
                // ..\..\.. : Retrocede al nivel raíz del proyecto
                string rutaImagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Imagen", "meme.jpg");

                pbxImagenRelleno.Image = Image.FromFile(rutaImagen);
            }
            catch (FileNotFoundException)
            {
                // Si el archivo no se encuentra
                pbxImagenRelleno.Load("https://image.shutterstock.com/image-vector/ui-image-placeholder-wireframes-apps-260nw-1037719204.jpg");
            }
        }

        private void descargarAudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<FormDescargarAudio>();
            frm.ShowDialog();
        }

        private void descargarVideoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = _serviceProvider.GetRequiredService<FormDescargarVideo>();
            frm.ShowDialog();
        }

        private async Task<bool> HayConexionInternetAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Establecer un tiempo de espera breve para evitar bloqueos
                    client.Timeout = TimeSpan.FromSeconds(5);

                    // Enviar una solicitud HEAD a un sitio confiable
                    HttpResponseMessage response = await client.GetAsync("https://www.google.com", HttpCompletionOption.ResponseHeadersRead);
                    return response.IsSuccessStatusCode;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
