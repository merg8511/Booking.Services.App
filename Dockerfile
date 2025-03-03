# 1 Etapa de compilacion (Build)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar la solucion completa
COPY . ./

# Restaurar paquetes de NuGet
RUN dotnet restore "Booking.Services.App/Booking.Services.App.csproj"

# Compilar la aplicacion
RUN dotnet publish "Booking.Services.App/Booking.Services.App.csproj" -c Release -o /app/build

# 2 Etapa de ejecucion (Runtime)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copiar la aplicacion compilada
COPY --from=build /app/build ./

# Exponer el puerto
EXPOSE 8080

# Ejecutar la aplicacion
CMD ["dotnet", "Booking.Services.App.dll"]
