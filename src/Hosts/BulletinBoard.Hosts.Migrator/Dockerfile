FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Hosts/BulletinBoard.Hosts.Migrator/BulletinBoard.Hosts.Migrator.csproj", "src/Hosts/BulletinBoard.Hosts.Migrator/"]
COPY ["src/Infrastructure/BulletinBoard.Infrastructure.DataAccess/BulletinBoard.Infrastructure.DataAccess.csproj", "src/Infrastructure/BulletinBoard.Infrastructure.DataAccess/"]
COPY ["src/Application/BulletinBoard.AppServices/BulletinBoard.AppServices.csproj", "src/Application/BulletinBoard.AppServices/"]
COPY ["src/Contracts/BulletinBoard.Contracts/BulletinBoard.Contracts.csproj", "src/Contracts/BulletinBoard.Contracts/"]
COPY ["src/Domain/BulletinBoard.Domain/BulletinBoard.Domain.csproj", "src/Domain/BulletinBoard.Domain/"]
RUN dotnet restore "src/Hosts/BulletinBoard.Hosts.Migrator/BulletinBoard.Hosts.Migrator.csproj"
COPY . .
WORKDIR "/src/src/Hosts/BulletinBoard.Hosts.Migrator"
RUN dotnet build "./BulletinBoard.Hosts.Migrator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BulletinBoard.Hosts.Migrator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BulletinBoard.Hosts.Migrator.dll"]
