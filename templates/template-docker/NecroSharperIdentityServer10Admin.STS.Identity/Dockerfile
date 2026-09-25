FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["src/NecroSharperIdentityServer10Admin.STS.Identity/NecroSharperIdentityServer10Admin.STS.Identity.csproj", "src/NecroSharperIdentityServer10Admin.STS.Identity/"]
COPY ["src/NecroSharperIdentityServer10Admin.Admin.EntityFramework.Shared/NecroSharperIdentityServer10Admin.Admin.EntityFramework.Shared.csproj", "src/NecroSharperIdentityServer10Admin.Admin.EntityFramework.Shared/"]
COPY ["src/NecroSharperIdentityServer10Admin.Shared/NecroSharperIdentityServer10Admin.Shared.csproj", "src/NecroSharperIdentityServer10Admin.Shared/"]
RUN dotnet restore "src/NecroSharperIdentityServer10Admin.STS.Identity/NecroSharperIdentityServer10Admin.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/NecroSharperIdentityServer10Admin.STS.Identity"
RUN dotnet build "NecroSharperIdentityServer10Admin.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NecroSharperIdentityServer10Admin.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "NecroSharperIdentityServer10Admin.STS.Identity.dll"]