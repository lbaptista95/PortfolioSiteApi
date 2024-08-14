
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["PortfolioSiteApi.csproj", "."]
RUN dotnet restore "./PortfolioSiteApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "PortfolioSiteApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PortfolioSiteApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "PortfolioSiteApi.dll"]
