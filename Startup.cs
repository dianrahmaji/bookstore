using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Bookstore.Data;
using Bookstore.Repository;

namespace Bookstore
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<BookstoreContext>(options => options.UseSqlServer("Server=.;Database=Bookstore;User Id=SA;Password=Rasenshuriken123"));
      services.AddControllersWithViews();
#if DEBUG
      services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
      services.AddScoped<BookRepository, BookRepository>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseStaticFiles();

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapDefaultControllerRoute();
        // endpoints.MapControllerRoute(
        //   name: "Default",
        //   pattern: "{controller=Home}/{action=Index}/{id?}"
        // );
      });
    }
  }
}
