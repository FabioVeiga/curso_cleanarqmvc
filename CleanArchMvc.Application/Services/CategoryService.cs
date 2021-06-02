using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categoriesEntity = await _categoryRepository.GetCategoriesAsync();
            //irá mapear a entidade e retornar com as propriedades da DTO
            //O auto mapper realiza esta operação
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetByIDAsync(int? id)
        {
            var categoriesEntity = await _categoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(categoriesEntity);
        }

        public async Task AddAsync(CategoryDTO categoryDto)
        {
            //deve converter a DTO para tipo Entity
            var categoriesEntity = _mapper.Map<Category>(categoryDto);
            //passa por paramentro o modelo convertido
            await _categoryRepository.CreateAsync(categoriesEntity);
        }

        public async Task UpdateAsync(CategoryDTO categoryDto)
        {
            var categoriesEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.UpdateAsync(categoriesEntity);
        }

        public async Task RemoveAsync(int? id)
        {
            //result, já converte para a DTO
            var categoriesEntity = _categoryRepository.GetByIdAsync(id).Result;
            await _categoryRepository.RemoveAsync(categoriesEntity);
        }
    }
}