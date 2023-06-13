﻿
using Microsoft.EntityFrameworkCore;
using MovieSystemNewest1.Data;

namespace MovieSystemNewest1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Adding services to the container
            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configuring the HTTP request pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("corsapp");
            app.UseAuthorization();


            //Getting all users
            app.MapGet("/Get/User", async (DataContext context) =>
            {
                var user = context.User;
                return await user.ToListAsync();
            })
           .WithName("GetUser");

            //Getting genre for specific user
            app.MapGet("/Get/UserGenre/", async (int Id, DataContext context) =>
            {
                var userGenre = from userGenreItem in context.UserGenre
                                select new
                                {
                                    userGenreItem.User.Id,
                                    userGenreItem.Genre.Title
                                };

                return await userGenre.Where(userGenreItem => userGenreItem.Id == Id).ToListAsync();
            })
            .WithName("/Get/GenrebyUserId");


            app.Run();
        }
    }
}