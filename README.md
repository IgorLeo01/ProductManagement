# Documentação da Aplicação ProductManagement

## Introdução

Este projeto é uma aplicação simples de gestão de produtos para um pequeno e-commerce. A aplicação foi desenvolvida com **ASP.NET Core MVC** e **Entity Framework Core** (versão 6 ou superior). Ela permite realizar operações CRUD (Criar, Ler, Atualizar e Deletar) em um catálogo de produtos, e está integrada com um banco de dados **PostgreSQL** para persistência.

A aplicação permite que os administradores visualizem, editem e excluam produtos, bem como adicionem novos produtos ao sistema. Além disso, foram adicionados recursos de validação de dados, pesquisa, filtro e paginação na listagem de produtos.

## Funcionalidades

- **Cadastro de Produtos**: O sistema permite que o usuário adicione um produto com os campos: nome, descrição, preço e quantidade em estoque.
- **Edição de Produtos**: O usuário pode editar qualquer campo de um produto.
- **Exclusão de Produtos**: O produto pode ser removido se a quantidade em estoque for 0.
- **Listagem de Produtos**: Exibe todos os produtos cadastrados com a opção de pesquisa, filtro e paginação.
- **Validação de Dados**: Os campos são validados tanto no lado do cliente quanto no lado do servidor para garantir que os dados inseridos sejam válidos.

## Tecnologias Utilizadas

- **ASP.NET Core MVC**: Framework web para construir a aplicação.
- **Entity Framework Core**: ORM para comunicação com o banco de dados.
- **NUnit**: Framework de testes unitários para realizar os testes automatizados da aplicação.
- **PostgreSQL / SQL Server**: Banco de dados para persistência dos dados.
- **Bootstrap**: Framework CSS para estilização da aplicação.
- **Font Awesome**: Biblioteca de ícones utilizada para representar ações como editar e excluir produtos.

---

## Rodando o Projeto

### Pré-requisitos

1. **.NET SDK** (versão 6 ou superior): Para rodar e construir a aplicação.
2. **Banco de Dados PostgreSQL**: Certifique-se de ter um banco de dados configurado, ou você pode utilizar um banco de dados em memória durante o desenvolvimento e testes.

### Clonando o Repositório

Clone o repositório para a sua máquina local:

```bash
git clone https://github.com/IgorLeo01/ProdutoManagementApp.git
cd ProdutoManagementApp
```

### Executando o Projeto

Restaurar os pacotes NuGet:

```bash
dotnet restore
```

### Executar a aplicação

```bash
dotnet run
```

A aplicação será executada localmente. Você pode acessá-la através do navegador utilizando o endereço:

```bash
(http://localhost:5033)
```

### Rodando os Testes Unitários

**Pré-requisitos para os Testes**

**.NET SDK** (versão 6 ou superior).
**Banco de Dados In-Memory**: Para rodar os testes unitários, a aplicação usa um banco de dados em memória, configurado no arquivo de testes.

### Executando os Testes

**Restaurar os pacotes NuGet para o projeto de testes:**

```bash
dotnet restore
```

**Executar os testes unitários:**

```bash
dotnet test
```

### Testes Implementados

**Os testes estão localizados no projeto ProductManagementApp.Tests e cobrem as seguintes funcionalidades principais:**

- **AddProdutoAsync_ShouldAddProduct**: Testa a adição de um novo produto.
- **EditProdutoAsync_ShouldUpdateProduct**: Testa a atualização de um produto existente.
- **RemoveProdutoAsync_ShouldRemoveProduct**: Testa a remoção de um produto.
