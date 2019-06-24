using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRUDEmpleados.Startup))]
namespace CRUDEmpleados
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
