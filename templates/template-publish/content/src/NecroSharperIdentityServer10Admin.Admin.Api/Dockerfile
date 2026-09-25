FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["src/NecroSharperIdentityServer10Admin.Admin.Api/NecroSharperIdentityServer10Admin.Admin.Api.csproj", "src/NecroSharperIdentityServer10Admin.Admin.Api/"]
COPY ["src/NecroSharperIdentityServer10Admin.Admin.EntityFramework.Shared/NecroSharperIdentityServer10Admin.Admin.EntityFramework.Shared.csproj", "src/NecroSharperIdentityServer10Admin.Admin.EntityFramework.Shared/"]
COPY ["src/NecroSharperIdentityServer10Admin.Admin.EntityFramework.SqlServer/NecroSharperIdentityServer10Admin.Admin.EntityFramework.SqlServer.csproj", "src/NecroSharperIdentityServer10Admin.Admin.EntityFramework.SqlServer/"]
COPY ["src/NecroSharperIdentityServer10Admin.Shared/NecroSharperIdentityServer10Admin.Shared.csproj", "src/NecroSharperIdentityServer10Admin.Shared/"]
COPY ["src/NecroSharperIdentityServer10Admin.Admin.EntityFramework.PostgreSQL/NecroSharperIdentityServer10Admin.Admin.EntityFramework.PostgreSQL.csproj", "src/NecroSharperIdentityServer10Admin.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/NecroSharperIdentityServer10Admin.Admin.EntityFramework.MySql/NecroSharperIdentityServer10Admin.Admin.EntityFramework.MySql.csproj", "src/NecroSharperIdentityServer10Admin.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/NecroSharperIdentityServer10Admin.Admin.Api/NecroSharperIdentityServer10Admin.Admin.Api.csproj"
COPY . .
WORKDIR "/src/src/NecroSharperIdentityServer10Admin.Admin.Api"
RUN dotnet build "NecroSharperIdentityServer10Admin.Admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NecroSharperIdentityServer10Admin.Admin.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "NecroSharperIdentityServer10Admin.Admin.Api.dll"]