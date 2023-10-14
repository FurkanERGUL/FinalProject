using FinalProject.BLL.Services.AppUserServices;
using FinalProject.BLL.Services.BaseServices;
using FinalProject.BLL.Services.KonuService;
using FinalProject.BLL.Services.MakaleService;
using FinalProject.CORE.Concrete;
using FinalProject.CORE.Repositories;
using FinalProject.DAL.Contexts;
using FinalProject.DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();



        //Connection Configuration 
        var con = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string bulunamadi");
        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(con));



        //Repository Injection
        builder.Services.AddScoped(typeof(IBaseRepo<>), typeof(BaseRepo<>));
        builder.Services.AddScoped<IAppUserRepo, AppUserRepo>();
        builder.Services.AddScoped<IMakaleRepo, MakaleRepo>();
        builder.Services.AddScoped<IKonuRepo, KonuRepo>();


        //Services Injection
        builder.Services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
        builder.Services.AddTransient<IAppUserService, AppUserService>();
        builder.Services.AddTransient<IMakaleService, MakaleService>();
        builder.Services.AddTransient<IKonuService, KonuService>();

        //AutoMapper Configuration
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
        {
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 6;

            options.SignIn.RequireConfirmedPhoneNumber = false;
            options.SignIn.RequireConfirmedEmail = false;
            options.SignIn.RequireConfirmedAccount = false;

            options.User.RequireUniqueEmail = true;
            options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";
        }).AddEntityFrameworkStores<AppDbContext>();



        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}