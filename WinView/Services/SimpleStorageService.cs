using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web;

namespace WinView.Services
{
    class SimpleStorageService : IStorageService
    {
        public async Task<string[]> GetImageUrls(string query)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(Settings.Default.StorageUrl)
            };
            var queryParams = HttpUtility.ParseQueryString(query);
            var folderName = queryParams["foldername"];
            if (folderName != null)
            {
                var fileNames = await client.GetFromJsonAsync<string[]>("storage/" + folderName);
                return fileNames.Select(fileName => $"{client.BaseAddress}storage/{folderName}/{Path.ChangeExtension(fileName, ".jpg")}").ToArray();
            }
            return null;
        }

        public string GetImageName(string imageUrl) => Path.GetFileName(imageUrl);
    }
}
