using System;

namespace WinView.Models
{
    class Image
    {
        public Image(string url)
        {
            Uri = new Uri(url);
        }

        public Uri Uri { get; }

        public string Name { get; set; }
    }
}
