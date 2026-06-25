using InventoryApi.Dtos;
using InventoryApi.Entities;
using InventoryApi.Interfaces;

namespace InventoryApi.Services;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;

    public CategoriaService(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    public async Task<CategoriaResponseDto> CreateAsync(CategoriaRequestDto request)
    {
        var categoria = new Categoria
        {
            Nombre = request.Nombre.Trim(),
            Productos = request.Productos.Select(producto => new Producto
            {
                Nombre = producto.Nombre.Trim(),
                Precio = producto.Precio,
                CantidadStock = producto.CantidadStock
            }).ToList()
        };

        var categoriaCreada = await _categoriaRepository.CreateAsync(categoria);

        return MapToResponseDto(categoriaCreada);
    }

    public async Task<CategoriaResponseDto?> GetByIdAsync(int id)
    {
        var categoria = await _categoriaRepository.GetByIdWithProductsAsync(id);

        if (categoria is null)
        {
            return null;
        }

        return MapToResponseDto(categoria);
    }

    private static CategoriaResponseDto MapToResponseDto(Categoria categoria)
    {
        return new CategoriaResponseDto
        {
            Id = categoria.Id,
            Nombre = categoria.Nombre,
            Productos = categoria.Productos.Select(producto => new ProductoResponseDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                CantidadStock = producto.CantidadStock
            }).ToList()
        };
    }
}