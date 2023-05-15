using Microsoft.EntityFrameworkCore;
using SocialConnect.Endpoints;
using SocialConnect.Model;
using SocialConnect.Repository.MemberRepository;
using SocialConnect.Repository.UserRepository;
using SocialConnect.Services.MemberService;
using SocialConnect.Services.UserService;

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

            builder.Services.AddTransient<IMemberService, MemberService>();
            builder.Services.AddTransient<IMemberRepository, MemberRepository>();

            builder.Services.AddDbContext<SocialConnectContext>(x => 
                x.UseSqlServer("Server=LAPTOP-DRMV9MFV;Database=SocialConnect;Trusted_Connection=True;TrustServerCertificate=True"));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapBulletinsEndpoints();
            app.MapUserEndpoints();

            app.CreateMemberComment();

            app.Run();
        }
    }
}