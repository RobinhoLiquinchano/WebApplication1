# Etapa base para ejecución
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
# Render usa un puerto dinámico, pero exponemos el que configuramos por defecto
EXPOSE 8080

# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# COPIAR EL CSPROJ: 
# Como el Dockerfile está dentro de la carpeta WebApplication1, 
# solo necesitamos copiar el archivo que está a su lado.
COPY ["WebApplication1.csproj", "./"]
RUN dotnet restore "WebApplication1.csproj"

# Copiamos todo lo demás y compilamos
COPY . .
RUN dotnet build "WebApplication1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApplication1.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Esta línea es la que hace que Render funcione con .NET 10
ENV ASPNETCORE_URLS=http://+:${PORT}

ENTRYPOINT ["dotnet", "WebApplication1.dll"]