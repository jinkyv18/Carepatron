using api.Data;
using api.Service;
using api.Service.Contract;
using api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
//Use for MVC Controller for easy routing
services.AddControllers();

// cors
services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => builder
        .SetIsOriginAllowedToAllowWildcardSubdomains()
        .WithOrigins("http://localhost:3000")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .Build());
});

//Use to save data inMemory so we don't need to use SQL database. This is for testing purposes.
services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase(databaseName: "Test"));

services.AddScoped<DataSeeder>();
services.AddScoped<IClientRepository, ClientRepository>();
services.AddScoped<IClientService, ClientService>();
//Use for adding scope of Autommaper, so the DTO and entity is easy to map.
services.AddAutoMapper(typeof(CommonMappingProfile));
services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Remove this part and use the MVC Controller for easy routing.
//app.MapGet("/clients", async (IClientRepository clientRepository) =>
//{
//    return await clientRepository.Get();
//})
//.WithName("get clients");

app.UseCors();

//Seed
using (var scope = app.Services.CreateScope())
{
    var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();

    //Create initial data on datacontext
    dataSeeder.Seed();
}

// run app
app.Run();