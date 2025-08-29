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
            var studyId = queryParams["studyid"];
            var fileNames = await client.GetFromJsonAsync<string[]>("storage/" + studyId);
            return fileNames.Select(fileName => $"{client.BaseAddress}storage/{studyId}/{Path.ChangeExtension(fileName, ".jpg")}").ToArray();
        }
    }
}
