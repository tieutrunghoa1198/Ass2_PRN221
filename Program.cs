using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ass2_PRN221.Data;
using Ass2_PRN221.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Ass2_PRN221Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Ass2_PRN221Context") ?? throw new InvalidOperationException("Connection string 'Ass2_PRN221Context' not found.")));
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<Ass2_PRN221Context>();
    context.Database.EnsureCreated();
    
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.Map("/Admin", (app1) =>
{
    app1.Run(async context =>
    {
        try
        {
            var acc = context.Session.GetString("account") ?? "";
            Console.WriteLine(acc);
            if (String.IsNullOrEmpty(acc.ToLower()))
            {
                Console.WriteLine("Cannot find acc");
            } else
            {
                context.Response.Redirect("/App/Product/Create");
            }

        } catch (Exception e)
        {
            context.Response.Redirect("/App/Order/Index");
            Console.WriteLine(e.Message);
        }
    });
});

app.MapRazorPages();

app.Run();
