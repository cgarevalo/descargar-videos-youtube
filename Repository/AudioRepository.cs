using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace Repository
{
    public class AudioRepository : IAudioRepository
    {

        public async Task DownloadAudioAsync(string videoUrl, string outputPath)
        {
            // Cliente de YouTube
            var youtubeClient = new YoutubeClient();

            // Obtiene información del video
            var video = await youtubeClient.Videos.GetAsync(videoUrl);
            string videoTitle = video.Title;

            // Limpia el título del video para que sea válido como nombre de archivo
            string tituloLimpio = string.Concat(videoTitle.Split(Path.GetInvalidFileNameChars()));
            string fileName = $"{tituloLimpio}.m4a";

            // Combina el directorio con el nombre del archivo
            string fullOutputPath = Path.Combine(outputPath, fileName);

            // Obtiene información de los flujos disponibles
            var streamMainFest = await youtubeClient.Videos.Streams.GetManifestAsync(videoUrl);
            // Selecciona el flujo de audio de mayor calidad
            var audioStreamInfo = streamMainFest.GetAudioOnlyStreams().GetWithHighestBitrate();

            if (audioStreamInfo == null)
                throw new Exception("No se encontró un flujo de audio para este video.");

            // Descarga el flujo de audio
            await youtubeClient.Videos.Streams.DownloadAsync(audioStreamInfo, fullOutputPath);
        }
    }
}
