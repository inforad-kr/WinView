using System.IO;
using System.Threading.Tasks;

namespace WinView.Services
{
    class LocalStorageService : IStorageService
    {
        public Task<string[]> GetImageUrls(string query)
        {
            var filePaths = Directory.GetFiles(query, "*.jpg");
            return Task.FromResult(filePaths);
        }
    }
}
