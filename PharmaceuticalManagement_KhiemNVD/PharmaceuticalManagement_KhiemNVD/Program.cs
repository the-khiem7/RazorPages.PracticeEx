using Microsoft.AspNetCore.Authentication.Cookies;
using PharmaceuticalManagement_Repository.Repository;
using PharmaceuticalManagement_Service.Interfaces;
using PharmaceuticalManagement_Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IManufacturerService, ManufacturerService>();
builder.Services.AddScoped<ManufacturerRepository>();
builder.Services.AddScoped<MedicineInformationRepository>();
builder.Services.AddScoped<StoreAccountRepository>();
builder.Services.AddScoped<IMedicineInformationService, MedicineInformationService>();
builder.Services.AddScoped<IStoreAccountService, StoreAccountService>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/Account/Forbidden";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    });


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
app.MapRazorPages().RequireAuthorization();
app.Run();
