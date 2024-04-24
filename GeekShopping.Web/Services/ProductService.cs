using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;

namespace GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;

        public const string BasePath = "api/v1/product";

        public ProductService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAsync<List<ProductModel>>();
        }

        public async Task<ProductModel> FindProductById(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAsync<ProductModel>();
        }
        public async Task<ProductModel> CreateProduct(ProductModel product)
        {
            var response = await _client.PostAsJson(BasePath, product);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Something went wrong calling the API {BasePath} : {response.RequestMessage?.Method}");
            return await response.ReadContentAsync<ProductModel>();
        }

        public async Task<ProductModel> UpdateProduct(ProductModel product)
        {
            var response = await _client.PutAsJson(BasePath, product);
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Something went wrong calling the API {BasePath} : {response.RequestMessage?.Method}");
            return await response.ReadContentAsync<ProductModel>();
        }

        public async Task<bool> DeleteProduct(long id)
        {
            var response = await _client.DeleteAsync($"{BasePath}/{id}");
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Something went wrong calling the API {BasePath} : {response.RequestMessage?.Method}");
            return await response.ReadContentAsync<bool>();
        }

       
    }
}
