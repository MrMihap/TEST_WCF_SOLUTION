using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Contract;
using System.ServiceModel;
namespace Client
{
  public partial class FClientForm : Form, IDataReciever
  {
    public FClientForm()
    {
      InitializeComponent();
    }

    private void Disconnect_Click(object sender, EventArgs e)
    {
      ChannelFactory<ICaptureServer> pipeFactory = new ChannelFactory<ICaptureServer>(new NetNamedPipeBinding(),
        new EndpointAddress("net.pipe://localhost/PipeReverse"));
      ICaptureServer pipeProxy = pipeFactory.CreateChannel();
      pipeProxy.UnSubscribe(this as IDataReciever);
    }

    private void Connect_Click(object sender, EventArgs e)
    {
      ChannelFactory<ICaptureServer> pipeFactory =  new ChannelFactory<ICaptureServer>(new NetNamedPipeBinding(),
        new EndpointAddress(
          "net.pipe://localhost/PipeReverse"));
      ICaptureServer pipeProxy = pipeFactory.CreateChannel();
      pipeProxy.Subscribe(this as IDataReciever);
    }
    void IDataReciever.RecieveData(Int16 data)
    {
      RecievedData.Text += data.ToString() + Environment.NewLine;
    }
  }
}
