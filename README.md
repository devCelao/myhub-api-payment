# MyHub — API Payment

API de gerenciamento de pagamentos, assinaturas e integração com gateways de pagamento.

## Estrutura

```
PaymentAPI/           → Controllers e configuração da API
PaymentApplication/   → Serviços e lógica de aplicação
PaymentDomain/        → Entidades e DTOs
PaymentInfrastructure/ → Repositórios e contexto de dados
```

## Desenvolvimento Local

Requisitos: Docker, Docker Compose e .NET 9.0

### Rodar com Docker Compose

```bash
# 1. Configurar variáveis de ambiente
cp .env.example .env

# 2. Subir o container
docker compose up -d --build
```

A API fica disponível em `http://api-payment.localhost` (via Traefik).

### Rodar com dotnet CLI

```bash
cd PaymentAPI
dotnet run
```

A API fica disponível em `http://localhost:8080`.

## Deploy

O deploy é feito via GitHub Actions. Para publicar uma nova versão no Docker Hub:

1. Criar uma tag no repositório (ex: `v1.2.0`)
2. Ir em **Actions → Build & Push Docker Image**
3. Executar manualmente informando a tag criada

A imagem é publicada como `<dockerhub-username>/api-payment:<tag>`.
