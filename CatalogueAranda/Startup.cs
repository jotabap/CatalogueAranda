
using CatalogueAranda.Entity.Entities;
using CatalogueAranda.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace CatalogueAranda
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureSevices(IServiceCollection services)
        {
            services.AddDbContext<CatalogoArandaContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
           c.SwaggerDoc("v1", new OpenApiInfo
           {
               Version="v1",
               Title = "Catalogue Aranda API",
               Description="Api desarrollada en .NET 6",
               Contact= new OpenApiContact
               {
                   Name="John Batista",
                   Email="johnk_batista@yahoo.com"
               }

           }));
            services.AddScoped<ProductService>();
            services.AddAutoMapper(typeof(Startup));

            services.AddMvc()
               .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
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
