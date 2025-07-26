using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticaSeedCode.Models;

public partial class User
{
    public int Id { get; set; }
    [Display(Name = "Nombre")]
    public string Name { get; set; } = null!;
    [EmailAddress(ErrorMessage ="Ingrese formato valido de correo")]
    public string Email { get; set; } = null!;
    [Display(Name = "Contraseña")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Display(Name = "Rol")]
    public int? RoleId { get; set; }  

    public virtual Role? Role { get; set; }

    public string? FotoPerfil { get; set; }

    [NotMapped]
    public IFormFile? FotoFile { get; set; } 

}
