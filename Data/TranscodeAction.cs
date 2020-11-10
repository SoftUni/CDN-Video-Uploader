using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDN_Video_Uploader.Data
{
    public class TranscodeAction : TaskAction
    {
        public string TranscodingCommand { get; set; }
        public string OutputFile { get; set; }
    }
}
