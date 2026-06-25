using InventoryApi.Data;
using InventoryApi.Entities;
using InventoryApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryApi.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly AppDbContext _context;

    public CategoriaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Categoria> CreateAsync(Categoria categoria)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return categoria;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<Categoria?> GetByIdWithProductsAsync(int id)
    {
        return await _context.Categorias
            .Include(c => c.Productos)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}