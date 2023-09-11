FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["market-place/market-place.csproj", "market-place/"]
RUN dotnet restore "market-place/market-place.csproj"
COPY . .
WORKDIR "/src/market-place"
RUN dotnet build "market-place.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "market-place.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "market-place.dll"]
