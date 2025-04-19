namespace book.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // add services

            builder.Services.AddControllers();

            builder.Services.AddCors(option =>
            {
                option.AddPolicy("MyCors", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
            var app = builder.Build();

            app.UseCors("MyCors");
            // add mapping
            app.MapControllers();

            app.MapGet("/", () =>
            {
                return Results.Redirect("/api/books");
            });

            app.Run();
        }
    }
}
