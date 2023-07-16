
# DB Configurar InMemory ou MySQL local
Em Program.cs existe uma variável booleana "inMemoryDatabase". Se true, a aplicação usará InMemoryDatabase.

# Docker
Rodar docker para gerar Container MySQL, Container webapi .NET e Container React
docker compose up -d 

# Autenticação
Estou utiliziando Identity.EntityFrameworkCore para validar o usuario e senha
No mitration está sendo inserido o usuario de teste (letscode)

# Migration
Update-Database -Context UsuarioContext
Update-Database -Context CardContext

# Listagem de Cards
Estou usando paginação (Skip/take). Por Default retorna tudo.
ex http://localhost:5000/cards?skip=10&take=50

# Variaveis de ambientes
Arquivo appsettings.json

"AppSettings": {
    "TokenKey": "0nwau0rmiUjdskjd9jdIOjdlNLKD7D*&Daewur293749283sdhf"
  },
  "MYSQL_HOST": "127.0.0.1",
  "MYSQL_DB": "kanban",
  "MYSQL_USER": "root",
  "MYSQL_PASSWORD": "12345678"

Mas todas as variaveis estão sendo configuradas automaticamente pelo Docker.

