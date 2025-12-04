## Evaluación técnica para Coink - Elaborada por Diego Cardona


## CoinkApiDC -- .NET 8 + PostgreSQL + Redis + Docker

Este proyecto es una plantilla profesional basada en **.NET 8 Web API**,
ejecutada completamente dentro de **Docker**, utilizando:

-   **ASP.NET Core 8**
-   **PostgreSQL 16**
-   **Redis 7**
-   **Docker & Docker Compose**
-   **Swagger (OpenAPI)**

Permite desarrollar sin instalar .NET localmente.

Adicionalmente para uso local en mi caso, estoy usando Windows 11, y estoy corriendo docker sobre ubuntu en WSL2

------------------------------------------------------------------------

## Estructura del Proyecto

    .
    ├── docker-compose.yml
    ├── Dockerfile
    └── src/
        └── CoinkApiDC/
            ├── CoinkApiDC.csproj
            └── Program.cs

------------------------------------------------------------------------

# Docker Compose -- Comandos Principales

## Compilar y levantar contenedores

``` bash
docker compose up -d --build
```

## Levantar sin reconstruir

``` bash
docker compose up -d
```

## Reconstruir sin usar caché

``` bash
docker compose up -d --build --no-cache
```

## Ver logs

``` bash
docker compose logs -f app
```

## Detener contenedores

``` bash
docker compose down
```

## Recompilar imagen base 
``` bash
docker build -t coinkapi .
```
## Detener y borrar volúmenes (incluye base de datos)

**Advertencia**: elimina datos de PostgreSQL.

``` bash
docker compose down -v
```

------------------------------------------------------------------------

# Modo Desarrollo (Hot Reload)

Permite que los cambios en el código se reflejen sin reconstruir la
imagen. Para efectos de esta prueba solo se esta utilizando este modo para facilitar todo el desarrollo

### 1 Asegurar volumen en `docker-compose.yml`

``` yaml
volumes:
  - ./src/CoinkApiDC:/app
```

### 2️ Asegurar entorno de desarrollo

``` yaml
ASPNETCORE_ENVIRONMENT=Development
```

### 3️ Ejecutar Hot Reload dentro del contenedor

``` bash
docker compose exec app bash
dotnet watch run
```

------------------------------------------------------------------------

# Documentación Swagger

### Swagger UI

    http://localhost:8080/swagger

### OpenAPI JSON

    http://localhost:8080/swagger/v1/swagger.json

------------------------------------------------------------------------

# Endpoint de prueba

    GET http://localhost:8080/ping

------------------------------------------------------------------------

# Comandos útiles

### Ver contenedores

``` bash
docker ps
```

### Entrar al contenedor de la API

``` bash
docker compose exec app bash
```

### Acceder a PostgreSQL

``` bash
docker compose exec postgres bash
psql -U user -d coinkdb
```

### Actualizar permisos para escribir en el contenedor

``` bash
sudo chown -R dev:dev /home/dev/projects
sudo chmod -R u+rw /home/dev/projects
```

### Instalar EF dentro de un contenedor 

``` bash
dotnet tool install --global dotnet-ef --version 8.*
o
dotnet tool install --global dotnet-ef --version 8.0.22
export PATH="$PATH:/root/.dotnet/tools"
dotnet --version
dotnet --list-sdks

dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.0
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 8.0.0

dotnet add src/CoinkApiDC.Infrastructure package Microsoft.EntityFrameworkCore
dotnet add src/CoinkApiDC.Infrastructure package Microsoft.EntityFrameworkCore.Design
dotnet add src/CoinkApiDC.Infrastructure package Npgsql.EntityFrameworkCore.PostgreSQL

dotnet add src/CoinkApiDC.Infrastructure package Microsoft.EntityFrameworkCore.Design
dotnet add src/CoinkApiDC.Infrastructure package Npgsql.EntityFrameworkCore.PostgreSQL

dotnet build src/CoinkApiDC.Domain/CoinkApiDC.Domain.csproj
dotnet build src/CoinkApiDC.Application/CoinkApiDC.Application.csproj
dotnet build src/CoinkApiDC.Infrastructure/CoinkApiDC.Infrastructure.csproj
dotnet build src/CoinkApiDC.Api/CoinkApiDC.Api.csproj

```

### Inicializar migraciones 

``` bash
dotnet ef migrations add InitialCreate

dotnet ef migrations add InitialCreate \
    --project src/CoinkApiDC.Infrastructure/CoinkApiDC.Infrastructure.csproj \
    --startup-project src/CoinkApiDC.Api/CoinkApiDC.Api.csproj \
    --output-dir Migrations

```

### Aplicar migraciones a PostgreSQL

``` bash
dotnet ef database update

dotnet ef database update \
    --project src/CoinkApiDC.Infrastructure/CoinkApiDC.Infrastructure.csproj \
    --startup-project src/CoinkApiDC.Api/CoinkApiDC.Api.csproj

export POSTGRES_HOST=172.24.43.127
export POSTGRES_PORT=5432
export POSTGRES_DB=coinkdb
export POSTGRES_USER=user
export POSTGRES_PASSWORD=pass
    
```

### Ejecutar seeders

``` bash
dotnet ef migrations add SeedInitialData \
    --project src/CoinkApiDC.Infrastructure/CoinkApiDC.Infrastructure.csproj \
    --startup-project src/CoinkApiDC.Api/CoinkApiDC.Api.csproj
```    

### Ver definicion en el schema de la tabla Users

``` bash
docker exec -it coink-api-db psql -U user -d coinkdb -c "SELECT column_name, data_type, character_maximum_length FROM information_schema.columns WHERE table_name='Users';"

# all tables
docker exec -it coink-api-db psql -U user -d coinkdb -c "SELECT table_name FROM information_schema.tables WHERE table_schema='public';"
``` 

### Borrar base de datos actual

``` bash
docker exec -it coink-api-db psql -U user -d postgres -c "DROP DATABASE coinkdb WITH (FORCE);"
docker exec -it coink-api-db psql -U user -d postgres -c "CREATE DATABASE coinkdb;"
```

### Agregar referencias entre proyectos

``` bash
dotnet add src/CoinkApiDC.Application/CoinkApiDC.Application.csproj reference src/CoinkApiDC.Domain/CoinkApiDC.Domain.csproj
dotnet add src/CoinkApiDC.Infrastructure/CoinkApiDC.Infrastructure.csproj reference src/CoinkApiDC.Application/CoinkApiDC.Application.csproj


```


``` bash
```

``` bash
```