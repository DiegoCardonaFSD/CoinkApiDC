FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

RUN dotnet tool install --global dotnet-ef --version 8.0.22
RUN export PATH="$PATH:/root/.dotnet/tools"

COPY ./src/CoinkApiDC/ ./src/CoinkApiDC/

WORKDIR ./src/CoinkApiDC
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

RUN dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.0
RUN dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.0
RUN dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 8.0.0

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CoinkApiDC.dll"]
