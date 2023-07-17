# ADA - KANBAN
#### DB Configurar _InMemory_ ou MySQL local
Em **Program.cs** existe uma variável booleana _"inMemoryDatabase"_. Se true, a aplicação usará InMemoryDatabase.

### Docker
Rodar Docker Composer no Root do projeto para gerar: 
- Container MySQL, 
- Container webapi .NET e 
- Container React
```sh
docker compose up -d 
```
### Autenticação
Estou utilizando **Identity.EntityFrameworkCore** para validar o usuario e senha
No migration está sendo inserido o usuário de teste (letscode)

### Migration
Rodar Migration para gerar o Banco, tabelas e inserir usuário demo:
`Tools -> NuGet Package Manager -> Package Manager Console`
```sh
Update-Database -Context UsuarioContext
Update-Database -Context CardContext
```
###  Listagem de Cards
Estou usando paginação (Skip/take). Por pardão ele irá retornar todo conteúdo.
Ex: http://localhost:5000/cards?skip=10&take=50 (Não vai fucnionar,pois precisa do Token)

###  Variáveis de ambientes
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
Todas as variáveis estão sendo configuradas automaticamente pelo Docker Composer.

`Fábio Colombini`

[//]: # (These are reference links) 
[Paginacao]: <http://localhost:5000/cards?skip=10&take=50>
