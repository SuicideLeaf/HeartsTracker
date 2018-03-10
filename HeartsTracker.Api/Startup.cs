using AutoMapper;
using HeartsTracker.Dal.Classes;
using HeartsTracker.Dal.Contexts;
using HeartsTracker.Dal.Entities;
using HeartsTracker.Dal.Entities.Interfaces;
using HeartsTracker.Dal.Repositories;
using HeartsTracker.Dal.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

			services.AddScoped<IPlayerRepository, PlayerRepository>( );

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure( IApplicationBuilder app, IHostingEnvironment env, HeartsTrackerContext context )
		{
			app.UseMvc( routes =>
			{
				routes.MapRoute( "default", "api/{controller=Home}/{action=Index}/{id?}" );
			} );

			DbInitializer.Initialize( context );
		}
	}
}
