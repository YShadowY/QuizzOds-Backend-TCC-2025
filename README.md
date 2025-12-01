# QuizzODS — Back-end Challenge (.NET)

Este repositório contém o desafio back-end do **QuizzODS**, parte do Desafio Suplementar 2025 do Estartando Devs.
O objetivo é desenvolver uma **API REST** para alimentar o aplicativo QuizzODS, seguindo boas práticas, uma estrutura organizada e trabalhando em conjunto com o front-end da sua dupla.

## Sobre o desafio

Você deve implementar uma API responsável por:

* Gerenciar os dados das ODS
* Gerenciar os dados dos quizzes
* Atender às telas do Figma consumidas pelo front-end
* Organizar o projeto em camadas
* Criar o schema do banco e migrations
* Publicar a API em um serviço gratuito

Este repositório já inclui um **boilerplate inicial**, mas você tem liberdade para estruturar, reorganizar ou expandir conforme achar necessário.

## Estrutura do Projeto

A estrutura base do projeto é dividida em camadas:

```shell
Domain/            → Entidades e regras básicas
Infrastructure/    → DbContext, configurações do EF Core e repositórios
Application/       → Casos de uso (MediatR)
Api/               → Controllers e Program.cs
```

Você pode manter esse padrão ou expandir — desde que o projeto permaneça claro e organizado.

## O que deve ser implementado

Sua API deverá atender às seguintes necessidades do front-end:

### **1. ODS**

* Listar todas as ODS
* Retornar detalhes e conteúdo de uma ODS específica

### **2. Quiz**

* Listar quizzes disponíveis
* Retornar perguntas e opções
* Enviar resposta e retornar feedback

## Integração com o Front-end

Você e sua dupla são responsáveis por definir:

* Estrutura final das entidades
* Formato das respostas da API
* Rotas e payloads
* Fluxo entre as telas
* Quais endpoints existirão

## Banco de Dados

Você deve criar o modelo do banco conforme o que seu app exigir.

O repositório permite trabalhar com MySQL, mas você pode usar:

* MySQL local (XAMPP, WAMP, Docker)
* PlanetScale
* Aiven (plano gratuito)

A estrutura do banco deve ser criada via **migrations do EF Core**.

## Como rodar o projeto

1. Faça um fork deste repositório

2. Clone o repositório da **sua conta**:

   ```shell
   git clone https://github.com/estartandodevs-course/QuizzOds-Backend-TCC-2025.git
   ```

3. Configure a connection string no `appsettings.json`

4. Instale as dependências:

   ```shell
   dotnet restore
   ```

5. Atualize o banco:

   ```shell
   dotnet ef database update -p ./QuizzOds.Api
   ```

6. Execute a API:

   ```shell
   dotnet run --project ./QuizzOds.Api
   ```

7. Acesse o Swagger:

   ```shell
   http://localhost:5278/swagger
   ```

## Entrega

Sua entrega deve conter:

* Repositório público no GitHub (seu fork)
* API funcional
* Publicação da API em um serviço gratuito (Render, Fly.io, Azure Student etc.) — inclua o link no README
* Código organizado e em camadas
* Migrations versionadas
* Integração real com o front-end da sua dupla
* README atualizado
* Histórico de commits legível

## Critérios de Avaliação

* Organização do projeto
* Clareza e separação das camadas
* Estrutura dos casos de uso
* Integração com o front-end
* Qualidade das rotas e respostas
* Boas práticas com Entity Framework e MediatR
* Histórico de commits
* Comunicação com a dupla

## Observações

* Total liberdade para evoluir a arquitetura
* Você define o banco, as entidades e as relações
* Pode incluir bibliotecas úteis (ex: FluentValidation)
* O foco é entregar uma API limpa, funcional e bem estruturada
