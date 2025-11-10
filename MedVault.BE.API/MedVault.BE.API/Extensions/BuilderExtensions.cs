using MedVault.BE.API.Configuration;
using MedVault.BE.API.Middleware;
using MedVault.BE.API.Response;
using MedVault.BE.Common.Constants;
using MedVault.BE.Common.Helpers;
using MedVault.BE.Data.Context;
using MedVault.BE.Data.IRepositories;
using MedVault.BE.Data.Repositories;
using MedVault.BE.Services.IServices;
using MedVault.BE.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;
using static MedVault.BE.Common.Enums.Enums;

namespace MedVault.BE.API.Extensions
{
    public static class BuilderExtensions
    {
        public static void AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(SwaggerConstants.API_VERSION, new OpenApiInfo
                {
                    Title = SwaggerConstants.SWAGGER_API_NAME,
                    Version = SwaggerConstants.API_VERSION
                });

                options.AddSecurityDefinition(SwaggerConstants.SECURITY_SCHEME, new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = SwaggerConstants.SECURITY_SCHEME_DESCRIPTION,
                    Name = SwaggerConstants.SECURITY_SCHEME_NAME,
                    Type = SecuritySchemeType.Http,
                    BearerFormat = SwaggerConstants.SECURITY_SCHEME_FORMAT,
                    Scheme = SwaggerConstants.SECURITY_SCHEME
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = SwaggerConstants.SECURITY_SCHEME
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        public static void AddDatabase(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<MedVaultDbContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString(SystemConstant.CONNECTION_STRING_NAME)));
        }

        public static void AddInternalServices(this WebApplicationBuilder builder)
        {
            // CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(SystemConstant.CORS_POLICY_NAME, policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            // Suppress default model validation response
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            // Enforce lowercase URLs
            builder.Services.AddRouting(options => options.LowercaseUrls = true);

            // Controllers & API explorer
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            // Caching & Context
            builder.Services.AddHttpContextAccessor();
        }

        public static void AddApplicationServices(this WebApplicationBuilder builder)
        {
            //Common services
            builder.Services.AddSingleton<IResponseService, ResponseService>();
            builder.Services.AddScoped<AuthenticationHelper>();

            // Application services            
            builder.Services.AddScoped<IHospitalService, HospitalService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IPatientProfileService, PatientProfileService>();
            builder.Services.AddScoped<IDoctorProfileService, DoctorProfileService>();
            builder.Services.AddScoped<IDashboardService, DashboardService>();

            // Repositories
            builder.Services.AddScoped<IHospitalRepository, HospitalRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IOtpRepository, OtpRepository>();
            builder.Services.AddScoped<IPatientProfileRepositories, PatientProfileRepositories>();
            builder.Services.AddScoped<IDoctorProfileRepositories, DoctorProfileRepositories>();
            builder.Services.AddScoped<IPatientHistoryRepository, PatientHistoryRepository>();
            builder.Services.AddScoped<IReminderRepository, ReminderRepository>();
        }

        public static void AddExternalServices(this WebApplicationBuilder builder)
        {
            // mapster configuration for object mapping
            MapsterConfig.RegisterMappings();
        }

        public static void AddMiddlewareServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ExceptionMiddleware>();
        }

        public static void AddJwtAuthentication(this WebApplicationBuilder builder)
        {
            var key = builder.Configuration[SystemConstant.JWT_AUTHKEY] ?? string.Empty;

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void AddAuthorizationPolicies(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy =>
                    policy.RequireClaim(ClaimTypes.Role, ((int)UserRole.Admin).ToString()));

                options.AddPolicy("DoctorOnly", policy =>
                    policy.RequireClaim(ClaimTypes.Role, ((int)UserRole.Doctor).ToString()));

                options.AddPolicy("UserOnly", policy =>
                    policy.RequireClaim(ClaimTypes.Role, ((int)UserRole.User).ToString()));

                options.AddPolicy("UserOrDoctor", policy =>
                    policy.RequireClaim(ClaimTypes.Role,
                        ((int)UserRole.User).ToString(),
                        ((int)UserRole.Doctor).ToString()));
            });
        }

    }
}