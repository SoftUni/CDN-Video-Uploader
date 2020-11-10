using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDN_Video_Uploader.Data
{
    public class TaskForExecution
    {
        public string Description { get; set; }
        public string Status { get; set; }
        public float PercentsDone { get; set; }
        public string SourceFileName { get; set; }
        public List<TaskAction> Actions { get; set; }
    }
}
