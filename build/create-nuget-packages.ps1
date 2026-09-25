$packagesOutput = ".\packages"

# Business Logic
dotnet pack .\..\src\NecroSharper.IdentityServer10.Admin.BusinessLogic\NecroSharper.IdentityServer10.Admin.BusinessLogic.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity\NecroSharper.IdentityServer10.Admin.BusinessLogic.Identity.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\NecroSharper.IdentityServer10.Admin.BusinessLogic.Shared\NecroSharper.IdentityServer10.Admin.BusinessLogic.Shared.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\NecroSharper.IdentityServer10.Shared.Configuration\NecroSharper.IdentityServer10.Shared.Configuration.csproj -c Release -o $packagesOutput

# EF
dotnet pack .\..\src\NecroSharper.IdentityServer10.Admin.EntityFramework\NecroSharper.IdentityServer10.Admin.EntityFramework.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\NecroSharper.IdentityServer10.Admin.EntityFramework.Extensions\NecroSharper.IdentityServer10.Admin.EntityFramework.Extensions.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\NecroSharper.IdentityServer10.Admin.EntityFramework.Identity\NecroSharper.IdentityServer10.Admin.EntityFramework.Identity.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\NecroSharper.IdentityServer10.Admin.EntityFramework.Shared\NecroSharper.IdentityServer10.Admin.EntityFramework.Shared.csproj -c Release -o $packagesOutput
dotnet pack .\..\src\NecroSharper.IdentityServer10.Admin.EntityFramework.Configuration\NecroSharper.IdentityServer10.Admin.EntityFramework.Configuration.csproj -c Release -o $packagesOutput

# UI
dotnet pack .\..\src\NecroSharper.IdentityServer10.Admin.UI\NecroSharper.IdentityServer10.Admin.UI.csproj -c Release -o $packagesOutput