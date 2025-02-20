
# Exemplo de API Locadora

Este projeto é um **exemplo básico** de uma API para gerenciar filmes em uma locadora, utilizando **ASP.NET Core**, **Entity Framework Core** e **PostgreSQL**. Ele serve como um exemplo simples para se basear ao criar uma API do zero. As funcionalidades básicas de CRUD (Criar, Ler, Atualizar e Deletar) estão implementadas para manipulação de filmes.

**Este projeto é apenas um exemplo simples e básico** e pode ser expandido ou adaptado conforme necessário para projetos mais complexos.


## Funcionalidades

A API oferece os seguintes endpoints:

### `GET /api/filmes`
Retorna todos os filmes ativos.

### `GET /api/filmes/{id}`
Retorna um filme específico pelo `id`.

### `POST /api/filmes`
Cria um novo filme. Exemplo de corpo da requisição:

```json
{
  "titulo": "Filme Exemplo",
  "genero": "Ação",
  "ano": 2025
}
```

### `PUT /api/filmes/{id}`
Atualiza um filme existente.

### `DELETE /api/filmes/{id}`
Desativa um filme.

## Documentação Swagger

A documentação interativa da API está disponível via Swagger. Quando rodando a API localmente, acesse:

```

```

## Estrutura do Projeto

- **Exemplo_Api_Locadora**: Projeto principal que contém a implementação dos serviços e controladores.
- **Data**: Contém o contexto do banco de dados e as migrations.
- **Services**: Implementação da lógica de negócios, como manipulação de filmes.
- **Interface**: Contém as interfaces usadas nos serviços, como `IFilmeService`.
