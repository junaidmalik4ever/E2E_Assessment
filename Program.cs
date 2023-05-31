using E2EwebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace E2EwebAPI.Models
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string policyName = "myPolicy";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddTransient<IHotelComponent, HotelComponent>();
            builder.Services.AddCors((options) =>
            {
                options.AddPolicy(policyName, options =>
                {
                    options.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                });
            });
            builder.Services.AddControllers();
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();
            app.UseCors();

            app.MapGet("/Menu", ([FromServices] HotelComponent com) =>
            {
                return com.GetMenu();
            });
            app.MapGet("/Menu{Id}", (int Id, IHotelComponent com) =>
            {
                return com.GetItem(Id);
            });
            app.MapPost("/Menu", (DBHotel Item, IHotelComponent com) =>
            {
                com.AddItem(Item);
            });

            app.Run();
        }
    }
}