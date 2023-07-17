using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuadroKanban.Controller;
using QuadroKanban.Data.DTO;
using QuadroKanban.Model;

namespace QuadroKanban.Services;

public class UsuarioService
{
    private IMapper _mapper;
    private UserManager<Usuario> _userManager;
    private SignInManager<Usuario> _signInManager;
    private TokenService _tokenService;

    public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, TokenService tokenService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<IActionResult> CadastrarAsync(CreateUsuarioDto dto)
    {
        Usuario usuario = _mapper.Map<Usuario>(dto);
        IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Senha);

        if (resultado.Succeeded)
        {
            return new OkObjectResult("Cadastro realizado com sucesso!");
        }
        else
        {
            return new NoContentResult();
        }
    }

    public async Task<string> LoginAsync(LoginUsuarioDto dto)
    {
        var resultado = await _signInManager.PasswordSignInAsync(dto.Login, dto.Senha, false, false);

        if (!resultado.Succeeded)
        {
            throw new Exception("Login inválido");
        }

        Usuario? usuario = _signInManager
                    .UserManager
                    .Users.FirstOrDefault(user => user.NormalizedUserName == dto.Login.ToUpper());

        string token = _tokenService.GenerateToken(usuario);

        return token;
    }
}
