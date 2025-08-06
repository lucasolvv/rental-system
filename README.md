# 🚀 Rental System API

API RESTful para o gerenciamento de **aluguel de motos** e **cadastro de entregadores**, desenvolvida como parte de um desafio técnico.

A aplicação foi construída com foco em **arquitetura limpa**, uso de **mensageria via RabbitMQ** e banco de dados **PostgreSQL**.

---

## 🛠 Tecnologias Utilizadas

- .NET 8
- C#
- PostgreSQL
- RabbitMQ
- Docker / Docker Compose
- Entity Framework Core
- AutoMapper
- Clean Architecture (DDD + SOLID)
- Design Patterns
- Swagger (OpenAPI)
- Mensageria com RabbitMQ
- Filtro global para tratamento de erros

---

## ⚙️ Funcionalidades

- CRUD de motos (cadastro, listagem, edição e exclusão)
- Cadastro de entregadores com CNH (imagem)
- Upload e armazenamento local da imagem da CNH (fora do banco)
- Locação de motos com validações de plano e categoria da CNH
- Devolução de motos com cálculo de multa ou adicionais
- Publicação de evento via RabbitMQ ao cadastrar uma moto do ano 2024
- Consumidor escuta o evento e armazena a notificação no banco de dados

---

## 💻 Como Rodar o Projeto Localmente

### 📦 Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)

---

### 1. Subir o PostgreSQL e RabbitMQ com Docker

Após clonar o projeto em uma pasta da sua maquina, raiz do projeto, execute:

```bash
docker-compose up -d
```

> Isso irá subir:
> - Um container com o banco `PostgreSQL`
> - Um container com o `RabbitMQ` + interface web (`http://localhost:15672`)

---

### 2. Rodar a API localmente

No terminal(na raiz do projeto), execute os comandos abaixo para iniciar a API:

```bash
cd src/RentalSystem.Presentation
dotnet run
```

---

### 3. Acessar a documentação da API (Swagger)

- Swagger UI: [http://localhost:5006/swagger](http://localhost:5006/swagger)
- API via HTTPS: [https://localhost:7266](https://localhost:7266)
- RabbitMQ UI: [http://localhost:15672](http://localhost:15672)
  - Usuário: `admin`
  - Senha: `adminrentalsystem`

---

## 📂 Estrutura do Projeto

```
RentalSystem
├── src/
│   ├── RentalSystem.Presentation    // Camada de API (Controllers, Filtros, Swagger, etc)
│   ├── RentalSystem.Application     // Casos de uso, regras de negócio e validações
│   ├── RentalSystem.Domain          // Entidades e contratos do domínio
│   ├── RentalSystem.Infra           // Acesso a dados, contexto EF, mensageria
├── shared/
│   ├── RentalSystem.Communication   // DTOs de entrada/saída (Requests/Responses)
│   ├── RentalSystem.Exceptions      // Exceções customizadas da aplicação
├── docker-compose.yml
├── Dockerfile
└── README.md
```

---

## 📌 Observações

- A API está sendo executada localmente, enquanto **o banco e o RabbitMQ estão rodando via Docker**.
- A decisão de não containerizar completamente a aplicação foi feita por conta de dependências específicas de ambiente (ex: manipulação de imagens com bibliotecas que requerem suporte do sistema operacional).
- A imagem da CNH é salva localmente no diretório `Storage/CNH` dentro da camada `RentalSystem.Presentation`.
- A aplicação utiliza `AutoMapper`, injeção de dependência via `IServiceCollection` e um `HostedService` para o consumidor RabbitMQ.
- As validações de regras de negócio estão concentradas nos Use Cases, com suporte de classes auxiliares (`validators`) para validações específicas.
- O projeto adota princípios de Clean Architecture, com forte separação de responsabilidades, seguindo DDD e SOLID.

---

## ✅ Status do Desafio

| Funcionalidade                          | Status        |
|----------------------------------------|---------------|
| Cadastro de motos                      | ✅ Concluído   |
| Edição e exclusão de motos             | ✅ Concluído   |
| Filtro de motos por placa              | ✅ Concluído   |
| Cadastro de entregadores               | ✅ Concluído   |
| Upload de imagem da CNH                | ✅ Concluído   |
| Locação de motos                       | ✅ Concluído   |
| Devolução com multa/adicionais         | ✅ Concluído   |
| Publicação e consumo de evento Rabbit  | ✅ Concluído   |
| Testes unitários                       | ❌ Não implementado |
| Testes de integração                   | ❌ Não implementado |
| Logs estruturados                      | ❌ Não implementado |
| Documentação via Swagger               | ✅ Concluído   |
