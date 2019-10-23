using AutoMapper;
using Ireckonu.Abstractions;
using Ireckonu.Api.Parsers;
using Ireckonu.IO.Json;
using Ireckonu.IO.Sql;
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
      services.AddTransient<IWriter<Product>, JsonWriter<Product>>();
      services.AddTransient<IWriter<Product>, ProductSqlWriter>();
      services.AddTransient<IProductMapper, ProductMapper>();
      var mappingConfig = new MapperConfiguration(mc =>
      {
        mc.AddProfile(new IreckonuProfile());
      });
      var mapper = mappingConfig.CreateMapper();
      services.AddSingleton(mapper);
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
