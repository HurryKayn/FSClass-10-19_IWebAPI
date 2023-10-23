using WebApi.Models;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //-- Servizion per getione JSON
            builder.Services.AddControllersWithViews().AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();

            //---Dependency Injection
            builder.Services.AddSingleton<IRepository, Repository>();
            //--- 
                                    

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("Home/Error");
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                );

            app.Run();
        }
    }
}