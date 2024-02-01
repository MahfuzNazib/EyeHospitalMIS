using EysHospitalMIS.BLL.IManager.SecurityManager;
using EysHospitalMIS.BLL.IManager.SystemData;
using EysHospitalMIS.BLL.Manager.SecurityManager;
using EysHospitalMIS.BLL.Manager.SystemData;
using EysHospitalMIS.DAL.Data;
using EysHospitalMIS.DAL.IRepository.SecurityManager;
using EysHospitalMIS.DAL.IRepository.SystemData;
using EysHospitalMIS.DAL.Repository.SecurityManager;
using EysHospitalMIS.DAL.Repository.SystemData;

namespace EyeHospitalMIS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IDbContext, DbContext>();

            builder.Services.AddScoped<IDepartmentManager, DepartmentManager>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            builder.Services.AddScoped<IRoleManager, RoleManager>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();

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
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}