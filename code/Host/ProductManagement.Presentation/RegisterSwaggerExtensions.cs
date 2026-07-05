//using Microsoft.OpenApi.Models;

//namespace ProductManagement.Presentation
//{
//    public static class RegisterSwaggerExtensions
//    {
//        public static IServiceCollection RegisterSwagger(this IServiceCollection services, string appName)
//        {
//            services.AddSwaggerGen(c =>
//            {
//                c.SwaggerDoc("v1", new OpenApiInfo { Title = $"{appName} - V1", Version = "v1", Description = "User Side" });
//                //c.SwaggerDoc("v2", new OpenApiInfo { Title = $"{appName} - V2", Version = "v2" });
//                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.FirstOrDefault());
//                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//                {
//                    Name = "Authorization",
//                    Type = SecuritySchemeType.ApiKey,
//                    Scheme = "Bearer",
//                    BearerFormat = "JWT",
//                    In = ParameterLocation.Header,
//                    Description = "JWT Authorization header using the Bearer scheme."
//                });
//                c.AddSecurityRequirement(new OpenApiSecurityRequirement
//                {{
//                    new OpenApiSecurityScheme
//                    {
//                        Reference = new OpenApiReference
//                        {
//                            Type = ReferenceType.SecurityScheme,
//                            Id = "Bearer"
//                        }
//                    },
//                    Array.Empty<string>()}
//                });

//                // Disable default grouping by controller
//                c.DocInclusionPredicate((_, _) => true);
//            });
//            return services;
//        }
//    }
//}
