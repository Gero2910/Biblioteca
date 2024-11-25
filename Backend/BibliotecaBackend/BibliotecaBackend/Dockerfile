# Etapa base
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Etapa de construcción
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copiar el archivo .csproj correctamente (ruta corregida)
COPY ["BibliotecaBackend/BibliotecaBackend.csproj", "."]
RUN dotnet restore "BibliotecaBackend.csproj"

# Copiar el resto de los archivos
COPY . .
WORKDIR "/src/BibliotecaBackend/BibliotecaBackend"
RUN dotnet build "BibliotecaBackend.csproj" -c Release -o /app/build

# Etapa de publicación
FROM build AS publish
RUN dotnet publish "BibliotecaBackend.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BibliotecaBackend.dll"]
