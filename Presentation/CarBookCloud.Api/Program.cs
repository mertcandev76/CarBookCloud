using CarBookCloud.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Connection string'i çek
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Null kontrolü yapýlýyor 
if (string.IsNullOrEmpty(connectionString))
    throw new InvalidOperationException("DefaultConnection’ adlý connection string yapýlandýrýlmamýþ.");

// Application servislerini ekle (Persistence dahil)
builder.Services.AddApplicationServices(connectionString);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ----------------------
// HTTP PIPELINE
// ----------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();
