using ProductsAPI.Domains;
using static ProductsAPI.Domains.Products;

namespace ProductsAPI.Interface
{
    public interface IProductsRepository
    {
        List<Products> Get();
        Products GetById(Guid id);
        void Post(Products newProduct);
        void Put(Guid id, Products newProduct);
        void Delete(Guid id);
    }
}
