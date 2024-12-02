using Entity;

namespace ApplicationBusiness
{
    public class AudioDownloader
    {
        private readonly IAudioRepository _audioRepository;

        public AudioDownloader(IAudioRepository audioRepository)
        {
            _audioRepository = audioRepository;
        }

        public async Task ExecuteAsync(string videoUrl, string outputPath)
        {
            await _audioRepository.DownloadAudioAsync(videoUrl, outputPath);
        }
    }
}
