
using Stylehub.Infrastructure;

namespace Stylehub.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            IConfiguration configuration = builder.Configuration;
            builder.Services.AddControllers();
            
            builder.Services.AddOpenApi();
            builder.Services.AddInfrastructure(configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
