FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 3007/tcp
EXPOSE 3008/tcp
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Regiao.Api/Regiao.Api.csproj", "Regiao.Api/"]
COPY ["src/Regiao.Domain/Regiao.Domain.csproj", "Regiao.Domain/"]
COPY ["src/Regiao.Infra/Regiao.Infra.csproj", "Regiao.Infra/"]

RUN dotnet restore "Regiao.Api/Regiao.Api.csproj"
RUN dotnet restore "Regiao.Domain/Regiao.Domain.csproj"
RUN dotnet restore "Regiao.Infra/Regiao.Infra.csproj"
COPY . .
RUN dotnet build "src/Regiao.Api.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "src/Regiao.Api.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Regiao.Api.dll"]