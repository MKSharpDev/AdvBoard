using AdvBoard.ComponentRegistrator;
using AdvBoard.DataAccess;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AdvBoard.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AdvDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddApplicationServices();

            //builder.Services
            //    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(options =>
            //    {
            //        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
            //        options.SlidingExpiration = true;
            //        options.Events.OnSignedIn = context =>
            //        {
            //            return Task.CompletedTask;
            //        };
            //        options.Events.OnRedirectToAccessDenied = context =>
            //        {
            //            context.Response.StatusCode = 403;
            //            return Task.CompletedTask;
            //        };
            //        options.Events.OnRedirectToLogin = context =>
            //        {
            //            context.Response.StatusCode = 401;
            //            return Task.CompletedTask;
            //        };
            //        //options.SessionStore = new CustomTicketStore();
            //    });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("500f8598-2273-482b-a99f-77c9de5a321c"))
                    };

                    //options.Events = new JwtBearerEvents() 
                    //{ 
                    //    OnMessageReceived = 
                    //};
                    //"inn-cookies"
                }
                );
            builder.Services.AddAuthorization();

           var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}
