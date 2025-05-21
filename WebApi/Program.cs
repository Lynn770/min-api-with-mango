using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);
var movieDatabaseConfigSection = builder.Configuration.GetSection("DatabaseSettings");
builder.Services.Configure<DatabaseSettings>(movieDatabaseConfigSection);
var app = builder.Build();

app.MapGet("/", () => "Hello World!\r\n");


app.MapGet("/check", async (Microsoft.Extensions.Options.IOptions<DatabaseSettings> options) =>
{
    try
    {
        var mongoClient = new MongoClient(options.Value.ConnectionString);
        var databases = await mongoClient.ListDatabaseNamesAsync();
        List<string> databaseNames = await databases.ToListAsync();
        string responseString = "MongoDB connection ok: " + string.Join(", ", databaseNames);
        return responseString;
    }
    catch (Exception ex)
    {
        return $"Error fetching databases: {ex.Message}";
    }
});

app.Run();

 // Insert Movie
 // Wenn das übergebene Objekt eingefügt werden konnte,
 // wird es mit Statuscode 200 zurückgegeben.
 // Bei Fehler wird Statuscode 409 Conflict zurückgegeben.
 app.MapPost("/api/movies", (Movie movie) =>
 {
 throw new NotImplementedException();
 });
 // Get all Movies
 // Gibt alle vorhandenen Movie-Objekte mit Statuscode 200 OK zurück.
 app.MapGet("api/movies", () =>
 {
 throw new NotImplementedException();
 });
 // Get Movie by id
 // Gibt das gewünschte Movie-Objekt mit Statuscode 200 OK zurück.
 // Bei ungültiger id wird Statuscode 404 not found zurückgegeben.
  app.MapGet("api/movies/{id}", (string id) =>
   {
        if(id == "1")
            {
            var myMovie = new Movie()
            {
                Id = "1",
                Title = "Asterix und Obelix",
            };
            return Results.Ok(myMovie);
        }
        else
        { 
            return Results.NotFound();
        }
    });
 // Update Movie
 // Gibt das aktualisierte Movie-Objekt zurück.
 // Bei ungültiger id wird Statuscode 404 not found zurückgegeben.
 app.MapPut("/api/movies/{id}", (string id, Movie movie) =>
 {
 throw new NotImplementedException();
 });
 // Delete Movie
 // Gibt bei erfolgreicher Löschung Statuscode 200 OK zurück.
 // Bei ungültiger id wird Statuscode 404 not found zurückgegeben.
 app.MapDelete("api/movies/{id}", (string id) =>
 {
 throw new NotImplementedException();
 });