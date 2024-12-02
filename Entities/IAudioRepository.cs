using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public interface IAudioRepository
    {
        Task DownloadAudioAsync(string videoUrl, string outputPath);
    }
}
