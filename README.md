# Ambev Developer Evaluation - Estrutura de Estudo

Este projeto é uma estrutura base desenvolvida com o propósito de estudo e avaliação técnica. Ele contém uma API com .NET, banco de dados PostgreSQL, MongoDB, Redis e Docker. Pode ser utilizado localmente tanto com containers quanto com serviços instalados na máquina.

---

### Descrição do teste [aqui](.doc/TesteDescription.md).

## 🚀 Tecnologias Utilizadas

- .NET 8+
- PostgreSQL 13
- MongoDB 8
- Redis 7.4
- Docker e Docker Compose
- Git Flow

---
## 📦 Pré-requisitos

- [.NET SDK 8+](https://dotnet.microsoft.com/en-us/download)
- [Docker e Docker Compose](https://www.docker.com/products/docker-desktop/)
- [DBeaver (opcional)](https://dbeaver.io/) - Cliente visual para bancos de dados
- [GitHub Desktop (opcional)](https://desktop.github.com/) - Interface visual para Git

---
## 📌 Estrutura do Projeto
```
📂 template
 ┣ 📂 backend             # Repositório principal
 ┃ ┣ 📂 src               # Lógica da API
 ┃ ┃ ┣ 📂 Application     # Regras de negócio
 ┃ ┃ ┣ 📂 Common          # Utilidades Globais
 ┃ ┃ ┣ 📂 Domain          # Regras de Domínio
 ┃ ┃ ┣ 📂 ORM             # Persistência de Dados
 ┃ ┃ ┣ 📂 Ioc             # Injeção de Dependência
 ┃ ┃ ┗ 📂 WebApi          # Interface da API
 ┃ ┣ 📂 tests             # Repositório de testes
 ┃ ┗ ┣ 📂 Functional      # Testes Funcionais
 ┃   ┣ 📂 Integration     # Testes de Integração
 ┃   ┗ 📂 Unit            # Testes Unitários
 ┗
```

## ⚙️ Rodando o Projeto Localmente

### ✅ Usando Docker

1. Clone o repositório:

   ```bash
   git clone https://github.com/seu-usuario/seu-repositorio.git
   cd seu-repositorio
   ```
2. Execute o .sln na pasta template > backend
3. Dentro do visual studio abra o terminal da solução e faça o passo 4.
4. Execute o Docker Compose : Fique a tento ao item do **PostgreSQL** logo abaixo **Primeiro execute ele e depois os pacotes necessários e volte a esse passo**:

   ```bash
   docker-compose up --build
   ```
5. Após rodar e subir os containers, execute as migrations
6. teste a solução execute o sistema.
7. Agora segue os demais passos abaixo:

### Descrição da API com os EndPoints [aqui](.doc/salesapi.md).

### ✅ Usando PostgreSQL Instalado Localmente

⚠️ Caso opte por usar o PostgreSQL local (sem Docker), será necessário alterar a `connection string` no `appsettings.json`.

Exemplo:
```json
"DefaultConnection": "Server=localhost;Database=developer_evaluation;User Id=sa;Password=sua_senha;TrustServerCertificate=True"
```
Também é necessário garantir que a **porta 5432** da sua máquina esteja igual à configurada no container - pode alterar o do docker-compose.yml para garantir **5432:5432**.

---

## 🛠️ Configurações Adicionais

### 🧩 Pacotes Necessários
Certifique-se de instalar os seguintes pacotes NuGet se for trabalhar somente com o PostgreSQL: 

Utilizei versão compatível com o teste.
```bash
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Design 
dotnet add package Microsoft.EntityFrameworkCore.Tools
```
### 📌 Migrations

Após configurar a string de conexão e garantir que o banco está ativo, execute:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```
Você pode verificar a criação das tabelas usando ferramentas como **DBeaver**.

---
## AGORA SÓ TESTAR A API

## 🧠 Dicas de Ferramentas

- 🏦 **DBeaver**: Cliente gráfico para PostgreSQL e MongoDB. Muito prático para visualizar estrutura de tabelas.
- 🐙 **GitHub Desktop**: Interface amigável para gerenciar branches e commits.
- 🐳 **Docker Desktop**: Facilita a visualização de containers ativos.

## 🌱 Git Flow Sugerido

### Fluxo Atual

- `main` (produção)
- `dev` (desenvolvimento)

### Fluxo Recomendado para Projetos Profissionais

| Branch         | Finalidade                                  |
|----------------|---------------------------------------------|
| `main`         | Código estável em produção                  |
| `dev`          | Código de desenvolvimento integrado         |
| `staging`      | Código réplica do main de produção          |
| `feature/*`    | Implementação de novas funcionalidades      |
| `hotfix/*`     | Correções críticas em produção              |
| `release/*`    | Preparação de versões para produção         |

Nessa estrutura fica bem possível utilização de PRs para Code Review.

## ⭐ Curiosidade
Esse README foi feito no [readme.so](https://readme.so/pt/editor)

## 📜 Licença

Este projeto é de uso livre para fins de estudo.



