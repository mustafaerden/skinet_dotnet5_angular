using API.Extensions;
using API.Helpers;
using API.Middleware;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API
{
  public class Startup
  {
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddControllers();
      services.AddAutoMapper(typeof(MappingProfiles));
      services.AddDbContext<StoreContext>(x =>
        x.UseSqlite(_configuration.GetConnectionString("DefaultConnection")));

      // Burasi kalabalik olmasin diye bazi servisleri Extensions/ApplicationServicesExtension icindeki AddApplicationServices icine tasidik;
      services.AddApplicationServices();
      services.AddSwaggerDocumentation();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseMiddleware<ExceptionMiddleware>();

      app.UseSwaggerDocumentation();

      // if (env.IsDevelopment())
      // {
      //   app.UseDeveloperExceptionPage(); // We wrote our own Exception Middleware!!
      //   app.UseSwagger();
      //   app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
      // }

      // when we have a request to our api server and if we dont have a match of that request(url), it will hit this middleware and it will redirect to ErrorController
      app.UseStatusCodePagesWithReExecute("/errors/{0}");

      // app.UseHttpsRedirection();

      app.UseRouting();

      app.UseStaticFiles();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
