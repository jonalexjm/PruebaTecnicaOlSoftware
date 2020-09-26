using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using OLSoftware.Infrastructure.Data;
using OLSoftware.Infrastructure.Data.Seed;
using OLSoftware.Core.Repositories;
using OLSoftware.Infrastructure.Repositories;

namespace OlSoftware.Api
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

            services.AddDbContext<OlsoftwareContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection"));
                //configuracion del servidor
            });

            services.AddTransient<SeedDb>();

            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProgramLanguageRepository, ProgramLanguageRepository>();
            services.AddScoped<IUserProjectRepository, UserProjectRepository>();
          //  services.AddScoped<IProgramLanguageRepository, ProgramLanguageRepository>();

            //evitar los loop
            services.AddMvc().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);



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
