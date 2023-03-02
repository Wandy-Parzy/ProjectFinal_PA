using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Areas.Identity;
using ProyectoFinal.Data;
using Blazored.Toast;
using Models;
using ProyectoFinal.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorStrap;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddDefaultIdentity<Usuarios>(options => 
{

       options.SignIn.RequireConfirmedAccount = false;
       options.Password.RequireDigit = false;
       options.Password.RequiredLength = 4;
       options.Password.RequireLowercase = false;
       options.Password.RequireNonAlphanumeric = false;
       options.Password.RequireUppercase = false;
            })
    .AddEntityFrameworkStores<ApplicationDbContext>();


  
builder.Services.AddBlazoredToast();  // Inyectando el Toast
builder.Services.AddTransient<UsuariosBLL>();
builder.Services.AddTransient<ClientesBLL>();    // BLLS
builder.Services.AddTransient<SuplidorBLL>();
builder.Services.AddTransient<CategoriaBLL>();
builder.Services.AddTransient<VentasBLL>();
builder.Services.AddTransient<ArticuloBLL>();
builder.Services.AddTransient<PagoBLL>();
builder.Services.AddTransient<InventarioBLL>();


builder.Services.AddRazorPages();
builder.Services.AddBlazorStrap();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<Usuarios>>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
