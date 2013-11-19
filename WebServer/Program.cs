using System;
using Nancy;
using Nancy.Hosting.Self;

namespace WebServer
{
    class Program
    {
        static void Main()
        {
            var hostConfig = new HostConfiguration {UrlReservations = new UrlReservations {CreateAutomatically = true}};
            var nancyHost = new NancyHost(new Uri("http://localhost:8888/"), new DefaultNancyBootstrapper() ,hostConfig);
            nancyHost.Start();

            Console.WriteLine("Nancy now listening - navigating to http://localhost:8888/. Press enter to stop");
            //Process.Start("http://localhost:8888/");
            Console.ReadKey();

            nancyHost.Stop();

            Console.WriteLine("Stopped. Good bye!");
        }
    }
}