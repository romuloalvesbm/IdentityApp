#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Projeto.Identity.API/Projeto.Identity.API.csproj", "Projeto.Identity.API/"]
COPY ["Projeto.CrossCutting.Authorization/Projeto.CrossCutting.Authorization.csproj", "Projeto.CrossCutting.Authorization/"]
COPY ["Projeto.Identity.Data/Projeto.Identity.Data.csproj", "Projeto.Identity.Data/"]
COPY ["Projeto.Identity.Domain/Projeto.Identity.Domain.csproj", "Projeto.Identity.Domain/"]
RUN dotnet restore "./Projeto.Identity.API/Projeto.Identity.API.csproj"
COPY . .
WORKDIR "/src/Projeto.Identity.API"
RUN dotnet build "./Projeto.Identity.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Projeto.Identity.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Homolog
ENTRYPOINT ["dotnet", "Projeto.Identity.API.dll"]