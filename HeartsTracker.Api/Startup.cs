using AutoMapper;
using HeartsTracker.Api.Services;
using HeartsTracker.Api.Services.Interfaces;
using HeartsTracker.Dal.Classes;
using HeartsTracker.Dal.Contexts;
using HeartsTracker.Dal.Repositories;
using HeartsTracker.Dal.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace HeartsTracker.Api
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup( IConfiguration configuration )
		{
			Configuration = configuration;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices( IServiceCollection services )
		{
			string connectionString = Configuration.GetConnectionString( "HeartsTrackerDb" );
			services.AddDbContext<HeartsTrackerContext>( options => options.UseSqlServer( connectionString, b => b.MigrationsAssembly( "HeartsTracker.Dal" ) ) );
			services.AddAutoMapper( );
			services.AddMvc( );

			InjectServices( services );
			InjectRepositories( services );

			services.AddSwaggerGen( c =>
			{
				c.SwaggerDoc( "v1", new Info { Title = "Hearts Tracker API", Version = "v1" } );
			} );
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure( IApplicationBuilder app, IHostingEnvironment env, HeartsTrackerContext context )
		{
			app.UseMvc( routes =>
			{
				routes.MapRoute( "default", "api/{controller=Home}/{action=Index}/{id?}" );
			} );

			DbInitializer.Initialize( context );

			// Enable middleware to serve generated Swagger as a JSON endpoint.
			app.UseSwagger( );

			// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
			// specifying the Swagger JSON endpoint.
			app.UseSwaggerUI( c =>
			{
				c.SwaggerEndpoint( "/swagger/v1/swagger.json", "My API V1" );
			} );
		}

		private static void InjectServices( IServiceCollection services )
		{
			services.AddScoped<IPlayerService, PlayerService>( );
		}

		private static void InjectRepositories( IServiceCollection services )
		{
			services.AddScoped<IPlayerRepository, PlayerRepository>( );
		}
	}
}
