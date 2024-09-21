FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["dotnet-aspire.Api/dotnet-aspire.Api.csproj", "dotnet-aspire.Api/"]
RUN dotnet restore "dotnet-aspire.Api/dotnet-aspire.Api.csproj"
COPY . .
WORKDIR "/src/dotnet-aspire.Api"
RUN dotnet build "dotnet-aspire.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dotnet-aspire.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "dotnet-aspire.Api.dll"]