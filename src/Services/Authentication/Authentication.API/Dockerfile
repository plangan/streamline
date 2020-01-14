FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Services/Authentication/Authentication.API/Authentication.API.csproj", "src/Services/Authentication/Authentication.API/"]
COPY ["src/DataModels/StreamLineModels/StreamLineModels.csproj", "src/DataModels/StreamLineModels/"]
RUN dotnet restore "src/Services/Authentication/Authentication.API/Authentication.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Authentication/Authentication.API"
RUN dotnet build "Authentication.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Authentication.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Authentication.API.dll"]
