using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using P_Galchis_Cristian.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
});

builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Clienti");
    options.Conventions.AuthorizeFolder("/Bilete");
    options.Conventions.AuthorizeFolder("/Obiective");
    options.Conventions.AuthorizeFolder("/Stiluri");
    options.Conventions.AuthorizeFolder("/Reviews");
    options.Conventions.AllowAnonymousToPage("/Obiective/Index");
    options.Conventions.AllowAnonymousToPage("/Obiective/Details");
    options.Conventions.AllowAnonymousToPage("/Stiluri/Index");
    options.Conventions.AllowAnonymousToPage("/Stiluri/Details");
    options.Conventions.AllowAnonymousToPage("/Bilete/Index");
    options.Conventions.AllowAnonymousToPage("/Bilete/Details");
    options.Conventions.AllowAnonymousToPage("/Reviews/Index");
    options.Conventions.AllowAnonymousToPage("/Reviews/Details");
    options.Conventions.AuthorizeFolder("/Clienti", "AdminPolicy");
    options.Conventions.AuthorizePage("/Bilete/Create", "AdminPolicy");
    options.Conventions.AuthorizePage("/Bilete/Delete", "AdminPolicy");
    options.Conventions.AuthorizePage("/Stiluri/Create", "AdminPolicy");
    options.Conventions.AuthorizePage("/Stiluri/Delete", "AdminPolicy");
    options.Conventions.AuthorizePage("/Obiective/Create", "AdminPolicy");
    options.Conventions.AuthorizePage("/Obiective/Delete", "AdminPolicy");
});

builder.Services.AddDbContext<P_Galchis_CristianContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("P_Galchis_CristianContext")
    ?? throw new InvalidOperationException("Connection string 'P_Galchis_CristianContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("P_Galchis_CristianContext")
    ?? throw new InvalidOperationException("Connection string 'P_Galchis_CristianContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
