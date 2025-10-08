FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/BulletinBoard/Hosts/BulletinBoard.Hosts.Migrator/BulletinBoard.Hosts.Migrator.csproj", "src/BulletinBoard/Hosts/BulletinBoard.Hosts.Migrator/"]
RUN dotnet restore "src/BulletinBoard/Hosts/BulletinBoard.Hosts.Migrator/BulletinBoard.Hosts.Migrator.csproj"
COPY . .
WORKDIR "/src/src/BulletinBoard/Hosts/BulletinBoard.Hosts.Migrator"
RUN dotnet build "./BulletinBoard.Hosts.Migrator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BulletinBoard.Hosts.Migrator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BulletinBoard.Hosts.Migrator.dll"]
