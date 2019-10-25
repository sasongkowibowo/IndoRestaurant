using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IndoRestaurant.Startup))]
namespace IndoRestaurant
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
