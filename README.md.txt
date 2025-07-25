# Proyecto ASP.NET MVC - Gestión de Roles y Usuarios

Este proyecto implementa dos CRUD básicos de usuario y rol utilizando Entity Framework Core y SQL Server.

Requisitos

- .NET 6 o superior
- Visual Studio 2022
- SQL Server
- Paquetes instalados:
  - Microsoft.EntityFrameworkCore.SqlServer
  - Microsoft.EntityFrameworkCore.Tools

Instalación

1. Clona el repositorio o descarga el proyecto.
2. Abre el proyecto en Visual Studio.
3. Configura la cadena de conexión en `appsettings.json`.

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR;Database=PracticaSeedCode;Trusted_Connection=True;"
}

