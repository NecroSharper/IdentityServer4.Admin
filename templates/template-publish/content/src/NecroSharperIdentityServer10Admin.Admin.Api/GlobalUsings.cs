global using System;
global using System.Collections.Generic;
global using System.IO;
global using System.IdentityModel.Tokens.Jwt;
global using HealthChecks.UI.Client;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.OpenApi;
global using Serilog;
global using Skoruba.AuditLogging.EntityFramework.Entities;
global using NecroSharperIdentityServer10Admin.Admin.Api.Configuration;
global using NecroSharperIdentityServer10Admin.Admin.Api.Configuration.Authorization;
global using NecroSharperIdentityServer10Admin.Admin.Api.ExceptionHandling;
global using NecroSharperIdentityServer10Admin.Admin.Api.Helpers;
global using NecroSharperIdentityServer10Admin.Admin.Api.Middlewares;
global using NecroSharperIdentityServer10Admin.Admin.Api.Mappers;
global using NecroSharperIdentityServer10Admin.Admin.Api.Resources;
global using NecroSharperIdentityServer10Admin.Admin.EntityFramework.Shared.DbContexts;
global using NecroSharperIdentityServer10Admin.Admin.EntityFramework.Shared.Entities.Identity;
global using NecroSharper.IdentityServer10.Shared.Configuration.Helpers;
global using NecroSharperIdentityServer10Admin.Shared.Dtos;
global using NecroSharperIdentityServer10Admin.Shared.Dtos.Identity;







