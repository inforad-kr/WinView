using System.Threading.Tasks;

namespace WinView.Services
{
    interface IStorageService
    {
        Task<string[]> GetImageUrls(string query);
   }
}
