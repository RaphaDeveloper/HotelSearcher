using Application.Hotels.UseCases;
using Application.Services;
using Domain;
using Domain.Hotels.Repositories;
using Domain.Hotels.Services;
using Domain.Hotels.UseCases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API
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
			services.AddScoped<IHotelAppService, HotelAppService>();
			services.AddScoped<IHotelService, HotelService>();
			services.AddScoped<IHotelRepository, HotelRepository>();

			services.AddScoped<IFindTheCheapestHotel, FindTheCheapestHotel>();
			services.AddScoped<IFindTheCheapestHotelApp, FindTheCheapestHotelApp>();

			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();
		}
	}
}
