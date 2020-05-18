using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;

using Microsoft.Owin;
[assembly: OwinStartup(typeof(SignalRChat.Startup))]
namespace SignalRChat
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 所有连接或集线器连线和配置都应该放在这里
            app.MapSignalR();
        }
    }
}