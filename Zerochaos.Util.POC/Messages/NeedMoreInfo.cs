using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zerochaos.Util.POC.Messages
{
    public class NeedMoreInfo
    {
        public List<string> Options { get; set; }
        public string Title { get; set; }
        public NeedMoreInfo(string title,List<string> options)
        {
            this.Title = title;
            this.Options = options;
        }

    }
}
