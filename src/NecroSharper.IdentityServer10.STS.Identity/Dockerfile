FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["src/NecroSharper.IdentityServer10.STS.Identity/NecroSharper.IdentityServer10.STS.Identity.csproj", "src/NecroSharper.IdentityServer10.STS.Identity/"]
COPY ["src/NecroSharper.IdentityServer10.Shared.Configuration/NecroSharper.IdentityServer10.Shared.Configuration.csproj", "src/NecroSharper.IdentityServer10.Shared.Configuration/"]
COPY ["src/NecroSharper.IdentityServer10.Admin.EntityFramework.Shared/NecroSharper.IdentityServer10.Admin.EntityFramework.Shared.csproj", "src/NecroSharper.IdentityServer10.Admin.EntityFramework.Shared/"]
COPY ["src/NecroSharper.IdentityServer10.Admin.EntityFramework.Identity/NecroSharper.IdentityServer10.Admin.EntityFramework.Identity.csproj", "src/NecroSharper.IdentityServer10.Admin.EntityFramework.Identity/"]
COPY ["src/NecroSharper.IdentityServer10.Admin.EntityFramework/NecroSharper.IdentityServer10.Admin.EntityFramework.csproj", "src/NecroSharper.IdentityServer10.Admin.EntityFramework/"]
COPY ["src/NecroSharper.IdentityServer10.Admin.EntityFramework.Extensions/NecroSharper.IdentityServer10.Admin.EntityFramework.Extensions.csproj", "src/NecroSharper.IdentityServer10.Admin.EntityFramework.Extensions/"]
COPY ["src/NecroSharper.IdentityServer10.Admin.EntityFramework.Configuration/NecroSharper.IdentityServer10.Admin.EntityFramework.Configuration.csproj", "src/NecroSharper.IdentityServer10.Admin.EntityFramework.Configuration/"]
COPY ["src/NecroSharper.IdentityServer10.Shared/NecroSharper.IdentityServer10.Shared.csproj", "src/NecroSharper.IdentityServer10.Shared/"]
COPY ["src/NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity/NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.csproj", "src/NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity/"]
COPY ["src/NecroSharper.IdentityServer10.Admin.BusinessLogic.Shared/NecroSharper.IdentityServer10.Admin.BusinessLogic.Shared.csproj", "src/NecroSharper.IdentityServer10.Admin.BusinessLogic.Shared/"]
RUN dotnet restore "src/NecroSharper.IdentityServer10.STS.Identity/NecroSharper.IdentityServer10.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/NecroSharper.IdentityServer10.STS.Identity"
RUN dotnet build "NecroSharper.IdentityServer10.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NecroSharper.IdentityServer10.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "NecroSharper.IdentityServer10.STS.Identity.dll"]