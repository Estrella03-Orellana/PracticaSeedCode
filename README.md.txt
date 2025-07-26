# Proyecto ASP.NET MVC - Gesti�n Integral de Usuarios y Roles

Este proyecto es un sistema web completo en ASP.NET Core MVC para la gesti�n integral de usuarios y roles.

---

## Caracter�sticas Principales

El proyecto es 100% funcional e incluye:

Autenticaci�n por Roles: Login, control de acceso por rol y p�gina de acceso denegado.
P�gina de Inicio: Introducci�n al sistema con botones que dirigen al login o a secciones espec�ficas seg�n el rol.
Gesti�n de Usuarios (CRUD): Administradores: Acceso completo (Crear, Leer, Actualizar, Eliminar).
Usuarios Normales: Solo pueden ver sus datos.
Gesti�n de Roles (CRUD): Exclusivo para Administradores (Crear, Leer, Actualizar, Eliminar).
Manejo de Im�genes de Perfil: Administradores pueden subir y cambiar im�genes. Es opcional al crear un usuario, con 
una imagen por defecto si no se sube ninguna.

---

## Tecnolog�as Utilizadas

ASP.NET Core MVC
Entity Framework Core
SQL Server
NET 6 o superior
Visual Studio 2022
Bootstrap 5
ASP.NET Core Identity (Personalizado)

---

## Requisitos

.NET 6 SDK o superior.
 Visual Studio 2022.
 Instancia de SQL Server accesible.
 Paquetes NuGet: `Microsoft.EntityFrameworkCore.SqlServer`, `Microsoft.EntityFrameworkCore.Tools`.

---

## Instalaci�n y Ejecuci�n

1.  Clonar el Repositorio:
    ```bash
    git clone [https://github.com/Estrella03-Orellana/PracticaSeedCode.git]
    cd PracticaSeedCode
    ```
2.  Abrir en Visual Studio.
3.  Configurar Cadena de Conexi�n: En `appsettings.json`, actualiza `"DefaultConnection"` con tus datos de SQL Server
(ej. `"Server=TU_SERVIDOR;Database=PracticaSeedCode;Trusted_Connection=True;TrustServerCertificate=True;"`).
4.  Ejecutar Migraciones: Abre la Consola del Administrador de Paquetes o la terminal y ejecuta:
    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```
5.  Ejecutar Proyecto: Presiona `F5` en Visual Studio o `dotnet run` en la terminal.
6.  Acceder a la Aplicaci�n: La aplicaci�n se abrir� en tu navegador (usualmente `https://localhost:XXXX`).

---

Credenciales de Acceso

Puedes iniciar sesi�n como administrador con las siguientes credenciales:

Usuario: `admin@correo.com`
Contrase�a: `admin123`

Ingresas como administrador y puedes crear un usuario normal
---

Repositorio GitHub: [https://github.com/Estrella03-Orellana/PracticaSeedCode.git]
