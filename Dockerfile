# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar solución y proyectos
COPY WebApplicationAws.slnx ./
COPY WebApplicationAws/ ./WebApplicationAws/

# Restaurar dependencias
RUN dotnet restore WebApplicationAws.slnx

# Publicar WebApi
RUN dotnet publish ./WebApplicationAws/WebApi/WebApi.csproj -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copiar binarios publicados desde la etapa build
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "WebApi.dll"]
