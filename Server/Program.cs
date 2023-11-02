using BlazorApp1santa.Server.Data;
using BlazorApp1santa.Shared;

namespace BlazorApp1santa
{
    public class Program
    {

        public static async Task Main(string[] args)
        {

            using (var santasdatabaseContext = new SantasdatabaseContext())
            {
                #region Inserting Persons
                var persons1 = new Person()
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Santa",
                    LastName = "Clause"
                };
                
                
                var persons2 = new Person()
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = "Elin",
                    LastName = "Thim"
                };

                santasdatabaseContext.Add(persons1);
                santasdatabaseContext.Add(persons2);

                await santasdatabaseContext.SaveChangesAsync();

                #endregion

            }


            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }

}
