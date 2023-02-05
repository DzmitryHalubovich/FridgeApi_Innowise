
namespace FridgeApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            FrigeApi.Infrastructure.Dependencies.ConfigureServices(builder.Configuration, builder.Services);

            builder.Services.AddControllers();
            // Add services to the container.
            builder.Services.AddAuthorization();

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

            app.UseHttpsRedirection();

            app.UseAuthorization();

            var summaries = new[]
            {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            var persons = new List<Person> 
            {
                new Person { Id = 1, Name = "Max" },
                new Person { Id = 2, Name = "Peter"},
                new Person { Id = 3, Name = "Fred"},
                new Person { Id = 4, Name = "Chester"}
            };

            app.MapGet("/weatherforecast", (HttpContext httpContext) =>
            {
                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();

            app.MapGet("/persons", (HttpContext httpContext) =>
            {
                return persons;
            })
            .WithName("GetPersons")
            .WithOpenApi();

            app.MapPut("/persons/put", (Person userData) => {

                // получаем пользовател€ по id
                var user = persons.FirstOrDefault(u => u.Id == userData.Id);
                // если не найден, отправл€ем статусный код и сообщение об ошибке
                if (user == null) return Results.NotFound(new { message = "ѕользователь не найден" });
                // если пользователь найден, измен€ем его данные и отправл€ем обратно клиенту

                user.Id = userData.Id;
                user.Name = userData.Name;
                return Results.Json(user);
            });

            app.MapDelete("/person/delete", (int id) =>
            {
                Person person = persons.FirstOrDefault(u => u.Id == id);

                if (person == null) return Results.NotFound(new { message = "ѕользователь не найден" });
                persons.Remove(person);
                return Results.Json(person);
            });

            app.MapGet("/person/Get", (int id) =>
            {
                Person person = persons.FirstOrDefault(u=>u.Id == id);
                if (person == null) return Results.NotFound(new { message = "ѕользователь не найден" });
                return Results.Json(person);
            });

            app.MapPost("/person/Put", (Person person) => {
                persons.Add(person);
                return persons;
            });


            app.MapControllers();

            app.Run();
        }


        
    }

     public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}