using Microsoft.EntityFrameworkCore;
using Storyteller.Api;
using Storyteller.Data;
using Storyteller.Host.Extensions;
using Storyteller.Host.Filters;

namespace Storyteller.Host
{

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<StorytellerContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetSection("DatabaseContext:ConnectionString").Value);
            });

            services.AddCustomAuthentication(Configuration);

            services.AddEndpointsApiExplorer();

            services.AddCustomSwagger(Configuration);

            services.AddControllers(opt =>
            {
                opt.Filters.Add(typeof(HandlerResultFilter));
            });

            services.ConfigureApiServices(Configuration);
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
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

