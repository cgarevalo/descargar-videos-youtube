using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using System.Diagnostics;
using YoutubeExplode.Converter;
using YoutubeExplode.Videos;

namespace Repository
{
    public class VideoRepository : IVideoRepository
    {
        private readonly YoutubeClient _youtubeClient;
        public VideoRepository()
        {
            _youtubeClient = new YoutubeClient();
        }

        public async Task VideoDownloadAsync(string videoUrl, string outputPath, string videoQuality)
        {
            // 0. Verifica si es posible descargar el video
            await IsVideoPlayableAsync(videoUrl);

            // 1. Validar y obtener los flujos de video y audio
            var streams = await GetVideoAndAudioStreamsAsync(videoUrl, videoQuality);

            // 2. Generar el nombre del archivo
            string fileName = GenerateFileName(await _youtubeClient.Videos.GetAsync(videoUrl));
            string fullOutputPath = Path.Combine(outputPath, fileName);

            // 3. Descargar y combinar usando FFmpeg
            await DownloadAndCombineAsync(streams.videoStream, streams.audioStream, fullOutputPath);
        }

        public async Task<List<StreamInfo>> GetAvailableStreamsAsync(string videoUrl)
        {
            // Verifica si es posible descargar el vide
            await IsVideoPlayableAsync(videoUrl);

            var streamManifest = await _youtubeClient.Videos.Streams.GetManifestAsync(videoUrl);

            if (streamManifest == null)
                throw new Exception("No se pudieron obtener los flujos del video.");

            var availableStreams = new List<StreamInfo>();

            // Agrega flujos de video
            foreach (var videoStream in streamManifest.GetVideoOnlyStreams())
            {
                availableStreams.Add(new StreamInfo
                {
                    StreamType = "Video",
                    Quality = videoStream.VideoQuality.Label,
                    Size = videoStream.Size.MegaBytes,
                    Url = videoStream.Url
                });
            }


            // Obtén el flujo de audio con la calidad más alta
            var audioStream = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();

            availableStreams.Add(new StreamInfo
            {
                StreamType = "Audio",
                Quality = $"{audioStream.Bitrate.KiloBitsPerSecond} kbps",
                Size = audioStream.Size.MegaBytes,
                Url = audioStream.Url
            });

            return availableStreams;
        }

        private async Task<(IStreamInfo videoStream, IStreamInfo audioStream)> GetVideoAndAudioStreamsAsync(string videoUrl, string videoQuality)
        {
            var streamManifest = await _youtubeClient.Videos.Streams.GetManifestAsync(videoUrl);

            // Seleccionar el flujo de video
            var videoStream = streamManifest
                .GetVideoOnlyStreams()
                .FirstOrDefault(v => v.VideoQuality.Label == videoQuality);
            if (videoStream == null)
                throw new Exception($"No se encontró un flujo de video con la calidad seleccionada: {videoQuality}");

            // Seleccionar el flujo de audio
            var audioStream = streamManifest.GetAudioOnlyStreams().GetWithHighestBitrate();
            if (audioStream == null)
                throw new Exception("No se encontró un flujo de audio disponible.");

            return (videoStream, audioStream);
        }

        private string GenerateFileName(Video video)
        {
            string videoTitle = video.Title;

            // Limpia el título para que sea válido como nombre de archivo
            string tituloLimpio = string.Concat(videoTitle.Split(Path.GetInvalidFileNameChars()));
            return $"{tituloLimpio}.mp4";
        }

        private async Task DownloadAndCombineAsync(IStreamInfo videoStream, IStreamInfo audioStream, string outputPath)
        {
            await _youtubeClient.Videos.DownloadAsync(
                new[] { videoStream, audioStream },
                new ConversionRequestBuilder(outputPath)
                    .SetFFmpegPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "ffmpeg.exe"))
                    .SetContainer("mp4")
                    .Build()
            );

            /* Otra forma de hacerlo, pero no se puede elegir la calidad
             * // Cliente de YouTube
            var youtubeClient = new YoutubeClient();

            // Usa FFmpeg para descargar y combinar
            await youtubeClient.Videos.DownloadAsync(
                videoUrl,// URL del video
                fullOutputPath, // Ruta del archivo de salida
                builder => builder
                .SetFFmpegPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "ffmpeg.exe")) // Ruta a FFmpeg
                .SetContainer("mp4")// Especifica el contenedor del archivo de salida
            );
             */
        }

        public async Task IsVideoPlayableAsync(string videoUrl)
        {
            try
            {
                var video = await _youtubeClient.Videos.Streams.GetManifestAsync(videoUrl);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("sign in"))
                {
                    throw new Exception("El video tiene restricción de edad.");
                }
                throw new Exception($"El video no está disponible: {ex.Message}");
            }
        }
    }
}