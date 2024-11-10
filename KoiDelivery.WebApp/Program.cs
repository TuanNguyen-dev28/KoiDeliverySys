using KoiDelivery.Repositories;
using KoiDelivery.Repositories.Entities;
using KoiDelivery.Repositories.Interfaces;
using KoiDelivery.Services;
using KoiDelivery.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//DI
builder.Services.AddDbContext<KoiFishContext>();
//DI Repositories
builder.Services.AddScoped<IKoiFishRepository, KoiFishRepository>();
//DI Services
builder.Services.AddScoped<IKoiFishService, KoiFishService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
