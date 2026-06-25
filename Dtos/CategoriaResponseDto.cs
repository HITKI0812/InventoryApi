namespace InventoryApi.Dtos;

public class CategoriaResponseDto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public List<ProductoResponseDto> Productos { get; set; } = new();
}