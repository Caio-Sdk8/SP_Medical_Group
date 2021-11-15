using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using SpMedicalGroup.WebApi.Repositories;
using SpMedicalGroup.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
            public IActionResult Login(loginViewModel login)
            {
                try
                {
                    Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                    if (usuarioBuscado == null)
                    {
                        return BadRequest("E-mail ou senha inválidos!");
                    }
                    var minhasClaims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.EmailUsuario),
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.NomeUsuario),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),
                    new Claim("role", usuarioBuscado.IdTipoUsuario.ToString())
                };

                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spMed-senha-backend"));

                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var meuToken = new JwtSecurityToken(
                            issuer: "SpMedicalGroup.webAPI",
                            audience: "SpMedicalGroup.webAPI",
                            claims: minhasClaims,
                            expires: DateTime.Now.AddHours(2),
                            signingCredentials: creds
                        );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
        }
    } 

