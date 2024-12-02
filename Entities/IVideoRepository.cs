using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public interface IVideoRepository
    {
        Task<List<StreamInfo>> GetAvailableStreamsAsync(string videoUrl);
        Task VideoDownloadAsync(string videoUrl, string outputPath, string videoQuality);
    }
}
