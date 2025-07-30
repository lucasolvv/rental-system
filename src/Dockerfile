# Fase 1 - Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os .csproj de todos os projetos
COPY ["src/RentalSystem.Presentation/RentalSystem.Presentation.csproj", "src/RentalSystem.Presentation/"]
COPY ["src/RentalSystem.Application/RentalSystem.Application.csproj", "src/RentalSystem.Application/"]
COPY ["src/RentalSystem.Domain/RentalSystem.Domain.csproj", "src/RentalSystem.Domain/"]
COPY ["src/RentalSystem.Infra/RentalSystem.Infra.csproj", "src/RentalSystem.Infra/"]
COPY ["shared/proj.Communication/proj.Communication.csproj", "shared/proj.Communication/"]
COPY ["shared/proj.Exceptions/proj.Exceptions.csproj", "shared/proj.Exceptions/"]

# Restaura os pacotes
RUN dotnet restore "src/RentalSystem.Presentation/RentalSystem.Presentation.csproj"

# Copia o restante dos arquivos do projeto
COPY . .

# Compila o projeto
WORKDIR "/src/RentalSystem.Presentation"
RUN dotnet publish "RentalSystem.Presentation.csproj" -c Release -o /app/publish

# Fase 2 - Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copia os arquivos da publicação
COPY --from=build /app/publish .

# Define a porta
EXPOSE 8080

# Comando de inicialização
ENTRYPOINT ["dotnet", "RentalSystem.Presentation.dll"]
