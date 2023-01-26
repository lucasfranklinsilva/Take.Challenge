FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine3.11 AS base
WORKDIR /app
EXPOSE 80

RUN apk add icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false 

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine3.11 AS build
WORKDIR /src

COPY ["GitHubIntegration.Facades/GitHubIntegration.Facades.csproj", "GitHubIntegration.Facades/"]
COPY ["GitHubIntegration.Models/GitHubIntegration.Models.csproj", "GitHubIntegration.Models/"]
COPY ["GitHubIntegration.Services/GitHubIntegration.Services.csproj", "GitHubIntegration.Services/"]
COPY ["GitHubIntegration/GitHubIntegration.csproj", "GitHubIntegration/"]

RUN dotnet restore "GitHubIntegration/GitHubIntegration.csproj"
COPY . .
WORKDIR "/src/GitHubIntegration"
RUN dotnet build "GitHubIntegration.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GitHubIntegration.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GitHubIntegration.dll"]


