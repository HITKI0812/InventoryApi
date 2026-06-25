using System.ComponentModel.DataAnnotations;

namespace InventoryApi.Dtos;

public class ProductoRequestDto
{
    [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre del producto no puede superar los 100 caracteres.")]
    [RegularExpression(@"^(?=.*\S)[a-zA-Z0-9áéíóúÁÉÍÓÚñÑ ]+$",
        ErrorMessage = "El nombre del producto solo debe contener letras, números y espacios.")]
    public string Nombre { get; set; } = string.Empty;

    [Range(typeof(decimal), "0.01", "999999999999999999",
        ErrorMessage = "El precio debe ser mayor a cero.")]
    public decimal Precio { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "La cantidad en stock debe ser mayor a cero.")]
    public int CantidadStock { get; set; }
}