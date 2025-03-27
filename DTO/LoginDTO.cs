using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Informe o e-mail do usuário!!")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Informe a senha do usuário!!")]
        public string? Senha { get; set; }
    }
}
