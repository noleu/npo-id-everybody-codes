FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Search.APi/Search.APi.csproj", "Search.APi/"]
COPY ["Search.Service/Search.Service.csproj", "Search.Service/"]
COPY ["Search.Data/Search.Data.csproj", "Search.Data/"]
RUN dotnet restore "Search.APi/Search.APi.csproj"
COPY . .
WORKDIR "/src/Search.APi"
RUN dotnet build "./Search.APi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Search.APi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Search.APi.dll"]
