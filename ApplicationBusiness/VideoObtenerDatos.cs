using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationBusiness
{
    public class VideoObtenerDatos
    {
        private readonly IVideoRepository _videoRepository;

        public VideoObtenerDatos(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public async Task<List<StreamInfo>> ExecuteAsync(string videoUrl)
        {
            return await _videoRepository.GetAvailableStreamsAsync(videoUrl);
        }
    }
}
