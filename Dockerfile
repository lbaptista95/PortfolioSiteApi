
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app


#ENV DB_CONNECTION_STRING="Host=10.126.48.3;Database=portfoliositedb;Username=lbaptista95;Password=PPRVBD14)nG_8jLc;Port=5432;"
ENV DB_CONNECTION_STRING="Server=10.126.48.3;Port=5432;Database=portfoliositedb;Username=lbaptista95;Password=PPRVBD14)nG_8jLc;SSL Mode=Prefer;Trust Server Certificate=true;"
ENV SMTP_PWD="J051295k@"

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
