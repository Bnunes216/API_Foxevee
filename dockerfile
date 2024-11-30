# Use uma imagem base do .NET
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Use uma imagem do .NET para build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ApiJogo.csproj", "./"]
RUN dotnet restore "ApiJogo.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "ApiJogo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiJogo.csproj" -c Release -o /app/publish

# Copie o conteúdo publicado para a imagem base
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiJogo.dll"]
