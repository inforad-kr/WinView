using System.IO;
using System.Threading.Tasks;

namespace WinView.Services
{
    class LocalStorageService : IStorageService
    {
        public Task<string[]> GetImageUrls(string query)
        {
            var filePaths = Directory.Exists(query) ? Directory.GetFiles(query, "*.jpg") : null;
            return Task.FromResult(filePaths);
        }

        public string GetImageName(string imageUrl) => Path.GetFileName(imageUrl);
    }
}
