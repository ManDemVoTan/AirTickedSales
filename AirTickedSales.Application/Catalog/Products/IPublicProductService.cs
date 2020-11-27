using AirTickedSales.ViewModel.Catalog.Common;
using AirTickedSales.ViewModel.Catalog.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirTickedSales.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PageResult<ProductViewModel>> GetAllByCategoryId(string LanguageId, GetPublicProductPagingRequest request);
        //Task<List<ProductViewModel>> GetAll(string languageId);
    }
}
