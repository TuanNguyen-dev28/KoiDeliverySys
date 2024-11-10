using KoiDelivery.Repositories;
using KoiDelivery.Repositories.Entities;
using KoiDelivery.Repositories.Interfaces;
using KoiDelivery.Services.Interfaces;
using KoiDelivery.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//DI
builder.Services.AddDbContext<TaiKhoanContext>();
//DI Repository
builder.Services.AddScoped<IKhachHangRepository, KhachHangRepository>();
//DI Service
builder.Services.AddScoped<IKhachHangService, KhachHangServices>();

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
