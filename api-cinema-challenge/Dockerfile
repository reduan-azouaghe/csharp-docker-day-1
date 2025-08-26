FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 4000
EXPOSE 8000

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["api-cinema-challenge/api-cinema-challenge.csproj", "api-cinema-challenge/"]
RUN dotnet restore "api-cinema-challenge/api-cinema-challenge.csproj"
COPY . .
WORKDIR "/src/api-cinema-challenge"
RUN dotnet build "./api-cinema-challenge.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./api-cinema-challenge.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api-cinema-challenge.dll"]
