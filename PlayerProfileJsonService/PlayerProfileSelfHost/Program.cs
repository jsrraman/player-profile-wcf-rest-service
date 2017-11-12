using Rajaraman.PlayerProfile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Rajaraman.PlayerProfile.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ServiceHost host = new ServiceHost(typeof(PlayerProfileJsonService), new Uri[] { });
                WebHttpBinding binding = new WebHttpBinding(WebHttpSecurityMode.None);

                ServiceEndpoint endPoint = new ServiceEndpoint(ContractDescription.GetContract(typeof(PlayerProfileJsonService)),
                    binding, new EndpointAddress("http://localhost:3001"));

                WebHttpBehavior webHttpBehavior = new WebHttpBehavior();
                endPoint.Behaviors.Add(webHttpBehavior);

                host.AddServiceEndpoint(endPoint);

                host.Open();

                Console.WriteLine("Player Profile service started. Hit any key to stop the service");
                Console.ReadLine();

                host.Close();

                //  ServiceHost host = new ServiceHost(typeof(CalculatorService),
                //new Uri[] { });

                //  WebHttpBinding binding = new WebHttpBinding(WebHttpSecurityMode.None);

                //  ServiceEndpoint endPoint = new ServiceEndpoint(ContractDescription.GetContract(typeof(CalculatorService)),
                //      binding, new EndpointAddress("http://localhost:8080/Calculator&quot;));

                //  WebHttpBehavior webBehavior = new WebHttpBehavior();
                //  endPoint.Behaviors.Add(webBehavior);
                //  host.AddServiceEndpoint(endPoint);

                //  host.Open();
                //  Console.WriteLine("Calculator Service Started!!!" +
                //      "\nPress enter to stop the service");
                //  Console.ReadLine();
                //  host.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
