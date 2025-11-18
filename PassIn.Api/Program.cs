using PassIn.Api.Filters;
using PassIn.Application.UseCases.Events.GetById;
using PassIn.Application.UseCases.Events.Register;
using PassIn.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<GetEventByIdUseCase>();
builder.Services.AddScoped<RegisterEventUseCase>();
builder.Services.AddSingleton<PassInDbContext>();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
