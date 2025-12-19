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

## Arquitetura do Projeto

src/
├── QuizOds.Api            → Camada de apresentação (Controllers)
├── QuizOds.Application    → Casos de uso, Queries, Commands e DTOs
├── QuizOds.Domain         → Entidades e regras de domínio
├── QuizOds.Infrastructure → Banco de dados, DbContext e Seed


## Tecnologias Utilizadas

.NET 8 (ASP.NET Core Web API)

Entity Framework Core

MySQL (Aiven – banco gerenciado)

Docker

MediatR (CQRS)

Swagger / OpenAPI

Render (Deploy)

## Funcionalidades implementadas

Funcionalidades Implementadas

✔ Listagem de ODS

✔ Consulta de ODS por número

✔ Quiz associado a cada ODS

✔ Perguntas de múltipla escolha

✔ Submissão de respostas do usuário

✔ Validação de resposta correta/incorreta

✔ Seed automático de dados no banco

✔ Documentação via Swagger

## URL da API

https://quizzods-backend-tcc-2025.onrender.com Obs:A aplicação é uma API REST, portanto não possui página inicial (/).

## Swagger (documentação interativa)

https://quizzods-backend-tcc-2025.onrender.com/swagger

## Principais Endpoints

Principais Endpoints
 Listar todas as ODS
GET /api/ods

 Buscar ODS por número
GET /api/ods/{numero}

 Buscar quiz de uma ODS
GET /api/ods/{numero}/quiz

 Submeter resposta de uma pergunta
POST /api/questions/answer

## Banco de Dados

Banco MySQL hospedado no Aiven

Conexão configurada via variáveis de ambiente

Seed automático executado na inicialização da aplicação

