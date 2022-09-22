using DemoLib;
using DemoLib.DataAccess;
using DemoLib.EventService;
using MediatR;
using NuGet.Protocol.Core.Types;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICommandSender, MessageDispatcher>();
builder.Services.AddSingleton<IEventPublisher, MessageDispatcher>();
builder.Services.AddSingleton<IEventStore, EventStore>();
builder.Services.AddSingleton(typeof(IRepository<>), typeof(EventRepository<>));
builder.Services.AddSingleton<IDemoDataAccess, DemoDataAccess>();
builder.Services.AddMediatR(typeof(DemoLibMediatREntryPoint).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();