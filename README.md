# ADA - KANBAN
#### DB Configurar _InMemory_ ou MySQL local
Em **Program.cs** existe uma variável booleana _"inMemoryDatabase"_.<br> 
Se true, a aplicação usará InMemoryDatabase.<br>
(Mas o Back foi criado para usar MySQL, então pode deixar **false** mesmo :)

### Docker
Rodar Docker Composer no Root do projeto para gerar: 
- Container MySQL, 
- Container webapi .NET e 
- Container React
```sh
docker compose up -d 
```
### Autenticação
Estou utilizando **Identity.EntityFrameworkCore** para validar o usuario e senha (com Mapeamento, Profile)<br>
No migration está sendo inserido o usuário de teste (letscode)

### Migration
Rodar Migration para gerar o Banco, tabelas e inserir usuário demo.<br>
Precisa configurar as variáveis de ambiente (appsettings.json).<br> <br> 
`Tools -> NuGet Package Manager -> Package Manager Console`
```sh
Update-Database -Context UsuarioContext
Update-Database -Context CardContext
```
###  Listagem de Cards
Estou usando paginação (Skip/take). Por pardão ele irá retornar todo conteúdo.<br>
Ex: http://localhost:5000/cards?skip=10&take=50 (Clicando nesse Link não vai funcionar, pois precisa do Token. Usar Postman)

###  Variáveis de ambientes
Arquivo **appsettings.json**
```sh
  "TOKEN_KEY": "0nwau0rmiUjdskjd9jdIOjdlNLKD7D*&Daewur293749283sdhf",
  "MYSQL_HOST": "127.0.0.1",
  "MYSQL_DB": "kanban",
  "MYSQL_USER": "root",
  "MYSQL_PASSWORD": "12345678"
```
Todas as variáveis estão sendo configuradas automaticamente pelo Docker Composer.

###  Linter
Utilizando Roslynator como ferramenta de análise estática de código para o C#.<br>
Ex: Não permitir deixar 2 linhas em branco<br>
`rcs1036: Avoid multiple Blank Lines`

`Fábio Colombini`

[//]: # (These are reference links) 
[Paginacao]: <http://localhost:5000/cards?skip=10&take=50>


