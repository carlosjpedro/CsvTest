using Ireckonu.Abstractions;
using Ireckonu.Api.Parsers;
using Ireckonu.IO.Json;
using Ireckonu.IO.Sql;
using Ireckonu.IO.Sql.Mappers;
using Ireckonu.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ireckonu.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.AddTransient<ICsvStreamParser<Product>, ProductCsvStreamParser>();
      services.AddTransient<IWriter<Product>>(x=>
        new JsonWriter<Product>(
          Configuration.GetSection("JsonConfig")["TargetFilePath"],
          Configuration.GetSection("JsonConfig")["TargetFilePrefix"]));
      services.AddTransient<IWriter<Product>, ProductSqlWriter>();
      services.AddTransient<IProductMapper, ProductMapper>();
      services.AddDbContext<IreckonuContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("IreckonuDatabase")));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();
      
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
