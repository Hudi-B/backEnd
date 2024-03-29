
using LibraryAPIv2.Models;
using LibraryAPIv2.Repositories;

namespace LibraryAPIv2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<LibraryV2Context>();

            // Add services to the container.
            builder.Services.AddScoped<INationalityInterface, NationalityService> ();
            builder.Services.AddScoped<IBookInterface, BookService> ();
            builder.Services.AddScoped<IAuthorInterface, AuthorService>();
            builder.Services.AddScoped<IEmailService, EmailService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
