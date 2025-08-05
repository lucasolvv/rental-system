# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar arquivos da solução
COPY *.sln ./
COPY src/RentalSystem.Presentation/RentalSystem.Presentation.csproj ./src/RentalSystem.Presentation/
COPY src/RentalSystem.Application/RentalSystem.Application.csproj ./src/RentalSystem.Application/
COPY src/RentalSystem.Domain/RentalSystem.Domain.csproj ./src/RentalSystem.Domain/
COPY src/RentalSystem.Infra/RentalSystem.Infra.csproj ./src/RentalSystem.Infra/
COPY shared/RentalSystem.Communication/RentalSystem.Communication.csproj ./shared/RentalSystem.Communication/
COPY shared/RentalSystem.Exceptions/RentalSystem.Exceptions.csproj ./shared/RentalSystem.Exceptions/

# Restaurar dependências
RUN dotnet restore

# Copiar o restante do código
COPY src/ ./src/
COPY shared/ ./shared/  

# Build da aplicação
WORKDIR /app/src/RentalSystem.Presentation
RUN dotnet publish -c Release -o /app/publish

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "RentalSystem.Presentation.dll"]
