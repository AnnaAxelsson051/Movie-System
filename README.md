# MOVIE SYSTEM SERVER

This is a backend application in C# built with ASP.NET CORE Web API, Entity Framework and Azure Datastudio that interacts with a local database as well as with an external API - The Movie Database (TMDB). The application acts as a server to a [Movie System Client](https://github.com/AnnaAxelsson051/Movie-System-Client) I have built and makes it possible to retrieve and modify information in the database regarding users, genres and movies as well as offer users movie suggestions based on genre preferences via the external TMDB-API.

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

---

## API Requests and return data
|**Type**|**API-request**|**Input**|**Return data**|
|-|-|-|-|
|GET|/Get/User|n/a|Returns information about all the users in the Database - Id, Name and Email|
|GET|/Get/UserGenre|?Id=4|Returns all genres a specified user has liked|
|GET|/Get/UserMovie|?Id=4|Returns all the movies a user has added to the DB|
|GET|/Get/MoviesRating|?Id=4|Returns all movies and their corresponding ratings given by a specific user|
|POST|/Post/AddMovie|?userId=4&genreId=28&movie=Terminator|Enables the addition of new movies each with specified genre to the DB|
|POST|/Post/AddGenre|?userId=4&genreId=28|Enables a user to like new genres|
|POST|/Post/AddRating|?userId=4&rating=5&movie=Terminator|Enables a user to add a rating to a movie|
|GET|/Get/Recommendations|?genreTitle=Action|Retrieving new movie recommendations from an external API based on a specified genre|