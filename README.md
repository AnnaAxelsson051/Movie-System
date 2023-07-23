# MOVIE SYSTEM SERVER

This is the back end part of a movie system application built in C#, ASP.NET CORE Web API, Entity Framework and Azure Datastudio that interacts with a local database as well as with an external API - The Movie Database (TMDB). The application acts as a server to a [Movie System Client](https://github.com/AnnaAxelsson051/Movie-System-Client).
Users can add new movies with specific genres to the database, add likes to genres and ratings to movies. Its possible to retrieve personal information about the users in the database, to retrieve all the genres a specific user has liked as well as all the movies a user has added and ratings for these movies. Its also possible for users to get new movie suggestions based on a specific genre from an external API.

---

## Technologies used

- C#
- ASP.NET CORE Web API
- Entity Framework
- Azure Datastudio
- Postman
- Swagger
- Code first
- External TheMovieDBs API
- Docker

---

## Instructions

Open the project in your IDE / Visual Studio. Add an appsettings.json file with a [connection string](https://www.connectionstrings.com/) suitable for your system.
```
    {
  "ConnectionStrings": {
    "DefaultConnection": "<Your connection string>"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```

Install dotnet tools:
```
dotnet tool install --global dotnet-ef
```

Navigate to the project folder and create migrations:
```
dotnet ef migrations add InitialCreate
```

Create database and schema from the migration:
```
dotnet ef database update
```

Run the program inside Visual Studio.