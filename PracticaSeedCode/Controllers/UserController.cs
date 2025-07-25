﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaSeedCode.Models;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PracticaSeedCode.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly PracticaSeedCodeContext _context;

        public UserController(PracticaSeedCodeContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        public async Task<IActionResult> Index(string Name, int topRegistro = 10)
        {
            var query = _context.Users
                .Include(u => u.Role) 
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(Name))
            {
                query = query.Where(s => s.Name.ToLower().Contains(Name.ToLower()));
            }

            if (topRegistro > 0)
            {
                query = query.Take(topRegistro);
            }

            return View(await query.ToListAsync());
        }



        [Authorize(Roles = "ADMINISTRADOR")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name");
            return View();
        }

    
        [HttpPost]
        [Authorize(Roles = "ADMINISTRADOR")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Password,RoleId")] User user)
        {
            if (ModelState.IsValid)

            {
                user.Password = CalcularHashMD5(user.Password);
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name", user.RoleId);
            return View(user);
        }


        [Authorize(Roles = "ADMINISTRADOR")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewBag.RoleId = new SelectList(_context.Roles, "Id", "Name", user.RoleId);
            return View(user);
        }


        [HttpPost]
        [Authorize(Roles = "ADMINISTRADOR")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Password,RoleId,FotoFile")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            var usuarioUpdate = await _context.Users.FirstOrDefaultAsync(m => m.Id == user.Id);
            if (usuarioUpdate == null)
            {
                return NotFound();
            }

            try
            {
                
                usuarioUpdate.Name = user.Name;
                usuarioUpdate.Email = user.Email;
                usuarioUpdate.RoleId = user.RoleId;

                if (user.FotoFile != null && user.FotoFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

                 
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                 
                    if (!string.IsNullOrEmpty(usuarioUpdate.FotoPerfil))
                    {
                        var oldFilePath = Path.Combine(uploadsFolder, usuarioUpdate.FotoPerfil);
                        if (System.IO.File.Exists(oldFilePath))
                        {
                            System.IO.File.Delete(oldFilePath);
                        }
                    }

                   
                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(user.FotoFile.FileName);
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

              
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await user.FotoFile.CopyToAsync(stream);
                    }

                  
                    usuarioUpdate.FotoPerfil = uniqueFileName;
                }

                _context.Update(usuarioUpdate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id))
                {
                    return NotFound();
                }

                ViewBag.RoleId = new SelectList(_context.Roles, "Id", "Name", user.RoleId);
                return View(user);
            }
        }


        [Authorize(Roles = "ADMINISTRADOR")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }


        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "ADMINISTRADOR")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // ----------- ACCIONES PÚBLICAS / AUTENTICADAS --------------
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            user.Password = CalcularHashMD5(user.Password);

            var usuarioAuth = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(s => s.Email == user.Email && s.Password == user.Password);

            if (usuarioAuth != null && usuarioAuth.Id > 0 && usuarioAuth.Email == user.Email)
            {
                var claims = new[] {
            new Claim(ClaimTypes.Name, usuarioAuth.Email),
            new Claim("Id", usuarioAuth.Id.ToString()),
            new Claim("Nombre", usuarioAuth.Name),
            new Claim(ClaimTypes.Role, usuarioAuth.Role.Name) 
        };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                // Redirigir según el rol
                if (usuarioAuth.Role.Name == "ADMINISTRADOR")
                {
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    return RedirectToAction("Perfil", "User");
                }

            }
            else
            {
                ModelState.AddModelError("", "El email o contraseña están incorrectos");
                return View();
            }
        }


        [AllowAnonymous]
        public async Task<IActionResult> CerrarSession()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Perfil()
        {

            var idStr = User.FindFirst("Id")?.Value;
            int id = int.Parse(idStr);
            var usuario = await _context.Users.FindAsync(id);
            return View(usuario);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Perfil(int id, [Bind("Id,Name,Email,Role")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            var usuarioUpdate = await _context.Users.FirstOrDefaultAsync(m => m.Id == user.Id);
            if (usuarioUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync(usuarioUpdate, "",
                u => u.Name, u => u.Email, u => u.Role))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error al actualizar. Inténtelo de nuevo.");
                    }
                }
            }

            return View(user);
        }


        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }


        private bool UsuarioExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }


        private string CalcularHashMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2")); // "x2" convierte el byte en una cadena hexadecimal de dos caracteres.
                }
                return sb.ToString();
            }
        }
    }
}
