using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Timers;
namespace Server.Core
{
  public class CServiceController : IDisposable
  {
    public FView viewForm;
    private ServiceHost service;
    private CServer server = new CServer();
    private Timer timer = new Timer(1000);
    public CServiceController()
    {
      viewForm = new FView();
      service = new ServiceHost(server, 
        new Uri[]{
       // new Uri("http://localhost:8000"),
        new Uri("net.pipe://localhost")
      });
      //service.AddServiceEndpoint(typeof(IstringReverser),
      //  new BasicHttpBinding(),
      //  "Reverse");

      service.AddServiceEndpoint(typeof(ICaptureServer),
        new NetNamedPipeBinding(),
        "PipeReverse");
      viewForm.Disposed += viewForm_Disposed;
      (service.SingletonInstance as CServer).OnStringRegistered += viewForm.AddString;
      service.Open();
      timer.Elapsed += timer_Elapsed;
    }

    void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
      Random rand = new Random(Environment.TickCount);
      server.SendDataToAll((Int16)rand.Next());
    }

    void viewForm_Disposed(object sender, EventArgs e)
    {
      service.Close();
    }

    void IDisposable.Dispose()
    {
      service.Close();
    }
  }
}
