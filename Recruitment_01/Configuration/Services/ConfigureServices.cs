

using Microsoft.Extensions.DependencyInjection;
using Recruitment.infrastructure.Data;
using Recruitment.infrastructure.Data.IRepository;
using Recruitment.infrastructure.Data.Repository;
using Recuritment.Application.IServices;
using Recuritment.Application.Services;

namespace Recruitment.Configuration;
public static class ApplicationServiceExtension
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<DbContext>();
        //Auto Mapper
       

        //Services
        services.AddScoped<IJobServices, JobServices>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<JWT_FILE>();



        //Repository
        services.AddScoped<IJobs ,Jobs>();
        services.AddScoped<IuserRepo, UserRepo>();




        return services;
    }
}

