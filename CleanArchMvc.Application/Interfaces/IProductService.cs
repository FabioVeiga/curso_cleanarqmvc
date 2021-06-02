using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchMvc.Application.DTOs;

namespace CleanArchMvc.Application.Interfaces
{
    public interface IProductService
    {
        Task <IEnumerable<ProductDTO>> GetProductsAsync();
        Task <ProductDTO> GetByIdAsync(int? id);
        //Task <ProductDTO> GetProductCategory(int? id);

        Task AddAsync(ProductDTO productDto);
        Task UpdateAsync(ProductDTO productDto);
        Task removeAsync(int? id);
    }
}