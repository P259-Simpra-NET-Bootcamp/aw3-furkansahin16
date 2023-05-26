namespace SimpraApi.Service;

public class Startup
{
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration) => Configuration = configuration;
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(opt =>
        {
            opt.Filters.Add<ValidationFilter>();
        });
        services.AddHttpContextAccessor();
        services
            .AddCustomSwaggerService()
            .AddApplicationServices()
            .AddPersistanceServices(Configuration);
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if(env.IsDevelopment()) app.UseDeveloperExceptionPage();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.DefaultModelExpandDepth(-1);
            c.SwaggerEndpoint("/swagger/v3/swagger.json", "Simpra");
            c.DocumentTitle = "Simpra Api";
        });

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}