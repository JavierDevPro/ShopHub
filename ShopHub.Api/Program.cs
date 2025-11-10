using Microsoft.EntityFrameworkCore;
using ShopHub.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// ======================
//  Database
var connection = builder.Configuration.GetConnectionString("ConnectionDefault");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connection, MySqlServerVersion.AutoDetect(connection)));
// ======================


// ======================
// App Building
var app = builder.Build();

// ======================
// Middlewares Look at the correct order
app.UseHttpsRedirection();


// ======================
app.Run();

