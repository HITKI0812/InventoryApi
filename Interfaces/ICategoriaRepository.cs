using InventoryApi.Entities;

namespace InventoryApi.Interfaces;

public interface ICategoriaRepository
{
    Task<Categoria> CreateAsync(Categoria categoria);

    Task<Categoria?> GetByIdWithProductsAsync(int id);
}