using System;
using System.IO;

namespace WinView.Models
{
    class Image
    {
        readonly string m_Url;

        public Image(string url)
        {
            m_Url = url;
        }

        public Uri Uri => new Uri(m_Url);

        public string Name => Path.GetFileNameWithoutExtension(m_Url);
    }
}
