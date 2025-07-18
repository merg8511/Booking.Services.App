using Booking.Services.App.Extensions;
using Booking.Services.App.Middleware;
using Booking.Services.App.Modules.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Add services to container
builder.Services.AddApplicationService(builder.Configuration);
builder.Services.RegisterModules();

var app = builder.Build();

app.UseRouting();
app.MapEndpoints();

app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/errors/{0}");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors(x => x.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod());

app.UseHttpsRedirection();

app.Run();
