using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarocodeReader.Interfaces
{
    public interface IAudio
    {
        void PlayAudioFile(string uri);

        void PlayAudioFileFromLocal(string fileName);
    }
}
