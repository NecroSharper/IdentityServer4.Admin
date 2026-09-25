global using System;
global using System.IO;
global using System.IdentityModel.Tokens.Jwt;
global using System.Linq;
global using System.Threading.Tasks;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Serilog;
global using Skoruba.AuditLogging.EntityFramework.Entities;
global using NecroSharperIdentityServer10Admin.Admin.Configuration.Database;
global using NecroSharper.IdentityServer10.Admin.EntityFramework.Configuration.Configuration;
global using NecroSharperIdentityServer10Admin.Admin.EntityFramework.Shared.DbContexts;
global using NecroSharperIdentityServer10Admin.Admin.EntityFramework.Shared.Entities.Identity;
global using NecroSharperIdentityServer10Admin.Admin.EntityFramework.Shared.Helpers;
global using NecroSharperIdentityServer10Admin.Admin.Helpers;
global using NecroSharper.IdentityServer10.Shared.Configuration.Helpers;
global using NecroSharperIdentityServer10Admin.Shared.Dtos;
global using NecroSharperIdentityServer10Admin.Shared.Dtos.Identity;







