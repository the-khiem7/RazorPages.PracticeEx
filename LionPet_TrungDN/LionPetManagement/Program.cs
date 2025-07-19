using LionPetManagement_DoanNgocTrung.Hubs;
using LionPetManagement_Repositories_DoanNgocTrung.Repositories;
using LionPetManagement_Services_DoanNgocTrung.Interfaces;
using LionPetManagement_Services_DoanNgocTrung.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

//Synalr
builder.Services.AddSignalR();
builder.Services.AddScoped<ILionProfileService, LionProfileService>();
builder.Services.AddScoped<LionProfileRepository>();
builder.Services.AddScoped<ILionAccountService, LionAccountService>();
builder.Services.AddScoped<LionAccountRepository>();
builder.Services.AddScoped<ILionTypeService, LionTypeService>();
builder.Services.AddScoped<LionTypeRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login"; //nhớ có dòng này
        options.AccessDeniedPath = "/Account/Forbidden";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    });


// Add services to the container.
builder.Services.AddRazorPages();


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


app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapRazorPages().RequireAuthorization();

//Synalr
app.MapHub<LionProfileHub>("/LionProfileHub");



app.Run();
