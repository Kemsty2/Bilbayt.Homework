using System;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text;
using Bilbayt.Homework.Api.Domain;
using Bilbayt.Homework.Api.Domain.Common;
using Bilbayt.Homework.Api.Domain.Entities;
using Bilbayt.Homework.Api.Domain.Settings;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using SendGrid.Extensions.DependencyInjection;

namespace Bilbayt.Homework.Api.Service
{
    public static class DependencyInjection
    {
        public static void AddServiceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            // or you can use assembly in Extension method in Infra layer with below command
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddSendGrid(options =>
            {
                options.ApiKey = configuration[$"{Constants.SendGridSettingsSectionName}:ApiKey"];
            });
        }

        public static void AddAuthenticationService(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection(Constants.JwtSettingsSectionName).Get<JwtSettings>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                    ValidAudience = jwtSettings.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };

                x.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = c =>
                    {
                        c.NoResult();
                        c.Response.StatusCode = 401;
                        c.Response.ContentType = "application/json";

                        const string result = "You are not Authorized";
                        return c.Response.WriteAsync(result);
                    },
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        if (!context.Response.HasStarted)
                        {
                            context.Response.StatusCode = 401;
                            context.Response.ContentType = "application/json";
                        }
                        const string result = "You are not Authorized";
                        return context.Response.WriteAsync(result);
                    },
                    OnForbidden = context =>
                    {
                        context.Response.StatusCode = 403;
                        context.Response.ContentType = "application/json";
                        const string result = "You are not authorized to access this resource";
                        return context.Response.WriteAsync(result);
                    },
                };
            });
        }

        public static void AddClassMap(this IServiceCollection _)
        {
            BsonClassMap.RegisterClassMap<BaseEntity>(cm =>
            {
                cm.SetIsRootClass(true);
                cm.MapIdMember(c => c.Id).SetIdGenerator(StringObjectIdGenerator.Instance);
            });

            BsonClassMap.RegisterClassMap<User>(cm =>
            {
                cm.AutoMap();
                cm.MapMember(c => c.UserName).SetIsRequired(true);
                cm.MapMember(c => c.FullName).SetIsRequired(true);
                cm.MapMember(c => c.Password).SetIsRequired(true);
            });
        }
    }
}