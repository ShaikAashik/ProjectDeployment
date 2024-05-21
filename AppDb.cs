using DataAccessLayer;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace ASSESSEMENT.Controllers
{
    public class AppDb
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseApplicationServiceProvider(Configuration("DefaultConnection")));

            IMvcBuilder mvcBuilder = services.AddControllers();
        }

        private IServiceProvider? Configuration(string v)
        {
            throw new NotImplementedException();
        }
    }
}
