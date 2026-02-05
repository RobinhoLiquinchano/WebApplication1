# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Al estar el Dockerfile en la misma carpeta que el .csproj, usamos "."
COPY ["WebApplication1.csproj", "./"]
RUN dotnet restore "WebApplication1.csproj"

# Copiamos todo el contenido de la carpeta actual
COPY . .
RUN dotnet publish "WebApplication1.csproj" -c Release -o /app

# Etapa de ejecución
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app .

# Forzamos el puerto de Render
ENV ASPNETCORE_URLS=http://+:${PORT}

ENTRYPOINT ["dotnet", "WebApplication1.dll"]