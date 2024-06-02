# LavoCar - Sistema de gerenciamento interno para Lava Jato

## Sumário

- [Descrição](#descrição)
- [Funcionalidades](#funcionalidades)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Instalação](#instalação)
- [Como Usar](#como-usar)
- [Contato](#contato)
- [Referências](#referências)

## Descrição

O LavoCar é uma aplicação web desenvolvida para gerenciamento de um lava jato, proporcionando um controle interno eficiente para o administrador. O sistema permite o cadastro de clientes, funcionários, veículos, tipos de lavagem e reparos, bem como a marcação de serviços de lavagem e reparos.

## Funcionalidades

- **Cadastro de Clientes:** Permite o registro de novos clientes.
- **Cadastro de Funcionários:** Gerencia os funcionários do lava jato.
- **Cadastro de Veículos:** Registra os veículos dos clientes.
- **Tipos de Lavagem e Reparos:** Define e gerencia os diferentes tipos de serviços oferecidos.
- **Agendamento de Serviços:** Facilita a marcação de lavagens e reparos.

## Tecnologias Utilizadas

- **Backend:** ASP.Net Core MVC
- **Frontend:** HTML, CSS, JavaScript, Bootstrap
- **Banco de Dados:** SQL Server
- **ORM:** Entity Framework
- **Controle de Versão:** Git

## Instalação

### Pré-requisitos

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [Git](https://git-scm.com/)

### Passos para instalação

1. Clone o repositório:
    ```bash
    git clone https://github.com/seu-usuario/LavoCar.git
    cd LavoCar
    ```

2. Configure o banco de dados no `appsettings.json`:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=seu_servidor;Database=LavocarDB;User Id=seu_usuario;Password=sua_senha;"
      }
    }
    ```

3. Execute as migrações do Entity Framework para criar o banco de dados:
    ```bash
    dotnet ef database update
    ```

4. Execute a aplicação:
    ```bash
    dotnet run
    ```

## Como Usar

1. Acesse a aplicação no navegador através do endereço: `http://localhost:5000`
2. Utilize o menu de navegação para acessar as funcionalidades de cadastro e gerenciamento.
3. Cadastre clientes, funcionários e veículos.
4. Agende serviços de lavagem e reparos.

## Contato

- **Email:** matheusfsbarreto@gmail.com
- **LinkedIn:** https://www.linkedin.com/in/matheusfsbarreto/

## Referências

- Livros:
  - "ASP.NET Core MVC: Aplicações modernas em conjunto com o Entity Framework" - Everton Coimbra de Araújo


