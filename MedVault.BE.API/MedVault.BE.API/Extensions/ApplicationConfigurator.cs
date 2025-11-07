using MedVault.BE.API.Middleware;
using MedVault.BE.Common.Constants;

namespace MedVault.BE.API.Extensions
{
    public static class ApplicationConfigurator
    {
        public static void RegisterServices(WebApplicationBuilder builder)
        {
            // Database
            builder.AddDatabase();

            // Add services to the container.
            builder.AddInternalServices();

            // Middleware registrations
            builder.AddMiddlewareServices();

            // Application-level services & repositories
            builder.AddApplicationServices();

            // 3rd-party services (Mapping)
            builder.AddExternalServices();

            // Authentication & Authorization
            builder.AddJwtAuthentication();
            builder.AddAuthorizationPolicies();

            // Swagger / OpenAPI (last)
            builder.AddSwagger();
        }

        public static void Configure(WebApplication app)
        {
            // Exception middleware comes first
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();

            // CORS (before authentication & authorization)
            app.UseCors(SystemConstant.CORS_POLICY_NAME);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}