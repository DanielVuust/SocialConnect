using Microsoft.EntityFrameworkCore;
using SocialConnect.Endpoints;
using SocialConnect.Model;

namespace SocialConnect
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddDbContext<SocialConnectContext>(x => 
                x.UseSqlServer("Server=DESKTOP-9CPP9JJ;Database=SocialConnect;Trusted_Connection=True;TrustServerCertificate=True"));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.CreateMemberComment();

            app.Run();
        }
    }
}