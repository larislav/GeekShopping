using GeekShopping.Web.Models;

namespace GeekShopping.Web.Services.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> FindAllProducts();
        Task<ProductModel> FindProductById(long id, string token);
        Task<ProductModel> CreateProduct(ProductModel product, string token);
        Task<ProductModel> UpdateProduct(ProductModel product, string token);
        Task<bool> DeleteProduct(long id, string token);

    }
}
