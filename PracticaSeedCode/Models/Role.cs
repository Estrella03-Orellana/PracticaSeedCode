using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PracticaSeedCode.Models;

public partial class Role
{
    public int Id { get; set; }
    [Display(Name = "Rol")]
    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
