using BusinessLayer.Interface;
using BusinessLayer.Service;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();




//Logger
builder.Logging.ClearProviders();//clearing all the pre defined outputs of logger
builder.Logging.AddConsole();//logs to the console
builder.Logging.AddDebug();//loogs to the debug console window

builder.Services.AddControllers();
//Adding services of business layer
builder.Services.AddScoped<IGreetingBL, GreetingBL>();
//Adding services of repository layer
builder.Services.AddScoped<IGreetingRL, GreetingRL>();

//Add swagger to the container
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();//using Swagger
    app.UseSwaggerUI();// responsible for colorfullness
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
