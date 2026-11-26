using AndelEnergiHovedopgave.Interfaces;
using AndelEnergiHovedopgave.Services;

var builder = WebApplication.CreateBuilder(args);

// Apply the connection strings
var connectionStringName = builder.Environment.IsDevelopment() ? "TestDatabase" : "RegularDatabase";

var connectionString = builder.Configuration.GetConnectionString(connectionStringName)
    ?? throw new InvalidOperationException($"Connection string '{connectionStringName}' is not configured.");

//builder.Services.AddSingleton<ICustomerEventService, CustomerEventService>();
//builder.Services.AddSingleton<IDataQualityErrorService, DataQualityErrorService>();
builder.Services.AddSingleton<ICustomerEventService>(_ => new CustomerEventService(connectionString));
builder.Services.AddSingleton<IDataQualityErrorService>(_ => new DataQualityErrorService(connectionString));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
