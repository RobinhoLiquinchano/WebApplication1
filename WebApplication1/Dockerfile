# Etapa de compilación (SDK de .NET 10)
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copiamos y restauramos basándonos en tu proyecto WebApplication1
COPY ["WebApplication1.csproj", "./"]
RUN dotnet restore "WebApplication1.csproj"

# Compilamos la aplicación
COPY . .
RUN dotnet publish "WebApplication1.csproj" -c Release -o /app

# Etapa de ejecución (Runtime de ASP.NET 10)
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app .

# Forzamos a que escuche en el puerto dinámico de Render
ENV ASPNETCORE_URLS=http://+:${PORT}

ENTRYPOINT ["dotnet", "WebApplication1.dll"]