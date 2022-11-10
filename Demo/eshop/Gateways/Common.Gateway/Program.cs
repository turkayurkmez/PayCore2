using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddJsonFile("ocelot.json", false, true);
builder.Services.AddOcelot(builder.Configuration);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("allow", builder =>
    {
        builder.AllowAnyMethod();
        builder.AllowCredentials();
        builder.AllowAnyHeader();
        builder.SetIsOriginAllowed(x => true);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("allow");
app.UseAuthorization();

app.MapControllers();
await app.UseOcelot();
app.Run();