FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/BulletinBoard/Hosts/BulletinBoard.Hosts.Api/BulletinBoard.Hosts.Api.csproj", "src/BulletinBoard/Hosts/BulletinBoard.Hosts.Api/"]
COPY ["src/BulletinBoard/Application/BulletinBoard.AppServices/BulletinBoard.AppServices.csproj", "src/BulletinBoard/Application/BulletinBoard.AppServices/"]
COPY ["src/BulletinBoard/Contracts/BulletinBoard.Contracts/BulletinBoard.Contracts.csproj", "src/BulletinBoard/Contracts/BulletinBoard.Contracts/"]
COPY ["src/BulletinBoard/Domain/BulletinBoard.Domain/BulletinBoard.Domain.csproj", "src/BulletinBoard/Domain/BulletinBoard.Domain/"]
COPY ["src/BulletinBoard/Infrastructure/BulletinBoard.Infrastructure.ComponentRegistrar/BulletinBoard.Infrastructure.ComponentRegistrar.csproj", "src/BulletinBoard/Infrastructure/BulletinBoard.Infrastructure.ComponentRegistrar/"]
COPY ["src/BulletinBoard/Infrastructure/BulletinBoard.Infrastructure.DataAccess/BulletinBoard.Infrastructure.DataAccess.csproj", "src/BulletinBoard/Infrastructure/BulletinBoard.Infrastructure.DataAccess/"]
COPY ["src/BulletinBoard/Infrastructure/BulletinBoard.Infrastructure/BulletinBoard.Infrastructure.csproj", "src/BulletinBoard/Infrastructure/BulletinBoard.Infrastructure/"]
RUN dotnet restore "src/BulletinBoard/Hosts/BulletinBoard.Hosts.Api/BulletinBoard.Hosts.Api.csproj"
COPY . .
WORKDIR "/src/src/BulletinBoard/Hosts/BulletinBoard.Hosts.Api"
RUN dotnet build "./BulletinBoard.Hosts.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BulletinBoard.Hosts.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BulletinBoard.Hosts.Api.dll"]
