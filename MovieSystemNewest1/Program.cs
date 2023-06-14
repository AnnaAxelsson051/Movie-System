
using System;
using System.Reflection.Metadata;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using MovieSystemNewest1.Data;
using MovieSystemNewest1.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
                var userGenre = from UserGenre in context.UserGenre
                                select new
                                {
                                    UserGenre.User.Id,
                                    UserGenre.Genre.Title
                                };

                return await userGenre.Where(UserGenre => UserGenre.Id == Id).ToListAsync();
            })
            .WithName("/Get/GenrebyUserId");

            //Getting movies for specific user
            app.MapGet("/Get/UserMovie/", async (int Id, DataContext context) =>
            {
                var userMovie = from UserGenre in context.UserGenre
                                select new
                                {
                                    UserGenre.User.Id,
                                    UserGenre.Movie
                                };

                return await userMovie.Where(UserGenre => UserGenre.Id == Id).ToListAsync();
            })
            .WithName("GetMoviebyUserId");


            //Getting rating for specific user and movie

            app.MapGet("/Get/MoviesRating/", async (int Id, DataContext context) =>
            {
                var movieRating = from UserGenre in context.UserGenre
                                  select new
                                  {
                                      UserGenre.User.Id,
                                      UserGenre.Movie,
                                      UserGenre.Rating
                                  };

                return await movieRating.Where(UserGenre => UserGenre.Id == Id).ToListAsync();
            })
            .WithName("GetMovieRatingbyUserId");

            //Add rating from a specific user on a specific movie 

            app.MapPost("/Post/AddRating/", async (DataContext context, int userId, int rating, string movie) =>
            {
                var updateRows = await context.UserGenre.Where(UserGenre => UserGenre.UserId == userId).Where(x => x.Movie == movie)
                .ExecuteUpdateAsync(updates =>
                updates.SetProperty(UserGenre => UserGenre.Rating, rating));

                return updateRows == 0 ? Results.NotFound() : Results.NoContent();
            })
               .WithName("PostRatingByUserIdAndMovieId");

            app.Run();
        }
    }
}