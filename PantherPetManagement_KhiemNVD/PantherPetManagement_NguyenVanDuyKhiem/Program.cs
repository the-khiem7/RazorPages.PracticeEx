using Microsoft.AspNetCore.Authentication.Cookies;
using PantherPetManagement_Repository.Repositories;
using PantherPetManagement_Service.Interfaces;
using PantherPetManagement_Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IPantherAccountService, PantherAccountService>();
builder.Services.AddScoped<PantherAccountRepository>();
builder.Services.AddScoped<IPantherProfileService, PantherProfileService>();
builder.Services.AddScoped<PantherProfileRepository>();
builder.Services.AddScoped<IPantherTypeService, PantherTypeService>();
builder.Services.AddScoped<PantherTypeRepository>();
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
