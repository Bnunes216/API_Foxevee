# Usar imagem base do .NET para execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Usar imagem do .NET SDK 8.0 para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ApiJogo.csproj", "."]
RUN dotnet restore "./././ApiJogo.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "./ApiJogo.csproj" -c Release -o /app/build

# Publicar a aplicação
FROM build AS publish
RUN dotnet publish "./ApiJogo.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Copiar para a imagem base final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN ls -la /app
ENTRYPOINT ["dotnet", "ApiJogo.dll"]
