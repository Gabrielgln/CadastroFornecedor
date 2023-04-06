using CadastroFornecedor.Data;
using CadastroFornecedor1.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace CadastroFornecedor1
{
    public class Startup
    {

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<BancoContext>(o => o.UseMySql("server=localhost;initial catalog=CRUD_MVC_MYSQL;uid=root;pwd=gabriel1221",
                Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql")));
            services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
