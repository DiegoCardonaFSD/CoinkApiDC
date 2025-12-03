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


