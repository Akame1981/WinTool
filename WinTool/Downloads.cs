using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinTool
{
    internal class Downloads
    {
        private string name;
        private string downloadUrl;
        private string description;
        private DateTime pubdate;
        private string version;
        private string ext;

        public Downloads(string name, string downloadUrl, string description,string version,string ext, DateTime pubdate)
        {
            this.name = name;
            this.downloadUrl = downloadUrl;
            this.description = description;
            this.pubdate = pubdate;
            this.version = version;
            this.ext = ext;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string DownloadUrl
        {
            get { return downloadUrl; }
            set { downloadUrl = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public DateTime PublishedDate
        {
            get { return pubdate; }
            set { pubdate = value; }
        }
        public string Version
        {
            get { return version; }
            set { version = value; }
        }
        public string Extension
        {
            get { return ext; }
            set { ext = value; }
        }


    }
}
