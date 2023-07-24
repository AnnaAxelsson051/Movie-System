# MOVIE SYSTEM SERVER

## Description

This is the back end part of a movie system application built in C#, ASP.NET CORE Web API, Entity Framework and Azure Datastudio that interacts with a local database as well as with an external API - The Movie Database (TMDB). The application acts as a server to a [Movie System Client](https://github.com/AnnaAxelsson051/Movie-System-Client).
Users can add new movies with specific genres to the database, add likes to genres and ratings to movies. Its possible to retrieve personal information about the users in the database, to retrieve all the genres a specific user has liked as well as all the movies a user has added and ratings for these movies. Its also possible for users to get new movie suggestions based on a specific genre from an external API.

---

## Technologies used:

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

## Code structure

The application consists of three model classes: User, Genre and UserGenre that handles model data. A Program class where API-calls are made and a Data Context class for interacting with the database.   

## API Requests and return data
|**Type**|**API-request**|**Input**|**Return data**|
|-|-|-|-|
|GET|/Get/User|n/a|Returns information about all the users in Db - Id, Name and Email|
|GET|/Get/UserGenre|?Id=4|Returns all genres a specified user has liked|
|GET|/Get/UserMovie|?Id=4|Returns all the movies a user has added to Db|
|GET|/Get/MoviesRating|?Id=4|Returns all movies and their corresponding ratings given by a specific user|
|POST|/Post/AddMovie|?userId=4&genreId=28&movie=Terminator|Enables the addition of new movies each with specified genre to Db|
|POST|/Post/AddGenre|?userId=4&genreId=28|Enables a user to like new genres|
|POST|/Post/AddRating|?userId=4&rating=5&movie=Terminator|Enables a user to add a rating to a movie|
|GET|/Get/Recommendations|?genreTitle=Action|Retrieves new movie recommendations from external API based on specific genre|

---

## Personal reflection

When it comes to the architecture of this application minimal API was used since its generally a smoother option for a not very large scale application. If I was building a larger application I would go with an MVC architecture since it provides much more structure as the code gets extensive and increasingly complex. Regarding database design Code first was used over Model and Database first due to it being more intuitive and allowing for application development without to much focus on database tables. In the code I favour using declarative names for variables in the api calls, this may contrast some developers preferences and I can also see how shorter more anonymous names can have its advantages as well. 

I would enjoy expanding this application further, adding viewable movie trailers, user chats or comment ability on movies. This would require said MVC architecture, log in functionality and security implementations amongst other things. 

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