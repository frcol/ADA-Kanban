# ADA - KANBAN
#### DB Configurar _InMemory_ ou MySQL local
Em **Program.cs** existe uma vari�vel booleana _"inMemoryDatabase"_. Se true, a aplica��o usar� InMemoryDatabase.

### Docker
Rodar Docker Composer no Root do projeto para gerar: 
- Container MySQL, 
- Container webapi .NET e 
- Container React
```sh
docker compose up -d 
```
### Autentica��o
Estou utilizando **Identity.EntityFrameworkCore** para validar o usuario e senha
No mitragion est� sendo inserido o usu�rio de teste (letscode)

### Migration
Rodar Migration para gerar o Banco, tabelas e inserir usu�rio demo:
`Tools -> NuGet Package Manager -> Package Manager Console`
```sh
Update-Database -Context UsuarioContext
Update-Database -Context CardContext
```
###  Listagem de Cards
Estou usando pagina��o (Skip/take). Por pard�o ele ir� retornar todo conte�do.
Ex: http://localhost:5000/cards?skip=10&take=50 (N�o vai fucnionar,pois precisa do Token)

###  Vari�veis de ambientes
Arquivo **appsettings.json**
```sh
"AppSettings": {
    "TokenKey": "0nwau0rmiUjdskjd9jdIOjdlNLKD7D*&Daewur293749283sdhf"
  },
  "MYSQL_HOST": "127.0.0.1",
  "MYSQL_DB": "kanban",
  "MYSQL_USER": "root",
  "MYSQL_PASSWORD": "12345678"
```
Todas as vari�veis est�o sendo configuradas automaticamente pelo Docker Composer.

`F�bio Colombini`

[//]: # (These are reference links) 
[Paginacao]: <http://localhost:5000/cards?skip=10&take=50>