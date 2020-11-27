using System.IO;
using System.Threading.Tasks;

namespace AirTickedSales.Application.Catalog.Common
{
    public interface IStorageService
    {
        string GetFileUrl(string fileName);
        Task SaveFileAsync(Stream mediaBinaryStream, string fileName);
        Task DeleteFileAsync(string fileName);

    }
}
