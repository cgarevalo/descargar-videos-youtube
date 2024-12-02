using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class StreamInfo
    {
        public string StreamType { get; set; } // Video o Audio
        public string Quality { get; set; } // Ejemplo: 1080p o 128 kbps
        public double Size { get; set; } // Tamaño en MB
        public string Url { get; set; } // URL del flujo
    }
}
