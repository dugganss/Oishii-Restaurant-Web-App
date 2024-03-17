using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CO5227_Assignment.Data;
using Microsoft.AspNetCore.Identity;
using CO5227_Assignment.Data;
using CO5227_Assignment.Areas.Email.Interfaces;
using Microsoft.AspNetCore.Identity.UI.Services;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<CO5227_AssignmentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CO5227_AssignmentContext") ?? throw new InvalidOperationException("Connection string 'CO5227_AssignmentContext' not found.")));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<CO5227_AssignmentContext>();
builder.Services.AddTransient<CO5227_Assignment.Areas.Email.Interfaces.IEmailSender, CO5227_Assignment.Areas.Email.EmailSender>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(

    options =>
    {
        options.Stores.MaxLengthForKeys = 128;
    })
    .AddEntityFrameworkStores<CO5227_AssignmentContext>()
    .AddRoles<IdentityRole>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();
//builder.Services.AddDatabasedeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<CO5227_AssignmentContext>();
    
    context.Database.EnsureCreated();
    DbInit.Initialise(context);
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<CO5227_AssignmentContext>();
    context.Database.Migrate();
    var userMgr = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleMgr = services.GetRequiredService<RoleManager<IdentityRole>>();
    IdentitySeedData.Initialise(context, userMgr, roleMgr).Wait();
}

app.Run();
