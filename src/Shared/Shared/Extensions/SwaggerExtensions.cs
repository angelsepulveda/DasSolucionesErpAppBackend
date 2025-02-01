using Microsoft.OpenApi.Models;

namespace Shared.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            // Created the Swagger document
            c.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Version = "Version .Net 9.0.x",
                    Title = "Api Sistema ERP Das Soluciones",
                    Description = "Api para sistema erp para la gestion de empresas",
                    Contact = new OpenApiContact
                    {
                        Name = "Ing. Angel Sepulveda Sepulveda",
                        Url = new Uri("https://www.linkedin.com/in/angelsepulvedas/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "For capacitation and reference use.",
                        Url = new Uri("https://example.com/license")
                    }
                }
            );

            foreach (
                string name in Directory.GetFiles(
                    AppContext.BaseDirectory,
                    "*.XML",
                    SearchOption.TopDirectoryOnly
                )
            )
            {
                c.IncludeXmlComments(filePath: name);
            }

            // second form to give Authorization with out whrite the world Bearer
            /*OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme()
            {
                Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT" // Optional
            };

            OpenApiSecurityRequirement securityRequirement = new OpenApiSecurityRequirement
              {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "bearerAuth"
                            }
                        },
                        new string[] {}
                    }
                }; */
            //c.AddSecurityDefinition("bearerAuth", securityScheme);
            //c.AddSecurityRequirement(securityRequirement);
        });

        return services;
    } // end method AddSwagger
}
