FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copie o arquivo de projeto e restaure as dependências
COPY ["dotnet-aspire.Web/dotnet-aspire.Web.csproj", "dotnet-aspire.Web/"]
RUN dotnet restore "dotnet-aspire.Web/dotnet-aspire.Web.csproj"

# Copie o resto dos arquivos e construa o aplicativo
COPY . .
WORKDIR "/src/dotnet-aspire.Web"
RUN dotnet build "dotnet-aspire.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dotnet-aspire.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "dotnet-aspire.Web.dll"]