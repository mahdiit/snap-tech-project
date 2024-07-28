using SnappTech.Persistence;
using SnappTech.Infrastructure;
using SnappTech.Application;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.DependencyInjection;

namespace snap_tech_project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //builder.Services.AddAuthentication(opt =>
            //{
            //    opt.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    opt.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            //})
            //    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, opt =>
            //    {
            //        opt.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //        opt.Authority = "https://localhost:5001";
            //        opt.ClientId = "interactive";
            //        opt.ClientSecret = "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0";
            //        opt.ResponseType = "code";
            //        opt.GetClaimsFromUserInfoEndpoint = true;
            //    });

            builder.Services.ConfigurePersistence(builder.Configuration);
            builder.Services.ConfigureInfrastructure(builder.Configuration);
            builder.Services.ConfigureApplication(builder.Configuration);

            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddProblemDetails();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseRouting();
            //app.UseAuthentication();
            app.UseAuthorization();
            app.UseExceptionHandler();
            app.MapControllers();

            app.Run();
        }
    }
}
