# Proyecto ASP.NET MVC - Gestión Integral de Usuarios y Roles

Este proyecto es un sistema web completo en ASP.NET Core MVC para la gestión integral de usuarios y roles.

---

## Características Principales

El proyecto es 100% funcional e incluye:

Autenticación por Roles: Login, control de acceso por rol y página de acceso denegado.
Página de Inicio: Introducción al sistema con botones que dirigen al login o a secciones específicas según el rol.
Gestión de Usuarios (CRUD): Administradores: Acceso completo (Crear, Leer, Actualizar, Eliminar).
Usuarios Normales: Solo pueden ver sus datos.
Gestión de Roles (CRUD): Exclusivo para Administradores (Crear, Leer, Actualizar, Eliminar).
Manejo de Imágenes de Perfil: Administradores pueden subir y cambiar imágenes. Es opcional al crear un usuario, con 
una imagen por defecto si no se sube ninguna.

---

## Tecnologías Utilizadas

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

## Instalación y Ejecución

1.  Clonar el Repositorio:
    ```bash
    git clone [https://github.com/Estrella03-Orellana/PracticaSeedCode.git]
    cd PracticaSeedCode
    ```
2.  Abrir en Visual Studio.
3.  Configurar Cadena de Conexión: En `appsettings.json`, actualiza `"DefaultConnection"` con tus datos de SQL Server
(ej. `"Server=TU_SERVIDOR;Database=PracticaSeedCode;Trusted_Connection=True;TrustServerCertificate=True;"`).
4.  Ejecutar Migraciones: Abre la Consola del Administrador de Paquetes o la terminal y ejecuta:
    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```
5.  Ejecutar Proyecto: Presiona `F5` en Visual Studio o `dotnet run` en la terminal.
6.  Acceder a la Aplicación: La aplicación se abrirá en tu navegador (usualmente `https://localhost:XXXX`).

---

Credenciales de Acceso

Puedes iniciar sesión como administrador con las siguientes credenciales:

Usuario: `admin@correo.com`
Contraseña: `admin123`

Ingresas como administrador y puedes crear un usuario normal
---

Repositorio GitHub: [https://github.com/Estrella03-Orellana/PracticaSeedCode.git]
