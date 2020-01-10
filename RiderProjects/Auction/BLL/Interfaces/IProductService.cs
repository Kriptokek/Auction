using System.Collections.Generic;
using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetProducts();
        void AddProduct(ProductDTO productDto);
        void DeleteProduct(int id);
        void Dispose();
    }
}