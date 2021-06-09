using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace SchlauHaus.WebApi.Extensions
{
    internal static class ServiceExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAndConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options
                    .AddPolicy("CorsPolicy",
                        builder => builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
            });

            return services;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAndConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "SchlauHaus.WebApi", Version = "v1"});
            });

            return services;
        }   
    }
}