using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using JKL_Healthcare_Services.Data;
using JKL_Healthcare_Services.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("JKL:SqlDb") ?? throw new InvalidOperationException("Connection string 'JKL:SqlDb' not found.");

builder.Services.AddDbContext<JKL_Healthcare_Services_DbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<JKL_Healthcare_ServicesUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<JKL_Healthcare_Services_DbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
});

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

using(var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Admin", "Patient", "Caregiver" };

    foreach (var role in roles)
    {
        if(!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<JKL_Healthcare_ServicesUser>>();

    var patientUser = await userManager.FindByEmailAsync("patient1@healthcare.com");

    if (patientUser != null && !(await userManager.IsInRoleAsync(patientUser, "Patient")))
    {
        await userManager.AddToRoleAsync(patientUser, "Patient");
    }

    //Check for the Admin User
    string firstname = "Eliot";
    string lastname = "Dahmer";
    string email = "admin@healthcare.com";
    string password = "admin@123";
    
    if(await userManager.FindByEmailAsync(email) == null)
    {
        var adminUser = new JKL_Healthcare_ServicesUser();
        adminUser.UserName = email;
        adminUser.Email = email;
        adminUser.FirstName = firstname;
        adminUser.LastName = lastname;

        await userManager.CreateAsync(adminUser, password);

        await userManager.AddToRoleAsync(adminUser, "Admin");
    }
}

app.Run();
