# Proyecto ASP.NET MVC - Gesti�n de Roles y Usuarios

Este proyecto implementa dos CRUD b�sicos de usuario y rol utilizando Entity Framework Core y SQL Server.

Requisitos

- .NET 6 o superior
- Visual Studio 2022
- SQL Server
- Paquetes instalados:
  - Microsoft.EntityFrameworkCore.SqlServer
  - Microsoft.EntityFrameworkCore.Tools

Instalaci�n

1. Clona el repositorio o descarga el proyecto.
2. Abre el proyecto en Visual Studio.
3. Configura la cadena de conexi�n en `appsettings.json`.

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR;Database=PracticaSeedCode;Trusted_Connection=True;"
}

 Funcionalidad Disponible

 Autenticaci�n de Administrador
- Se puede iniciar sesi�n �nicamente con un usuario de tipo **Administrador**.
- Al iniciar sesi�n, el sistema redirige al administrador al panel principal.

Men� Din�mico seg�n Rol
Una vez autenticado como administrador, se muestra un men� con las siguientes opciones:
- **Usuarios**
- **Roles**
- **Mi Perfil**
- **Cerrar Sesi�n**

Actualmente solo la opci�n **Roles** est� 100% funcional.

---

M�dulo de Roles
 Funcionalidades disponibles:
- Crear Rol 
  Formulario para registrar un nuevo rol en el sistema.
- Editar Rol  
  Permite modificar el nombre de un rol existente.
- Eliminar Rol 
  Elimina un rol de forma permanente.
- Listar Roles
  Muestra todos los roles registrados en la base de datos.

Todas estas operaciones interact�an con la base de datos mediante Entity Framework Core.

---

## Estructura del Proyecto

- `Models/`  
  Contiene las clases de modelo `User` y `Role`, utilizadas para mapear las entidades de base de datos.

- `Controllers/`  
  Controladores MVC como `UserController` y `RoleController` que manejan la l�gica de las vistas y el acceso a los datos.

- `Views/`  
  Vistas Razor (.cshtml) para cada funcionalidad, organizadas por carpeta seg�n el controlador.

- `Data/ApplicationDbContext.cs`  
  Archivo que gestiona el contexto de base de datos mediante Entity Framework Core.

- `Program.cs / Startup.cs`  
  Configuraci�n de servicios, autenticaci�n, y conexi�n a base de datos SQL Server.

---

Tecnolog�as Utilizadas

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Bootstrap 5 (para dise�o responsivo)
- Identity (autenticaci�n b�sica por roles, personalizada)

---

## C�mo Ejecutar el Proyecto

1. Clona el repositorio:
   ```bash
   git clone https://github.com/tuusuario/tu-proyecto.git
   cd tu-proyecto
   Configura la cadena de conexi�n a tu base de datos en appsettings.json.

Ejecuta las migraciones para crear la base de datos:

dotnet ef migrations add InitialCreate
dotnet ef database update

Ejecuta el proyecto:

dotnet run

Accede a la aplicaci�n desde tu navegador:


Credenciales de Acceso

Actualmente solo se puede acceder con un usuario administrador predefinido en la base de datos. 
Si no existe, deber�s agregarlo manualmente con SQL Server Management Studio o mediante una migraci�n de datos.