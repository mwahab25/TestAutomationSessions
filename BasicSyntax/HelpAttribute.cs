using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicSyntax
{
    public class HelpAttribute : Attribute
    {
        string url;
        string topic;
        public HelpAttribute(string url)
        {
            this.url = url;
        }
        public string Url => url;
        public string Topic
        {
            get { return topic; }
            set { topic = value; }
        }
    }

}
