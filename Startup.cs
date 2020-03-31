using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VotingApp.Startup))]
namespace VotingApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
