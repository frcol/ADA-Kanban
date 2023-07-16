using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuadroKanban.Data.DTO;
using QuadroKanban.Services;

namespace QuadroKanban.Controller;

[ApiController]
[Route("[Controller]")]
public class UsuarioController: ControllerBase
{
    private UsuarioService _usuarioService;

    public UsuarioController(UsuarioService service)
    {
        _usuarioService = service;
    }

    [HttpPost]
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto)
    {
        IdentityResult resultado = await _usuarioService.CadastrarAsync(dto);

        if (resultado.Succeeded)
        {
            return Ok("Cadastro realizado com sucesso!");
        }
        else
        {
            return NoContent();
        }
    }
}
