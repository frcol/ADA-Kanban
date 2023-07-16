using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MySqlConnector;
using QuadroKanban;
using QuadroKanban.Data;
using QuadroKanban.Model;
using QuadroKanban.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ---------------------------------------------------------------------------------------
// DB Entity
bool inMemoryDatabase = false;

if (inMemoryDatabase)
{
    builder.Services.AddDbContext<UsuarioContext>(opts => opts.UseInMemoryDatabase("MyDB"));
    builder.Services.AddDbContext<CardContext>(opts => opts.UseInMemoryDatabase("MyDB"));
}
else
{
    var conStrBuilder = new MySqlConnectionStringBuilder();
    conStrBuilder.Server = builder.Configuration["MYSQL_HOST"];
    conStrBuilder.Database = builder.Configuration["MYSQL_DB"];
    conStrBuilder.UserID = builder.Configuration["MYSQL_USER"];
    conStrBuilder.Password = builder.Configuration["MYSQL_PASSWORD"];

    var connectionString = conStrBuilder.ConnectionString;
    builder.Services.AddDbContext<UsuarioContext>(opts => opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    builder.Services.AddDbContext<CardContext>(opts => opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
}


// Identity
builder.Services
    .AddIdentity<Usuario, IdentityRole>(options =>
    {
        // Configurações de segurança da senha
        options.Password.RequireDigit = true;  // Requer ao menos um dígito
        options.Password.RequireLowercase = true;  // Requer ao menos uma letra minúscula
        options.Password.RequireUppercase = false;  // Requer ao menos uma letra maiúscula
        options.Password.RequireNonAlphanumeric = true;  // Requer ao menos um caractere especial
        options.Password.RequiredLength = 8;  // Tamanho mínimo da senha
        options.Password.RequiredUniqueChars = 6;  // Quantidade mínima de caracteres únicos

        // Outras configurações do Identity, se necessário
    })
    .AddEntityFrameworkStores<UsuarioContext>()
    .AddDefaultTokenProviders();

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Custom Services
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<ChangeLogFilter>();

// Autenticacao
var secretKey = Encoding.UTF8.GetBytes(builder.Configuration["TOKEN_KEY"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:3000", "http://192.168.1.102:3000")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
// ---------------------------------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
