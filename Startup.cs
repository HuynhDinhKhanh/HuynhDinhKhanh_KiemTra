using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KiemTra_HuynhDinhKhanh.Startup))]
namespace KiemTra_HuynhDinhKhanh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
