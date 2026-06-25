using InventoryApi.Dtos;
using InventoryApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApi.Controllers;

[ApiController]
[Route("api/categorias")]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaService _categoriaService;

    public CategoriasController(ICategoriaService categoriaService)
    {
        _categoriaService = categoriaService;
    }

    [HttpPost]
    public async Task<ActionResult<CategoriaResponseDto>> Create(CategoriaRequestDto request)
    {
        var categoriaCreada = await _categoriaService.CreateAsync(request);

        return CreatedAtAction(
            nameof(GetById),
            new { id = categoriaCreada.Id },
            categoriaCreada
        );
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CategoriaResponseDto>> GetById(int id)
    {
        var categoria = await _categoriaService.GetByIdAsync(id);

        if (categoria is null)
        {
            return NotFound(new
            {
                message = "Categoría no encontrada."
            });
        }

        return Ok(categoria);
    }
}