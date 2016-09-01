using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;

namespace DataProcessSolution.SignalR.Server
{
    /**http://www.codeproject.com/Articles/804770/Implementing-SignalR-in-Desktop-Applications**/
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            GlobalHost.HubPipeline.AddModule(new ErrorHandlingPipelineModule());
            app.MapSignalR();
        }
    }
}
