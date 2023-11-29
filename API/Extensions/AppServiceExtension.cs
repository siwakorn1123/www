using System;
using System.Text;
using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions;

public static class AppServiceExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration conf)
    {
        services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(conf.GetConnectionString("SQLiteConnection"));
}
);
        services.AddCors();
        services.AddScoped<ITokenService, TokenService>();


        return services;

    }
}