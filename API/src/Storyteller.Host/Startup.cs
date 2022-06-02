
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Storyteller.Api;
using Storyteller.Data;
using Storyteller.Host.Filters;
using System.Text;

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

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "",
                    ValidAudience = "",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(""))
                };
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            
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

