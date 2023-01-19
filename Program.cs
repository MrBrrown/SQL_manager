using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Vika_Automate.sakila;
using Vika_Automate.Services;
using Vika_Automate.Services.AdvertisingRep;
using Vika_Automate.Services.EmploeeRep;
using Vika_Automate.Services.PartnerRep;
using Vika_Automate.Services.ProductionRep;
using Vika_Automate.Services.ProductRep;
using Vika_Automate.Services.ProviderRep;
using Vika_Automate.Services.RawMaterialRep;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<new_databaseContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("vikasDB")));

builder.Services.AddScoped<IEmploeeRepository, SqlEmploeeRepository>();
builder.Services.AddScoped<IAdvertisingRepository, SqlAdvertisingRepository>();
builder.Services.AddScoped<IPartnerRepository, SqlPartnerRepository>();
builder.Services.AddScoped<IProductRepository, SqlProductRepository>();
builder.Services.AddScoped<IProductionRepository, SqlProductionRepository>();
builder.Services.AddScoped<IRawMaterialRepository, SqlRawMaterialRepository>();
builder.Services.AddScoped<IProviderRepository, SqlProviderRepository>();

builder.Services.AddSingleton<IDesignTimeServices, MysqlEntityFrameworkDesignTimeServices>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<new_databaseContext>();
    context.Database.EnsureCreated();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

