
# 🚀 Rental System API

API RESTful para o gerenciamento de **aluguel de motos** e **cadastro de entregadores**, construída como parte de um desafio técnico.

Desenvolvido com arquitetura limpa, uso de mensageria via RabbitMQ e banco de dados PostgreSQL.

---

## 🛠 Tecnologias utilizadas

- .NET 8
- C#
- PostgreSQL
- RabbitMQ
- Docker / Docker Compose
- Entity Framework Core
- AutoMapper
- Clean Architecture
- Design Patterns
- Swagger (OpenAPI)
- Mensageria com RabbitMQ
- Tratamento de erros com filtro global

---

## ⚙️ Funcionalidades

- Cadastro, listagem, edição e exclusão de motos
- Cadastro de entregadores com CNH (imagem)
- Upload e armazenamento local de imagens da CNH (não no banco)
- Locação de motos com regras de planos e validação de categoria CNH
- Devolução de moto com cálculo de multa ou adicionais
- Evento publicado via RabbitMQ ao cadastrar moto do ano 2024
- Consumidor escuta evento e armazena mensagem no banco

---

## 🧪 Requisitos

- Docker e Docker Compose instalados
- (Opcional) .NET SDK 8.0 instalado (caso deseje rodar sem Docker)

---

## ▶️ Como executar com Docker Compose

1. Clone este repositório:

```bash
git clone https://github.com/seu-usuario/seu-repo.git
cd seu-repo
```

2. No terminal, execute o comando abaixo para subir os containers:

```bash
docker-compose up --build
```

3. Acesse a aplicação via navegador:

- Swagger UI: [http://localhost:5006/swagger](http://localhost:5006/swagger)
- RabbitMQ Management UI: [http://localhost:15672](http://localhost:15672)
  - Usuário: `admin`
  - Senha: `adminrentalsystem`

4. A API também está disponível em HTTPS em:  
[https://localhost:7266](https://localhost:7266)

---

## 🧾 Variáveis de ambiente configuradas

No `docker-compose.yml`:

- Banco de Dados:
  - `POSTGRES_USER=admin`
  - `POSTGRES_PASSWORD=adminrentalsystem`
  - `POSTGRES_DB=rentalsystemdb`

- RabbitMQ:
  - `RABBITMQ_DEFAULT_USER=admin`
  - `RABBITMQ_DEFAULT_PASS=adminrentalsystem`

- API:
  - `ConnectionStrings__DefaultConnection=Host=postgres;Port=5432;Database=rentalsystemdb;Username=admin;Password=adminrentalsystem`
  - `RabbitMq__Host=rabbitmq`
  - `RabbitMq__Port=5672`
  - `RabbitMq__Username=admin`
  - `RabbitMq__Password=adminrentalsystem`

---

## 📂 Estrutura do Projeto

```
RentalSystem
├── src/
│   ├── RentalSystem.Presentation    // Camada de API (Controllers, Filtros, etc)
│   ├── RentalSystem.Application     // Casos de uso, interfaces, validações
│   ├── RentalSystem.Domain          // Entidades e contratos de domínio
│   ├── RentalSystem.Infra           // Repositórios, contexto EF, mensageria
├── shared/
│   ├── RentalSystem.Communication   // DTOs (Requests/Responses)
│   ├── RentalSystem.Exceptions      // Exceções customizadas
├── Dockerfile
├── docker-compose.yml
└── README.md
```

---

## 📌 Observações

- A imagem da CNH é salva no diretório local `Storage/CNH` dentro do container na camada de presentation da aplicação.
- A aplicação usa AutoMapper, injeção de dependência com `IServiceCollection` e HostedService para o consumidor RabbitMQ.
- As validações de negócio estão centralizadas nos Use Cases, algumas chamam outras classes "validator" pra casos de regras mais extensas.
- O projeto utiliza padrões DDD, SOLID e arquitetura em camadas (clean architecture).

---

## 📧 Contato

Caso deseje entrar em contato comigo:

**Lucas Oliveira**  
Email: lucasoliveir.tech@gmail.com  
LinkedIn: https://www.linkedin.com/in/lucas-oliveira-tech/
GitHub: https://github.com/lucasolvv?tab=repositories

---

## ✅ Status do Desafio

| Funcionalidade                          | Status     |
|----------------------------------------|------------|
| Cadastro de motos                      | ✅ Concluído |
| Edição e exclusão de motos             | ✅ Concluído |
| Filtro de motos por placa              | ✅ Concluído |
| Cadastro de entregadores               | ✅ Concluído |
| Upload de imagem da CNH                | ✅ Concluído |
| Locação de motos                       | ✅ Concluído |
| Devolução com multa/adicionais         | ✅ Concluído |
| Publicação e consumo de evento Rabbit  | ✅ Concluído |
| Testes unitários                       | ❌ Não implementado |
| Testes de Integração                       | ❌ Não implementado |
| Logs estruturados                      | ❌ Não implementado |
| Documentação via Swagger               | ✅ Concluído |
