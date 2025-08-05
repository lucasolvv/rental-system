#!/bin/bash

echo "Aguardando PostgreSQL subir..."
sleep 10

echo "Executando migrations..."
dotnet ef database update --project ../RentalSystem.Infra --startup-project . --verbose

echo "Iniciando aplicação..."
dotnet RentalSystem.Presentation.dll
