using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationBusiness
{
    public class VideoDownloader
    {
        private readonly IVideoRepository _videoRepository;

        public VideoDownloader(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public async Task ExecuteAsync(string videoUrl, string outputPath, string videoQuality)
        {
            await _videoRepository.VideoDownloadAsync(videoUrl, outputPath, videoQuality);
        }
    }
}
