using System.ComponentModel.DataAnnotations;

namespace InventoryApi.Dtos;

public class CategoriaRequestDto
{
    [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre de la categoría no puede superar los 100 caracteres.")]
    [RegularExpression(@"^(?=.*\S).+$",
        ErrorMessage = "El nombre de la categoría no puede estar vacío ni contener solo espacios.")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "Debe agregar al menos un producto.")]
    [MinLength(1, ErrorMessage = "Debe agregar al menos un producto.")]
    public List<ProductoRequestDto> Productos { get; set; } = new();
}