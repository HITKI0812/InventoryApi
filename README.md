# Inventory API

API REST desarrollada en .NET para gestionar categorías y productos de inventario.

El proyecto permite crear una categoría junto con múltiples productos asociados en una sola petición HTTP y consultar una categoría por su identificador, incluyendo la lista completa de productos relacionados.

## Tecnologías utilizadas

* .NET 9
* ASP.NET Core Web API
* Entity Framework Core
* SQLite
* C#
* Postman

## Funcionalidades principales

* Crear categorías con múltiples productos asociados.
* Consultar una categoría por ID incluyendo sus productos.
* Validar campos obligatorios.
* Validar que el nombre del producto solo contenga caracteres alfanuméricos y espacios.
* Validar que los valores numéricos, como precio y stock, sean mayores a cero.
* Separar responsabilidades mediante controladores, servicios, repositorios, DTOs y entidades.

## Estructura del proyecto

```text
InventoryApi/
├── Controllers/
├── Data/
├── Dtos/
├── Entities/
├── Interfaces/
├── Migrations/
├── Repositories/
├── Services/
├── Program.cs
├── appsettings.json
└── InventoryApi.csproj
```

## Descripción de carpetas

* `Controllers`: contiene los endpoints de la API.
* `Data`: contiene el `AppDbContext` para Entity Framework Core.
* `Dtos`: contiene los objetos de transferencia de datos para entrada y salida.
* `Entities`: contiene las entidades principales del dominio.
* `Interfaces`: contiene los contratos de servicios y repositorios.
* `Repositories`: contiene la lógica de acceso a datos.
* `Services`: contiene la lógica de negocio.
* `Migrations`: contiene las migraciones de Entity Framework Core.

## Endpoints disponibles

### Crear categoría con productos

```http
POST /api/categorias
```

Ejemplo de petición:

```json
{
  "nombre": "Electronica",
  "productos": [
    {
      "nombre": "Mouse Logitech",
      "precio": 150.50,
      "cantidadStock": 10
    },
    {
      "nombre": "Teclado Mecanico",
      "precio": 350.00,
      "cantidadStock": 5
    }
  ]
}
```

Respuesta esperada:

```http
201 Created
```

### Obtener categoría por ID

```http
GET /api/categorias/{id}
```

Ejemplo:

```http
GET /api/categorias/1
```

Respuesta esperada:

```json
{
  "id": 1,
  "nombre": "Electronica",
  "productos": [
    {
      "id": 1,
      "nombre": "Mouse Logitech",
      "precio": 150.5,
      "cantidadStock": 10
    }
  ]
}
```

## Validaciones implementadas

* El nombre de la categoría es obligatorio.
* El nombre del producto es obligatorio.
* El nombre del producto solo acepta letras, números y espacios.
* El precio debe ser mayor a cero.
* La cantidad en stock debe ser mayor a cero.
* La categoría debe contener al menos un producto.

## Cómo ejecutar el proyecto

Restaurar paquetes:

```bash
dotnet restore
```

Aplicar migraciones y crear la base de datos SQLite:

```bash
dotnet ef database update
```

Ejecutar la API:

```bash
dotnet run
```

La API se ejecutará en una URL similar a:

```text
http://localhost:5122
```

## Pruebas realizadas

Se realizaron pruebas en Postman para validar:

* `POST /api/categorias` devuelve `201 Created`.
* `GET /api/categorias/{id}` devuelve `200 OK`.
* Datos inválidos devuelven `400 Bad Request`.
* Categorías inexistentes devuelven `404 Not Found`.

## Decisiones técnicas

Se utilizó una arquitectura separada por responsabilidades para facilitar mantenimiento, escalabilidad y futuras pruebas unitarias.

El controlador se encarga únicamente de recibir las peticiones HTTP y devolver respuestas. La lógica principal se encuentra en la capa de servicios, mientras que el acceso a la base de datos se maneja mediante repositorios.

Se utilizaron DTOs para evitar exponer directamente las entidades de base de datos en la capa de presentación.
