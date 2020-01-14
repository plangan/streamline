FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Services/Administration/Administration.API/Administration.API.csproj", "src/Services/Administration/Administration.API/"]
COPY ["src/DataModels/StreamLineModels/StreamLineModels.csproj", "src/DataModels/StreamLineModels/"]
RUN dotnet restore "src/Services/Administration/Administration.API/Administration.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Administration/Administration.API"
RUN dotnet build "Administration.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Administration.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Administration.API.dll"]
