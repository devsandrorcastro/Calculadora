# Etapa 1 - build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copia csproj e restaura dependências
COPY *.csproj ./
RUN dotnet restore

# Copia tudo e publica
COPY . ./
RUN dotnet publish -c Release -o /publish

# Etapa 2 - runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

COPY --from=build /publish .

# Porta padrão
EXPOSE 8080

# Define URL
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "Calculadora.dll"]