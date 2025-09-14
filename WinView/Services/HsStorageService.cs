using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace WinView.Services
{
    class HsStorageService : IStorageService
    {
        public async Task<string[]> GetImageUrls(string query)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(Settings.Default.StorageUrl)
            };
            var queryParams = HttpUtility.ParseQueryString(query);
            var ship = queryParams["ship"];
            var report = queryParams["report"];
            var filmid = queryParams["filmid"];
            var vcode = queryParams["vcode"];
            if (ship != null && report != null && filmid != null && vcode != null)
            {
                var input = new
                {
                    I_PSPID = ship,
                    I_REP_NO = report,
                    I_FILMID = filmid,
                    I_VCODE = vcode
                };
                var response = await client.PostAsync($"RunRFC_QMIS?functionname=Z_QMSA_12_0017_GET&input={Uri.EscapeDataString(JsonSerializer.Serialize(input))}", new StringContent(""));
                var files = (await response.Content.ReadFromJsonAsync<ResultContainer>()).ET_RESULT;
                return files.Where(file => file.JD_GB == 'D').Select(file => $"{client.BaseAddress}GetImageFile?dirname={ship}&filename={Path.ChangeExtension(file.FILENM, ".JPG")}").ToArray();
            }
            return null;
        }

        class ResultContainer
        {
            public FileRef[] ET_RESULT { get; set; }
        }

        class FileRef
        {
            public char JD_GB { get; set; }

            public string FILENM { get; set; }
        }
    }
}
