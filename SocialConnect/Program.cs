using Microsoft.EntityFrameworkCore;
using SocialConnect.Endpoints;
using SocialConnect.Model;
using SocialConnect.Repository.BulletinRepository;
using SocialConnect.Repository.MemberRepository;
using SocialConnect.Repository.UserCommentRepository;
using SocialConnect.Repository.UserRepository;
using SocialConnect.Services.BulletinService;
using SocialConnect.Services.MemberCommentService;
using SocialConnect.Services.MemberService;
using SocialConnect.Services.UserCommentService;
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

            //Member
            builder.Services.AddTransient<IMemberService, MemberService>();
            builder.Services.AddTransient<IMemberRepository, MemberRepository>();


            //Member comment
            builder.Services.AddTransient<IMemberCommentService, MemberCommentService>();
            builder.Services.AddTransient<IMemberCommentRepository, MemberCommentRepository>();

            //Bulletin
            builder.Services.AddTransient<IBulletinService, BulletinService>();
            builder.Services.AddTransient<IBulletinRepository, BulletinRepository>();


            builder.Services.AddDbContext<SocialConnectContext>(x => 
                x.UseSqlServer("Server=ZBC-E-CH-SKP011;Database=SocialConnect;Trusted_Connection=True;TrustServerCertificate=True"));
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