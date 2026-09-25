param([string] $packagesVersions)

$templateNuspecPath = "template-publish/NecroSharper.IdentityServer10.Admin.Templates.nuspec"
nuget pack $templateNuspecPath -NoDefaultExcludes

dotnet.exe new --uninstall NecroSharper.IdentityServer10.Admin.Templates

$templateLocalName = "NecroSharper.IdentityServer10.Admin.Templates.$packagesVersions.nupkg"
dotnet.exe new -i $templateLocalName

dotnet.exe new skoruba.is4admin --name MyProject --title MyProject --adminemail 'admin@necrosharper.com' --adminpassword 'Pa$$word123' --adminrole MyRole --adminclientid MyClientId --adminclientsecret MyClientSecret --dockersupport true