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

 Funcionalidad Disponible

 Autenticación de Administrador
- Se puede iniciar sesión únicamente con un usuario de tipo **Administrador**.
- Al iniciar sesión, el sistema redirige al administrador al panel principal.

Menú Dinámico según Rol
Una vez autenticado como administrador, se muestra un menú con las siguientes opciones:
- **Usuarios**
- **Roles**
- **Mi Perfil**
- **Cerrar Sesión**

Actualmente solo la opción **Roles** está 100% funcional.

---

Módulo de Roles
 Funcionalidades disponibles:
- Crear Rol 
  Formulario para registrar un nuevo rol en el sistema.
- Editar Rol  
  Permite modificar el nombre de un rol existente.
- Eliminar Rol 
  Elimina un rol de forma permanente.
- Listar Roles
  Muestra todos los roles registrados en la base de datos.

Todas estas operaciones interactúan con la base de datos mediante Entity Framework Core.

---

## Estructura del Proyecto

- `Models/`  
  Contiene las clases de modelo `User` y `Role`, utilizadas para mapear las entidades de base de datos.

- `Controllers/`  
  Controladores MVC como `UserController` y `RoleController` que manejan la lógica de las vistas y el acceso a los datos.

- `Views/`  
  Vistas Razor (.cshtml) para cada funcionalidad, organizadas por carpeta según el controlador.

- `Data/ApplicationDbContext.cs`  
  Archivo que gestiona el contexto de base de datos mediante Entity Framework Core.

- `Program.cs / Startup.cs`  
  Configuración de servicios, autenticación, y conexión a base de datos SQL Server.

---

Tecnologías Utilizadas

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Bootstrap 5 (para diseño responsivo)
- Identity (autenticación básica por roles, personalizada)

---

## Cómo Ejecutar el Proyecto

1. Clona el repositorio:
   ```bash
   git clone https://github.com/tuusuario/tu-proyecto.git
   cd tu-proyecto
   Configura la cadena de conexión a tu base de datos en appsettings.json.

Ejecuta las migraciones para crear la base de datos:

dotnet ef migrations add InitialCreate
dotnet ef database update

Ejecuta el proyecto:

dotnet run

Accede a la aplicación desde tu navegador:


Credenciales de Acceso

Actualmente solo se puede acceder con un usuario administrador predefinido en la base de datos. 
Si no existe, deberás agregarlo manualmente con SQL Server Management Studio o mediante una migración de datos.