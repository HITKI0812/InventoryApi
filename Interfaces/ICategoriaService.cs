using InventoryApi.Dtos;

namespace InventoryApi.Interfaces;

public interface ICategoriaService
{
    Task<CategoriaResponseDto> CreateAsync(CategoriaRequestDto request);

    Task<CategoriaResponseDto?> GetByIdAsync(int id);
}