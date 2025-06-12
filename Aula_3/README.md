# Aula_3 - CRUD de Usuários com ASP.NET Core MVC

## Descrição do Projeto

Este projeto é uma aplicação web desenvolvida em ASP.NET Core MVC (usando .NET 8) que implementa um CRUD (Create, Read, Update, Delete) simples de usuários. O sistema permite cadastrar, listar, editar e excluir usuários, tudo em memória (os dados não são persistidos em banco de dados, apenas durante a execução da aplicação). O layout utiliza Bootstrap para uma interface moderna e responsiva.

### Funcionalidades
- Listagem de usuários
- Cadastro de novos usuários
- Edição de usuários existentes
- Exclusão de usuários

## Estrutura do Projeto
- `Controllers/` - Controladores MVC (lógica das rotas e ações)
- `Models/` - Modelos de dados (classe `Usuario`)
- `Views/` - Páginas Razor para exibição e interação
- `wwwroot/lib/bootstrap/` - Biblioteca Bootstrap para estilização

## Requisitos para rodar o projeto
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Windows, Linux ou macOS
- Editor de código (Visual Studio, VS Code, etc.)

## Como rodar o projeto localmente

1. **Clone ou baixe o repositório**
2. **Abra o terminal na pasta do projeto**
3. **Restaure os pacotes e dependências:**
   ```powershell
   dotnet restore
   ```
4. **Execute a aplicação:**
   ```powershell
   dotnet run
   ```
5. **Acesse no navegador:**
   - O endereço padrão é [http://localhost:5164](http://localhost:5164) (ou conforme indicado no terminal)

## Observações
- Os dados dos usuários são armazenados apenas em memória, ou seja, ao reiniciar a aplicação os dados voltam ao estado inicial.
- O Bootstrap já está incluído via LibMan e não requer instalação manual.

## Estrutura de Telas
- **Página Inicial:** Mostra o total de usuários cadastrados e link para a listagem.
- **Listagem de Usuários:** Exibe todos os usuários, com opções para editar ou excluir.
- **Cadastro/Edição:** Formulário para adicionar ou alterar usuários.
- **Exclusão:** Confirmação antes de remover um usuário.

---

Projeto para fins didáticos, demonstrando conceitos básicos de ASP.NET Core MVC e manipulação de dados em memória.
