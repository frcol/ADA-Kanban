using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuadroKanban.Data.DTO;
using QuadroKanban.Services;

namespace QuadroKanban.Controller;

[ApiController]
[Route("[Controller]")]
public class LoginController: ControllerBase
{
    private UsuarioService _usuarioService;

    public LoginController(UsuarioService service)
    {
        _usuarioService = service;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginUsuarioDto dto)
    {
        string token;
        try
        {
            token = await _usuarioService.LoginAsync(dto);
        }
        catch (Exception ex)
        {
            return Unauthorized(ex.Message);
        }
        
        return Ok(token);
    }
}
