using AutoMapper;
using Bilbayt.Homework.Api.Domain.Common;
using Bilbayt.Homework.Api.Domain.Settings;
using Bilbayt.Homework.Api.Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using Bilbayt.Homework.Api.Persistence.Repositories.Contracts;
using Bilbayt.Homework.Api.Persistence.Repositories.Implementations;
using Bilbayt.Homework.Api.Service.Contract;
using Bilbayt.Homework.Api.Service.Implementation;

namespace Bilbayt.Homework.Api.Infrastructure.Extension
{
    public static class ConfigureServiceContainer
    {
        public static void AddAutoMapper(this IServiceCollection serviceCollection)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
            });
            var mapper = mappingConfig.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }

        public static void AddScopedServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IJwtAuthService, JwtAuthService>();
            serviceCollection.AddScoped<INotificationService, NotificationService>();
            serviceCollection.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
        }

        public static void AddTransientServices(this IServiceCollection serviceCollection)
        {
        }

        public static void AddSwaggerOpenApi(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddSwaggerGen(setupAction =>
            {
                var provider = serviceCollection.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    setupAction.SwaggerDoc(description.GroupName, new OpenApiInfo
                    {
                        Title = configuration[$"{Constants.ApplicationSectionName}:ApplicationName"],
                        Version = description.GroupName,
                        Contact = new OpenApiContact()
                        {
                            Email = configuration[$"{Constants.ApplicationSectionName}:AuthorEmail"],
                            Name = configuration[$"{Constants.ApplicationSectionName}:AuthorName"],
                            Url = new Uri(configuration[$"{Constants.ApplicationSectionName}:ContactWebsite"])
                        },
                        License = new OpenApiLicense()
                        {
                            Name = configuration[$"{Constants.ApplicationSectionName}:LicenceName"],
                            Url = new Uri(configuration[$"{Constants.ApplicationSectionName}:LicenseDetail"])
                        }
                    });
                }

                setupAction.OperationFilter<RemoveVersionParameterFilter>();
                setupAction.DocumentFilter<ReplaceVersionWithExactValuePathFilter>();
                setupAction.EnableAnnotations();

                #region Bearer Token

                setupAction.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "Input your Bearer token in this format - Bearer token to access this API",
                });

                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                        }, new List<string>()
                    },
                });

                #endregion Bearer Token

                var xmlCommentsFile = "Bilbayt.Homework.Api.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
                setupAction.IncludeXmlComments(xmlCommentsFullPath);
            });

            serviceCollection.AddSwaggerGenNewtonsoftSupport();
        }

        public static void AddController(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                options.SerializerSettings.Converters.Add(new StringEnumConverter());
            });
        }

        public static void AddVersion(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

            serviceCollection.AddVersionedApiExplorer();
        }

        public static void AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection($"{Constants.JwtSettingsSectionName}"));
            services.Configure<MongoDbSettings>(configuration.GetSection($"{Constants.MongoDbSettingsSectionName}"));
        }
    }
}